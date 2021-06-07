using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using backend.Autoecole.Api.Configurations;
using backend.Autoecole.Api.Resources.Agent;
using backend.Autoecole.DataAccess.Data;
using backend.Autoecole.Domain.Abstract;
using backend.Autoecole.Domain.Exceptions;
using backend.Autoecole.Domain.Models.Types;
using backend.Autoecole.Domain.Services.IServices;
using backend.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace backend.Autoecole.Domain.Services
{
    public class ServiceAuthentification : IServiceAuthentification
    {
        private readonly ILoggerManager loggerManager;
        private readonly IUnitofWork context;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        public ServiceAuthentification(IUnitofWork context, ILoggerManager loggerManager, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
            this.loggerManager = loggerManager;

        }

        public async void Registry(ApplicationUser agent, string pwd, string vehiculeId)
        {
            var user = await userManager.FindByIdAsync(agent.UserName);
            if (user != null)
            {
                if (user.Fonction == AgentFunction.Directeur)
                {
                    throw new Exception(AgentExceptions.AdminExist);
                }
                throw new Exception(AuthentificationExceptions.UserExist);
            }
            else
            {
                ///dans le cas où le  directeur a le role de gestion seulement
                var result = userManager.CreateAsync(agent, pwd);
                ///Sinon 
                if (agent.Fonction.Equals(Domain.Models.Types.AgentFunction.AgentConduite))
                {
                    context.Agents_Vehicules.AssignVehicleToAgent(Int32.Parse(agent.Id), vehiculeId);
                }
                context.Save();
                loggerManager.LogInfo($"A new Agent [ID:{agent.Id} | Fonction: {agent.Fonction}] has been added.");

            }
        }

        public async Task<string> Login(AgentLogin agent)
        {
            var user = await userManager.FindByIdAsync(agent.UserName);
            if (user != null &&
                 await userManager.CheckPasswordAsync(user, agent.Password))
            {

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Nom)
                };

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.Secret));
                var token = new JwtSecurityToken(
                    issuer: "https://localhost:5001",
                    audience: "https://localhost:5001",
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );
                var access_token = new JwtSecurityTokenHandler().WriteToken(token);
                loggerManager.LogInfo($"The agent[Id:{user.Id}] logged in the system");
                return access_token;
            }
            else
            {
                throw new Exception(AuthentificationExceptions.InvalidUsername_Password);
            }
        }
        public async void LogOut()
        {
           
            await signInManager.SignOutAsync();
           // logging 
        }
        public Task<ApplicationUser> GetAgentByUsername(string username)
        {
            return userManager.FindByIdAsync(username);
        }

    }
}