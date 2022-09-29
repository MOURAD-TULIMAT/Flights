using System;

namespace flights.Models
{
    public class AirlineCompany
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Guid CityId { get; set; }
    }
}
