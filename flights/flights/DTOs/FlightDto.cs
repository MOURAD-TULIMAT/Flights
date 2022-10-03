using System;

namespace flights.DTOs
{
    public class FlightDto
    {
        public Guid FlightId { get; set; }
        public string FromAirport { get; set; }
        public string ToAirport { get; set; }
        public string Airplane { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public string Date { get; set; }
        public decimal TicketPrice { get; set; }
        public decimal BusinessTicketPrice { get; set; }
        public decimal EconominyTicketPrice { get; set; }
        public decimal ChildTicketPrice { get; set; }
    }
}
