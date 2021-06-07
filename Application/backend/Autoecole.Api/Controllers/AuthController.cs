using System;
using AutoMapper;
using backend.Autoecole.Api.Resources.Agent;
using backend.Autoecole.DataAccess.Data;
using backend.Autoecole.Domain.Models.Entities;
using backend.Autoecole.Domain.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace backend.Autoecole.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]

    public class AuthController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IServiceAgent serviceAgent;
        private readonly IServiceAuthentification serviceAuthentification;
        public AuthController(IMapper mapper, IServiceAgent serviceAgent, IServiceAuthentification serviceAuthentification)
        {
            this.serviceAuthentification = serviceAuthentification;
            this.serviceAgent = serviceAgent;
            this.mapper = mapper;

        }

        // POST : api/auth/register
        [HttpPost("register")]
        public IActionResult Register(AgentRegister agentRegister)
        {
            try
            {
                if (agentRegister.Fonction != Domain.Models.Types.AgentFunction.Directeur)
                {
                    var agent = mapper.Map<Agent>(agentRegister);
                    serviceAgent.AddAgent(agent);
                }
                var agentToRegister = mapper.Map<ApplicationUser>(agentRegister);
                serviceAuthentification.Registry(agentToRegister, agentRegister.Password, agentRegister.VehiculeId);

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

            var agent = serviceAuthentification.GetAgentByUsername(agentRegister.UserName);
            var agentname = agent.Result.Nom;
            var agentFonction = agent.Result.Fonction;
            var token = serviceAuthentification.Login(agentRegister).Result;
            return Ok(new { agentFonction, agentname, token });
        }

        // POST: pai/auth/logout
        [HttpPost("logout")]
        public IActionResult LogOut()
        {
            serviceAuthentification.LogOut();
            return Ok();
        }

    }
}