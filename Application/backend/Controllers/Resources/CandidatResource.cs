using System;
namespace backend.Controllers.Resources
{
    public class CandidatResource
    {
        public int CandidatCIN { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public DateTime Naissance { get; set; }

        public string Adresse { get; set; }

        public string Tel { get; set; }

    }
}