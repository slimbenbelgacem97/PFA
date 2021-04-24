using System;
using System.Collections.Generic;
using backend.Models;
namespace backend.Controllers.Resources
{
    public class SeanceResource
    {
        public DateTime DateSeance { get; set; }

        public SeanceType SeanceType { get; set; }

        
    }
}