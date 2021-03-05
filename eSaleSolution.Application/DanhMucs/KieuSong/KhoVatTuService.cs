using eSaleSolution.Application.Common;
using eSaleSolution.Data.EF;
using eSaleSolution.Data.Entities;
using eSaleSolution.Utilities.Exceptions;
using eSaleSolution.ViewModels.Common;
using eSaleSolution.ViewModels.DanhMuc.KieuSongs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace eSaleSolution.Application.DanhMuc.KieuSongs
{
    public class KieuSongService : IKieuSongService
    {
        private readonly ESaleDbContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";

        public KieuSongService(ESaleDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<int> Create(KieuSongCreateRequest request)
        {
            var item = new DanhMucKieuSong()
            {
                MaSo = request.MaSo,
                ChiTieu = request.ChiTieu,
                GhiChu = request.GhiChu,
                MaDonViSuDung = request.MaDonViSuDung,
            };

            _context.DanhMucKieuSongs.Add(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }

        public async Task<int> Delete(int Id)
        {
            var item = await _context.DanhMucKieuSongs.FindAsync(Id);

            if (item == null) throw new ESaleException($"Không tìm thấy đối tượng: {Id}");

            _context.DanhMucKieuSongs.Remove(item);

            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<KieuSongVm>> GetAllPaging(GetKieuSongPagingRequest request)
        {
            //1. Select join
            var query = from p in _context.DanhMucKieuSongs
                        select new { p };

            //2. filter
            if (!string.IsNullOrEmpty(request.MaSo))
                query = query.Where(x => x.p.MaSo.Equals(request.MaSo));

            if (!string.IsNullOrEmpty(request.ChiTieu))
                query = query.Where(x => x.p.ChiTieu.Contains(request.ChiTieu));

            if (!string.IsNullOrEmpty(request.GhiChu))
                query = query.Where(x => x.p.GhiChu.Contains(request.GhiChu));

            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new KieuSongVm()
                {
                    Id = x.p.Id,
                    MaSo = x.p.MaSo,
                    ChiTieu = x.p.ChiTieu,
                    GhiChu = x.p.GhiChu
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<KieuSongVm>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }

        public async Task<KieuSongVm> GetById(int Id)
        {
            var item = await _context.DanhMucKieuSongs.FindAsync(Id);

            var dodayViewModel = new KieuSongVm()
            {
                Id = item.Id,
                MaSo = item.MaSo,
                ChiTieu = item.ChiTieu,
                GhiChu = item.GhiChu
            };
            return dodayViewModel;
        }
        public async Task<int> Update(KieuSongUpdateRequest request)
        {
            var item = await _context.DanhMucKieuSongs.FindAsync(request.Id);

            if (item == null) throw new ESaleException($"Không tìm thấy đối tượng : {request.Id}");

            item.Id = item.Id;
            item.MaSo = request.MaSo;
            item.ChiTieu = request.ChiTieu;
            item.GhiChu = request.GhiChu;

            return await _context.SaveChangesAsync();
        }


    }
}