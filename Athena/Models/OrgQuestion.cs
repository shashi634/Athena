using System;
using System.Collections.Generic;

namespace Athena.Models
{
    public class OrgQuestion
    {
        public OrgQuestion()
        {
            UserAnswer = new HashSet<UserAnswer>();
        }

        public decimal Id { get; set; }
        public string Question { get; set; }
        public Guid PublicId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDateTime { get; set; }
        public decimal OrganizationId { get; set; }
        public int SubjectId { get; set; }

        public virtual Organization Organization { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual ICollection<UserAnswer> UserAnswer { get; set; }
    }
}
