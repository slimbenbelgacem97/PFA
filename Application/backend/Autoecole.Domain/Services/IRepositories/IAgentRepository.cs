using backend.Autoecole.Domain.Abstract;
using backend.Autoecole.Domain.Models.Entities;
using System.Collections.Generic;
namespace backend.Autoecole.Domain.Services.IRepositories
{
    public interface IAgentRepository : IGenericRepositry<Agent>
    {
        public IEnumerable<Agent> GetAllAgents();
        public Agent GetAgentById(int agentId);
        public Agent GetDetailsAgentById(int AgentId);
        

    }
}