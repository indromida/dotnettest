using _1.SmartEvent.Core.Modèles;
using System;
using System.Collections.Generic;

namespace _1.SmartEvent.Core.Modèles
{
    public class Evenement
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public string Lieu { get; set; }
        public int CapaciteMax { get; set; }
        public string ImageUrl { get; set; } // Added this property
        public string Category { get; set; }
        public ICollection<Utilisateur> Participants { get; set; } = new List<Utilisateur>();
        public ICollection<Inscription> Inscriptions { get; set; } = new List<Inscription>();
    }
}