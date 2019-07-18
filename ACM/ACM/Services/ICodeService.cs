using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACM.Services
{
    public interface ICodeService
    {
        bool IsCodeValid(string code);
        void RemoveCode(string code);
    }
}
