using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class SpecialOffersViewModel : ViewModelBase<SpecialOffersSchema>
    {
        private RelayCommandEx<SpecialOffersSchema> itemClickCommand;
        public RelayCommandEx<SpecialOffersSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<SpecialOffersSchema>(
                        (item) =>
                        {

                            NavigationServices.NavigateToPage("SpecialOffersDetail", item);
                        });
                }

                return itemClickCommand;
            }
        }
        public override bool CanSave()
        {
            return !string.IsNullOrEmpty(SelectedItem.Title) &&
                   !string.IsNullOrEmpty(SelectedItem.Subtitle) &&
                   !string.IsNullOrEmpty(SelectedItem.Starter1) &&
                   !string.IsNullOrEmpty(SelectedItem.Main1) &&
                   !string.IsNullOrEmpty(SelectedItem.Dessert1);
        }
        override protected DataSourceBase<SpecialOffersSchema> CreateDataSource()
        {
            return new SpecialOffersDataSource(); // CollectionDataSource
        }

        public override void AddItemAsync()
        {
            ProgressBarVisibility = Visibility.Visible;

            ProgressBarVisibility = Visibility.Visible;
            var newItem = new SpecialOffersSchema();
            newItem.IsNew = true;
            Items.Add(newItem);
            NavigationServices.NavigateToPage("SpecialOffersDetail", newItem);
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
            base.PinToStart("SpecialOffersDetail", "{DefaultTitle}", "{DefaultSummary}", "{DefaultImageUrl}");
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
            await base.SpeakText("Subtitle");
        }

        override public void NavigateToSectionList()
        {
            NavigationServices.NavigateToPage("SpecialOffersList");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("SpecialOffersDetail");
        }
    }
}
