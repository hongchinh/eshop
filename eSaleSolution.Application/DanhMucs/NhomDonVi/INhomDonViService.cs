using eSaleSolution.ViewModels.Catalog.ProductImages;
using eSaleSolution.ViewModels.Catalog.Products;
using eSaleSolution.ViewModels.Common;
using eSaleSolution.ViewModels.DanhMuc.NhomDonVis;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eSaleSolution.Application.DanhMuc.NhomDonVis
{
    public interface INhomDonViService
    {
        Task<int> Create(NhomDonViCreateRequest request);

        Task<int> Update(NhomDonViUpdateRequest request);

        Task<int> Delete(int Id);

        Task<NhomDonViVm> GetById(int id);

        Task<PagedResult<NhomDonViVm>> GetAllPaging(GetNhomDonViPagingRequest request);

    }
}