using System.Collections.Generic;

namespace NaControl.App.Model
{
    public class Address
    {
        public int AddId { get; set; }

        public string Addresses { get; set; }

        public string Complement { get; set; }

        public int Number { get; set; }

        public string City { get; set; }

        public int ZipCode { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public virtual IEnumerable<Group> Group { get; set; }
    }
}
