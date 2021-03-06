using System;
using System.Net.NetworkInformation;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel.DataTransfer;
using AppStudio.Data;
using AppStudio.Services;
using AppStudio.ViewModels;

namespace AppStudio.Views
{
    public sealed partial class SpecialOffersDetail : Page
    {
        private NavigationHelper _navigationHelper;

        private DataTransferManager _dataTransferManager;

        public SpecialOffersDetail()
        {
            this.InitializeComponent();
            _navigationHelper = new NavigationHelper(this);

            SizeChanged += OnSizeChanged;

            SpecialOffersModel = new SpecialOffersViewModel();
        }

        public SpecialOffersViewModel SpecialOffersModel { get; private set; }

        public NavigationHelper NavigationHelper
        {
            get { return _navigationHelper; }
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width < 500)
            {
                VisualStateManager.GoToState(this, "SnappedView", true);
            }
            else
            {
                VisualStateManager.GoToState(this, "FullscreenView", true);
            }
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;

            _navigationHelper.OnNavigatedTo(e);

            await SpecialOffersModel.LoadItemsAsync();
            if (e.Parameter is SpecialOffersSchema)
            {
                SpecialOffersModel.Items.Add(e.Parameter as SpecialOffersSchema);
            }
            SpecialOffersModel.SelectItem(e.Parameter);

            if (SpecialOffersModel != null)
            {
                SpecialOffersModel.ViewType = ViewTypes.Detail;
            }
            DataContext = this;
            BottomAppBar.IsOpen = true;
            BottomAppBar.IsSticky = true;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _navigationHelper.OnNavigatedFrom(e);
            _dataTransferManager.DataRequested -= OnDataRequested;
        }

        private void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            if (SpecialOffersModel != null)
            {
                SpecialOffersModel.GetShareContent(args.Request);
            }
        }
    }
}
