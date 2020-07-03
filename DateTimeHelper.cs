    public class DateTimeHelper
    {
        public static DateTime GetDateTime(DateTime dateTime,string timeZoneId)
        {
            DateTime newValue = DateTime.Now;
            try
            {
                dateTime = dateTime.ToUniversalTime();
                TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
                newValue = TimeZoneInfo.ConvertTimeFromUtc(dateTime, tz);
            }
            catch
            {
                newValue = DateTime.Now;
            }
            return newValue;

        }
    }
//How to use: DateTimeHelper.GetDateTime(DateTime.Now, "Pacific SA Standard Time");
