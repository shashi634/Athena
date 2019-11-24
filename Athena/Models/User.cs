using System;
using System.Collections.Generic;

namespace Athena.Models
{
    public class User
    {
        public User()
        {
            ExamResult = new HashSet<ExamResult>();
            UserAnswer = new HashSet<UserAnswer>();
            UserParticipation = new HashSet<UserParticipation>();
        }

        public decimal Id { get; set; }
        public Guid PublicId { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public string Password { get; set; }
        public decimal OrganizationId { get; set; }
        public string ProfilePic { get; set; }
        public int Currentlevel { get; set; }
        public bool IsActive { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime? ActivationDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int? PinCode { get; set; }

        public virtual Organization Organization { get; set; }
        public virtual ICollection<ExamResult> ExamResult { get; set; }
        public virtual ICollection<UserAnswer> UserAnswer { get; set; }
        public virtual ICollection<UserParticipation> UserParticipation { get; set; }
    }
}
