using System;
using System.Collections.Generic;
using backend.Logging;
using backend.Autoecole.Domain.Models.Entities;
using backend.Autoecole.Domain.Exreptions;
using backend.Autoecole.Domain.Services.IServices;
using backend.Autoecole.Domain.Abstract;
using backend.Autoecole.Domain.Models.Types;
using Microsoft.AspNetCore.Identity;
using backend.Autoecole.DataAccess.Data;
using System.Threading.Tasks;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using backend.Autoecole.Api.Resources.Agent;

namespace backend.Autoecole.Domain.Services
{
    public class SrevicesAgent : IServiceAgent
    {
        private readonly ILoggerManager loggerManager;
        private readonly IUnitofWork context;

        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        public SrevicesAgent(IUnitofWork context, ILoggerManager loggerManager, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
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
            var AgentExist = context.Agent.GetAgentById (agent.Id);
            if (AgentExist != null)
            {
                throw new Exception(AgentExceptions.AgentExist);
            }
            else
            {
                context.Agent.Create(agent);
               // context.Save();
                loggerManager.LogInfo($"New Agent with ID: {agent.Id}, Name: {agent.Nom} has been added.");

            }

        }

        public async void AdminRegistry(ApplicationUser agent, string pwd)
        {
            var user = await userManager.FindByIdAsync(agent.UserName);
            if (user != null){
                if (user.Fonction == AgentFunction.Directeur) 
                {
                    throw new Exception(AgentExceptions.AdminExist);
                }
            }
            else
            {
                ///dans le cas où le  directeur a le role de gestion seulement
                var result = userManager.CreateAsync(agent, pwd);
                ///Sinon 

                context.Save();
                loggerManager.LogInfo($"The Admin [ID: {agent.Id}, Name: {agent.Nom}]has been added.");
            }
        }

        public async Task<string> Login(AgentLogin agent)
        {
            var user = await userManager.FindByIdAsync(agent.UserName);
            if (user != null &&
                 await userManager.CheckPasswordAsync(user, agent.Password))
            {
                var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, "some_id"),
              //  new Claim("granny", "cookie")
            };

            var secretBytes = Encoding.UTF8.GetBytes(Constants.Secret);
            var key = new SymmetricSecurityKey(secretBytes);
            var algorithm = SecurityAlgorithms.HmacSha256;

            var signingCredentials = new SigningCredentials(key, algorithm);

            var token = new JwtSecurityToken(
                Constants.Issuer,
                Constants.Audiance,
                claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddHours(1),
                signingCredentials);

            var tokenJson = new JwtSecurityTokenHandler().WriteToken(token);
                return tokenJson;
            }else
            {
                throw new Exception();
            }
        }
         public async void LogOut()
        {
            await signInManager.SignOutAsync();
        }
        
        public Task<ApplicationUser> GetAgentByUsername(string username)
        {
            return userManager.FindByIdAsync(username);
        }
    }

       
    public static class Constants
    {
        public const string Issuer = Audiance;
        public const string Audiance = "https://localhost:5001/";
        public const string Secret = "not_too_short_secret_otherwise_it_might_error";
    }
}