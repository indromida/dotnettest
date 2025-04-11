using System.Collections.Generic;
using System.Threading.Tasks;
using _1.SmartEvent.Core.Modèles;


namespace   _1.SmartEvent.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<Utilisateur> GetUserByIdAsync(int id);
        Task<Utilisateur> GetUserByEmailAsync(string email);
        Task<bool> IsUserRegisteredForEventAsync(int userId, int eventId);
        Task<IEnumerable<Evenement>> GetUserEventsAsync(int userId);
    }
}