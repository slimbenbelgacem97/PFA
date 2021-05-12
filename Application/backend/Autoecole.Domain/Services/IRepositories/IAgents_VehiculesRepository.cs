using backend.Autoecole.Domain.Abstract;
using backend.Autoecole.Domain.Models.Entities;

namespace backend.Autoecole.Domain.Services.IRepositories
{
    public interface IAgents_VehiculesRepository : IGenericRepositry<Agent_Vehicule>
    {
        public Agent GetAgentByVehiculeId(string vehiculeId);
        public Vehicule GetVehiculeByAgentId(int AgentId);
    }
}