using System.Collections.Generic;
using backend.Models;
namespace backend.Repositries
{
    public interface ISeanceRepository : IRepositryBase<Seance>
    {
        public IEnumerable<Seance> GetSeances();
        public Seance GetSeancesByType(SeanceType seanceType);
        public Seance GetSeancesByAgentId(int id);
        public Seance GetSeancesByCandidateId(int id);
    }
}