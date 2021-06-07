using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Autoecole.Domain.Abstract;

namespace backend.Autoecole.Domain.Models.Entities
{
    public class Agent_Vehicule 
    {
        
        public int AgentId { get; set; }
        public  Agent Agent { get; set; }
        public string Immatricule { get; set; }
        public  Vehicule Vehicule { get; set; }
      
      
    }
}