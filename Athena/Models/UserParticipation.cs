using System;
using System.Collections.Generic;

namespace Athena.Models
{
    public class UserParticipation
    {
        public decimal Id { get; set; }
        public decimal ExamSetId { get; set; }
        public decimal UserId { get; set; }
        public DateTime SelectedDateTime { get; set; }
        public decimal CoupanCodeId { get; set; }
        public Guid PublicId { get; set; }

        public virtual ExamCoupan CoupanCode { get; set; }
        public virtual ExamSet ExamSet { get; set; }
        public virtual User User { get; set; }
    }
}
