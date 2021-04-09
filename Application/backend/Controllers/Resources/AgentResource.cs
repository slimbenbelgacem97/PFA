using System;
using backend.Models;
namespace backend.Controllers.Resources
{
    public class AgentResource
    {
        public int AgentCIN { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public DateTime DateEmb { get; set; }

        public string Adresse { get; set; }

        public double Salaire { get; set; }

        public AgentFunction Fonction { get; set; }
    }
}