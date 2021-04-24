using AutoMapper;
using backend.Models;
using backend.Controllers.Resources;
namespace backend.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Vehicule, VehicleResource>();
            CreateMap<Agent, AgentResource>();
            CreateMap<Candidate, CandidatResource>();
            CreateMap<Seance, SeanceResource>();
            CreateMap<Agent_Vehicule, Agent_VehiculeResource>();


        }
    }
}