using System;
namespace Students.Entities
{
    public class Vehicle
    {

        public string Id
        {
            get;
            set;
        }

        public string LicensePlate
        {
            get;
            set;
        }

        public string Model
        {
            get;
            set;
        }

        public int Year
        {
            get;
            set;
        }

        public int IdOwner
        {
            get;
            set;
        }

        public Owner Owner
        {
            get;
            set;
        }

    }
}
