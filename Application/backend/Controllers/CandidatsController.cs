using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;

namespace backend.Controllers
{
    public class CandidatsController : Controller
    {
        private readonly Model context;
        public CandidatsController(Model context)
        {
            this.context = context;
        }
        [HttpGet("/api/Candidat")]
        public async  Task< IEnumerable<Candidat>> GetCandidats()
        {
            return await context.Candidats.Include(m => m.Seances).ToListAsync();
        }
    }
}