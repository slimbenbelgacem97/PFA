using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using backend.Models;
using backend.Repositries;
using backend.Logging;
using backend.Controllers.Resources;
namespace backend.Controllers
{
    [ApiController]
    [Route("api/agent")]
    public class AgentController : ControllerBase
    {
        private ILoggerManager loggerManager;
        private IMapper mapper;
        private readonly IRepositoryWrapper context;
        public AgentController(IRepositoryWrapper context, IMapper mapper, ILoggerManager loggerManager)
        {
            this.context = context;
            this.mapper = mapper;
            this.loggerManager = loggerManager;
        }

        [HttpGet]
        public IActionResult GetAllAgents()
        {
            try
            {
                var agents = context.Agent.GetAllAgents();
                loggerManager.LogInfo($"Returned all Agents from database.");
                var agentsResult = mapper.Map<IEnumerable<AgentResource>>(agents);
                return Ok(agentsResult);
            }
            catch (Exception ex)
            {

                loggerManager.LogError($"Something went wrong while Geting All Agents:{ex.StackTrace}");
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpGet("{id?}")]
        public IActionResult GetAgent(int id)
        {
           
            try
            {
                var agent = context.Agent.GetAgentById((int)id);
                if (agent == null)
                {
                    loggerManager.LogError($"Agent with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    loggerManager.LogInfo($"Get agent (ID: {agent.AgentId})");
                    var agentResult = mapper.Map<AgentResource>(agent);
                    return Ok(agentResult);
                }
            }
            catch (Exception ex)
            {
                loggerManager.LogError($"Something went wrong while Geting  agent  :{ex.StackTrace}");
                return StatusCode(500, "Internal Server Error");
            }
        }
        
        [HttpGet("details/{id?}")]
        public IActionResult GetAgentDetails(int id)
        {
            try
            {

                var agent = context.Agent.GetDetailsAgentById(id);  
                if (agent == null)
                {
                    loggerManager.LogError($"Agent with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    var agentResult = mapper.Map<AgentResource>(agent);
                    loggerManager.LogInfo($"Get agent (ID: {agent.AgentId})");
                    var sc = mapper.Map<ICollection<Seance>, ICollection<SeanceResource>>(agent.Seances);
                    loggerManager.LogInfo($"Returned All seances of the agent [ID:{id}]");
                    var vehicules = mapper.Map<ICollection<Agent_VehiculeResource>>(agent.Vehicules);
                    loggerManager.LogInfo($"Returned the vehicule of the agent [ID:{id}]");
                    return Ok(new { agentResult, sc, vehicules });
                }
            }
            catch (Exception ex)
            {
                loggerManager.LogError($"Something went wrong while Geting  agent  :{ex.StackTrace}");
                return StatusCode(500, "Internal Server Error");
            }
        }

       [HttpPost("add")]
        public ActionResult AddAgent(Agent agent)
        {
            try
            {
                context.Agent.Create(agent);
                loggerManager.LogInfo($"New Agent with ID: {agent.AgentId}, Name: {agent.Nom} has been added.");
                var agentResult = mapper.Map<AgentResource>(agent);
                context.Save();
                return Ok(agentResult);
            }
            catch (Exception ex)
            {
                loggerManager.LogError($"Something went wrong while adding new (creating) Agent : {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("update/{id?}")]
        public IActionResult UpdateAgent(Agent updatedAgent)
        {
            try
            {
                var agent = context.Agent.GetAgentById(updatedAgent.AgentId);
                if (agent == null)
                {
                    loggerManager.LogError($"Agent [ ID: {updatedAgent.AgentId}], hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    context.Agent.Update(updatedAgent);
                    context.Save();
                    loggerManager.LogInfo($"Agent [ID:{updatedAgent.AgentId}] has been updated.");
                    return Ok(updatedAgent);
                }
            }
            catch (Exception ex)
            {
                loggerManager.LogError($"Something went wrong while updating  agent  :{ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

    }
}