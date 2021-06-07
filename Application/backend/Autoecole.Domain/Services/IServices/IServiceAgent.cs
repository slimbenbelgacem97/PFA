using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Autoecole.Api.Resources.Agent;
using backend.Autoecole.DataAccess.Data;
using backend.Autoecole.Domain.Models.Entities;

namespace backend.Autoecole.Domain.Services.IServices
{
    public interface IServiceAgent
    {
        public IEnumerable<Agent> GetAgents();
        public Agent GetAgent(int id);
        public Agent GetAgentDetaillsResource(int id);
        public void AddAgent(Agent agent);
        public void UpdateAgent(Agent agent);
        public void DeleteAgent(int id);

    }
}