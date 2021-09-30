using System;

namespace orderApi.Util.SystemInfo
{
    public static class Time
    {
        public static long GetCurrentTimeInUnixTimestamp()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }

        public static long GetCurrentTimeInUnixTimestampPlusTimeToWait()
        {
            int randomDelay = new Random().Next(1, 10);
            return DateTimeOffset.UtcNow.AddMinutes(randomDelay).ToUnixTimeSeconds();
        }
    }
}
