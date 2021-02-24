using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.DanhMuc.HangHoas;
using eShopSolution.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.ApiIntegration
{
    public interface IHangHoasApiClient
    {
        Task<PagedResult<HangHoaVm>> GetPagings(GetHangHoaPagingRequest request);

        Task<bool> CreateHangHoa(HangHoaCreateRequest request);

        Task<bool> UpdateHangHoa(HangHoaUpdateRequest request);

        Task<HangHoaVm> GetById(int id);

        Task<bool> DeleteHangHoa(int id);
    }
}