using System;
using System.ComponentModel.DataAnnotations;
using backend.Autoecole.Domain.Models.Types;
using Microsoft.AspNetCore.Identity;
namespace backend.Autoecole.DataAccess.Data
{
    public class ApplicationUser : IdentityUser 
    {
        
        //public int Id { get; set; }
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
       // public string PhoneNumber { get; set; }
        [Required]
        public AgentFunction Fonction { get; set; }
    }
   
}