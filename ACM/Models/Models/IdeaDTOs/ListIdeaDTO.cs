using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class ListIdeaDTO
    {
        public ListIdeaDTO()
        {
            Ideas = new List<IdeaDTO>();
        }

        public List<IdeaDTO> Ideas { get; set; }
    }
}
