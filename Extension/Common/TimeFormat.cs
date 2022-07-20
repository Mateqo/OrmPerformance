using System.Diagnostics;

namespace OrmPerformance.Extension.Common
{
    public static class TimeFormat
    {
        public static string GetSecondsFormat(Stopwatch stopWatch)
        {
            return string.Format("{0:N3}", stopWatch.Elapsed.TotalSeconds) + " s";
        }
    }
}
