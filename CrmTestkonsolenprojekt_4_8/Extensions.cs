using System;
using System.Collections.Generic;

namespace CrmTestkonsolenprojekt_4_8
{
    public static class Extensions
    {
        /// <summary>
        ///     A DateTime extension method that return a DateTime of the last day of the month with the time set to
        ///     "23:59:59:999". The last moment of the last day of the month.  Use "DateTime2" column type in sql to keep the
        ///     precision.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>A DateTime of the last day of the month with the time set to "23:59:59:999".</returns>
        public static DateTime EndOfMonth(this DateTime @this)
        {
            return new DateTime(@this.Year, @this.Month, 1).AddMonths(1).Subtract(new TimeSpan(0, 0, 0, 0, 1));
        }

        public static DateTime StartOfMonth(this DateTime @this)
        {
            return new DateTime(@this.Year, @this.Month, 1);
        }

        public static bool IsEndOfMonth(this DateTime @this)
        {
            var endOfMonth = EndOfMonth(@this).Day;
            if (endOfMonth.Equals(@this.Day))
            {
                return true;
            }

            return false;
        }

        public static bool IsStartOfMonth(this DateTime @this)
        {
            if (@this.Day.Equals(1))
            {
                return true;
            }

            return false;
        }

        public static int CountMonthBetweenDates(this DateTime startDate, DateTime endDate)
        {
            if (startDate.Year.Equals(endDate.Year) && startDate.Month.Equals(endDate.Month))
            {
                return 1;
            }

            int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
            return Math.Abs(monthsApart) + 1;
        }

        public static bool IsBetween<T>(this T item, T start, T end)
        {
            return Comparer<T>.Default.Compare(item, start) >= 0
                   && Comparer<T>.Default.Compare(item, end) <= 0;
        }
    }
}