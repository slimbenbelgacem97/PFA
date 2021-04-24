using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Seance
    {

        public DateTime DateSeance { get; set; }

        public SeanceType SeanceType { get; set; }


        public int CandidatCIN { get; set; }
        public Candidate Candidate { get; set; }

        public int AgentId { get; set; }
        public Agent Agent { get; set; }
    }
}