using _1.SmartEvent.Core.Modèles;
using System;

namespace _1.SmartEvent.Core.Modèles
{
    public class Inscription
    {
        public int Id { get; set; }
        public int UtilisateurId { get; set; }
        public int EvenementId { get; set; }
        public DateTime DateInscription { get; set; } = DateTime.Now;

        // Navigation properties
        public Utilisateur Utilisateur { get; set; }
        public Evenement Evenement { get; set; }
    }
}