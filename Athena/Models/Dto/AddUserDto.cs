using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Athena.Models.Dto
{
    public class AddUserDto
    {
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public Guid OrganizationId { get; set; }
        public string ProfilePic { get; set; }
        public int Currentlevel { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int? PinCode { get; set; }
    }
}