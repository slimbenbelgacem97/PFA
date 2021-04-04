using backend.Models;
using backend.Data;
namespace backend.Repositries
{
    public class SeanceRepository : RepositryBase<Seances> , ISeanceRepository
    {
        public SeanceRepository(Model context)
        :base(context)
        {
            
        }
    }
}