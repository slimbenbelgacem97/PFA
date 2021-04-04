using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using backend.Data;
using backend.Models;
using backend.Repositries;
namespace backend.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AgentController:ControllerBase
    {
        private readonly IRepositoryWrapper context;
        public AgentController(IRepositoryWrapper context)
        {
            this.context = context;
        }

        
        [HttpGet("/all")]    
        public IEnumerable<Agent> GetAgents()
        {
            var agents = context.Agent.FindAll();
            return agents;
        }
    }
}