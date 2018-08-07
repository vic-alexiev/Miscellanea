using System;

namespace BiscuitMachine.Utils.Extensions
{
    public static class DateTimeExtensions
    {
        public static string Iso8601Formatted(this DateTime utcDate)
        {
            return utcDate.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
        }
    }
}
