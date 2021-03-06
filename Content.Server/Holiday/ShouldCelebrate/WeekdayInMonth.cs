using System;
using System.Globalization;
using JetBrains.Annotations;
using Robust.Shared.Serialization;

namespace Content.Server.Holiday.ShouldCelebrate
{
    /// <summary>
    ///     For a holiday that happens the first instance of a weekday on a month.
    /// </summary>
    [UsedImplicitly]
    public class WeekdayInMonth : DefaultHolidayShouldCelebrate, IExposeData
    {
        private DayOfWeek _weekday;
        private uint _occurrence;

        void IExposeData.ExposeData(ObjectSerializer serializer)
        {
            serializer.DataField(ref _weekday, "weekday", DayOfWeek.Monday);
            serializer.DataField(ref _occurrence, "occurrence", 1u);
        }

        public override bool ShouldCelebrate(DateTime date, HolidayPrototype holiday)
        {
            // Occurrence NEEDS to be between 1 and 4.
            _occurrence = Math.Max(1, Math.Min(_occurrence, 4));

            var calendar = new GregorianCalendar();

            var d = new DateTime(date.Year, date.Month, 1, calendar);
            for (var i = 1; i <= 7; i++)
            {
                if (d.DayOfWeek != _weekday)
                {
                    d = d.AddDays(1);
                    continue;
                }

                d = d.AddDays(7 * (_occurrence-1));

                return date.Day == d.Day;
            }

            return false;
        }
    }
}
