using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using HADU.hem.ApplicationCore.DTOs.Events;
using HADU.hem.ApplicationCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HADU.hem.HemWeb.Pages.Events
{
    [Authorize("IsEventAdmin")]
    public class EventCreateModel : PageModel
    {

        private readonly EventService _eventService;

        [BindProperty]
        public InputModel Input { get; set; }

        public EventCreateModel(EventService eventService)
        {
            _eventService = eventService;
        }

        public class InputModel
        {
            [Required]
            [Display(Name = "Navn")]
            public string Name { get; set; }

            [Display(Name = "Beskrivelse")]
            public string Description { get; set; }

            [Required]
            [Display(Name = "Starttidspunkt")]
            [DataType(DataType.DateTime)]
            public DateTime StartTime { get; set; }

            [Required]
            [Display(Name = "Suttidspnkt")]
            [DataType(DataType.DateTime)]
            public DateTime EndTime { get; set; }

            [Display(Name = "Lokasjon")]
            public string Location { get; set; }

            [Display(Name = "Tredjepartsarrangement")]
            public bool IsThirdParty { get; set; }
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var newEvent = new EventCreateDTO() {
                    Name = Input.Name,
                    Description = Input.Description,
                    StartTime = Input.StartTime,
                    EndTime = Input.EndTime,
                    Location = Input.Location,
                    IsThirdParty = Input.IsThirdParty
                };

                var e = await _eventService.CreateEventAsync(newEvent);

                return Redirect("/Events/" + e.EventId);
            }

            return Page();
        }
    }
}