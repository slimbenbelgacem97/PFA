using System;
using System.Collections.Generic;
using System.Linq;
using backend.Autoecole.DataAccess.Data;
using backend.Autoecole.Domain.Models.Entities;
using backend.Autoecole.Domain.Models.Types;
using backend.Autoecole.Domain.Services.IRepositories;

namespace backend.Autoecole.DataAccess.Repositories
{
    public class SeanceRepository : GenericRepositry<Seance>, ISeanceRepository
    {
        public SeanceRepository(ModelContextV2 context)
        : base(context)
        {

        }
        public IEnumerable<Seance> GetSeances()
        {
            return FindAll()
                .OrderBy(sc => sc.DateSeance)
                .ToList();
        }
        public IEnumerable<Seance> GetSeancesByType(SeanceType seanceType)
        {
            return FindByCondition(sc => sc.SeanceType.Equals(seanceType))
                   .OrderBy(s => s.SeanceType);


        }
        public Seance GetSeanceByAgentId(int id)
        {
            return FindByCondition(sc => sc.Agent.Id == id)
                    .FirstOrDefault();
        }
        public ICollection<Seance> GetSeancesByCandidateId(int id)
        {
            return FindByCondition(sc => sc.Candidate.Id == id)
                    .OrderBy(s => s.DateSeance)
                    .ToList();
        }
        public IEnumerable<Seance> GetSeancesByAgentId(int agentId)
        {
            return FindByCondition(a => a.AgentId== agentId).OrderBy(s =>s.DateSeance).ToList();
        }
        public void AssignSeanceToAgent(Seance seance)
        {
            base.Create(seance);
        }
    }
}