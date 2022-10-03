using System.Collections.Generic;

namespace flights.DTOs
{
    public class AllInfoDto
    {
        public List<FlightDto> Flights { get; set; }
        public UserDto User { get; set; }
        public PassengerDto Passenger { get; set; }
        public ETicketDto ETicket { get; set; }
    }
}
