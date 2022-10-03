using System;

namespace flights.DTOs
{
    public class ETicketDto
    {
        public Guid FlightId { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
