using eSaleSolution.ViewModels.Catalog.ProductImages;
using eSaleSolution.ViewModels.Catalog.Products;
using eSaleSolution.ViewModels.Common;
using eSaleSolution.ViewModels.DanhMuc.HangHoas;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eSaleSolution.Application.DanhMuc.HangHoas
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