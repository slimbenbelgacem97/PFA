using AutoMapper;
using backend.Models;
using backend.Controllers.Resources;
namespace backend.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Agent, AgentResource>();
            CreateMap<Candidat, CandidatResource>();
            CreateMap<Seances, SeanceResource>();

        }
    }
}