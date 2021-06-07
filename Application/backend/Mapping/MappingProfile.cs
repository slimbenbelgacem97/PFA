//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 4/21/2021 2:40:00 AM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------



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