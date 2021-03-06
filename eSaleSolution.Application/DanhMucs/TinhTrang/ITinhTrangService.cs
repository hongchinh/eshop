using eSaleSolution.ViewModels.Catalog.ProductImages;
using eSaleSolution.ViewModels.Catalog.Products;
using eSaleSolution.ViewModels.Common;
using eSaleSolution.ViewModels.DanhMuc.TinhTrangs;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eSaleSolution.Application.DanhMuc.TinhTrangs
{
    public interface ITinhTrangService
    {
        Task<int> Create(TinhTrangCreateRequest request);

        Task<int> Update(TinhTrangUpdateRequest request);

        Task<int> Delete(int Id);

        Task<TinhTrangVm> GetById(int id);

        Task<PagedResult<TinhTrangVm>> GetAllPaging(GetTinhTrangPagingRequest request);

    }
}