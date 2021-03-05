using eSaleSolution.ViewModels.Catalog.ProductImages;
using eSaleSolution.ViewModels.Catalog.Products;
using eSaleSolution.ViewModels.Common;
using eSaleSolution.ViewModels.DanhMuc.KhoanThus;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eSaleSolution.Application.DanhMuc.KhoanThus
{
    public interface IKhoanThuService
    {
        Task<int> Create(KhoanThuCreateRequest request);

        Task<int> Update(KhoanThuUpdateRequest request);

        Task<int> Delete(int Id);

        Task<KhoanThuVm> GetById(int id);

        Task<PagedResult<KhoanThuVm>> GetAllPaging(GetKhoanThuPagingRequest request);

    }
}