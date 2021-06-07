using System;
using backend.Autoecole.Domain.Models.Types;

namespace backend.Autoecole.Api.Resources.Seance
{
    public class SeanceResource
    {
        public DateTime DateSeance { get; set; }

        public SeanceType SeanceType { get; set; }
        public int CandidatId { get; set; }
        public int AgentId { get; set; }

        
    }
}