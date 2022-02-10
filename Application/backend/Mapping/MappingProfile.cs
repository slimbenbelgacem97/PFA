



using AutoMapper;
using backend.Autoecole.Api.Resources;
using backend.Autoecole.Api.Resources.Agent;
using backend.Autoecole.Api.Resources.Seance;
using backend.Autoecole.DataAccess.Data;
using backend.Autoecole.Domain.Models.Entities;

namespace backend.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           
            CreateMap<Agent, AgentResource>();
            CreateMap<AgentResource, Agent>();
            CreateMap<AgentRegister, Agent>();
            CreateMap<AgentLogin, ApplicationUser>();
            CreateMap<AgentRegister, ApplicationUser>()
            .ForMember(u => u.PhoneNumber, opt => opt.MapFrom(x => x.PhoneNumber));

            CreateMap<Candidate, CandidatResource>();
            CreateMap<CandidatResource, Candidate>();

            CreateMap<Seance, SeanceResource>();
            CreateMap<Seance, SeanceCandidateResource>();
            CreateMap<Seance, SeanceAgentResource>();

            CreateMap<Agent_Vehicule, Agent_VehiculeResource>();

            CreateMap<Vehicule, VehicleResource>();
            CreateMap<VehicleResource, Vehicule>();


        }
    }
}
