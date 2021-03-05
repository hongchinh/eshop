using eSaleSolution.Application.Common;
using eSaleSolution.Data.EF;
using eSaleSolution.Data.Entities;
using eSaleSolution.Utilities.Exceptions;
using eSaleSolution.ViewModels.Common;
using eSaleSolution.ViewModels.DanhMuc.LyDoThuChis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace eSaleSolution.Application.DanhMuc.LyDoThuChis
{
    public class LyDoThuChiService : ILyDoThuChiService
    {
        private readonly ESaleDbContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";

        public LyDoThuChiService(ESaleDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<int> Create(LyDoThuChiCreateRequest request)
        {
            var item = new DanhMucLyDoThuChi()
            {
                MaLyDo = request.MaLyDo,
                TenLyDo = request.TenLyDo,
                Loai = request.Loai,
                GhiChu = request.GhiChu,
                MaDonViSuDung = request.MaDonViSuDung,
            };

            _context.DanhMucLyDoThuChis.Add(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }

        public async Task<int> Delete(int Id)
        {
            var item = await _context.DanhMucLyDoThuChis.FindAsync(Id);

            if (item == null) throw new ESaleException($"Không tìm thấy đối tượng: {Id}");

            _context.DanhMucLyDoThuChis.Remove(item);

            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<LyDoThuChiVm>> GetAllPaging(GetLyDoThuChiPagingRequest request)
        {
            //1. Select join
            var query = from p in _context.DanhMucLyDoThuChis
                        select new { p };

            //2. filter
            if (!string.IsNullOrEmpty(request.Loai))
                query = query.Where(x => x.p.Loai.Equals(request.Loai));

            if (!string.IsNullOrEmpty(request.MaLyDo))
                query = query.Where(x => x.p.MaLyDo.Equals(request.MaLyDo));

            if (!string.IsNullOrEmpty(request.TenLyDo))
                query = query.Where(x => x.p.TenLyDo.Contains(request.TenLyDo));

            if (!string.IsNullOrEmpty(request.GhiChu))
                query = query.Where(x => x.p.GhiChu.Contains(request.GhiChu));

            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new LyDoThuChiVm()
                {
                    Id = x.p.Id,
                    Loai = x.p.Loai,
                    MaLyDo = x.p.MaLyDo,
                    TenLyDo = x.p.TenLyDo,
                    GhiChu = x.p.GhiChu
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<LyDoThuChiVm>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }

        public async Task<LyDoThuChiVm> GetById(int Id)
        {
            var item = await _context.DanhMucLyDoThuChis.FindAsync(Id);

            var dodayViewModel = new LyDoThuChiVm()
            {
                Id = item.Id,
                Loai = item.Loai,
                MaLyDo = item.MaLyDo,
                TenLyDo = item.TenLyDo,
                GhiChu = item.GhiChu
            };
            return dodayViewModel;
        }
        public async Task<int> Update(LyDoThuChiUpdateRequest request)
        {
            var item = await _context.DanhMucLyDoThuChis.FindAsync(request.Id);

            if (item == null) throw new ESaleException($"Không tìm thấy đối tượng : {request.Id}");

            item.Id = item.Id;
            item.Loai = request.Loai;
            item.MaLyDo = request.MaLyDo;
            item.TenLyDo = request.TenLyDo;
            item.GhiChu = request.GhiChu;

            return await _context.SaveChangesAsync();
        }


    }
}