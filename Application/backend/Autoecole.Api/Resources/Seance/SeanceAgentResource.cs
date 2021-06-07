using System;
using backend.Autoecole.Domain.Models.Types;

namespace backend.Autoecole.Api.Resources.Seance
{
    public class SeanceAgentResource
    {
        public DateTime DateSeance { get; set; }

        public SeanceType SeanceType { get; set; }
        public int CandidatId { get; set; }
        
    }
}