using System.Collections.Generic;

namespace NaControl.App.Model
{
    public class Group
    {
        public int GroId { get; set; }

        public string Name { get; set; }

        public virtual Address Address { get; set; }

        public ICollection<Meeting> MeetingList { get; set; }
    }
}
