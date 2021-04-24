using backend.Models;
using backend.Data;
using System.Collections.Generic;
using System.Linq;
namespace backend.Repositries
{
    public class CandidatRepository : RepositryBase<Candidate>, ICandidatRepository
    {

        public CandidatRepository(ModelContextV2 context)
        : base(context)
        {

        }
        public IEnumerable<Candidate> GetAllCandidats()
        {
            return FindAll()
                    .OrderBy(c => c.Nom)
                    .ToList();
        }
        public void CreateAgent(Candidate candidat)
        {
            base.Create(candidat);
        }
        public Candidate GetCandidatById(int id)
        {
            return FindByCondition(candidat => candidat.CandidatCIN == id)
                .FirstOrDefault();
        }
    }
}