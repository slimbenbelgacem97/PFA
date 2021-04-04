using backend.Models;
using backend.Data;
namespace backend.Repositries
{
    public class CandidatRepository : RepositryBase<Candidat>, ICandidatRepository
    {

        public CandidatRepository(Model context)
        : base(context)
        {

        }
    }
}