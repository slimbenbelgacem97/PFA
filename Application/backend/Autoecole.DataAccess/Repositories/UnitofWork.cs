using System.Threading;
using System.Threading.Tasks;
using backend.Autoecole.DataAccess.Data;
using backend.Autoecole.Domain.Abstract;
using backend.Autoecole.Domain.Services.IRepositories;
namespace backend.Autoecole.DataAccess.Repositories
{
    public class UnitofWork : IUnitofWork
    {
        private ModelContextV2 context;
        private IAgentRepository agentRepository;
        private ISeanceRepository seanceRepository;
        private ICandidatRepository candidatRepository;
        private IVehiculeRepository vehiculeRepository;
        private IAgents_VehiculesRepository agents_VehiculesRepository;

        public IAgentRepository Agent
        {
            get
            {
                if (agentRepository == null)
                {
                    agentRepository = new AgentRepository(context);
                }
                return agentRepository;
            }
            set { }
        }
        public ICandidatRepository Candidate
        {
            get
            {
                if (candidatRepository == null)
                {
                    candidatRepository = new CandidatRepository(context);
                }
                return candidatRepository;
            }
            set { }
        }
        public ISeanceRepository Seance
        {
            get
            {
                if (seanceRepository == null)
                {
                    seanceRepository = new SeanceRepository(context);
                }
                return seanceRepository;
            }
            set { }
        }
        public IVehiculeRepository Vehicule
        {
            get
            {
                if (vehiculeRepository == null)
                {
                    vehiculeRepository = new VehiculeRepository(context);
                }
                return vehiculeRepository;
            }
            set { }
        }

        public IAgents_VehiculesRepository Agents_Vehicules
        {
            get
            {
                if (agents_VehiculesRepository == null)
                {
                    agents_VehiculesRepository = new Agents_VehiculesRepository(context);
                }
                return agents_VehiculesRepository;
            }
            set { }
        }

        public UnitofWork(ModelContextV2 context)
        {
            this.context = context;
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);

        }


    }
}