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
    public sealed partial class BeveragesDetail : Page
    {
        private NavigationHelper _navigationHelper;

        private DataTransferManager _dataTransferManager;

        public BeveragesDetail()
        {
            this.InitializeComponent();
            _navigationHelper = new NavigationHelper(this);

            SizeChanged += OnSizeChanged;

            BeveragesModel = new BeveragesViewModel();
        }

        public BeveragesViewModel BeveragesModel { get; private set; }

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

            await BeveragesModel.LoadItemsAsync();
            if (e.Parameter is BeveragesSchema)
            {
                BeveragesModel.Items.Add(e.Parameter as BeveragesSchema);
            }
            BeveragesModel.SelectItem(e.Parameter);

            if (BeveragesModel != null)
            {
                BeveragesModel.ViewType = ViewTypes.Detail;
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
            if (BeveragesModel != null)
            {
                BeveragesModel.GetShareContent(args.Request);
            }
        }
    }
}
