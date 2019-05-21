using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HADU.hem.ApplicationCore.Data;
using HADU.hem.ApplicationCore.DTOs.Event;
using HADU.hem.ApplicationCore.Entities;
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
                    Name = e.Name
                })
                .ToListAsync();
        }

    }
}