using System.Threading.Tasks;
using _1.SmartEvent.Core.DTOs;

namespace _1.SmartEvent.Core.Interfaces
{
    public interface IRegistrationService
    {
        Task<bool> RegisterUserForEventAsync(RegistrationDto registrationDto);
        Task<bool> IsUserRegisteredForEventAsync(int userId, int eventId);
    }
}