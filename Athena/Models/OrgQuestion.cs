namespace Athena.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrgQuestion")]
    public class OrgQuestion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrgQuestion()
        {
            UserAnswer = new HashSet<UserAnswer>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Id { get; set; }

        [Required]
        public string Question { get; set; }

        public Guid PublicId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdatedDateTime { get; set; }

        public decimal OrganizationId { get; set; }

        public int SubjectId { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual Subject Subject { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserAnswer> UserAnswer { get; set; }
    }
}
