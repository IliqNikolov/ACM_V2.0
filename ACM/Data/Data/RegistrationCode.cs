namespace Data
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.EntityFrameworkCore;

    public class RegistrationCode
    {
        public RegistrationCode()
        {
        }

        [Key]
        public string Code { get; set; }

        public virtual Apartment Apartment { get; set; }
    }
}
