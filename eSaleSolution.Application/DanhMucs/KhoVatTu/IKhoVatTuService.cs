using eSaleSolution.ViewModels.Catalog.ProductImages;
using eSaleSolution.ViewModels.Catalog.Products;
using eSaleSolution.ViewModels.Common;
using eSaleSolution.ViewModels.DanhMuc.KhoVatTus;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eSaleSolution.Application.DanhMuc.KhoVatTus
{
    public interface IKhoVatTuService
    {
        Task<int> Create(KhoVatTuCreateRequest request);

        Task<int> Update(KhoVatTuUpdateRequest request);

        Task<int> Delete(int Id);

        Task<KhoVatTuVm> GetById(int id);

        Task<PagedResult<KhoVatTuVm>> GetAllPaging(GetKhoVatTuPagingRequest request);

    }
}