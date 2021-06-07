using Microsoft.AspNetCore.Mvc;
using backend.Logging;
using AutoMapper;
using backend.Autoecole.Domain.Abstract;
using backend.Autoecole.Api.Resources;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using backend.Autoecole.Domain.Services.IServices;
using System;
using backend.Autoecole.Domain.Models.Entities;

namespace backend.Autoecole.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    // [Authorize]
    public class VehicleController : ControllerBase
    {
        
        private IMapper mapper;
        private readonly IServiceVehicule serviceVehicule;
        public VehicleController( IMapper mapper, IServiceVehicule serviceVehicule)
        {
            this.serviceVehicule = serviceVehicule;
            this.mapper = mapper;
        }

        // GET : api/vehicule/
        [HttpGet]
        public IActionResult GetVehicules()
        {
            try
            {
                var ve = serviceVehicule.GetAllVehicules();
                var vehicules = mapper.Map<IEnumerable<VehicleResource>>(ve);
                return Ok(vehicules);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET : api/vehicule/111TUN55555
        [HttpGet("{Immat?}")]
        public IActionResult GetVehicule(string immatricule)
        {
            try
            {
                var v = serviceVehicule.GetVehicule(immatricule);
                var vehicule = mapper.Map<VehicleResource>(v);
                return Ok(vehicule);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST : api/vehicule/add
        [HttpPost("add")]
        public IActionResult AddVehicle(VehicleResource vehicleResource)
        {
            try
            {
                var v = mapper.Map<Vehicule>(vehicleResource);
                serviceVehicule.AddVehicule(v);
                return Ok(v);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT : api/vehicule/update/111TUN4444
        [HttpPut("update/{immatricule}")]
        public IActionResult UpdateVehicle(VehicleResource vehicleResource)
        {
            try
            {
                var vehicleToUpdate = mapper.Map<Vehicule>(vehicleResource);
                serviceVehicule.UpdateVehicule(vehicleToUpdate);
                return Ok(vehicleToUpdate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //DELETE : api/vehicule/delete/111TUN4444
        [HttpDelete("delete/{immatricule}")]
        public IActionResult DeleteVehicle(string immatricule)
        {
            try
            {
               
                serviceVehicule.DeleteVehicule(immatricule);
                return Ok($"Vehicle [Immatricule: {immatricule} has been deleted.]");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}