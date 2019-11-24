using System;
using System.Collections.Generic;

namespace Athena.Models
{
    public class ExamCoupan
    {
        public ExamCoupan()
        {
            UserParticipation = new HashSet<UserParticipation>();
        }

        public decimal Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal ExamSetId { get; set; }
        public int FeeReductionPercentage { get; set; }
        public Guid PublicId { get; set; }

        public virtual ICollection<UserParticipation> UserParticipation { get; set; }
    }
}
