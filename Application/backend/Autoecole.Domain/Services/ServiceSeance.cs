using System.Collections.Generic;
using AutoMapper;
using backend.Autoecole.Domain.Abstract;
using backend.Autoecole.Domain.Models.Entities;
using backend.Autoecole.Domain.Models.Types;
using backend.Autoecole.Domain.Services.IServices;
using backend.Logging;

namespace backend.Autoecole.Domain.Services
{
    public class ServiceSeance : IServiceSeance
    {
        private readonly IUnitofWork context;

        private readonly ILoggerManager loggerManager;
        public ServiceSeance(IUnitofWork context, ILoggerManager loggerManager)
        {
            this.loggerManager = loggerManager;

            this.context = context;
        }
        #region GET
        public IEnumerable<Seance> GetSeances()
        {
            return context.Seance.GetSeances();
        }

        public IEnumerable<Seance> GetSeancesByCandidateId(int id)
        {
            return context.Seance.GetSeancesByCandidateId(id);
        }

        public IEnumerable<Seance> GetSenacesByAgentId(int agentId)
        {
            return context.Seance.GetSeancesByAgentId(agentId);
        }
        
        public IEnumerable<Seance> GetSeancesByType(SeanceType type)
        {
            return context.Seance.GetSeancesByType(type);
        }
        #endregion

        
            
        public void AddSeance(Seance seance)
        {
            //TODO : test existance Agent / candidate 
            //      date's seance not in the past
            context.Seance.Create(seance);
            context.Save();
        }

        public void UpdateSeance(Seance seance)
        {
            //TODO : test existance Agent / candidate 
            //      date's seance not in the past
            context.Seance.Update(seance);
            context.Save();
        }

        public void DeleteSeance(Seance seance)
        {
            //TODO : test existance Agent / candidate 
            //      date's seance not in the past
            context.Seance.Delete(seance);
            context.Save();
        }

    }
}