using System;
using System.Collections.Generic;

namespace Students.Entities
{
    public class Owner
    {
        public int Id
        {
            get;
            set;
        }

        public string Names
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string Identification
        {
            get;
            set;
        }

        public virtual ICollection<PenaltyFee> Penalties { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }

    }
}
