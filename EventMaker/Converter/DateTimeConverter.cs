using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.UserDataTasks.DataProvider;

namespace EventMaker.Converter
{
   public static class DateTimeConverter
    {
        public static DateTime DateTimeOffsetAndTimeSetToDateTime(DateTimeOffset date, TimeSpan time)
        {
            return new DateTime(date.Year,date.Month,date.Day,time.Hours,time.Minutes,0);
        }

    }
}
