using eSaleSolution.ViewModels.Common;
using eSaleSolution.ViewModels.System.Languages;
using eSaleSolution.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eSaleSolution.Application.System.Languages
{
    public interface ILanguageService
    {
        Task<ApiResult<List<LanguageVm>>> GetAll();
    }
}