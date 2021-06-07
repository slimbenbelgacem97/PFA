using System;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using backend.Autoecole.Api.Resources;
using backend.Autoecole.Domain.Models.Entities;
using backend.Autoecole.Domain.Services.IServices;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using backend.Autoecole.Api.Resources.Seance;

namespace backend.Autoecole.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class AgentController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IServiceSeance serviceSeance;

        private readonly IServiceAgent serviceAgent;
        public AgentController(IServiceAgent serviceAgent, IServiceSeance serviceSeance, IMapper mapper)
        {
            this.serviceSeance = serviceSeance;
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
                if (agents == null)
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
                var s = serviceSeance.GetSenacesByAgentId(id);
                var seances = mapper.Map<IEnumerable<Seance>, ICollection<SeanceAgentResource>>(s);
                var vehicule = mapper.Map<ICollection<Agent_VehiculeResource>>(agent.Vehicules);
                return Ok(new { agentResult, seances, vehicule });
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

        //PUT :api/agent/update/1233547
        [HttpPut("update/{id}")]
        public IActionResult UpdateAgent(AgentResource updatedAgent)
        {
            try
            {
                var _agent_to_update = mapper.Map<Agent>(updatedAgent);
                serviceAgent.UpdateAgent(_agent_to_update);
                return Ok(_agent_to_update);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //DELETE : api/agent/delete/1234576
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteAgent(int agentId)
        {
            try
            {
                serviceAgent.DeleteAgent(agentId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}