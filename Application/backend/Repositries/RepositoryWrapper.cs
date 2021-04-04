using backend.Data;
namespace backend.Repositries
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private Model context;
        private IAgentRepository agentRepository;
        private ICandidatRepository candidatRepository;
        private ISeanceRepository seanceRepository;
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
        public ICandidatRepository Candidat
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
        public RepositoryWrapper(Model context)
        {
            this.context = context;
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}