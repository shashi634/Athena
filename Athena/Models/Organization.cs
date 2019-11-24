using System;
using System.Collections.Generic;

namespace Athena.Models
{
    public class Organization
    {
        public Organization()
        {
            ExamSet = new HashSet<ExamSet>();
            OrgQuestion = new HashSet<OrgQuestion>();
            QuestionOption = new HashSet<QuestionOption>();
            User = new HashSet<User>();
            UserLevel = new HashSet<UserLevel>();
        }

        public decimal Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int? PinCode { get; set; }
        public bool IsActive { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime? ActivationDate { get; set; }
        public Guid? PublicId { get; set; }

        public virtual ICollection<ExamSet> ExamSet { get; set; }
        public virtual ICollection<OrgQuestion> OrgQuestion { get; set; }
        public virtual ICollection<QuestionOption> QuestionOption { get; set; }
        public virtual ICollection<User> User { get; set; }
        public virtual ICollection<UserLevel> UserLevel { get; set; }
    }
}
