using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Autoecole.Domain.Abstract;

namespace backend.Autoecole.Domain.Models.Entities
{
    public class Agent_Vehicule :IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        public int AgentId { get; set; }
        public  Agent Agent { get; set; }
        public int VehiculeId { get; set; }
        public  Vehicule Vehicule { get; set; }
      
      
    }
}