using System;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using backend.Autoecole.Api.Resources;
using backend.Autoecole.Domain.Models.Entities;
using backend.Autoecole.Domain.Services.IServices;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using backend.Autoecole.Api.Resources.Agent;
using backend.Autoecole.DataAccess.Data;

namespace backend.Autoecole.Api.Controllers
{
    [ApiController]
   //[Authorize]
    [Route("api/[controller]")]
    public class AgentController : ControllerBase
    {
        private readonly IMapper mapper;

        private readonly IServiceAgent serviceAgent;
        public AgentController(IServiceAgent serviceAgent, IMapper mapper)
        {
            this.mapper = mapper;
            this.serviceAgent = serviceAgent;

        }
        // GET : api/agent
        [HttpGet]
        
        public IActionResult GetAllAgents()
        {
            try
            {
                var agents = serviceAgent.GetAgents();
                var agentResource = mapper.Map<IEnumerable<AgentResource>>(agents);
                return Ok(agentResource);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET : api/agent/110
        [HttpGet("{id?}")]
        public IActionResult GetAgent(int id)
        {
            try
            {
                var agents = serviceAgent.GetAgent(id);
                var agentResource = mapper.Map<AgentResource>(agents);
                if (agents== null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(agentResource);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET : api/agent/details/110
        [HttpGet("details/{id?}")]
        public IActionResult GetAgentDetails(int id)
        {
            try
            {
                var agent = serviceAgent.GetAgentDetaillsResource(id);
                var agentResult = mapper.Map<AgentResource>(agent);
                var seances = mapper.Map<ICollection<Seance>,ICollection<SeanceResource>>(agent.Seances);
                var vehicule = mapper.Map<ICollection<Agent_VehiculeResource>>(agent.Vehicules);
                return Ok(new{agentResult, seances, vehicule});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // POST :  api/agent/add
        [HttpPost("add")]
        public ActionResult AddAgent(AgentResource agentResource)
        {
            try
            {
                var agent = mapper.Map<Agent>(agentResource);
                serviceAgent.AddAgent(agent);
                return Ok(agent);
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }


        //POST : api/agent/register
        // [AllowAnonymous]
        // [HttpPost("register")]
        // public IActionResult Register(AgentRegister agentRegister)
        // {
        //     try
        //     {
        //         var agent = mapper.Map<ApplicationUser>(agentRegister);
        //         serviceAgent.AdminRegistry(agent,agentRegister.Password);
        //         return Ok(agent);
        //     }
        //     catch (Exception ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
        // }





        // [HttpPut("update/{id?}")]
        // public IActionResult UpdateAgent(Agent updatedAgent)
        // {
        //     try
        //     {
        //         var agent = context.Agent.GetAgentById(updatedAgent.AgentId);
        //         if (agent == null)
        //         {
        //             loggerManager.LogError($"Agent [ ID: {updatedAgent.AgentId}], hasn't been found in db.");
        //             return NotFound();
        //         }
        //         else
        //         {
        //             context.Agent.Update(updatedAgent);
        //             context.Save();
        //             loggerManager.LogInfo($"Agent [ID:{updatedAgent.AgentId}] has been updated.");
        //             return Ok(updatedAgent);
        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //         loggerManager.LogError($"Something went wrong while updating  agent  :{ex.Message}");
        //         return StatusCode(500, "Internal Server Error");
        //     }
        // }


    }
}