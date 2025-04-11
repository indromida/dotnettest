using System.Threading.Tasks;
using _1.SmartEvent.Core.Modèles;


namespace _1.SmartEvent.Core.Interfaces
{
    public interface IRegistrationRepository
    {
        Task<Inscription> RegisterUserForEventAsync(int userId, int eventId);
        Task<bool> IsUserRegisteredForEventAsync(int userId, int eventId);
    }
}