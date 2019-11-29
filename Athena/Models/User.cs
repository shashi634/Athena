namespace Athena.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            ExamResult = new HashSet<ExamResult>();
            UserAnswer = new HashSet<UserAnswer>();
            UserParticipation = new HashSet<UserParticipation>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Id { get; set; }

        public Guid PublicId { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [StringLength(250)]
        public string EmailId { get; set; }

        [StringLength(20)]
        public string MobileNo { get; set; }

        [Required]
        public string Password { get; set; }

        public decimal OrganizationId { get; set; }

        [StringLength(550)]
        public string ProfilePic { get; set; }

        public int Currentlevel { get; set; }

        public bool IsActive { get; set; }

        public DateTime JoiningDate { get; set; }

        public DateTime? ActivationDate { get; set; }

        [StringLength(550)]
        public string Address { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        public int? PinCode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExamResult> ExamResult { get; set; }

        public virtual Organization Organization { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserAnswer> UserAnswer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserParticipation> UserParticipation { get; set; }
    }
}
