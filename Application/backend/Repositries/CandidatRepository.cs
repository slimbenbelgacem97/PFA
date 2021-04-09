using backend.Models;
using backend.Data;
using System.Collections.Generic;
using System.Linq;
namespace backend.Repositries
{
    public class CandidatRepository : RepositryBase<Candidat>, ICandidatRepository
    {

        public CandidatRepository(Model context)
        : base(context)
        {

        }
        public IEnumerable<Candidat> GetAllCandidats()
        {
            return FindAll()
                    .OrderBy(c => c.Nom)
                    .ToList();
        }
        public void CreateAgent(Candidat candidat)
        {
            base.Create(candidat);
        }
        public Candidat GetCandidatById(int id)
        {
            return FindByCondition(candidat => candidat.CandidatCIN == id)
                .FirstOrDefault();
        }
    }
}