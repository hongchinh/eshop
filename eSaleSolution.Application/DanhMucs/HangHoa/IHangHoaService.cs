using eShopSolution.ViewModels.Catalog.ProductImages;
using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.DanhMuc.HangHoas;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopSolution.Application.DanhMuc.HangHoas
{
    public interface IHangHoaService
    {
        Task<int> Create(HangHoaCreateRequest request);

        Task<int> Update(HangHoaUpdateRequest request);

        Task<int> Delete(int hangHoaId);

        Task<HangHoaVm> GetById(int hangHoaId);

        Task<PagedResult<HangHoaVm>> GetAllPaging(GetHangHoaPagingRequest request);

    }
}