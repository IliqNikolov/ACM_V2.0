﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ACM.Areas.Administration.Models
{
    public class CreateApartmentViewModel
    {
        [Range(0, int.MaxValue)]
        [Required]
        public int Number { get; set; }
    }
}
