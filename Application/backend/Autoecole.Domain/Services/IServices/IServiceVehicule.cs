using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Autoecole.Api.Resources;
using backend.Autoecole.Domain.Models.Entities;

namespace backend.Autoecole.Domain.Services.IServices
{
    public interface IServiceVehicule
    {
        public IEnumerable<Vehicule> GetAllVehicules();
        public Vehicule GetVehicule(string Immatricule);
        public void AddVehicule(Vehicule vehicle); 
        public void UpdateVehicule(Vehicule vehicle);
        public void DeleteVehicule(string immatricule);
        
        
    }
}