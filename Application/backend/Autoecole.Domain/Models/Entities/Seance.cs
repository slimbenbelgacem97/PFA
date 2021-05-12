using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Autoecole.Domain.Abstract;
using backend.Autoecole.Domain.Models.Types;

namespace backend.Autoecole.Domain.Models.Entities
{
    public class Seance : IEntity<int>
    {
        [Key]
        public int Id { get ; set; }
        public DateTime DateSeance { get; set; }
        public SeanceType SeanceType { get; set; }


        public int CandidatId { get; set; }
        public virtual Candidate Candidate { get; set; }

        public int AgentId { get; set; }
        public virtual Agent Agent { get; set; }
        
    }
}