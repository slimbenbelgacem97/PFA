using Microsoft.AspNetCore.Mvc;
using backend.Repositries;
namespace backend.Controllers
{
    public class CandidatController :ControllerBase
    {
        private readonly IRepositoryWrapper context;
        public CandidatController(IRepositoryWrapper context)
        {
            this.context = context;
        }
        //Actions TODO
    }
}