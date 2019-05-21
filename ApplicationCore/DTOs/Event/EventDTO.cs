using System;

namespace HADU.hem.ApplicationCore.DTOs.Event {
    public class EventDTO {
        public long EventId { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}