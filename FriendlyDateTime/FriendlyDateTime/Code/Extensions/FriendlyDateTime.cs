using System;
using FriendlyDateTime.Code.Environment;

namespace FriendlyDateTime.Code.Extensions
{
    public static class FriendlyDateTime
    {
        public static string ToFriendlyString(this DateTime dateTime)
        {
            var ts = dateTime.Kind == DateTimeKind.Utc 
                ? new TimeSpan(SystemTime.UtcNow().Ticks - dateTime.Ticks) 
                : new TimeSpan(SystemTime.Now().Ticks - dateTime.Ticks);

            var future = ts.Ticks < 0;
            var delta = Math.Abs(ts.TotalSeconds);

            const int SECOND = 1;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;
            const int DAY = 24 * HOUR;
            const int MONTH = 30 * DAY;


            if (delta <= 5 * SECOND)
            {
                return "just now";
            }
            if (delta < 1 * MINUTE)
            {
                var message = future ? "in {0} seconds" : "{0} seconds ago";
                return string.Format(message, Math.Abs(ts.Seconds));
            }
            if (delta < 2 * MINUTE)
            {
                return future ? "in a minute" : "a minute ago";
            }
            if (delta < 45 * MINUTE)
            {
                var message = future ? "in {0} minutes" : "{0} minutes ago";
                return string.Format(message, Math.Abs(ts.Minutes));
            }
            if (delta < 90 * MINUTE)
            {
                return "an hour ago";
            }
            if (delta < 24 * HOUR)
            {
                return ts.Hours + " hours ago";
            }
            if (delta < 48 * HOUR)
            {
                return "yesterday";
            }
            if (delta < 30 * DAY)
            {
                return ts.Days + " days ago";
            }
            if (delta < 12 * MONTH)
            {
                var months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "one month ago" : months + " months ago";
            }
            else
            {
                var years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                return years <= 1 ? "one year ago" : years + " years ago";
            }
            
            
        }
    }
}