using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACM.Areas.Administration.Models
{
    public class ApartmentListViewModel
    {
        public string Id { get; set; }
        public int Number { get; set; }
        public int RegisteredUsersCount { get; set; }
    }
}
