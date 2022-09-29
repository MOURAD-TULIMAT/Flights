using System;

namespace flights.Models
{
    public class Account
    {
        public Guid Id { get; set; }

        public Guid TypeId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CreationDate { get; set; }
    }
}
