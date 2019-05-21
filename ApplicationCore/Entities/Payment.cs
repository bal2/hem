using System;
using System.Collections.Generic;

namespace HADU.hem.ApplicationCore.Entities
{
    public class Payment
    {
        public long PaymentId {get; set;}
        public long Amount { get; set; }
        public string PaymentReference { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime ExpirationTime { get; set; }
        public DateTime PaymentTime { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}
