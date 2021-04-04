using Microsoft.AspNetCore.Mvc;
using backend.Repositries;
namespace backend.Controllers
{
    [ApiController]
    public class SeanceController:ControllerBase
    {
        private IRepositoryWrapper context;
        public SeanceController(IRepositoryWrapper context)
        {
            this.context = context;
        }
        //Actions to do
    }
}