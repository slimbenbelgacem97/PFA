using System;
using System.Collections.Generic;
using backend.Autoecole.Domain.Models.Types;

namespace backend.Autoecole.Api.Resources
{
    public class AgentResource
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateEmb { get; set; }
        public string Adresse { get; set; }
        public double Salaire { get; set; }
        public AgentFunction Fonction { get; set; }
        
    }
}