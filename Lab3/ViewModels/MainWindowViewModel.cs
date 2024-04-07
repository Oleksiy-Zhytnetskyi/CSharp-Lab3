using KMA.CSharp2024.Lab3.ViewModels.Abstract;
using KMA.CSharp2024.Lab3.Views;

namespace KMA.CSharp2024.Lab3.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields
        private object _currentView;
        #endregion

        #region Constructor
        public MainWindowViewModel(object content)
        {
            CurrentViewModel = new LandingViewModel();
            CurrentViewModel.ChangeViewRequested += OnChangeViewRequested;
            CurrentViewModel.ChangeViewRequested += HandleViewChangeRequested;
            CurrentView = new LandingView((LandingViewModel)CurrentViewModel);
            Content = content;
        }
        #endregion

        #region Properties
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                if (_currentView != value)
                {
                    _currentView = value;
                    OnPropertyChanged(nameof(CurrentView));
                }
            }
        }

        public ViewChangeCapableViewModel CurrentViewModel { get; private set; }

        public object Content { get; private set; }
        #endregion

        #region ChangeView event handling
        private void OnChangeViewRequested(object sender, Type newViewType, 
                                           object[] constructionParams)
        {
            var newViewInstance = Activator.CreateInstance(newViewType, constructionParams);
            CurrentViewModel = (ViewChangeCapableViewModel)constructionParams[0];
            CurrentViewModel.ChangeViewRequested += OnChangeViewRequested;
            CurrentViewModel.ChangeViewRequested += HandleViewChangeRequested;
            CurrentView = newViewInstance;
        }

        private void HandleViewChangeRequested(object sender, Type newViewType,
                                               object[] constructionParams)
        {
            if (newViewType != null)
            {
                Content = Activator.CreateInstance(newViewType, constructionParams);
            }
        }
        #endregion
    }
}
