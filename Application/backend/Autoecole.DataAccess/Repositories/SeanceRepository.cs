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
        public Seance GetSeancesByType(SeanceType seanceType)
        {
            return FindByCondition(sc => sc.SeanceType.Equals(seanceType))
                    .FirstOrDefault();


        }
        public Seance GetSeancesByAgentId(int id)
        {
            return FindByCondition(sc => sc.Agent.Id == id)
                    .FirstOrDefault();
        }
        public Seance GetSeancesByCandidateId(int id)
        {
            return FindByCondition(sc => sc.Candidate.Id == id)
                    .FirstOrDefault();
        }
    }
}