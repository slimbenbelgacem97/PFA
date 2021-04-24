namespace backend.Repositries
{
    public interface IRepositoryWrapper
    {
        public IAgentRepository Agent { get; set; }
        public ICandidatRepository Candidate { get; set; }
        public ISeanceRepository Seance { get; set; }
        public IVehiculeRepository Vehicule { get; set; }
        void Save();
    }
}