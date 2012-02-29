using System;

namespace FriendlyDateTime.Code.Environment
{
    public static class SystemTime
    {
        public static Func<DateTime> UtcNow = () => DateTime.UtcNow;
        public static Func<DateTime> Now = () => DateTime.Now;

        public static void ResetToRealTime()
        {
            Now = () => DateTime.Now;
            UtcNow = () => DateTime.UtcNow;
        }
    }
}