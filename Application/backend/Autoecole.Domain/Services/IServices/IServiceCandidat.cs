using System.Collections.Generic;
using backend.Autoecole.Domain.Models.Entities;

namespace backend.Autoecole.Domain.Services.IServices
{
    public interface IServiceCandidat
    {
        public IEnumerable<Candidate> GetCandidats();
        public Candidate GetCandidat(int id);
        public void AddCandidate(Candidate candidat);
        public void UpdateCandicate(Candidate newCandidate);
        public void DeleteCandidate(int id);
    }
}