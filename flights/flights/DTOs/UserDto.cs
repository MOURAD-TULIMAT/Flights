using System;

namespace flights.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
