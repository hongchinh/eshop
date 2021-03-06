using eSaleSolution.ViewModels.Catalog.Products;
using eSaleSolution.ViewModels.Common;
using eSaleSolution.ViewModels.DanhMuc.HangHoas;
using eSaleSolution.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eSaleSolution.ApiIntegration
{
    public interface IHangHoasApiClient
    {
        Task<PagedResult<HangHoaVm>> GetPagings(GetHangHoaPagingRequest request);

        Task<bool> Create(HangHoaCreateRequest request);

        Task<bool> Update(HangHoaUpdateRequest request);

        Task<HangHoaVm> GetById(int id);

        Task<bool> Delete(int id);
    }
}