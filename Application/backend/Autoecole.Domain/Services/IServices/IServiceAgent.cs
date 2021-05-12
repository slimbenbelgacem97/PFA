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
        public void AdminRegistry(ApplicationUser admin, string pwd);
        public  Task<string> Login(AgentLogin agent);
        public void LogOut();
        public Task<ApplicationUser> GetAgentByUsername(string username);

    }
}