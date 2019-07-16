namespace ACM
{
    using Microsoft.EntityFrameworkCore;

    public class Apartment
    {
        public Apartment()
        {
        }

        public string Id { get; set; }

        public int Number { get; set; }

        public virtual ACMUser User { get; set; }
    }
}
