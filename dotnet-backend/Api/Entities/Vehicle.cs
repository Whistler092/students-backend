using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Students.Entities
{
    public class Vehicle
    {

        public int Id { get; set; }

        public string LicensePlate { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public int IdOwner { get; set; }

        public Owner Owner { get; set; }

        [JsonIgnore]
        public virtual ICollection<PenaltyFee> Penalties { get; set; }


    }
}
