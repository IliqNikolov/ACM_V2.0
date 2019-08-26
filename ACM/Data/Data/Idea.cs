namespace Data
{ using System;

    using Microsoft.EntityFrameworkCore;

    public class Idea
    {
        public Idea()
        {
            Id = Guid.NewGuid().ToString();
            CreatedOn = DateTime.Now;
        }
        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual ACMUser User { get; set; }

        public string Text { get; set; }
    }
}
