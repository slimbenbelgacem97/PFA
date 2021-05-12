using System.Collections.Generic;
using backend.Autoecole.Domain.Abstract;
using backend.Autoecole.Domain.Models.Entities;
using backend.Autoecole.Domain.Models.Types;

namespace backend.Autoecole.Domain.Services.IRepositories
{
    public interface ISeanceRepository : IGenericRepositry<Seance>
    {
        public IEnumerable<Seance> GetSeances();
        public Seance GetSeancesByType(SeanceType seanceType);
        public Seance GetSeancesByAgentId(int id);
        public Seance GetSeancesByCandidateId(int id);
    }
}