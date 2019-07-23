using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACM.Models
{
    public class IdeaViewModel
    {

        public IdeaViewModel(Idea idea,string name,string userName)
        {
            Text = idea.Text;
            Name = name;
            UserName = userName;
            Date = idea.CreatedOn;
            Id = idea.Id;
        }
        public string Text { get; set; }

        public string Name { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }
        public string Id { get; set; }
    }
}
