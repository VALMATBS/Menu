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

        override protected DataSourceBase<SpecialOffersSchema> CreateDataSource()
        {
            return new SpecialOffersDataSource(); // CollectionDataSource
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
