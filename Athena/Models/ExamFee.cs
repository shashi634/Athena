using System;
using System.Collections.Generic;

namespace Athena.Models
{
    public class ExamFee
    {
        public decimal Id { get; set; }
        public decimal ExamSetId { get; set; }
        public int JoiningFee { get; set; }
        public Guid PublicId { get; set; }

        public virtual ExamSet ExamSet { get; set; }
    }
}
