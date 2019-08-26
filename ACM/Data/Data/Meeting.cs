namespace Data
{ 

    using System;
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;

    public class Meeting
    {
        public Meeting()
        {
            Id = Guid.NewGuid().ToString();
            Date = DateTime.Now;
            Votes = new List<Vote>();
        }

        public string Id { get; set; }

        public DateTime Date { get; set; }

        public string Text { get; set; }

        public virtual IEnumerable<Vote> Votes { get; set; }
    }
}
