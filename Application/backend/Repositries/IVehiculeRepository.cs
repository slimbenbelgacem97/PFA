using System.Collections.Generic;
using backend.Models;
namespace backend.Repositries
{
    public interface IVehiculeRepository : IRepositryBase<Vehicule>
    {
        public IEnumerable<Vehicule> GetVehicles();
        public Vehicule GetVehicleById(string vehiculeId);
    }
}