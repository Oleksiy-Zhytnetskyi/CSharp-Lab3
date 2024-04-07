using KMA.CSharp2024.Lab3.Models.Enums;

namespace KMA.CSharp2024.Lab3.Helpers
{
    public static class ZodiacHelper
    {
        public static ChineseSign GetChineseSign(DateTime birthDate)
        {
            if (birthDate.Year < 4)
                throw new ArgumentException("Error: Birth date year < 4 AD");
            const int startYear = 4;
            int offset = (birthDate.Year - startYear) % 12;
            return (ChineseSign)offset;
        }

        public static SunSign GetSunSign(DateTime birthDate)
        {
            Month month = (Month)birthDate.Month;
            int day = birthDate.Day;

            switch (month)
            {
                case Month.January:
                    return day <= 19 ? SunSign.Capricorn : SunSign.Aquarius;
                case Month.February:
                    return day <= 18 ? SunSign.Aquarius : SunSign.Pisces;
                case Month.March:
                    return day <= 20 ? SunSign.Pisces : SunSign.Aries;
                case Month.April:
                    return day <= 19 ? SunSign.Aries : SunSign.Taurus;
                case Month.May:
                    return day <= 20 ? SunSign.Taurus : SunSign.Gemini;
                case Month.June:
                    return day <= 20 ? SunSign.Gemini : SunSign.Cancer;
                case Month.July:
                    return day <= 22 ? SunSign.Cancer : SunSign.Leo;
                case Month.August:
                    return day <= 22 ? SunSign.Leo : SunSign.Virgo;
                case Month.September:
                    return day <= 22 ? SunSign.Virgo : SunSign.Libra;
                case Month.October:
                    return day <= 23 ? SunSign.Libra : SunSign.Scorpio;
                case Month.November:
                    return day <= 21 ? SunSign.Scorpio : SunSign.Sagittarius;
                case Month.December:
                    return day <= 21 ? SunSign.Sagittarius : SunSign.Capricorn;
                default:
                    throw new ArgumentException("Error calculating Western zodiac sign: Invalid month");
            }
        }
    }
}
