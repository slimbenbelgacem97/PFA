using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class LoginAgent
    {

        [Key]
        [ForeignKey(nameof(Agent))]
        public int AgentId { get; set; }
        public string Password { get; set; }
    }
}