using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACM.Services
{
    public interface IEmailSender
    {
        bool Send(string to, string subject, string test);
    }
}
