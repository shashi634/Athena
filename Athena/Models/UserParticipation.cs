namespace Athena.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserParticipation")]
    public class UserParticipation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Id { get; set; }

        public decimal ExamSetId { get; set; }

        public decimal UserId { get; set; }

        public DateTime SelectedDateTime { get; set; }

        public decimal CoupanCodeId { get; set; }

        public Guid PublicId { get; set; }

        public virtual ExamCoupan ExamCoupan { get; set; }

        public virtual ExamSet ExamSet { get; set; }

        public virtual User User { get; set; }
    }
}
