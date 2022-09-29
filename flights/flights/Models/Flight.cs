using System;

namespace flights.Models
{
    public class Flight
    {
        public Guid Id { get; set; }
        public Guid AirportFromId { get; set; }
        public Guid AirportToId { get; set; }
        public Guid AirplaneId { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public string Date { get; set; }
        public decimal TicketPrice { get; set; }
        public decimal BusinessTicketPrice { get; set; }
        public decimal EconominTicketPrice { get; set; }
        public decimal ChildTicketPrice { get; set; }
        public string CreationDate { get; set; }
        public byte Status { get; set; }
    }
}
