using System;

namespace NaControl.App.Model
{
    public class Meeting
    {
        public int MeeId { get; set; }

        public bool Private { get; set; }

        public DayOfWeek Day { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public Group Group { get; set; }
    }
}
