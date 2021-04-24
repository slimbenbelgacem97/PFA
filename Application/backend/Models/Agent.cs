using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



namespace backend.Models
{

    public class Agent
    {
        [Key]
        public int AgentId { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        public DateTime DateEmb { get; set; }
        [Required]
        public string Adresse { get; set; }
        [Required]
        public double Salaire { get; set; }
        [Required]
        public AgentFunction Fonction { get; set; }
        public ICollection<Seance> Seances { get; set; }
         
        public ICollection<Agent_Vehicule> Vehicules { get; set; }
    }
}