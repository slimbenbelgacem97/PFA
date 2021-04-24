using backend.Models;
using System.Collections.Generic;
namespace backend.Repositries
{
    public interface IAgentRepository : IRepositryBase<Agent>
    {
        public IEnumerable<Agent> GetAllAgents();
       public Agent GetAgentById(int agentId);
        public Agent GetDetailsAgentById(int AgentId);

    }
}