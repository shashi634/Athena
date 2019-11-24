using System;
using System.Collections.Generic;

namespace Athena.Models
{
    public class UserAnswer
    {
        public decimal Id { get; set; }
        public decimal ExamSetId { get; set; }
        public decimal UserId { get; set; }
        public decimal QuestionId { get; set; }
        public decimal SelectedOptionId { get; set; }
        public DateTime LastUpdatedateTime { get; set; }
        public Guid PublicId { get; set; }

        public virtual ExamSet ExamSet { get; set; }
        public virtual OrgQuestion Question { get; set; }
        public virtual QuestionOption SelectedOption { get; set; }
        public virtual User User { get; set; }
    }
}
