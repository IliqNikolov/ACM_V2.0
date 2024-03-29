﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Data
{
    public class ACMUser : IdentityUser
    {
        public ACMUser()
        {
            IPs = new List<IP>();
            ExpectedCode = null;
        }

        public string FullName { get; set; }

        public int AppartentNumber { get; set; }

        public string ExpectedCode { get; set; }

        public virtual IEnumerable<IP> IPs { get; set; }
    }
}
