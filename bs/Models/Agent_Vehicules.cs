using System.ComponentModel.DataAnnotations;
namespace backend.Models
{
    public class Agent_Vehicules
    {
        public int AgentCIN { get; set; }
        public Agent Agent { get; set; }
        public string Immatricule { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}