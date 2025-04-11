using System.Collections.Generic;
using System.Threading.Tasks;
using _1.SmartEvent.Core.Modèles;


namespace _1.SmartEvent.Core.Interfaces
{
    public interface IEventRepository
    {
        Task<IEnumerable<Evenement>> GetAllEventsAsync();
        Task<Evenement> GetEventByIdAsync(int id);
        Task<Evenement> CreateEventAsync(Evenement evenement);
        Task UpdateEventAsync(Evenement evenement);
        Task DeleteEventAsync(int id);
        Task<IEnumerable<Utilisateur>> GetEventParticipantsAsync(int eventId);
    }
}