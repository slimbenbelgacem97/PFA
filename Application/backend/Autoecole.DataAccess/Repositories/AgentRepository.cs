using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using backend.Autoecole.DataAccess.Data;
using backend.Autoecole.Domain.Models.Entities;
using backend.Autoecole.Domain.Services.IRepositories;

namespace backend.Autoecole.DataAccess.Repositories
{
    public class AgentRepository : GenericRepositry<Agent>, IAgentRepository
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
            return FindByCondition(agent => agent.Id == agentId)
                .FirstOrDefault();
        }
        public Agent GetDetailsAgentById(int agentId)
        {
            return FindByCondition(a => a.Id == agentId)
            .Include(a => a.Seances)
            .Include(a => a.Vehicules)
            .ThenInclude(av => av.Vehicule)
            .AsSplitQuery()
            .FirstOrDefault();
        }
    }
}