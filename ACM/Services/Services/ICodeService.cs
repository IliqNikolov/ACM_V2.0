using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public interface ICodeService
    {
        bool IsCodeValid(string code);
        CodeDTO CreateARegistrationCode(string id);
        List<CodeDTO> GetAllCodes();
        bool DeleteCode(string code);
    }
}
