// using System;
// using System.Collections.Generic;
// using Microsoft.AspNetCore.Mvc;
// using AutoMapper;

// using backend.Logging;
// using backend.Autoecole.Domain.Services.IRepositories;
// using backend.Autoecole.Api.Resources;
// using backend.Autoecole.Domain.Models.Entities;

// namespace backend.Autoecole.Api.Controllers
// {
//     [Route("api/candidat")]
//     [ApiController]
//     public class CandidatController : ControllerBase
//     {
//         private readonly IUnitOfwork context;
//         private ILoggerManager loggerManager;
//         private IMapper mapper;
//         public CandidatController(IRepositoryWrapper context, IMapper mapper, ILoggerManager loggerManager)
//         {
//             this.context = context;
//             this.mapper = mapper;
//             this.loggerManager = loggerManager;
//         }
//         public IActionResult GetAllCandidates()
//         {
//             try
//             {
//                 var candidats = context.Candidate.GetAllCandidats();
//                 loggerManager.LogInfo($"Returned all Candidates from database.");
//                 var candidatsResult = mapper.Map<IEnumerable<CandidatResource>>(candidats);
//                 return Ok(candidatsResult);
//             }
//             catch (Exception ex)
//             {

//                 loggerManager.LogError($"Something went wrong while Geting All cadidates:{ex.Message}");
//                 return StatusCode(500, "Internal Server Error");
//             }
//         }
//         [HttpGet("{id}")]
//         public IActionResult GetCandidat(int id)
//         {
//             try
//             {
//                 var candidat = context.Candidate.GetCandidatById(id);
//                 if (candidat == null)
//                 {
//                     loggerManager.LogError($"Candidate with id: {id}, hasn't been found in db.");
//                     return NotFound();
//                 }
//                 else
//                 {
//                     loggerManager.LogInfo($" Get agent (ID: {candidat.CandidatCIN})");
//                     var candidatResource = mapper.Map<CandidatResource>(candidat);
//                     return Ok(candidatResource);
//                 }
//             }
//             catch (Exception ex)
//             {
//                 loggerManager.LogError($"Something went wrong while Geting  candidate  :{ex.Message}");
//                 return StatusCode(500, "Internal Server Error");
//             }
//         }

//         [HttpGet("{id}/details")]
//         public IActionResult GetCandidatDetails(int id)
//         {
//             try
//             {
//                 var candidat = context.Candidate.GetCandidatById(id);
//                 var seance = context.Seance.GetSeancesByCandidateId(id);
//                 if (candidat == null)
//                 {
//                     loggerManager.LogError($"Candidate with id: {id}, hasn't been found in db.");
//                     return NotFound();
//                 }
//                 else
//                 {

//                     var candidatResource = mapper.Map<CandidatResource>(candidat);
//                     loggerManager.LogInfo($" Get agent (ID: {candidat.CandidatCIN})");
//                     var seances = mapper.Map<SeanceResource>(seance);
//                     loggerManager.LogInfo($"Returned all the seances of Cadidate[ID: {id}]");
//                     return Ok(new { candidatResource, seances });
//                 }
//             }
//             catch (Exception ex)
//             {
//                 loggerManager.LogError($"Something went wrong while Geting  candidate  :{ex.Message}");
//                 return StatusCode(500, "Internal Server Error");
//             }
//         }

//         [HttpPost]
//         public ActionResult CreateCandidate(Candidate candidat)
//         {
//             try
//             {
//                 context.Candidate.Create(candidat);
//                 loggerManager.LogInfo($"New Candidate with ID: {candidat.CandidatCIN}, Name: {candidat.Nom} has been added.");
//                 var candidatResult = mapper.Map<CandidatResource>(candidat);
//                 context.Save();
//                 return Ok(candidatResult);
//             }
//             catch (Exception ex)
//             {
//                 loggerManager.LogError($"Something went wrong while adding new (creating) Candidate : {ex.Message}");
//                 return StatusCode(500, "Internal server error");
//             }
//         }

//     }
// }