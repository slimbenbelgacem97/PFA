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
    [Route("api/seance")]
    [ApiController]
    public class SeanceController : ControllerBase
    {
        private readonly IRepositoryWrapper context;
        private ILoggerManager loggerManager;
        private IMapper mapper;

        public SeanceController(IRepositoryWrapper context, IMapper mapper, ILoggerManager loggerManager)
        {
            this.context = context;
            this.mapper = mapper;
            this.loggerManager = loggerManager;
        }

        [HttpGet]
        public IActionResult GetAllScenaces()
        {
            try
            {
                var seance = context.Seance.GetSeances();
                loggerManager.LogInfo($"Returned all Scenaces from database.");
                var seanceResult = mapper.Map<IEnumerable<SeanceResource>>(seance);
                return Ok(seanceResult);
            }
            catch (Exception ex)
            {

                loggerManager.LogError($"Something went wrong while Geting All Agents:{ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpGet("type/{type}")]
        public IActionResult GetSeancesByType(SeanceType seanceType)
        {
            try
            {
                var seances = context.Seance.GetSeancesByType(seanceType);
                loggerManager.LogInfo($"Returned All seances (type : {seances.SeanceType}");
                var seanceResult = mapper.Map<SeanceResource>(seances);
                // var agent = context.Agent.FindByCondition(agent => agent.AgentCIN == 0);
                return Ok(seanceResult);
            }
            catch (Exception ex)
            {

                loggerManager.LogError($"Something went wrong while Geting All Agents:{ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

    }
}