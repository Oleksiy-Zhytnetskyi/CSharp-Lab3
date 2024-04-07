using KMA.CSharp2024.Lab3.Helpers;
using KMA.CSharp2024.Lab3.Models.Enums;

namespace KMA.CSharp2024.Lab3.Models
{
    public class Person
    {
        #region Fields
        // Main Fields (get, set)
        private string _firstName;
        private string _lastName;
        private string _email;
        private DateTime _birthDate;

        // Readonly Fields
        private bool _isAdult;
        private bool _isBirthday;
        private SunSign _sunSign;
        private ChineseSign _chineseSign;
        #endregion

        #region Constructors
        public Person(string firstName, string lastName, string email, DateTime birthDate)
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _birthDate = birthDate;
        }

        public Person(string firstName, string lastName, string email) :
            this(firstName, lastName, email, DateTime.Today)
        {
        }

        public Person(string firstName, string lastName, DateTime birthDate) :
            this(firstName, lastName, "NOT SET", birthDate)
        {
        }
        #endregion

        #region Full Properties
        public string FirstName {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }
        #endregion

        #region Readonly Properties
        public string FullName
        {
            get { return $"{_firstName} {_lastName}"; }
        }

        public bool IsAdult
        {
            get { return _isAdult; }
        }

        public bool IsBirthDay
        {
            get { return _isBirthday; }
        }

        public SunSign SunSign
        {
            get { return _sunSign; }
        }

        public ChineseSign ChineseSign
        {
            get { return _chineseSign; }
        }
        #endregion

        #region Public Methods
        public async Task UpdateReadonlyFieldsAsync()
        {
            Task<bool> isAdultTask = Task.Run(() => PersonHelper.IsAdult(_birthDate));
            Task<bool> isBirthdayTask = Task.Run(() => PersonHelper.IsBirthday(_birthDate));
            Task<SunSign> sunSignTask = Task.Run(() => PersonHelper.GetSunSign(_birthDate));
            Task<ChineseSign> chineseSignTask = Task.Run(() => PersonHelper.GetChineseSign(_birthDate));

            _isAdult = await isAdultTask;
            _isBirthday = await isBirthdayTask;
            _sunSign = await sunSignTask;
            _chineseSign = await chineseSignTask;
        }
        #endregion
    }
}
