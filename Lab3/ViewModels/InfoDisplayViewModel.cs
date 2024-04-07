using KMA.CSharp2024.Lab3.Commands;
using KMA.CSharp2024.Lab3.Models.Enums;
using KMA.CSharp2024.Lab3.ViewModels.Abstract;
using KMA.CSharp2024.Lab3.Views;
using System.Windows.Input;

namespace KMA.CSharp2024.Lab3.ViewModels
{
    public class InfoDisplayViewModel : ViewChangeCapableViewModel
    {
        #region Fields
        private string _firstName;
        private string _lastName;
        private string _email;
        private DateTime _birthDate;
        private bool _isAdult;
        private bool _isBirthday;
        private SunSign _sunSign;
        private ChineseSign _chineseSign;
        #endregion

        #region Constructor
        public InfoDisplayViewModel(string firstName, string lastName, string email, 
                                    DateTime birthDate, bool isAdult, bool isBirthday,
                                    SunSign sunSign, ChineseSign chineseSign) 
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _birthDate = birthDate;
            _isAdult = isAdult;
            _isBirthday = isBirthday;
            _sunSign = sunSign;
            _chineseSign = chineseSign;
            ReturnCommand = new RelayCommand(ExecuteReturn, CanExecuteReturn);
        }
        #endregion

        #region Properties
        public string FirstName
        {
            get { return _firstName; }
        }

        public string LastName
        {
            get { return _lastName; }
        }

        public string Email
        {
            get { return _email; }
        }

        public string BirthDate
        {
            get { return _birthDate.ToString("dd/MMM/yyyy"); }
        }

        public string IsAdult
        {
            get { return (_isAdult) ? "Yes" : "No";  }
        }

        public string IsBirthday
        {
            get { return (_isBirthday) ? "Yes (Happy Birthday!)" : "No"; }
        }

        public string SunSign
        {
            get { return _sunSign.ToString(); }
        }

        public string ChineseSign
        {
            get { return _chineseSign.ToString(); }
        }

        public ICommand ReturnCommand { get; private set; }
        #endregion

        #region Methods
        private void ExecuteReturn(object parameter)
        {
            RequestViewChange(typeof(LandingView), [new LandingViewModel()]);
        }

        private bool CanExecuteReturn(object parameter)
        {
            return true;
        }
        #endregion
    }
}
