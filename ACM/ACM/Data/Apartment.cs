namespace ACM
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    public class Apartment
    {
        public Apartment()
        {
        }

        public string Id { get; set; }
        [Required]
        [Index(IsUnique = true)]
        public int Number { get; set; }

        public virtual ACMUser User { get; set; }
    }
}
