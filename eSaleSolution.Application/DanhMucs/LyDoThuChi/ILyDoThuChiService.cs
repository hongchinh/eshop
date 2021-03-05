using eSaleSolution.ViewModels.Catalog.ProductImages;
using eSaleSolution.ViewModels.Catalog.Products;
using eSaleSolution.ViewModels.Common;
using eSaleSolution.ViewModels.DanhMuc.LyDoThuChis;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eSaleSolution.Application.DanhMuc.LyDoThuChis
{
    public interface ILyDoThuChiService
    {
        Task<int> Create(LyDoThuChiCreateRequest request);

        Task<int> Update(LyDoThuChiUpdateRequest request);

        Task<int> Delete(int Id);

        Task<LyDoThuChiVm> GetById(int id);

        Task<PagedResult<LyDoThuChiVm>> GetAllPaging(GetLyDoThuChiPagingRequest request);

    }
}