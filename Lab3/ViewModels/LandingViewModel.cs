using KMA.CSharp2024.Lab3.Commands;
using KMA.CSharp2024.Lab3.Helpers;
using KMA.CSharp2024.Lab3.Models;
using KMA.CSharp2024.Lab3.ViewModels.Abstract;
using KMA.CSharp2024.Lab3.Views;
using System.Windows;
using System.Windows.Input;

namespace KMA.CSharp2024.Lab3.ViewModels
{
    public class LandingViewModel : ViewChangeCapableViewModel
    {
        #region Constants
        private const int AGE_THRESHOLD = 135;
        #endregion

        #region Fields
        private Person _person;

        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private string _email = string.Empty;
        private DateTime _birthDate;

        private bool _isActiveUI = true;
        #endregion

        #region Constructor
        public LandingViewModel()
        {
            ProceedCommand = new RelayCommand(ExecuteProceed, CanExecuteProceed);
        }
        #endregion

        #region Properties
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(IsFormValid));
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(IsFormValid));
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(IsFormValid));
            }
        }

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                _birthDate = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsFormValid));
            }
        }

        public bool IsActiveUI { 
            get { return _isActiveUI; }
            private set { _isActiveUI = value; }
        }

        public bool IsFormValid
        {
            get
            {
                return !string.IsNullOrEmpty(FirstName) && 
                       !string.IsNullOrEmpty(LastName) && 
                       !string.IsNullOrEmpty(Email) && 
                       BirthDate != default && 
                       IsActiveUI;
            }
        }

        public ICommand ProceedCommand { get; private set; }
        #endregion

        #region Methods
        private async void ExecuteProceed(object parameter)
        {
            BlockUI();
            if (!BirthDateIsValid())
            {
                MessageBox.Show("Invalid birth date entered. Please try again.",
                        "Error: Invalid Birth Date", MessageBoxButton.OK, MessageBoxImage.Error);
                UnblockUI();
                return;
            }
            _person = new Person(_firstName, _lastName, _email, _birthDate);
            await _person.UpdateReadonlyFieldsAsync();
            UnblockUI();
            InfoDisplayViewModel infoViewModelInstance = new InfoDisplayViewModel(
                FirstName, LastName, Email, BirthDate, 
                _person.IsAdult, _person.IsBirthDay, _person.SunSign, _person.ChineseSign
            );
            RequestViewChange(typeof(InfoDisplayView), [infoViewModelInstance]);
        }

        private bool CanExecuteProceed(object parameter)
        {
            return IsFormValid;
        }

        private bool BirthDateIsValid()
        {
            return !(_birthDate > DateTime.Today || PersonHelper.GetAge(_birthDate) > AGE_THRESHOLD);
        }

        private void BlockUI()
        {
            IsActiveUI = false;
            OnPropertyChanged(nameof(IsActiveUI));
        }

        private void UnblockUI()
        {
            IsActiveUI = true;
            OnPropertyChanged(nameof(IsActiveUI));
        }
        #endregion        
    }
}
