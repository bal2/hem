using System.Collections.Generic;
using System.Threading.Tasks;
using HADU.hem.ApplicationCore.DTOs.Event;
using HADU.hem.ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HADU.hem.HemWeb.Pages
{
    public class IndexModel : PageModel
    {

        public List<EventDTO> events {get; set;} = new List<EventDTO>();

        private EventService _eventService;

        public IndexModel(EventService eventService) {
            _eventService = eventService;
        }

        public async Task OnGetAsync()
        {
            events = await _eventService.GetEventsAsync();
        }
    }
}
