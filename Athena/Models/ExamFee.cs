namespace Athena.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExamFee")]
    public class ExamFee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Id { get; set; }

        public decimal ExamSetId { get; set; }

        public int JoiningFee { get; set; }

        public Guid PublicId { get; set; }

        public virtual ExamSet ExamSet { get; set; }
    }
}
