using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;

namespace backend.Repositries
{
    public class Agents_VehiculesRepository : RepositryBase<Agent_Vehicule>, IAgents_VehiculesRepository
    {
        public Agents_VehiculesRepository(ModelContextV2 context) : base(context)
        {
        }

        public Agent GetAgentByVehiculeId(string vehiculeId)
        {
            throw new System.NotImplementedException();


        }
        public Vehicule GetVehiculeByAgentId(int agentId)
        {
            throw new System.NotImplementedException();
          
        }
    }
}