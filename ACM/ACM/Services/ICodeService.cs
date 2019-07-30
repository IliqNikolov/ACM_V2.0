using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACM.Areas.Administration.Models;

namespace ACM.Services
{
    public interface ICodeService
    {
        bool IsCodeValid(string code);
        void RemoveCode(string code);
        CodeViewModel CreateARegistrationCode(string id);
        List<CodeViewModel> GetAllCodes();
        bool DeleteCode(string code);
    }
}
