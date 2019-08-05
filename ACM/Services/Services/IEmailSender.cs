using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public interface IEmailSender
    {
        bool Send(string to, string subject, string test);
    }
}
