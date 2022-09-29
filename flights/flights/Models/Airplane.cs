using System;

namespace flights.Models
{
    public class Airplane
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
        public int Seats { get; set; }
        public int EconomicSeats { get; set; }
        public int BusinessSeats { get; set; }
    }
}
