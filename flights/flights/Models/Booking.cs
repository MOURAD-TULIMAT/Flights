using System;

namespace flights.Models
{
    public class Booking
    {
        public Guid Id { get; set; }
        public Guid TicketId { get; set; }
        public Guid PassengerId { get; set; }
        public Guid FlightId { get; set; }
    }
}
