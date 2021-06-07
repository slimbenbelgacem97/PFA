using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using backend.Autoecole.Api.Resources;
using backend.Autoecole.Domain.Models.Entities;
using backend.Autoecole.Domain.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using backend.Autoecole.Api.Resources.Seance;

namespace backend.Autoecole.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class CandidatsController : ControllerBase
    {

        private readonly IServiceCandidat serviceCandidat;
        private IMapper mapper;
        private readonly IServiceSeance serviceSeance;
        public CandidatsController(IServiceCandidat serviceCandidat, IServiceSeance serviceSeance, IMapper mapper)
        {
            this.serviceSeance = serviceSeance;
            this.serviceCandidat = serviceCandidat;
            this.mapper = mapper;
        }
        
        //GET: api/candidats/
        [HttpGet]
        public IActionResult GetAllCandidates()
        {
            try
            {
                var candidats = serviceCandidat.GetCandidats();
                var candidatsResult = mapper.Map<IEnumerable<CandidatResource>>(candidats);
                return Ok(candidatsResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GET: api/candidats/15
        [HttpGet("{id}")]
        public IActionResult GetCandidat(int id)
        {
            try
            {
                var candidat = serviceCandidat.GetCandidat(id);
                var candidatResource = mapper.Map<CandidatResource>(candidat);
                return Ok(candidatResource);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //GET: api/candidats/details/5
        [HttpGet("details/{id}")]
        public IActionResult GetCandidatDetails(int id)
        {
            try
            {
                var candidat = serviceCandidat.GetCandidat(id);
                var seance = serviceSeance.GetSeancesByCandidateId(id);
                var candidatResource = mapper.Map<CandidatResource>(candidat);
                var seances = mapper.Map<IEnumerable<SeanceCandidateResource>>(seance);

                return Ok(new { candidatResource, seances });
            }
            catch (Exception )
            {

                return StatusCode(500, "Internal Server Error");
            }
        }

        //POST : api/candidats/add
        [HttpPost("add")]
        public ActionResult CreateCandidate(CandidatResource candidat)
        {
            try
            {
                var candidatToAdd = mapper.Map<Candidate>(candidat);
                serviceCandidat.AddCandidate(candidatToAdd);
                
                return Ok();
            }
            catch (Exception ex )
            {
                return BadRequest(ex.Message);
            }
        }

        //PUT : api/candidats/update/12345678
        [HttpPut("update/{id}")]
        public IActionResult UpdateCandicate(CandidatResource newCandidate)
        {
            try
            {
            var  candidatToUpdate = mapper.Map<Candidate>(newCandidate); 
            serviceCandidat.UpdateCandicate(candidatToUpdate);
            return Ok();
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteCandidate(int id)
        {
            try
            {
                // Add to Archive then delete
                serviceCandidat.DeleteCandidate(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}