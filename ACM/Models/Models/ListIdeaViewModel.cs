using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class ListIdeaViewModel
    {
        public ListIdeaViewModel()
        {
            Ideas = new List<IdeaViewModel>();
        }
        public List<IdeaViewModel> Ideas { get; set; }
    }
}
