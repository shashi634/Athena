namespace Athena.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserLevel")]
    public class UserLevel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(550)]
        public string Description { get; set; }

        public decimal OrganizationId { get; set; }

        [Required]
        [StringLength(50)]
        public string PublicId { get; set; }

        public virtual Organization Organization { get; set; }
    }
}
