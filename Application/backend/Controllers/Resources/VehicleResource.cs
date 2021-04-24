using System;
using System.Collections.Generic;

namespace backend.Controllers.Resources
{
    public class VehicleResource
    {
        public string Immatricule { get; set; }

        public string Marque { get; set; }

        public DateTime DateCirculation { get; set; } //datetime
        //public IList<AgentResource> Agents { get; set; }
    }
}