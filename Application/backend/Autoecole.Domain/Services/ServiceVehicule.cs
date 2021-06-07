using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using backend.Autoecole.Domain.Abstract;
using backend.Autoecole.Domain.Exceptions;
using backend.Autoecole.Domain.Models.Entities;
using backend.Autoecole.Domain.Services.IServices;
using backend.Logging;

namespace backend.Autoecole.Domain.Services
{
    public class ServiceVehicule : IServiceVehicule
    {
        private readonly IUnitofWork context;
        private readonly IMapper mapper;
        private readonly ILoggerManager loggerManager;
        public ServiceVehicule(IUnitofWork context, IMapper mapper, ILoggerManager loggerManager)
        {
            this.loggerManager = loggerManager;
            this.mapper = mapper;
            this.context = context;

        }
        public void AddVehicule(Vehicule vehicle)
        {
           var vehicleExist = context.Vehicule.GetVehicleById(vehicle.Immatricule);
            if (vehicleExist != null)
            {
                throw new Exception(VehiculeExceptions.VehicleExist);
            }
            else
            {
                context.Vehicule.Create(vehicle);
                context.Save();
                loggerManager.LogInfo($"A new Vehicle [Immatricule :{vehicle.Immatricule}] has been added");
            }
        }

        public IEnumerable<Vehicule> GetAllVehicules()
        {
            return context.Vehicule.GetVehicles();
        }

        public Vehicule GetVehicule(string Immatricule)
        {
            var vehicle = context.Vehicule.GetVehicleById(Immatricule);
            if (vehicle == null)
            {
                throw new Exception(VehiculeExceptions.VehicleNotExist);
            }
            return (vehicle);
        }
        public void UpdateVehicule(Vehicule vehicle)
        {
            var ve = context.Vehicule.GetVehicleById(vehicle.Immatricule);
            if (vehicle == null)
            {
                throw new Exception(VehiculeExceptions.VehicleNotExist);
            }
            else
            {
                context.Vehicule.Update(vehicle);
                context.Save();
            }
        }

        public void DeleteVehicule(string immatricule)
        {
            var ve = context.Vehicule.GetVehicleById(immatricule);
            if (ve == null)
            {
                throw new Exception(VehiculeExceptions.VehicleNotExist);
            }
            else
            {
                context.Vehicule.Delete(ve);
                context.Save();
            }
        }
    }
}