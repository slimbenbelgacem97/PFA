using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using backend.Autoecole.Domain.Abstract;

namespace backend.Autoecole.Domain.Models.Entities
{
    public class Candidate :IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        public DateTime Naissance { get; set; }
        [Required]
        public string Adresse { get; set; }
        [Required]
        public string Tel { get; set; }
        public virtual ICollection<Seance> Seances { get; set; }

    }
}