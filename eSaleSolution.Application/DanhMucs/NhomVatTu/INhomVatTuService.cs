using eSaleSolution.ViewModels.Catalog.ProductImages;
using eSaleSolution.ViewModels.Catalog.Products;
using eSaleSolution.ViewModels.Common;
using eSaleSolution.ViewModels.DanhMuc.NhomVatTus;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eSaleSolution.Application.DanhMuc.NhomVatTus
{
    public interface INhomVatTuService
    {
        Task<int> Create(NhomVatTuCreateRequest request);

        Task<int> Update(NhomVatTuUpdateRequest request);

        Task<int> Delete(int Id);

        Task<NhomVatTuVm> GetById(int id);

        Task<PagedResult<NhomVatTuVm>> GetAllPaging(GetNhomVatTuPagingRequest request);

    }
}