using System;

namespace flights.Models
{
    public class ETicket
    {
        public Guid Id { get; set; }
        public Guid FlightId { get; set; }
        public byte Status { get; set; }
        public decimal TotalPrice { get; set; }
        public string Date { get; set; }
        public Guid ManagedUserId { get; set; }
    }
}
