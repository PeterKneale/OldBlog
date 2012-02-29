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

            // These values are approximate and used to calculate a friendly
            // approximation of a date time in the past or future.
            const int second = 1;
            const int minute = 60 * second;
            const int hour = 60 * minute;
            const int day = 24 * hour;
            const int month = 30 * day; 

            if (delta <= 5 * second)
            {
                return "just now";
            }
            if (delta < 1 * minute)
            {
                var message = future ? "in {0} seconds" : "{0} seconds ago";
                return string.Format(message, Math.Abs(ts.Seconds));
            }
            if (delta < 2 * minute)
            {
                return future ? "in a minute" : "a minute ago";
            }
            if (delta < 45 * minute)
            {
                var message = future ? "in {0} minutes" : "{0} minutes ago";
                return string.Format(message, Math.Abs(ts.Minutes));
            }
            if (delta < 90 * minute)
            {
                return future ? "in an hour" : "an hour ago";
            }
            if (delta < 24 * hour)
            {
                var message = future ? "in {0} hours" : "{0} hours ago";
                return string.Format(message, Math.Abs(ts.Hours));
            }
            if (delta < 30 * day)
            {
                var message = future ? "in {0} days" : "{0} days ago";
                return string.Format(message, Math.Abs(ts.Days));
            }
            if (delta < 12 * month)
            {
                var months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                if(months<=1)
                {
                    return future ? "in 1 month" : "1 month ago";
                }
                var message = future ? "in {0} months" : "{0} months ago";
                return string.Format(message, months);
            }
            else
            {
                var years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                if(years<=1)
                {
                    return future ? "in 1 year" : "1 year ago";
                }
                var message = future ? "in {0} years" : "{0} years ago";
                return string.Format(message, years);
            }
        }
    }
}