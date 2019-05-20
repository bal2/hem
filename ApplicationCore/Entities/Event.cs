using System;
using System.Collections.Generic;

namespace HADU.hem.ApplicationCore.Entities
{
    public class Event
    {
        public long EventId {get; set;}
        public string Name {get; set;}
        public string Description { get; set; }
        public DateTime StartTime {get; set;}
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
        public bool IsThirdParty { get; set; }
        public List<TicketType> TicketTypes { get; set; }
        public List<Seatmap> Seatmaps { get; set; }
    }
}
