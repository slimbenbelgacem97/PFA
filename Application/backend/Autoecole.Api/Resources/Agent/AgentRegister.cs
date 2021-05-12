using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using backend.Autoecole.Domain.Models.Types;
using Newtonsoft.Json.Converters;

namespace backend.Autoecole.Api.Resources.Agent
{
    public class AgentRegister 
    {
        public string Id { get; set; }
        [Required]
        public String UserName { get; set; }
        
        public string Nom { get; set; }
        
        public string Prenom { get; set; }
        
        public DateTime DateEmb { get; set; }
        
        public string Adresse { get; set; }
        
        public double Salaire { get; set; }
        public string  PhoneNumber { get; set; }
        public AgentFunction Fonction { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}