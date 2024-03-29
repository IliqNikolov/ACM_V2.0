﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public interface IApartmentServise
    {
        List<ApartmentListElementDTO> GetAppartments();
        Task<string> Create(int number);
        List<ApartmentListDTO> GetAllApartments();


    }
}
