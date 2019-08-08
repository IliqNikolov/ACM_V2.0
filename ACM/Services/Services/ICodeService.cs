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
        Task<CodeDTO> CreateARegistrationCode(string id);
        List<CodeDTO> GetAllCodes();
        Task<bool> DeleteCode(string code);
    }
}
