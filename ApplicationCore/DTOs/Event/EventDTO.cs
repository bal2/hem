using System;
using HADU.hem.ApplicationCore.Entities;

namespace HADU.hem.ApplicationCore.DTOs.Events
{
    public class EventDTO
    {
        public long EventId { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public EventDTO() { }

        public EventDTO(Event e)
        {
            EventId = e.EventId;
            Name = e.Name;
            StartTime = e.StartTime;
            EndTime = e.EndTime;
        }
    }
}