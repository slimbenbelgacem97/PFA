using backend.Models;
using backend.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace backend.Repositries
{
    public class AgentRepository : RepositryBase<Agent>, IAgentRepository
    {
        public AgentRepository(ModelContextV2 context)
        : base(context)
        {

        }
        public IEnumerable<Agent> GetAllAgents()
        {
            return FindAll()
                    .OrderBy(a => a.DateEmb)
                    .ToList();
        }
        public void CreateAgent(Agent agent)
        {
            base.Create(agent);
        }
       public Agent GetAgentById(int agentId)
        {
            return FindByCondition(agent => agent.AgentId == agentId)
                .FirstOrDefault();
        }
        public Agent GetDetailsAgentById(int agentId)
        {
            return FindByCondition(a => a.AgentId == agentId)
            .Include(a =>a.Seances)
            .Include(a => a.Vehicules)
            .ThenInclude(av => av.Vehicule)
            .AsSplitQuery()
            .FirstOrDefault();
        }
    }
}