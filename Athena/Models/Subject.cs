using System;
using System.Collections.Generic;

namespace Athena.Models
{
    public class Subject
    {
        public Subject()
        {
            OrgQuestion = new HashSet<OrgQuestion>();
        }

        public int Id { get; set; }
        public Guid PublicId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<OrgQuestion> OrgQuestion { get; set; }
    }
}
