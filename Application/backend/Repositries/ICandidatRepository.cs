using System.Collections.Generic;
using backend.Models;
namespace backend.Repositries
{
    public interface ICandidatRepository : IRepositryBase<Candidate>
    {
        public IEnumerable<Candidate> GetAllCandidats();
        public Candidate GetCandidatById(int id);
    }
}