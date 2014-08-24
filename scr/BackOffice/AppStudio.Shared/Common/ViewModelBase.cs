using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Net.NetworkInformation;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage.Streams;

using AppStudio.Data;
using AppStudio.Services;

namespace AppStudio.ViewModels
{
    public enum ViewTypes
    {
        List,
        Detail
    }

    abstract public class ViewModelBase : BindableBase
    {
        private Visibility _progressBarVisibility = Visibility.Visible;

        public Visibility ProgressBarVisibility
        {
            get { return _progressBarVisibility; }
            set { SetProperty(ref _progressBarVisibility, value); }
        }

        public Visibility AppBarVisibility
        {
            get
            {
                return Visibility.Visible;
            }
        }

        virtual public ViewTypes ViewType { get; set; }

        virtual public Visibility TextToSpeechVisibility
        {
            get { return Visibility.Collapsed; }
        }

        virtual public Visibility PinToStartVisibility
        {
            get { return Visibility.Collapsed; }
        }

        virtual public Visibility GoToSourceVisibility
        {
            get { return Visibility.Collapsed; }
        }

        virtual public Visibility ShareItemVisibility
        {
            get { return Visibility.Collapsed; }
        }

        virtual public Visibility RefreshVisibility
        {
            get { return Visibility.Collapsed; }
        }

        virtual public void NavigateToSectionList() { }

        abstract public Task LoadItemsAsync(bool forceRefresh = false);

        virtual protected void TextToSpeech() { }
        virtual protected void PinToStart() { }
        virtual protected void GoToSource() { }
        virtual protected void ShareItem() { }

        abstract public void GetShareContent(DataRequest dataRequest);
    }

    abstract public class ViewModelBase<T> : ViewModelBase where T : BindableSchemaBase, new()
    {
        private const int PREVIEWITEMS_COUNT = 6;

        protected ObservableCollection<T> _items = new ObservableCollection<T>();
        protected ObservableCollection<T> _previewItems = new ObservableCollection<T>();

        protected T _selectedItem = null;

        protected DataSourceBase<T> _dataSource;

        protected virtual void NavigateToSelectedItem() { }

        protected abstract DataSourceBase<T> CreateDataSource();

        public ObservableCollection<T> Items
        {
            get { return _items; }
        }

        public ObservableCollection<T> PreviewItems
        {
            get
            {
                if (_items != null)
                {
                    _previewItems.AddRangeUnique(_items.Take(PREVIEWITEMS_COUNT));
                }
                return _previewItems;
            }
        }

        virtual public bool HasMoreItems
        {
            get { return _items != null ? _items.Count > PREVIEWITEMS_COUNT : false; }
        }


        public T SelectedItem
        {
            get { return _selectedItem; }
            set { SetProperty(ref _selectedItem, value); }
        }

        public bool IsItemSelected
        {
            get { return SelectedItem != null; }
        }

        public DataSourceBase<T> DataSource
        {
            get { return _dataSource ?? (_dataSource = CreateDataSource()); }
        }

        public void SelectItem(object item)
        {
            this.SelectedItem = item as T;
        }

        public override async Task LoadItemsAsync(bool forceRefresh = false)
        {
            ProgressBarVisibility = Visibility.Visible;

            var timeStamp = await DataSource.LoadDataAsync(Items, forceRefresh);

            OnPropertyChanged("PreviewItems");
            OnPropertyChanged("HasMoreItems");

            ProgressBarVisibility = Visibility.Collapsed;
        }

        protected override void ShareItem()
        {
            DataTransferManager.ShowShareUI();
        }

        /// <summary>
        /// Called from DataTransferManager when user wants to share App content.
        /// </summary>
        override public void GetShareContent(DataRequest dataRequest)
        {
            var currentItem = GetCurrentItem();
            if (currentItem != null)
            {
                // Share SelectedItem Title
                dataRequest.Data.Properties.Title = currentItem.DefaultTitle ?? App.APP_NAME;

                // Share SelectedItem Summary
                if (!String.IsNullOrEmpty(currentItem.DefaultSummary))
                {
                    dataRequest.Data.SetText(Utility.DecodeHtml(currentItem.DefaultSummary));
                }

                // Share SelectedItem Content
                if (!String.IsNullOrEmpty(currentItem.DefaultContent))
                {
                    dataRequest.Data.SetHtmlFormat(HtmlFormatHelper.CreateHtmlFormat(currentItem.DefaultContent));
                }

                // Share SelectedItem DefaultImageUrl
                string Image = currentItem.DefaultImageUrl;
                if (!string.IsNullOrEmpty(Image))
                {
                    if (Image.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                    {
                        dataRequest.Data.SetWebLink(new Uri(Image));
                    }
                    else
                    {
                        Image = string.Format("ms-appx://{0}", Image);
                    }
                    dataRequest.Data.SetBitmap(RandomAccessStreamReference.CreateFromUri(new Uri(Image)));
                }
            }
        }

        //
        // ICommands
        //
        public ICommand TextToSpeechCommand
        {
            get { return new DelegateCommand(TextToSpeech); }
        }

        public ICommand PinToStartCommand
        {
            get { return new DelegateCommand(PinToStart); }
        }

        public ICommand GoToSourceCommand
        {
            get { return new DelegateCommand(GoToSource); }
        }

        public ICommand ShareItemCommand
        {
            get { return new DelegateCommand(ShareItem); }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await LoadItemsAsync(true);
                });
            }
        }
        public ICommand AddCommand
        {
            get { return new DelegateCommand(AddItemAsync); }
        }

        public ICommand DeleteCommand
        {
            get { return new DelegateCommand(DeleteItemAsync); }
        }

        public ICommand SaveCommand
        {
            get { return new DelegateCommand(SaveItemAsync); }
        }

        public abstract bool CanSave();
       

        public abstract void AddItemAsync();
       
        private async void DeleteItemAsync()
        {
            ProgressBarVisibility = Visibility.Visible;
            var currentItem = GetCurrentItem();

            var messageDialog = new MessageDialog(currentItem.DefaultTitle, "Are you sure you want to delete this item?");
            messageDialog.Commands.Add(new UICommand("Yes"));
            messageDialog.Commands.Add(new UICommand("No"));
            var result = await messageDialog.ShowAsync();
            if (result.Label == "Yes")
            {
                await DataSource.DeleteAsync(currentItem);
                Items.Remove(currentItem);
                OnPropertyChanged("PreviewItems");
                OnPropertyChanged("Items");
                OnPropertyChanged("HasMoreItems");
            }
         
            ProgressBarVisibility = Visibility.Collapsed;
        }
      
        private async void SaveItemAsync()
        {
            if (!CanSave())
            {
                var cannotSaveMessageDialog = new MessageDialog("You must fill all data.", "Attention!");
                cannotSaveMessageDialog.Commands.Add(new UICommand("Ok"));
                await cannotSaveMessageDialog.ShowAsync();
                return;
            }
            ProgressBarVisibility = Visibility.Visible;
            var currentItem = GetCurrentItem();
            var messageDialog = new MessageDialog(currentItem.DefaultTitle, "The item was saved!");
            messageDialog.Commands.Add(new UICommand("Ok"));
            await DataSource.SaveAsync(currentItem);
            await messageDialog.ShowAsync();
            OnPropertyChanged("Items");
            OnPropertyChanged("PreviewItems");
            OnPropertyChanged("HasMoreItems");
            ProgressBarVisibility = Visibility.Collapsed;
        }

        //
        // Command implementation helpers
        //
        protected async Task SpeakText(params string[] propertyNames)
        {
            var currentItem = GetCurrentItem();
            if (currentItem != null)
            {
                await SpeechServices.StartTextToSpeech(currentItem.GetValues(propertyNames));
            }
        }

        protected void PinToStart(string path, string titleToShare, string messageToShare, string imageToShare)
        {
            var currentItem = GetCurrentItem();
            if (currentItem != null)
            {
                if (String.IsNullOrEmpty(path))
                {
                    path = "MainPage";
                }
                // TODO: Not implemented
            }
        }

        protected void GoToSource(string linkProperty)
        {
            var currentItem = GetCurrentItem();
            if (currentItem != null)
            {
                string url = GetBindingValue(linkProperty);
                if (!String.IsNullOrEmpty(url) && Uri.IsWellFormedUriString(url, UriKind.Absolute))
                {
                    NavigationServices.NavigateTo(new Uri(url, UriKind.Absolute));
                }
            }
        }

        private string GetBindingValue(string binding)
        {
            binding = binding ?? String.Empty;
            if (binding.StartsWith("{") && binding.EndsWith("}"))
            {
                var currentItem = GetCurrentItem();
                if (currentItem != null)
                {
                    string propertyName = binding.Substring(1, binding.Length - 2);
                    return currentItem.GetValue(propertyName);
                }
            }
            return binding;
        }

        protected T GetCurrentItem()
        {
            if (SelectedItem != null)
            {
                return SelectedItem;
            }
            if (Items != null && Items.Count > 0)
            {
                return Items[0];
            }
            return null;
        }

        protected Uri TryCreateUri(string uriString)
        {
            try
            {
                return new Uri(uriString, UriKind.Absolute);
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("ViewModelBase.TryCreateUri", ex);
            }
            return null;
        }
    }
}
