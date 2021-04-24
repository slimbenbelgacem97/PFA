using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Vehicule
    {
        [Key]
        public string Immatricule { get; set; }

        public string Marque { get; set; }

        public DateTime DateCirculation { get; set; }
        public ICollection<Agent_Vehicule> Agents { get; set; }
    }
}