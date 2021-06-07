using System.Threading.Tasks;
using backend.Autoecole.DataAccess.Data;
using backend.Autoecole.Domain.Models.Entities;
using backend.Autoecole.Domain.Services.IRepositories;

namespace backend.Autoecole.DataAccess.Repositories
{
    public class Agents_VehiculesRepository : GenericRepositry<Agent_Vehicule>, IAgents_VehiculesRepository
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
        public void AssignVehicleToAgent(int agentId, string vehiculeId)
        {
            var assignment = new Agent_Vehicule
            {
                AgentId = agentId,
                Immatricule = vehiculeId
            };
            base.Create(assignment); 

        }
    }
}