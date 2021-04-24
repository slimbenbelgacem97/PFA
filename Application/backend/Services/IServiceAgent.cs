using System.Collections.Generic;
using backend.Models;

namespace backend.Services
{
    public interface IServiceAgent
    {
        public IEnumerable<Agent> GetAgents();
    }
}