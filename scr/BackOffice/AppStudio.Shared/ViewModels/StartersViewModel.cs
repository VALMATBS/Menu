using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class StartersViewModel : ViewModelBase<StartersSchema>
    {
        private RelayCommandEx<StartersSchema> itemClickCommand;
        public RelayCommandEx<StartersSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<StartersSchema>(
                        (item) =>
                        {

                            NavigationServices.NavigateToPage("StartersDetail", item);
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
        override protected DataSourceBase<StartersSchema> CreateDataSource()
        {
            return new StartersDataSource(); // CollectionDataSource
        }

        public override void AddItemAsync()
        {
            ProgressBarVisibility = Visibility.Visible;

            ProgressBarVisibility = Visibility.Visible;
            var newItem = new StartersSchema();
            newItem.IsNew = true;
            Items.Add(newItem);
            SelectedItem = newItem;
            NavigationServices.NavigateToPage("StartersDetail", newItem);
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
            base.PinToStart("StartersDetail", "{DefaultTitle}", "{DefaultSummary}", "{DefaultImageUrl}");
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
            NavigationServices.NavigateToPage("StartersList");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("StartersDetail");
        }
    }
}
