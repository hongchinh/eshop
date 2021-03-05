using eSaleSolution.ViewModels.Catalog.ProductImages;
using eSaleSolution.ViewModels.Catalog.Products;
using eSaleSolution.ViewModels.Common;
using eSaleSolution.ViewModels.DanhMuc.HinhThucTTs;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eSaleSolution.Application.DanhMuc.HinhThucTTs
{
    public interface IHinhThucTTService
    {
        Task<int> Create(HinhThucTTCreateRequest request);

        Task<int> Update(HinhThucTTUpdateRequest request);

        Task<int> Delete(int Id);

        Task<HinhThucTTVm> GetById(int id);

        Task<PagedResult<HinhThucTTVm>> GetAllPaging(GetHinhThucTTPagingRequest request);

    }
}