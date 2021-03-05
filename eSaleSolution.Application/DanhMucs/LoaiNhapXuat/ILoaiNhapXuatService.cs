using eSaleSolution.ViewModels.Catalog.ProductImages;
using eSaleSolution.ViewModels.Catalog.Products;
using eSaleSolution.ViewModels.Common;
using eSaleSolution.ViewModels.DanhMuc.LoaiNhapXuats;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eSaleSolution.Application.DanhMuc.LoaiNhapXuats
{
    public interface ILoaiNhapXuatService
    {
        Task<int> Create(LoaiNhapXuatCreateRequest request);

        Task<int> Update(LoaiNhapXuatUpdateRequest request);

        Task<int> Delete(int Id);

        Task<LoaiNhapXuatVm> GetById(int id);

        Task<PagedResult<LoaiNhapXuatVm>> GetAllPaging(GetLoaiNhapXuatPagingRequest request);

    }
}