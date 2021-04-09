using backend.Models;
using backend.Data;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
namespace backend.Repositries
{
    public class AgentRepository : RepositryBase<Agent>, IAgentRepository
    {
        public AgentRepository(Model context)
        : base(context)
        {

        }
        public IEnumerable<Agent> GetAllAgents()
        {
            return FindAll()
                    .OrderBy(a => a.Nom)
                    .ToList();
        }
        public void CreateAgent(Agent agent)
        {
            base.Create(agent);
        }
       public Agent GetAgentById(int agentId)
        {
            return FindByCondition(agent => agent.AgentCIN== agentId)
                .FirstOrDefault();
        }

    }
}