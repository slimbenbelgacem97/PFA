using System.Collections.Generic;
using backend.Autoecole.Domain.Models.Entities;
using backend.Autoecole.Domain.Models.Types;

namespace backend.Autoecole.Domain.Services.IServices
{
    public interface IServiceSeance
    {
        public IEnumerable<Seance> GetSeances();
        public IEnumerable<Seance> GetSenacesByAgentId(int agentId);
        public IEnumerable<Seance> GetSeancesByCandidateId(int id);
        public IEnumerable<Seance> GetSeancesByType(SeanceType type);
        public void UpdateSeance(Seance seance);
        public void AddSeance(Seance seance);
        public void DeleteSeance(Seance seance);
        

    }
}