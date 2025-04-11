using System.Collections.Generic;
using System.Threading.Tasks;
using _1.SmartEvent.Core.DTOs;
using _1.SmartEvent.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace _1.SmartEvent.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetEvents()
        {
            var events = await _eventService.GetAllEventsAsync();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventDto>> GetEvent(int id)
        {
            var evenement = await _eventService.GetEventByIdAsync(id);

            if (evenement == null)
            {
                return NotFound();
            }

            return Ok(evenement);
        }

        [HttpPost]
        public async Task<ActionResult<EventDto>> CreateEvent(EventDto eventDto)
        {
            var createdEvent = await _eventService.CreateEventAsync(eventDto);

            return CreatedAtAction(
                nameof(GetEvent),
                new { id = createdEvent.Id },
                createdEvent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(int id, EventDto eventDto)
        {
            await _eventService.UpdateEventAsync(id, eventDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            await _eventService.DeleteEventAsync(id);
            return NoContent();
        }
    }
}
