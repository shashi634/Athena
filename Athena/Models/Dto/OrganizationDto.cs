﻿using System;

namespace Athena.Models.Dto
{
    /// <summary>
    /// OrganizationDto
    /// </summary>
    public class OrganizationDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public int? PinCode { get; set; }

        public Guid? PublicId { get; set; }
    }
}