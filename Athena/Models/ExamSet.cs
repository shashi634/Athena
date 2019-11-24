using System;
using System.Collections.Generic;

namespace Athena.Models
{
    public class ExamSet
    {
        public ExamSet()
        {
            ExamFee = new HashSet<ExamFee>();
            ExamResult = new HashSet<ExamResult>();
            UserAnswer = new HashSet<UserAnswer>();
            UserParticipation = new HashSet<UserParticipation>();
        }

        public decimal Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Questions { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public bool IsMinusMarking { get; set; }
        public int NegativemarksPerecntage { get; set; }
        public Guid PublicId { get; set; }
        public DateTime LastUpdateDateTime { get; set; }
        public decimal? OrganizationId { get; set; }

        public virtual Organization Organization { get; set; }
        public virtual ICollection<ExamFee> ExamFee { get; set; }
        public virtual ICollection<ExamResult> ExamResult { get; set; }
        public virtual ICollection<UserAnswer> UserAnswer { get; set; }
        public virtual ICollection<UserParticipation> UserParticipation { get; set; }
    }
}
