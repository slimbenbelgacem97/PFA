using System.Collections.Generic;
using System.Linq;
using backend.Autoecole.Domain.Models.Entities;
using backend.Autoecole.Domain.Services.IRepositories;
using backend.Autoecole.DataAccess.Data;

namespace backend.Autoecole.DataAccess.Repositories
{
    public class CandidatRepository : GenericRepositry<Candidate>, ICandidatRepository
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
            return FindByCondition(candidat => candidat.Id == id)
                .FirstOrDefault();
        }
    }
}