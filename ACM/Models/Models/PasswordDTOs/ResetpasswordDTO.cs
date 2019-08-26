using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace Models
{
    public class ResetpasswordDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public bool IsValid { get; set; }
    }
}