using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

using backend.Logging;
using backend.Autoecole.Domain.Models.Types;
using backend.Autoecole.Domain.Abstract;
using backend.Autoecole.Api.Resources.Seance;
using backend.Autoecole.Domain.Services.IServices;
using backend.Autoecole.Domain.Models.Entities;

namespace backend.Autoecole.Api.Controllers
{
    [Route("api/seance")]
    [ApiController]
    public class SeanceController : ControllerBase
    {
        private readonly IUnitofWork context;
        private ILoggerManager loggerManager;
        private IMapper mapper;
        private readonly IServiceSeance serviceSeance;

        public SeanceController(IServiceSeance serviceSeance, IMapper mapper, IUnitofWork context, ILoggerManager loggerManager)
        {
            this.serviceSeance = serviceSeance;
            this.context = context;
            this.mapper = mapper;
            this.loggerManager = loggerManager;
        }

        //GET: api/seance/
        [HttpGet]
        public IActionResult GetAllScenaces()
        {
            try
            {
                var seance = serviceSeance.GetSeances();
                var seanceResult = mapper.Map<IEnumerable<SeanceResource>>(seance);
                return Ok(seanceResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GET: api/seance/type/code
        [HttpGet("type/{type}")]
        public IActionResult GetSeancesByType(SeanceType seanceType)
        {
            try
            {
                var seances = serviceSeance.GetSeancesByType(seanceType);
                var seanceResult = mapper.Map<SeanceResource>(seances);
                return Ok(seanceResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GET: api/seance/candidat/13468713
        [HttpGet("candidat/{id}")]
        public IActionResult GetSeanceByCandidate(int id)
        {
            try
            {
                var seances = serviceSeance.GetSeancesByCandidateId(id);
                var seancesResult = mapper.Map<IEnumerable<SeanceCandidateResource>>(seances);
                return Ok(seancesResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GET: api/seance/agent/13468713
        [HttpGet("agent/{id}")]
        public IActionResult GetSeanceByAgent(int id)
        {
            try
            {
                var seances = serviceSeance.GetSenacesByAgentId(id);
                var seancesResult = mapper.Map<IEnumerable<SeanceAgentResource>>(seances);
                return Ok(seancesResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //POST: api/seance/add
        [HttpPost("add")]
        public IActionResult AddSeance(SeanceResource seance)
        {
            try
            {
                var sean = mapper.Map<Seance>(seance);
                serviceSeance.AddSeance(sean);
                return Ok(sean);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //PUT: api/seance/update
        [HttpPut("update")]
        public IActionResult UpdateSeance(SeanceResource seance)
        {
            try
            {
                var sean = mapper.Map<Seance>(seance);
                serviceSeance.UpdateSeance(sean);
                return Ok(sean);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //DELETE : api/seance/delete
        [HttpDelete("delete")]
        public IActionResult DetleteSeance(SeanceResource seanceResource)
        {
            try
            {
                var sean = mapper.Map<Seance>(seanceResource);
                serviceSeance.DeleteSeance(sean);
                return Ok(sean);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}