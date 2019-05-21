using System;

namespace HADU.hem.ApplicationCore.DTOs.Event {
    public class EventDetailsDTO {
        public long EventId {get; set;}
        public string Name {get; set;}
        public string Description { get; set; }
        public DateTime StartTime {get; set;}
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
        public bool IsThirdParty { get; set; }
        public bool IsPublished { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}