using System;

namespace nothinbutdotnetprep.utility.filtering
{
    public class YearOfDateIsGreaterThanYear : IMatchAnItem<DateTime>
    {
        int year;

        public YearOfDateIsGreaterThanYear(int year)
        {
            this.year = year;
        }

        public bool matches(DateTime item)
        {
            return item.Year > year;
        }
    }
}