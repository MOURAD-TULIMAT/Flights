using System;

namespace flights.Models
{
    public class Passenger
    {
        public Guid Id { get; set; }
        public Guid? AccountId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string BirthDate { get; set; }
        public string Address { get; set; }
        public byte Gender { get; set; }
        public Guid CityId { get; set; }
    }
}
