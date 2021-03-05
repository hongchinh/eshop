using eSaleSolution.ViewModels.Catalog.ProductImages;
using eSaleSolution.ViewModels.Catalog.Products;
using eSaleSolution.ViewModels.Common;
using eSaleSolution.ViewModels.DanhMuc.KieuSongs;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eSaleSolution.Application.DanhMuc.KieuSongs
{
    public interface IKieuSongService
    {
        Task<int> Create(KieuSongCreateRequest request);

        Task<int> Update(KieuSongUpdateRequest request);

        Task<int> Delete(int Id);

        Task<KieuSongVm> GetById(int id);

        Task<PagedResult<KieuSongVm>> GetAllPaging(GetKieuSongPagingRequest request);

    }
}