using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Athena.Models.Dto
{
    public class GetOrganizationDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public int? PinCode { get; set; }

        public bool IsActive { get; set; }

        public DateTime JoiningDate { get; set; }

        public DateTime? ActivationDate { get; set; }

    }
}