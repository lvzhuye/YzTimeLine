using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLine
{
    public enum TimelineCalendarType
    {
        Decades,
        Years,
        Months,
        Days,
        Hours,
        Minutes10,
        Minutes,
        Seconds,
        Milliseconds100,
        Milliseconds10,
        Milliseconds
    }
    public class TimeLineCalendar
    {
        private TimelineCalendarType m_type;


        public TimeLineCalendar(
            string cultureCalendar,
            TimelineCalendarType itemType,
            DateTime minDateTime,
            DateTime maxDateTime)
        {

        }
    }
}
