using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using backend.Autoecole.Domain.Abstract;

namespace backend.Autoecole.Domain.Models.Entities
{
    public class Vehicule:IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        
        public string Immatricule { get; set; }

        public string Marque { get; set; }

        public DateTime DateCirculation { get; set; }
        public virtual ICollection<Agent_Vehicule> Agents { get; set; }
    }
}