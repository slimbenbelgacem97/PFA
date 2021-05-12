using System;
using AutoMapper;
using backend.Autoecole.Api.Resources.Agent;
using backend.Autoecole.DataAccess.Data;
using backend.Autoecole.Domain.Models.Entities;
using backend.Autoecole.Domain.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace backend.Autoecole.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]

    public class AuthController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IServiceAgent serviceAgent;
        public AuthController(IMapper mapper, IServiceAgent serviceAgent)
        {
            this.serviceAgent = serviceAgent;
            this.mapper = mapper;

        }
        
        // POST : api/auth/register
        [HttpPost("register")]
        public IActionResult Register(AgentRegister agentRegister)
        {
            try
            {
                if (agentRegister.Fonction!=Domain.Models.Types.AgentFunction.Directeur)
                {
                    var agent = mapper.Map<Agent>(agentRegister);
                    serviceAgent.AddAgent(agent);
                }
                    var agentToRegister = mapper.Map<ApplicationUser>(agentRegister);
                    serviceAgent.AdminRegistry(agentToRegister, agentRegister.Password);
                
                return Ok(agentRegister);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: pai/auth/login
        [HttpPost("login")]
        public IActionResult Login(AgentLogin agentRegister)
        {
          
            var agent = serviceAgent.GetAgentByUsername(agentRegister.UserName);
            var agentname = agent.Result.Nom;
            var agentFonction = agent.Result.Fonction;
            var token = serviceAgent.Login(agentRegister).Result;
            return Ok(new {agentFonction, agentname, token});
        }

        // POST: pai/auth/logout
        [HttpPost("logout")]
        public IActionResult LogOut()
        {
            serviceAgent.LogOut();
            return Ok();
        }
    }
}