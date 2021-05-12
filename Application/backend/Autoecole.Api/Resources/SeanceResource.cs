using System;
using backend.Autoecole.Domain.Models.Types;

namespace backend.Autoecole.Api.Resources
{
    public class SeanceResource
    {
        public DateTime DateSeance { get; set; }

        public SeanceType SeanceType { get; set; }

        
    }
}