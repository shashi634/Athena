using System;
using System.Collections.Generic;

namespace Athena.Models
{
    public class ExamResult
    {
        public decimal Id { get; set; }
        public decimal ExamSetId { get; set; }
        public decimal? UserId { get; set; }
        public decimal MarksObtained { get; set; }
        public int? TotalMarks { get; set; }
        public int? CorrectAnswer { get; set; }
        public int? WrongAnswer { get; set; }
        public int? Ranking { get; set; }

        public virtual ExamSet ExamSet { get; set; }
        public virtual User User { get; set; }
    }
}
