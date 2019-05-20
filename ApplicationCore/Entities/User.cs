using System;
using System.Collections.Generic;

namespace HADU.hem.ApplicationCore.Entities
{
    public class User
    {
        public long UserId {get; set;}
        public string Email { get; set; }
        public string Nickname { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string GuardianName { get; set; }
        public string GuardianPhone { get; set; }
        public List<Ticket> Tickets { get; set; }
        public List<Payment> Payments { get; set; }
    }
}
