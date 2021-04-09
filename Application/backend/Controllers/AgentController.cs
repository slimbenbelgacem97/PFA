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
    public class AgentController:ControllerBase
    {
        private ILoggerManager loggerManager;
        private IMapper mapper;
        private readonly IRepositoryWrapper context;
        public AgentController(IRepositoryWrapper context, IMapper mapper,ILoggerManager loggerManager)
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

                loggerManager.LogError($"Something went wrong while Geting All Agents:{ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpGet("{id?}")]
        public IActionResult GetAgent(int id)
        {
            try
            {
                var agent = context.Agent.GetAgentById(id);
                if(agent ==null){
                    loggerManager.LogError($"Agent with id: {id}, hasn't been found in db.");
                    return NotFound();
                }else
                {
                    loggerManager.LogInfo($" Get agent (ID: {agent.AgentCIN})");
                    var agentResult = mapper.Map<AgentResource>(agent);
                    return Ok(agentResult);
                }
            }
            catch (Exception ex)
            {
                loggerManager.LogError($"Something went wrong while Geting  agent  :{ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpPost("/add")]
        public ActionResult CreateAgent(Agent agent)
        {
            try
            {
                context.Agent.Create(agent);
                loggerManager.LogInfo($"New Agent with ID: {agent.AgentCIN}, Name: {agent.Nom} has been added.");
                var agentResult = mapper.Map<AgentResource>(agent);
                return Ok(agentResult);
            }
            catch (Exception ex )
            {
                loggerManager.LogError($"Something went wrong while adding new (creating) Agent : {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        } 
        [Route("/update")]
        [HttpPost("/{id}")]
        public IActionResult UpdateAgent(int id, Agent agent)
        {
            
            try
            {
               
                context.Agent.Update(agent);
                loggerManager.LogInfo($"Agent{agent.AgentCIN} has been updated.");
                return Ok(agent);
            }
            catch (Exception ex)
            {
                loggerManager.LogError($"Something went wrong while  updating Agent   : {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("/test/logging")]
        public IEnumerable<string> Get()
        {
            loggerManager.LogInfo("Here is info message from the controller.");
            loggerManager.LogDebug("Here is debug message from the controller.");
            loggerManager.LogWarn("Here is warn message from the controller.");
            loggerManager.LogError("Here is error message from the controller.");
            return new string[] { "value1", "value2" };
        }

    }
}