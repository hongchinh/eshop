using eSaleSolution.ViewModels.Catalog.ProductImages;
using eSaleSolution.ViewModels.Catalog.Products;
using eSaleSolution.ViewModels.Common;
using eSaleSolution.ViewModels.DanhMuc.TenDonVis;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eSaleSolution.Application.DanhMuc.TenDonVis
{
    public interface ITenDonViService
    {
        Task<int> Create(TenDonViCreateRequest request);

        Task<int> Update(TenDonViUpdateRequest request);

        Task<int> Delete(int Id);

        Task<TenDonViVm> GetById(int id);

        Task<PagedResult<TenDonViVm>> GetAllPaging(GetTenDonViPagingRequest request);

    }
}