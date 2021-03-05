using eSaleSolution.ViewModels.Catalog.ProductImages;
using eSaleSolution.ViewModels.Catalog.Products;
using eSaleSolution.ViewModels.Common;
using eSaleSolution.ViewModels.DanhMuc.KhoanChis;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eSaleSolution.Application.DanhMuc.KhoanChis
{
    public interface IKhoanChiService
    {
        Task<int> Create(KhoanChiCreateRequest request);

        Task<int> Update(KhoanChiUpdateRequest request);

        Task<int> Delete(int Id);

        Task<KhoanChiVm> GetById(int id);

        Task<PagedResult<KhoanChiVm>> GetAllPaging(GetKhoanChiPagingRequest request);

    }
}