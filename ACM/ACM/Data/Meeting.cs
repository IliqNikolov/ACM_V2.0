namespace ACM { 

    using System;
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;

    public class Meeting
    {
        public Meeting()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Date = DateTime.Now;
            this.Votes = new List<Vote>();
        }

        public string Id { get; set; }

        public DateTime Date { get; set; }

        public string Text { get; set; }

        public virtual IEnumerable<Vote> Votes { get; set; }
    }
}
