using System.Collections.Generic;
using backend.Autoecole.Domain.Abstract;
using backend.Autoecole.Domain.Models.Entities;

namespace backend.Autoecole.Domain.Services.IRepositories
{
    public interface ICandidatRepository : IGenericRepositry<Candidate>
    {
        public IEnumerable<Candidate> GetAllCandidats();
        public Candidate GetCandidatById(int id);
    }
}