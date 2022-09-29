using System;

namespace flights.Models
{
    public class Airport
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public Guid CityId { get; set; }
    }
}
