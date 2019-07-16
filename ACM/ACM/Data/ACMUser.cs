using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ACM
{
    public class ACMUser : IdentityUser
    {
        public ACMUser()
        {
            this.IPs = new List<IP>();
        }

        public string FullName { get; set; }

        public int AppartentNumber { get; set; }

        public virtual IEnumerable<IP> IPs { get; set; }
    }
}
