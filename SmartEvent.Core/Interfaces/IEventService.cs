using System.Collections.Generic;
using System.Threading.Tasks;
using _1.SmartEvent.Core.DTOs;
using _1.SmartEvent.Core.Modèles;

namespace _1.SmartEvent.Core.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<EventDto>> GetAllEventsAsync();
        Task<EventDto> GetEventByIdAsync(int id);
        Task<EventDto> CreateEventAsync(EventDto eventDto);
        Task UpdateEventAsync(int id, EventDto eventDto);
        Task DeleteEventAsync(int id);
        Task<IEnumerable<Utilisateur>> GetEventParticipantsAsync(int eventId);
    }
}