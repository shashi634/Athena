using System;
using System.Collections.Generic;

namespace Athena.Models
{
    public class UserLevel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal OrganizationId { get; set; }
        public string PublicId { get; set; }

        public virtual Organization Organization { get; set; }
    }
}
