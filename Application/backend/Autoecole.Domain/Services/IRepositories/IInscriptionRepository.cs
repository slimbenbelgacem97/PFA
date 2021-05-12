using backend.Autoecole.Domain.Models.Entities;

namespace backend.Autoecole.Domain.Services.IRepositories
{
    public interface IInscriptionRepository
    {
        
        public void deleteAgent(int agentId);
        public void updatePassword(int agentId, string newPassword);
    }
}