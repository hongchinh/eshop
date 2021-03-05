using eSaleSolution.ViewModels.Catalog.ProductImages;
using eSaleSolution.ViewModels.Catalog.Products;
using eSaleSolution.ViewModels.Common;
using eSaleSolution.ViewModels.DanhMuc.LoaiTons;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eSaleSolution.Application.DanhMuc.LoaiTons
{
    public interface ILoaiTonService
    {
        Task<int> Create(LoaiTonCreateRequest request);

        Task<int> Update(LoaiTonUpdateRequest request);

        Task<int> Delete(int Id);

        Task<LoaiTonVm> GetById(int id);

        Task<PagedResult<LoaiTonVm>> GetAllPaging(GetLoaiTonPagingRequest request);

    }
}