﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class CreateMeetingDTO
    {
        [Required]
        [MaxLength(500)]
        public string Text { get; set; }

        public string Json { get; set; }
    }
}
