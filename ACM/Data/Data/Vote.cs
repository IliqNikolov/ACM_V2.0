namespace Data
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.EntityFrameworkCore;

    public class Vote
    {
        public Vote()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public virtual Meeting Meeting { get; set; }

        public string Text { get; set; }

        [Range(0, int.MaxValue)]
        public int Yes { get; set; }

        [Range(0, int.MaxValue)]
        public int No { get; set; }
    }
}
