using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class BeveragesViewModel : ViewModelBase<BeveragesSchema>
    {
        private RelayCommandEx<BeveragesSchema> itemClickCommand;
        public RelayCommandEx<BeveragesSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<BeveragesSchema>(
                        (item) =>
                        {

                            NavigationServices.NavigateToPage("BeveragesDetail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<BeveragesSchema> CreateDataSource()
        {
            return new BeveragesDataSource(); // CollectionDataSource
        }


        override public Visibility PinToStartVisibility
        {
            get { return ViewType == ViewTypes.Detail ? Visibility.Visible : Visibility.Collapsed; }
        }

        override protected void PinToStart()
        {
            base.PinToStart("BeveragesDetail", "{DefaultTitle}", "{DefaultSummary}", "{DefaultImageUrl}");
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
            NavigationServices.NavigateToPage("BeveragesList");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("BeveragesDetail");
        }
    }
}
