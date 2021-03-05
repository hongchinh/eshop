using eSaleSolution.ViewModels.Catalog.ProductImages;
using eSaleSolution.ViewModels.Catalog.Products;
using eSaleSolution.ViewModels.Common;
using eSaleSolution.ViewModels.DanhMuc.DoDays;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eSaleSolution.Application.DanhMuc.DoDays
{
    public interface IDoDayService
    {
        Task<int> Create(DoDayCreateRequest request);

        Task<int> Update(DoDayUpdateRequest request);

        Task<int> Delete(int Id);

        Task<DoDayVm> GetById(int Id);

        Task<PagedResult<DoDayVm>> GetAllPaging(GetDoDayPagingRequest request);

    }
}