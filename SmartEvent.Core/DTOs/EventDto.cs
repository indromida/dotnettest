namespace _1.SmartEvent.Core.DTOs
{
    public class EventDto
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public string Lieu { get; set; }
        public int CapaciteMax { get; set; }
        public int NombreParticipants { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }
    }
}
