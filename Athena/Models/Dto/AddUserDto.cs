using System;

namespace Athena.Models.Dto
{
    public class AddUserDto
    {
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int? PinCode { get; set; }
    }
}