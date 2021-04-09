using System.Collections.Generic;
using backend.Models;
namespace backend.Repositries
{
    public interface ISeanceRepository : IRepositryBase<Seances>
    {
        public IEnumerable<Seances> GetSeances();
        public Seances GetSeancesByType(SeanceType seanceType);
    }
}