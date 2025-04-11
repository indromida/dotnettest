using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1.SmartEvent.Core.Interfaces;
using _1.SmartEvent.Core.Modèles;
using Microsoft.EntityFrameworkCore;

using _1.SmartEvent.Data.DbContexte;

namespace _1.SmartEvent.Data.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly SmartEventDBContext _context;

        public EventRepository(SmartEventDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Evenement>> GetAllEventsAsync()
        {
            return await _context.Evenements.ToListAsync();
        }

        public async Task<Evenement> GetEventByIdAsync(int id)
        {
            return await _context.Evenements.FindAsync(id);
        }

        public async Task<Evenement> CreateEventAsync(Evenement evenement)
        {
            _context.Evenements.Add(evenement);
            await _context.SaveChangesAsync();
            return evenement;
        }

        public async Task UpdateEventAsync(Evenement evenement)
        {
            _context.Entry(evenement).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEventAsync(int id)
        {
            var evenement = await _context.Evenements.FindAsync(id);
            if (evenement != null)
            {
                _context.Evenements.Remove(evenement);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Utilisateur>> GetEventParticipantsAsync(int eventId)
        {
            var inscriptions = await _context.Inscriptions
                .Where(i => i.EvenementId == eventId)
                .Include(i => i.Utilisateur)
                .ToListAsync();

            return inscriptions.Select(i => i.Utilisateur).ToList();
        }
    }
}