using System;
using System.Collections.Generic;
using backend.Autoecole.Api.Resources;
using backend.Autoecole.Domain.Abstract;
using backend.Autoecole.Domain.Exceptions;
using backend.Autoecole.Domain.Models.Entities;
using backend.Autoecole.Domain.Services.IServices;
using backend.Logging;

namespace backend.Autoecole.Domain.Services
{
    public class ServiceCandidat : IServiceCandidat
    {
        private readonly IUnitofWork context;
        private readonly ILoggerManager loggerManager;
        private readonly IServiceSeance serviceSeance;
        public ServiceCandidat(IUnitofWork context, ILoggerManager loggerManager, IServiceSeance serviceSeance)
        {
            this.serviceSeance = serviceSeance;
            this.loggerManager = loggerManager;
            this.context = context;
        }

        public Candidate GetCandidat(int id)
        {
            var candidat = context.Candidate.GetCandidatById(id);
            if (candidat == null)
            {
                loggerManager.LogError($"Candidate with id: {id}, hasn't been found in db.");
                throw new Exception(CandidateExceptions.CandidateNotExist);
            }
            return candidat;
        }

        public IEnumerable<Candidate> GetCandidats()
        {
            loggerManager.LogInfo($"Returned all Candidates from database.");
            var candidats = context.Candidate.GetAllCandidats();
            return candidats;
        }

        public void AddCandidate(Candidate candidat)
        {
            var cand = context.Candidate.GetCandidatById(candidat.Id);
            if (cand != null)
            {
                throw new Exception(CandidateExceptions.CandidateExist);
            }
            else
            {
                context.Candidate.Create(candidat);
                context.Save();
                loggerManager.LogInfo($"A new candidate [Id:{candidat.Id}] has been added.");
            }
        }

        public void UpdateCandicate(Candidate newCandidate) // Task instead of void
        {
            var oldCandidate = context.Candidate.GetCandidatById(newCandidate.Id);
            if (oldCandidate == null)
            {
                throw new Exception(CandidateExceptions.CandidateNotExist);
            }
            else
            {
                context.Candidate.Update(newCandidate);
                context.Save();
                loggerManager.LogInfo($"The candidate [Id: {newCandidate.Id}] has been updated.");
            }
        }

        public void DeleteCandidate(int id)
        {
            var cand = context.Candidate.GetCandidatById(id);
            if(cand==null)
            {
                throw new Exception(CandidateExceptions.CandidateNotExist);
            }
            else
            {
                context.Candidate.Delete(cand);
                context.Save();
                loggerManager.LogInfo($"The Candidate[Id: {id} has been deleted.]");
            }
        }
    }
}