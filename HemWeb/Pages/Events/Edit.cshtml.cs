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
    public class EventEditModel : PageModel
    {

        private readonly EventService _eventService;

        [BindProperty]
        public InputModel Input { get; set; }

        public EventDetailsDTO EventDetails { get; set; }

        public EventEditModel(EventService eventService)
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

            [Display(Name = "Publisert")]
            public bool IsPublished { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
                return NotFound();

            EventDetails = await _eventService.GetEventAsync(id.Value);

            if (EventDetails == null)
                return NotFound();

            Input = new InputModel()
            {
                Name = EventDetails.Name,
                Description = EventDetails.Description,
                StartTime = EventDetails.StartTime,
                EndTime = EventDetails.EndTime,
                Location = EventDetails.Location,
                IsThirdParty = EventDetails.IsThirdParty,
                IsPublished = EventDetails.IsPublished
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                var updateDTO = new EventUpdateDTO()
                {
                    Name = Input.Name,
                    Description = Input.Description,
                    StartTime = Input.StartTime,
                    EndTime = Input.EndTime,
                    Location = Input.Location,
                    IsThirdParty = Input.IsThirdParty,
                    IsPublished = Input.IsPublished
                };

                var e = await _eventService.UpdateEventAsync(id.Value, updateDTO);

                return Redirect("/Events/" + e.EventId);
            }

            return Page();
        }

    }
}