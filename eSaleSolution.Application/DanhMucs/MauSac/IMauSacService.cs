using eSaleSolution.ViewModels.Catalog.ProductImages;
using eSaleSolution.ViewModels.Catalog.Products;
using eSaleSolution.ViewModels.Common;
using eSaleSolution.ViewModels.DanhMuc.MauSacs;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eSaleSolution.Application.DanhMuc.MauSacs
{
    public interface IMauSacService
    {
        Task<int> Create(MauSacCreateRequest request);

        Task<int> Update(MauSacUpdateRequest request);

        Task<int> Delete(int Id);

        Task<MauSacVm> GetById(int id);

        Task<PagedResult<MauSacVm>> GetAllPaging(GetMauSacPagingRequest request);

    }
}