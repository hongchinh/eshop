using eSaleSolution.ViewModels.Catalog.Products;
using eSaleSolution.ViewModels.Common;
using eSaleSolution.ViewModels.DanhMuc.TenDonVis;
using eSaleSolution.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eSaleSolution.ApiIntegration
{
    public interface ITenDonVisApiClient
    {
        Task<PagedResult<TenDonViVm>> GetPagings(GetTenDonViPagingRequest request);

        Task<bool> Create(TenDonViCreateRequest request);

        Task<bool> Update(TenDonViUpdateRequest request);

        Task<TenDonViVm> GetById(int id);

        Task<bool> Delete(int id);
    }
}