using backend.Models;

namespace backend.Repositries
{
    public interface IAgents_VehiculesRepository :IRepositryBase<Agent_Vehicule>
    {
        public Agent GetAgentByVehiculeId(string vehiculeId);
        public Vehicule GetVehiculeByAgentId(int AgentId);
    }
}