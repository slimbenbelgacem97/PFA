using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Exam
    {
        [Key]
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