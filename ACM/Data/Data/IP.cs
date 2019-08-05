namespace Data
{ using System;

    using Microsoft.EntityFrameworkCore;

    public class IP
    {
        public IP()
        {
            this.Id = Guid.NewGuid().ToString();
            this.FirstUsedOn = DateTime.Now;
        }

        public string Id { get; set; }

        public string IpString { get; set; }

        public DateTime FirstUsedOn { get; set; }

        public virtual ACMUser User { get; set; }
    }
}
