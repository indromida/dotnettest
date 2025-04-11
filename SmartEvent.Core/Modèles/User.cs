using _1.SmartEvent.Core.Modèles;

using System.Collections.Generic;

namespace _1.SmartEvent.Core.Modèles
{
    public class Utilisateur : Personne
    {
        public ICollection<Evenement> EvenementsInscrits { get; set; } = new List<Evenement>();
        public ICollection<Inscription> Inscriptions { get; set; } = new List<Inscription>();

        public bool EstInscrit(Evenement evenement)
        {
            // Implementation will come when we link with EF Core
            return EvenementsInscrits.Contains(evenement);
        }

        public void SInscrire(Evenement evenement)
        {
            if (!EstInscrit(evenement))
            {
                EvenementsInscrits.Add(evenement);
            }
        }
    }
}