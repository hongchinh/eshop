using eSaleSolution.ViewModels.Catalog.ProductImages;
using eSaleSolution.ViewModels.Catalog.Products;
using eSaleSolution.ViewModels.Common;
using eSaleSolution.ViewModels.NhapXuats;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eSaleSolution.Application.NhapXuats
{
    public interface INhapXuatService
    {
        Task<int> Create(NhapXuatCreateRequest request);

        Task<int> Update(NhapXuatUpdateRequest request);

        Task<int> Delete(int Id);

        Task<NhapXuatVm> GetById(int Id);

        Task<PagedResult<NhapXuatVm>> GetAll(GetNhapXuatRequest request);

    }
}