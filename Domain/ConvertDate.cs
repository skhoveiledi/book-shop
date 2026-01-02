using MD.PersianDateTime;

namespace Domain
{
    public static class ConvertDate
    {
        public static string ConvertToHijri(this DateTime date)
        {
            PersianDateTime persianDate = new PersianDateTime(date);
            return persianDate.ToString("yyyy/MM/dd");
        }
        public static string ConvertToHijri(this DateTime date, string format)
        {
            PersianDateTime persianDate = new PersianDateTime(date);
            return persianDate.ToString("yyyy/MM/dd HH:mm");
        }
    }
}
