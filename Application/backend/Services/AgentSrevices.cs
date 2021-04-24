using System;
using System.Collections.Generic;
using AutoMapper;
using backend.Controllers.Resources;
using backend.Logging;
using backend.Models;
using backend.Repositries;

namespace backend.Services
{
    public class AgentSrevices :IServiceAgent
    {
        private readonly ILoggerManager loggerManager;
        private readonly IRepositoryWrapper context;
        private readonly IMapper mapper;
        public AgentSrevices(IRepositoryWrapper context, IMapper mapper, ILoggerManager loggerManager)
        {
            this.mapper = mapper;
            this.context = context;
            this.loggerManager = loggerManager;

        }
        public IEnumerable<Agent> GetAgents()
        {
            
                var agents = context.Agent.FindAll();
                loggerManager.LogInfo($"Returned all Agents from database.");
                
                return agents;
            
            
        }
    }
}