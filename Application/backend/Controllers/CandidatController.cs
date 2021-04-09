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
    [Route("api/candidat")]
    [ApiController]
    public class CandidatController : ControllerBase
    {
        private readonly IRepositoryWrapper context;
        private ILoggerManager loggerManager;
        private IMapper mapper;
        public CandidatController(IRepositoryWrapper context, IMapper mapper, ILoggerManager loggerManager)
        {
            this.context = context;
            this.mapper = mapper;
            this.loggerManager = loggerManager;
        }
        public IActionResult GetAllCandidates()
        {
            try
            {
                var candidats = context.Candidat.GetAllCandidats();
                loggerManager.LogInfo($"Returned all Candidates from database.");
                var candidatsResult = mapper.Map<IEnumerable<CandidatResource>>(candidats);
                return Ok(candidatsResult);
            }
            catch (Exception ex)
            {

                loggerManager.LogError($"Something went wrong while Geting All cadidates:{ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpGet("{id?}")]
        public IActionResult GetCandidat(int id)
        {
            try
            {
                var candidat = context.Candidat.GetCandidatById(id);
                if (candidat == null)
                {
                    loggerManager.LogError($"Candidate with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    loggerManager.LogInfo($" Get agent (ID: {candidat.CandidatCIN})");
                    var candidatResource = mapper.Map<CandidatResource>(candidat);
                    return Ok(candidatResource);
                }
            }
            catch (Exception ex)
            {
                loggerManager.LogError($"Something went wrong while Geting  candidate  :{ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
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
        [HttpPost]
        public ActionResult CreateCandidate(Candidat candidat)
        {
            try
            {
                context.Candidat.Create(candidat);
                loggerManager.LogInfo($"New Candidate with ID: {candidat.CandidatCIN}, Name: {candidat.Nom} has been added.");
                var candidatResult = mapper.Map<CandidatResource>(candidat);
                return Ok(candidatResult);
            }
            catch (Exception ex)
            {
                loggerManager.LogError($"Something went wrong while adding new (creating) Candidate : {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        //update
        //delete
    }
}