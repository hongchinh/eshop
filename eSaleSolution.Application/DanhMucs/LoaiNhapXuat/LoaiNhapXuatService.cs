using eSaleSolution.Application.Common;
using eSaleSolution.Data.EF;
using eSaleSolution.Data.Entities;
using eSaleSolution.Utilities.Exceptions;
using eSaleSolution.ViewModels.Common;
using eSaleSolution.ViewModels.DanhMuc.LoaiNhapXuats;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace eSaleSolution.Application.DanhMuc.LoaiNhapXuats
{
    public class LoaiNhapXuatService : ILoaiNhapXuatService
    {
        private readonly ESaleDbContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";

        public LoaiNhapXuatService(ESaleDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<int> Create(LoaiNhapXuatCreateRequest request)
        {
            var item = new DanhMucLoaiNhapXuat()
            {
                Loai = request.Loai,
                MaSo = request.MaSo,
                ChiTieu = request.ChiTieu,
                GhiChu = request.GhiChu,
                MaDonViSuDung = request.MaDonViSuDung,
            };

            _context.DanhMucLoaiNhapXuats.Add(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }

        public async Task<int> Delete(int Id)
        {
            var item = await _context.DanhMucLoaiNhapXuats.FindAsync(Id);

            if (item == null) throw new ESaleException($"Không tìm thấy đối tượng: {Id}");

            _context.DanhMucLoaiNhapXuats.Remove(item);

            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<LoaiNhapXuatVm>> GetAllPaging(GetLoaiNhapXuatPagingRequest request)
        {
            //1. Select join
            var query = from p in _context.DanhMucLoaiNhapXuats
                        select new { p };

            //2. filter
            if (!string.IsNullOrEmpty(request.Loai))
                query = query.Where(x => x.p.Loai.Equals(request.Loai));

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
                .Select(x => new LoaiNhapXuatVm()
                {
                    Id = x.p.Id,
                    Loai = x.p.Loai,
                    MaSo = x.p.MaSo,
                    ChiTieu = x.p.ChiTieu,
                    GhiChu = x.p.GhiChu
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<LoaiNhapXuatVm>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }

        public async Task<LoaiNhapXuatVm> GetById(int Id)
        {
            var item = await _context.DanhMucLoaiNhapXuats.FindAsync(Id);

            var dodayViewModel = new LoaiNhapXuatVm()
            {
                Id = item.Id,
                Loai = item.Loai,
                MaSo = item.MaSo,
                ChiTieu = item.ChiTieu,
                GhiChu = item.GhiChu
            };
            return dodayViewModel;
        }
        public async Task<int> Update(LoaiNhapXuatUpdateRequest request)
        {
            var item = await _context.DanhMucLoaiNhapXuats.FindAsync(request.Id);

            if (item == null) throw new ESaleException($"Không tìm thấy đối tượng : {request.Id}");

            item.Id = item.Id;
            item.Loai = request.Loai;
            item.MaSo = request.MaSo;
            item.ChiTieu = request.ChiTieu;
            item.GhiChu = request.GhiChu;

            return await _context.SaveChangesAsync();
        }


    }
}