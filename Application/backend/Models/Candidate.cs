using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace backend.Models
{
    public class Candidate
    {
        [Key]
        public int CandidatCIN { get; set; }
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
        public ICollection<Seance> Seances { get; set; }

    }
}