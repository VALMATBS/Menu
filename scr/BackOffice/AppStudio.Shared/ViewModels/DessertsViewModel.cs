using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class DessertsViewModel : ViewModelBase<DessertsSchema>
    {
        private RelayCommandEx<DessertsSchema> itemClickCommand;
        public RelayCommandEx<DessertsSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<DessertsSchema>(
                        (item) =>
                        {

                            NavigationServices.NavigateToPage("DessertsDetail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<DessertsSchema> CreateDataSource()
        {
            return new DessertsDataSource(); // CollectionDataSource
        }


        override public Visibility PinToStartVisibility
        {
            get { return ViewType == ViewTypes.Detail ? Visibility.Visible : Visibility.Collapsed; }
        }

        override protected void PinToStart()
        {
            base.PinToStart("DessertsDetail", "{DefaultTitle}", "{DefaultSummary}", "{DefaultImageUrl}");
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
            NavigationServices.NavigateToPage("DessertsList");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("DessertsDetail");
        }
    }
}
