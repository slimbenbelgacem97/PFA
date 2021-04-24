using backend.Data;
namespace backend.Repositries
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ModelContextV2 context;
        private IAgentRepository agentRepository;
        private ICandidatRepository candidatRepository;
        private ISeanceRepository seanceRepository;
        private IVehiculeRepository vehiculeRepository;
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

        

        public RepositoryWrapper(ModelContextV2 context)
        {
            this.context = context;
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}