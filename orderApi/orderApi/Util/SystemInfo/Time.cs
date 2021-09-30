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
            Random random = new Random();
            double delay = random.NextDouble() * (10 - 1) + 1;
            return DateTimeOffset.UtcNow.AddMinutes(delay).ToUnixTimeSeconds();
        }
    }
}
