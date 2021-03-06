using eSaleSolution.ViewModels.Catalog.ProductImages;
using eSaleSolution.ViewModels.Catalog.Products;
using eSaleSolution.ViewModels.Common;
using eSaleSolution.ViewModels.DanhMuc.SoChungTus;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eSaleSolution.Application.DanhMuc.SoChungTus
{
    public interface ISoChungTuService
    {
        Task<int> Create(SoChungTuCreateRequest request);

        Task<int> Update(SoChungTuUpdateRequest request);

        Task<int> Delete(int Id);

        Task<SoChungTuVm> GetById(int id);

        Task<PagedResult<SoChungTuVm>> GetAllPaging(GetSoChungTuPagingRequest request);

    }
}