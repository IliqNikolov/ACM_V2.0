using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACM
{
    public static class MagicStrings
    {
        public static string EmailSenderName { get; set; } = "acmtest666@gmail.com";

        public static string EmailSenderPassword { get; set; } = "ACMtest123";

        public const string AdminString  = "Admin";

        public static string DBConnectionString = @"Server=localhost;Database=ACM;Trusted_Connection=True;";

        public static List<string> AdminEmails { get; set; } = new List<string> { "admin@admin.admin".ToUpper(), "kingtoster@gmail.com".ToUpper(), "t123@t123.com".ToUpper() };

        public static string GmailString { get; set; } = "smtp.gmail.com";
    }
}
