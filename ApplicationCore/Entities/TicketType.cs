using System;
using System.Collections.Generic;

namespace HADU.hem.ApplicationCore.Entities
{
    public class TicketType
    {
        public long TicketTypeId {get; set;}
        public string Name { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public bool IsSeatAble { get; set; }
        public long EventId { get; set; }
        public Event Event { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}
