using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HADU.hem.ApplicationCore.Data;
using HADU.hem.ApplicationCore.DTOs.Events;
using HADU.hem.ApplicationCore.Entities;
using HADU.hem.ApplicationCore.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HADU.hem.ApplicationCore.Services
{
    public class EventService
    {

        private HemContext _dbContext;

        public EventService(HemContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<EventDTO>> GetEventsAsync()
        {
            return await _dbContext
                .Events
                .Select(e => new EventDTO()
                {
                    EventId = e.EventId,
                    Name = e.Name
                })
                .ToListAsync();
        }

        public async Task<EventDetailsDTO> GetEventAsync(long id)
        {
            var evt = await _dbContext
                .Events
                .Where(e => e.EventId == id)
                .Select(e => new EventDetailsDTO()
                {
                    EventId = e.EventId,
                    Name = e.Name,
                    Description = e.Description,
                    StartTime = e.StartTime,
                    EndTime = e.EndTime,
                    Location = e.Location,
                    IsThirdParty = e.IsThirdParty,
                    IsPublished = e.IsPublished,
                    CreatedAt = e.CreatedAt,
                    UpdatedAt = e.UpdatedAt
                })
                .FirstOrDefaultAsync();

            if (evt == null)
                throw new EventNotFoundException();

            return evt;
        }

        public async Task<EventDetailsDTO> CreateEventAsync(EventCreateDTO inp) {
            Event e = new Event() {
                Name = inp.Name,
                Description = inp.Description,
                StartTime = inp.StartTime,
                EndTime = inp.EndTime,
                Location = inp.Location,
                IsThirdParty = inp.IsThirdParty
            };

            await _dbContext.Events.AddAsync(e);
            await _dbContext.SaveChangesAsync();

            return new EventDetailsDTO(e);
        }

        internal async Task<Event> GetEventModelAsync(long id) {
            var e = await _dbContext.Events.FindAsync(id);

            if(e == null)
                throw new EventNotFoundException();
            
            return e;
        }
    }
}