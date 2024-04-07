using KMA.CSharp2024.Lab3.Models.Enums;

namespace KMA.CSharp2024.Lab3.Helpers
{
    public static class PersonHelper
    {
        #region Main methods
        public static bool IsAdult(DateTime birthDate)
        {
            return GetAge(birthDate) >= 18;
        }

        public static bool IsBirthday(DateTime birthDate)
        {
            return birthDate.Day == DateTime.Today.Day && birthDate.Month == DateTime.Today.Month;
        }

        public static SunSign GetSunSign(DateTime birthDate)
        {
            return ZodiacHelper.GetSunSign(birthDate);
        }

        public static ChineseSign GetChineseSign(DateTime birthDate)
        {
            return ZodiacHelper.GetChineseSign(birthDate);
        }
        #endregion

        #region Auxiliary methods
        public static int GetAge(DateTime birthDate)
        {
            int age = DateTime.Today.Year - birthDate.Year;
            if (birthDate.Date > DateTime.Today.AddYears(-age))
                --age;
            return age;
        }
        #endregion
    }
}
