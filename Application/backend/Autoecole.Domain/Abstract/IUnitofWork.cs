using System;
using System.Threading;
using System.Threading.Tasks;
using backend.Autoecole.Domain.Services.IRepositories;

namespace backend.Autoecole.Domain.Abstract
{
    public interface IUnitofWork :IDisposable
    {
        public IAgentRepository Agent { get; set; }
        public ICandidatRepository Candidate { get; set; }
        public ISeanceRepository Seance { get; set; }
        public IVehiculeRepository Vehicule { get; set; }
        public IAgents_VehiculesRepository Agents_Vehicules { get; set; }
        void Save();
       
    }
}