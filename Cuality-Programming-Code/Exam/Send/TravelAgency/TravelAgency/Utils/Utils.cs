namespace TravelAgency.Utils
{
    using System;
    using System.Globalization;

    public static class Utils
    {
        public static string CreateFromToKey(string from, string to)
        {
            string result = from + "; " + to;
            return result;
        }

        public static DateTime ParseDateTime(string dateTime)
        {
            DateTime result = DateTime.ParseExact(dateTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            return result;
        }
    }
}
