using eSaleSolution.ViewModels.Catalog.ProductImages;
using eSaleSolution.ViewModels.Catalog.Products;
using eSaleSolution.ViewModels.Common;
using eSaleSolution.ViewModels.DanhMuc.LoaiTiens;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eSaleSolution.Application.DanhMuc.LoaiTiens
{
    public interface ILoaiTienService
    {
        Task<int> Create(LoaiTienCreateRequest request);

        Task<int> Update(LoaiTienUpdateRequest request);

        Task<int> Delete(int Id);

        Task<LoaiTienVm> GetById(int id);

        Task<PagedResult<LoaiTienVm>> GetAllPaging(GetLoaiTienPagingRequest request);

    }
}