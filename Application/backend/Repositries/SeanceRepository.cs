using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using backend.Models;
using backend.Data;
namespace backend.Repositries
{
    public class SeanceRepository : RepositryBase<Seances>, ISeanceRepository
    {
        public SeanceRepository(Model context)
        : base(context)
        {

        }
        public IEnumerable<Seances> GetSeances()
        {
            return FindAll()
                .OrderBy(sc => sc.DateSeance)
                .ToList();
        }
        public  Seances GetSeancesByType(SeanceType seanceType)
        {
            return FindByCondition(sc => sc.SeanceType.Equals(seanceType))
                .Include(a => a.Agent)
                .FirstOrDefault();


        }
    }
}