using System.Collections.Generic;
using System.Linq;
using backend.Models;
using backend.Data;
namespace backend.Repositries
{
    public class VehiculeRepository : RepositryBase<Vehicule>, IVehiculeRepository
    {
        public VehiculeRepository(ModelContextV2 context)
        :base(context)
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
            return FindByCondition(v => v.Immatricule==vehiculeId)
                    .FirstOrDefault();
        }
        public Vehicule GetVehicle(string s)
        {
            return FindByCondition(vehicle => vehicle.Immatricule == s).FirstOrDefault();
        }
    }
}