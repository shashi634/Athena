namespace Athena.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserAnswer")]
    public class UserAnswer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Id { get; set; }

        public decimal ExamSetId { get; set; }

        public decimal UserId { get; set; }

        public decimal QuestionId { get; set; }

        public decimal SelectedOptionId { get; set; }

        public DateTime LastUpdatedateTime { get; set; }

        public Guid PublicId { get; set; }

        public virtual ExamSet ExamSet { get; set; }

        public virtual OrgQuestion OrgQuestion { get; set; }

        public virtual QuestionOption QuestionOption { get; set; }

        public virtual User User { get; set; }
    }
}
