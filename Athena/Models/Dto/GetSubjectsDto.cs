using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Athena.Models.Dto
{
    /// <summary>
    /// Get Subjects Dto
    /// </summary>
    public class GetSubjectsDto
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
    }
}