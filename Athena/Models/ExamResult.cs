namespace Athena.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExamResult")]
    public class ExamResult
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
