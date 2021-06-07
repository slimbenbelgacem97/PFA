using System;
namespace backend.Autoecole.Api.Resources
{
    public class CandidatResource
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public DateTime Naissance { get; set; }

        public string Adresse { get; set; }

        public string Tel { get; set; }

    }
}