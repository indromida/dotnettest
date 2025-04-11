using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1.SmartEvent.Core.DTOs;
using _1.SmartEvent.Core.Interfaces;
using _1.SmartEvent.Core.Modèles;

namespace _1.SmartEvent.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<IEnumerable<EventDto>> GetAllEventsAsync()
        {
            var events = await _eventRepository.GetAllEventsAsync();
            return events.Select(e => new EventDto
            {
                Id = e.Id,
                Titre = e.Titre,
                Description = e.Description,
                DateDebut = e.DateDebut,
                DateFin = e.DateFin,
                Lieu = e.Lieu,
                CapaciteMax = e.CapaciteMax,
                NombreParticipants = e.Participants?.Count ?? 0,
                ImageUrl = e.ImageUrl,
                Category = e.Category // Handle Category property
            });
        }

        public async Task<EventDto> GetEventByIdAsync(int id)
        {
            var evenement = await _eventRepository.GetEventByIdAsync(id);
            if (evenement == null) return null;

            return new EventDto
            {
                Id = evenement.Id,
                Titre = evenement.Titre,
                Description = evenement.Description,
                DateDebut = evenement.DateDebut,
                DateFin = evenement.DateFin,
                Lieu = evenement.Lieu,
                CapaciteMax = evenement.CapaciteMax,
                NombreParticipants = evenement.Participants?.Count ?? 0,
                ImageUrl = evenement.ImageUrl,
                Category = evenement.Category // Handle Category property
            };
        }

        public async Task<EventDto> CreateEventAsync(EventDto eventDto)
        {
            var evenement = new Evenement
            {
                Titre = eventDto.Titre,
                Description = eventDto.Description,
                DateDebut = eventDto.DateDebut,
                DateFin = eventDto.DateFin,
                Lieu = eventDto.Lieu,
                CapaciteMax = eventDto.CapaciteMax,
                ImageUrl = eventDto.ImageUrl,
                Category = eventDto.Category // Handle Category property
            };

            await _eventRepository.CreateEventAsync(evenement);

            eventDto.Id = evenement.Id;
            return eventDto;
        }

        public async Task UpdateEventAsync(int id, EventDto eventDto)
        {
            var evenement = await _eventRepository.GetEventByIdAsync(id);
            if (evenement == null) return;

            evenement.Titre = eventDto.Titre;
            evenement.Description = eventDto.Description;
            evenement.DateDebut = eventDto.DateDebut;
            evenement.DateFin = eventDto.DateFin;
            evenement.Lieu = eventDto.Lieu;
            evenement.CapaciteMax = eventDto.CapaciteMax;
            evenement.ImageUrl = eventDto.ImageUrl;
            evenement.Category = eventDto.Category; // Handle Category property

            await _eventRepository.UpdateEventAsync(evenement);
        }

        public async Task DeleteEventAsync(int id)
        {
            await _eventRepository.DeleteEventAsync(id);
        }

        public async Task<IEnumerable<Utilisateur>> GetEventParticipantsAsync(int eventId)
        {
            return await _eventRepository.GetEventParticipantsAsync(eventId);
        }
    }
}
