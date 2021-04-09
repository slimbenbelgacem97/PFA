using System.Collections.Generic;
using backend.Models;
namespace backend.Repositries
{
    public interface ICandidatRepository : IRepositryBase<Candidat>
    {
        public IEnumerable<Candidat> GetAllCandidats();
        public Candidat GetCandidatById(int id);
    }
}