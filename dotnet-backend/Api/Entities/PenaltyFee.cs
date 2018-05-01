using System;
namespace Students.Entities
{
    
    public class PenaltyFee
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public bool State { get; set; }

        public decimal Value { get; set; }

        public int IdOwner { get; set; }

        public Owner Owner { get; set; } 

        public int IdVehicle { get; set; }

        public Vehicle Vehicle { get; set; }

    }
}
