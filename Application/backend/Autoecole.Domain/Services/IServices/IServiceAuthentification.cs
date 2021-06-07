using System.Threading.Tasks;
using backend.Autoecole.Api.Resources.Agent;
using backend.Autoecole.DataAccess.Data;

namespace backend.Autoecole.Domain.Services.IServices
{
    public interface IServiceAuthentification
    {
        public void Registry(ApplicationUser agent, string pwd, string vehiculeId);
        public Task<string> Login(AgentLogin agent);
        public void LogOut();
        public Task<ApplicationUser> GetAgentByUsername(string username);
    }
}