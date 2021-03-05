using eSaleSolution.ViewModels.Catalog.ProductImages;
using eSaleSolution.ViewModels.Catalog.Products;
using eSaleSolution.ViewModels.Common;
using eSaleSolution.ViewModels.DanhMuc.DonViTrucThuocs;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eSaleSolution.Application.DanhMuc.DonViTrucThuocs
{
    public interface IDonViTrucThuocService
    {
        Task<int> Create(DonViTrucThuocCreateRequest request);

        Task<int> Update(DonViTrucThuocUpdateRequest request);

        Task<int> Delete(int Id);

        Task<DonViTrucThuocVm> GetById(int id);

        Task<PagedResult<DonViTrucThuocVm>> GetAllPaging(GetDonViTrucThuocPagingRequest request);

    }
}