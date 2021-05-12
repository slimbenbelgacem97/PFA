using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Autoecole.Domain.Abstract;
using backend.Autoecole.Domain.Models.Types;

namespace backend.Autoecole.Domain.Models.Entities
{
    public class Exam :IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        public string Convocation { get; set; }
        [Required]

        public string List { get; set; }
        [Required]

        public DateTime DateExam { get; set; }
        [Required]

        public ExamType Type { get; set; }

        [ForeignKey(nameof(Candidate))]
        public int CandidatCIN { get; set; }
        public Candidate Candidat { get; set; } 
        public ICollection<Candidate> Candidates { get; set; }
    }
}