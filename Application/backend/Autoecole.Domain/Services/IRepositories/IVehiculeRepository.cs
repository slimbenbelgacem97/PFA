using System.Collections.Generic;
using backend.Autoecole.Domain.Abstract;
using backend.Autoecole.Domain.Models.Entities;

namespace backend.Autoecole.Domain.Services.IRepositories
{
    public interface IVehiculeRepository : IGenericRepositry<Vehicule>
    {
        public IEnumerable<Vehicule> GetVehicles();
        public Vehicule GetVehicleById(string vehiculeId);
    }
}