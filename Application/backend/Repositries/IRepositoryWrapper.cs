namespace backend.Repositries
{
    public interface IRepositoryWrapper
    {
        public IAgentRepository Agent { get; set; }
        public ICandidatRepository Candidat { get; set; }
        public ISeanceRepository Seance { get; set; }
        void Save();
    }
}