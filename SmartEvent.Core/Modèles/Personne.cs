using System;
using System.Collections.Generic;

namespace _1.SmartEvent.Core.Modèles
{
    public abstract class Personne
    {
        public int Id { get; set; }// Ensure primary key
        public string Nom { get; set; }
        public string Email { get; set; }
        public string MotDePasse { get; set; }
        public string Role { get; set; }
    }
}