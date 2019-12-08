namespace Athena.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("OrgQuestion")]
    public class OrgQuestion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrgQuestion()
        {
            QuestionOptions = new HashSet<QuestionOption>();
            UserAnswers = new HashSet<UserAnswer>();
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuestionOption> QuestionOptions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserAnswer> UserAnswers { get; set; }
    }
}
