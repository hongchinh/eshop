using eSaleSolution.ViewModels.Catalog.ProductImages;
using eSaleSolution.ViewModels.Catalog.Products;
using eSaleSolution.ViewModels.Common;
using eSaleSolution.ViewModels.DanhMuc.LyDoNhapXuats;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eSaleSolution.Application.DanhMuc.LyDoNhapXuats
{
    public interface ILyDoNhapXuatService
    {
        Task<int> Create(LyDoNhapXuatCreateRequest request);

        Task<int> Update(LyDoNhapXuatUpdateRequest request);

        Task<int> Delete(int Id);

        Task<LyDoNhapXuatVm> GetById(int id);

        Task<PagedResult<LyDoNhapXuatVm>> GetAllPaging(GetLyDoNhapXuatPagingRequest request);

    }
}