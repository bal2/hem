using System.Threading.Tasks;
using HADU.hem.ApplicationCore.DTOs.Event;
using HADU.hem.ApplicationCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HADU.hem.HemWeb.Pages.Events
{
    public class EventDetailsModel : PageModel
    {

        private readonly EventService _eventService;

        public EventDetailsModel(EventService eventService)
        {
            _eventService = eventService;
        }

        public EventDetailsDTO EventDetails { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
                return NotFound();

            EventDetails = await _eventService.GetEventAsync(id.Value);

            if (EventDetails == null)
                return NotFound();

            return Page();
        }
    }
}