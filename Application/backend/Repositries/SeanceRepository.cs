using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using backend.Models;
using backend.Data;
namespace backend.Repositries
{
    public class SeanceRepository : RepositryBase<Seance>, ISeanceRepository
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
        public Seance GetSeancesByType(SeanceType seanceType)
        {
            return FindByCondition(sc => sc.SeanceType.Equals(seanceType))
                    .FirstOrDefault();


        }
        public Seance GetSeancesByAgentId(int id)
        {
            return FindByCondition(sc => sc.Agent.AgentId == id)
                    .FirstOrDefault();
        }
        public Seance GetSeancesByCandidateId(int id)
        {
            return FindByCondition(sc => sc.Candidate.CandidatCIN == id)
                    .FirstOrDefault();
        }
    }
}