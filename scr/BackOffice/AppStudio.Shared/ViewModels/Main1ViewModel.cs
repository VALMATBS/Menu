using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class Main1ViewModel : ViewModelBase<MainSchema>
    {
        private RelayCommandEx<MainSchema> itemClickCommand;
        public RelayCommandEx<MainSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<MainSchema>(
                        (item) =>
                        {

                            NavigationServices.NavigateToPage("Main1Detail", item);
                        });
                }

                return itemClickCommand;
            }
        }
        public override bool CanSave()
        {
            return !string.IsNullOrEmpty(SelectedItem.Title) &&
                   !string.IsNullOrEmpty(SelectedItem.Subtitle) &&
                   !string.IsNullOrEmpty(SelectedItem.Image) &&
                   !string.IsNullOrEmpty(SelectedItem.Description);
        }
        override protected DataSourceBase<MainSchema> CreateDataSource()
        {
            return new MainDataSource(); // CollectionDataSource
        }

        public override void AddItemAsync()
        {
            ProgressBarVisibility = Visibility.Visible;

            ProgressBarVisibility = Visibility.Visible;
            var newItem = new MainSchema();
            newItem.IsNew = true;
            Items.Add(newItem);
            SelectedItem = newItem;
            NavigationServices.NavigateToPage("Main1Detail", newItem);
            OnPropertyChanged("PreviewItems");
            OnPropertyChanged("HasMoreItems");

            ProgressBarVisibility = Visibility.Collapsed;
            ProgressBarVisibility = Visibility.Collapsed;
        }

        override public Visibility PinToStartVisibility
        {
            get { return ViewType == ViewTypes.Detail ? Visibility.Visible : Visibility.Collapsed; }
        }

        override protected void PinToStart()
        {
            base.PinToStart("Main1Detail", "{DefaultTitle}", "{DefaultSummary}", "{DefaultImageUrl}");
        }

        override public Visibility ShareItemVisibility
        {
            get { return ViewType == ViewTypes.Detail ? Visibility.Visible : Visibility.Collapsed; }
        }

        override public Visibility TextToSpeechVisibility
        {
            get { return ViewType == ViewTypes.Detail ? Visibility.Visible : Visibility.Collapsed; }
        }

        override protected async void TextToSpeech()
        {
            await base.SpeakText("Description");
        }

        override public void NavigateToSectionList()
        {
            NavigationServices.NavigateToPage("Main1List");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("Main1Detail");
        }
    }
}
