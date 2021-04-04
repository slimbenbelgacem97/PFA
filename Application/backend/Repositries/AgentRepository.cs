using backend.Models;
using backend.Data;
namespace backend.Repositries
{
    public class AgentRepository : RepositryBase<Agent>, IAgentRepository
    {
        public AgentRepository(Model context)
        : base(context)
        {

        }
    }
}