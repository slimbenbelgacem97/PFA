using System.Collections.Generic;
using System.Linq;
using backend.Autoecole.Domain.Models.Entities;
using backend.Autoecole.Domain.Services.IRepositories;
using backend.Autoecole.DataAccess.Data;

namespace backend.Autoecole.DataAccess.Repositories
{
    public class VehiculeRepository : GenericRepositry<Vehicule>, IVehiculeRepository
    {
        public VehiculeRepository(ModelContextV2 context)
        : base(context)
        {

        }
        public IEnumerable<Vehicule> GetVehicles()
        {
            return FindAll()
                    .OrderBy(v => v.Immatricule)
                    .ToList();
        }
        public Vehicule GetVehicleById(string vehiculeId)
        {
            return FindByCondition(v => v.Immatricule == vehiculeId)
                    .FirstOrDefault();
        }
        public Vehicule GetVehicle(string s)
        {
            return FindByCondition(vehicle => vehicle.Immatricule == s).FirstOrDefault();
        }
    }
}