using System;
using HADU.hem.ApplicationCore.Entities;

namespace HADU.hem.ApplicationCore.DTOs.Events
{
    public class EventDetailsDTO
    {
        public long EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
        public bool IsThirdParty { get; set; }
        public bool IsPublished { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public EventDetailsDTO() { }

        public EventDetailsDTO(Event e)
        {
            EventId = e.EventId;
            Name = e.Name;
            Description = e.Description;
            StartTime = e.StartTime;
            EndTime = e.EndTime;
            Location = e.Location;
            IsThirdParty = e.IsThirdParty;
            IsPublished = e.IsPublished;
            CreatedAt = e.CreatedAt;
            UpdatedAt = e.UpdatedAt;
        }
    }
}