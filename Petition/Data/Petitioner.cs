using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petition.Data
{
    public class Petitioner : IdentityUser
    {
        public string NRIC { get; set; }
        public string FullName { get; set; }
        public string ResidentialAddress { get; set; }
        public string ProfilePicture { get; set; }
        public string Region { get; set; }
    }
}
