using System;

namespace Athena.Models.Dto
{
    public class GetUserDto
    {
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public AddOrganizationDto AssociatedOrganization { get; set; }
        public string ProfilePic { get; set; }
        public int Currentlevel { get; set; }
        public bool IsActive { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime? ActivationDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int? PinCode { get; set; }
    }
}