namespace Athena.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExamCoupan")]
    public class ExamCoupan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ExamCoupan()
        {
            UserParticipation = new HashSet<UserParticipation>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Id { get; set; }

        [Required]
        [StringLength(550)]
        public string Title { get; set; }

        [StringLength(1050)]
        public string Description { get; set; }

        public decimal ExamSetId { get; set; }

        public int FeeReductionPercentage { get; set; }

        public Guid PublicId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserParticipation> UserParticipation { get; set; }
    }
}
