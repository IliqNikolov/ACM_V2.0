﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class CreateApartmentDTO
    {
        [Range(0, int.MaxValue)]
        [Required]
        public int Number { get; set; }
    }
}
