using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ACM.Models
{
    public class CreateIdeaViewModel
    {
        [Required]
        [MaxLength(500)]
        public string Text { get; set; }
    }
}
