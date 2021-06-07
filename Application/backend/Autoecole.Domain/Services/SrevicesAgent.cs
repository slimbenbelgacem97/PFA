using System;
using System.Collections.Generic;
using backend.Logging;
using backend.Autoecole.Domain.Models.Entities;
using backend.Autoecole.Domain.Services.IServices;
using backend.Autoecole.Domain.Abstract;
using backend.Autoecole.Domain.Exceptions;
namespace backend.Autoecole.Domain.Services
{
    public class SrevicesAgent : IServiceAgent
    {

        private readonly ILoggerManager loggerManager;
        private readonly IUnitofWork context;


        public SrevicesAgent(IUnitofWork context, ILoggerManager loggerManager)
        {

            this.context = context;
            this.loggerManager = loggerManager;

        }
        public IEnumerable<Agent> GetAgents()
        {

            var agents = context.Agent.FindAll();
            loggerManager.LogInfo($"Returned all Agents from database.");

            if (agents == null)
            {
                loggerManager.LogError($"Something went wrong while Geting All Agents");
                throw new Exception();
            }
            return agents;

        }
        public Agent GetAgent(int id)
        {
            var agent = context.Agent.GetAgentById(id);
            if (agent == null)
            {
                loggerManager.LogError($"Agent with id: {id}, hasn't been found in db.");
                throw new Exception(AgentExceptions.AgentNotExist);
            }
            else
            {
                loggerManager.LogInfo($"Get agent (ID: {agent.Id})");
                return agent;
            }
        }
        public Agent GetAgentDetaillsResource(int id)
        {
            var agent = context.Agent.GetDetailsAgentById(id);
            if (agent == null)
            {
                loggerManager.LogError($"Agent with id: {id}, hasn't been found in db.");
                throw new Exception(AgentExceptions.AgentNotExist);
            }
            else
            {

                loggerManager.LogInfo($"Get agent (ID: {agent.Id})");
                loggerManager.LogInfo($"Returned All seances of the agent [ID:{id}]");
                loggerManager.LogInfo($"Returned the vehicule of the agent [ID:{id}]");
                return (agent);
            }
        }
        public void AddAgent(Agent agent)

        {
            var AgentExist = context.Agent.GetAgentById(agent.Id);
            if (AgentExist != null)
            {
                throw new Exception(AgentExceptions.AgentExist);
            }
            else
            {
                context.Agent.Create(agent);
                loggerManager.LogInfo($"New Agent with ID: {agent.Id}, Name: {agent.Nom} has been added.");

            }

        }

        public void UpdateAgent(Agent agent)
        {

            var agentExist = context.Agent.GetAgentById(agent.Id);
            if (agentExist == null)
            {
                loggerManager.LogError($"Agent [ ID: {agent.Id}], hasn't been found in db.");
                throw new Exception(AgentExceptions.AgentNotExist);
            }
            else
            {
                context.Agent.Update(agent);
                context.Save();
                loggerManager.LogInfo($"Agent [ID:{agent.Id}] has been updated.");
            }
        }

        public void DeleteAgent(int id)
        {
            var agentToDeelete = context.Agent.GetAgentById(id);
            if(agentToDeelete == null)
            {
                loggerManager.LogError($"Agent [ ID: {id}], hasn't been found in db.");
                throw new Exception(AgentExceptions.AgentNotExist);
            }
            else
            {
                context.Agent.Delete(agentToDeelete);
                context.Save();
                loggerManager.LogInfo($"The agent [Id:{id} ] has been deleted.");
            }
        }

    }

}