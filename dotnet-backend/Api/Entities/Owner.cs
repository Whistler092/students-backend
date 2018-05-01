using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Students.Entities
{
    public class Owner
    {
        public int Id { get; set; }

        public string Names { get; set; }

        public string LastName { get; set; }

        public string Identification { get; set; }

        [JsonIgnore]
        public virtual ICollection<PenaltyFee> Penalties { get; set; }

        [JsonIgnore]
        public virtual ICollection<Vehicle> Vehicles { get; set; }

    }
}
