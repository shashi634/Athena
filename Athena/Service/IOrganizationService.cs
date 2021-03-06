﻿using Athena.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athena.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface IOrganizationService
    {
        /// <summary>
        /// Get Organization Details
        /// </summary>
        /// <param name="orgId"></param>
        /// <returns></returns>
        Task<GetOrganizationDto> GetOrganizationDetails(string orgId);

        /// <summary>
        /// Add Update Organization
        /// </summary>
        /// <param name="organizationDto"></param>
        /// <returns></returns>
        Task<ReturnOrganizationDto> AddUpdateOrganization(OrganizationDto organizationDto);
    }
}
