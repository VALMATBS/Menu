using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Windows.Media.SpeechRecognition;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel.DataTransfer;
using Windows.ApplicationModel.Background;

using AppStudio.Services;
using AppStudio.ViewModels;
using Windows.UI.ViewManagement;

namespace AppStudio.Views
{
    public sealed partial class MainPage : Page
    {
        private MainViewModel _mainViewModel = null;

        private NavigationHelper _navigationHelper;

        private DataTransferManager _dataTransferManager;

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
            _navigationHelper = new NavigationHelper(this);
            
            _mainViewModel = _mainViewModel ?? new MainViewModel();

            DataContext = this;
            
            ApplicationView.GetForCurrentView().
                SetDesiredBoundsMode(ApplicationViewBoundsMode.UseCoreWindow);
        }
        

        public MainViewModel MainViewModel
        {
            get { return _mainViewModel; }
        }

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return _navigationHelper; }
        }

        private void OnSectionsInViewChanged(object sender, SectionsInViewChangedEventArgs e)
        {
            var selectedSection = Container.SectionsInView.FirstOrDefault();
            if (selectedSection != null)
            {
                MainViewModel.SelectedItem = selectedSection.DataContext as ViewModelBase;
            }
        }

        #region NavigationHelper registration
        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;
            _navigationHelper.OnNavigatedTo(e);
            await MainViewModel.LoadDataAsync();
            if (e.NavigationMode == NavigationMode.New)
            {
                await InstallVoiceCommandsAsync();
            }
        }

        private async Task InstallVoiceCommandsAsync()
        {
            var storageFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Cortana.xml"));
            await VoiceCommandManager.InstallCommandSetsFromStorageFileAsync(storageFile);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _navigationHelper.OnNavigatedFrom(e);
            _dataTransferManager.DataRequested -= OnDataRequested;
        }
        #endregion

        private void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            var viewModel = MainViewModel.SelectedItem;
            if (viewModel != null)
            {
                viewModel.GetShareContent(args.Request);
            }
        }
    }
}
