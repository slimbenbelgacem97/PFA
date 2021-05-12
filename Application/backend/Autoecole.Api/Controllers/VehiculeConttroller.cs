// using Microsoft.AspNetCore.Mvc;


// using backend.Logging;
// using AutoMapper;
// using backend.Autoecole.Domain.Services.IRepositories;

// namespace backend.Autoecole.Api.Controllers
// {
//     [ApiController]
//     [Route("api/vehicule")]
//     public class VehiculeConttroller : ControllerBase
//     {
//         private ILoggerManager loggerManager;
//         private IMapper mapper;
//         private readonly IRepositoryWrapper context;
//         public VehiculeConttroller(IRepositoryWrapper context, IMapper mapper, ILoggerManager loggerManager)
//         {
//             this.context = context;
//             this.mapper = mapper;
//             this.loggerManager = loggerManager;
//         }
//         //     [HttpGet("v/{id?}")]
//         //    public IActionResult GetVById(string id)
//         //    {
//         //         var ve = context.Vehicule.GetVehicleById(id);
//         //         var vehicules = mapper.Map< VehicleResource>(ve);
//         //         return Ok(vehicules);
//         //     }

//     }
// }