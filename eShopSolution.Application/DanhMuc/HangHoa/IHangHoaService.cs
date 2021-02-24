using eShopSolution.ViewModels.Catalog.ProductImages;
using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.DanhMuc.HangHoa;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
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