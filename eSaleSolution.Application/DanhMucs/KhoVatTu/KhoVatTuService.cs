using eSaleSolution.Application.Common;
using eSaleSolution.Data.EF;
using eSaleSolution.Data.Entities;
using eSaleSolution.Utilities.Exceptions;
using eSaleSolution.ViewModels.Common;
using eSaleSolution.ViewModels.DanhMuc.KhoVatTus;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace eSaleSolution.Application.DanhMuc.KhoVatTus
{
    public class KhoVatTuService : IKhoVatTuService
    {
        private readonly ESaleDbContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";

        public KhoVatTuService(ESaleDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<int> Create(KhoVatTuCreateRequest request)
        {
            var item = new DanhMucKhoVatTu()
            {
                MaKho = request.MaKho,
                TenKho = request.TenKho,
                DiaChi = request.DiaChi,
                ThuKho = request.ThuKho,
                GhiChu = request.GhiChu,
                MaDonViSuDung = request.MaDonViSuDung,
            };

            _context.DanhMucKhoVatTus.Add(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }

        public async Task<int> Delete(int Id)
        {
            var item = await _context.DanhMucKhoVatTus.FindAsync(Id);

            if (item == null) throw new ESaleException($"Không tìm thấy đối tượng: {Id}");

            _context.DanhMucKhoVatTus.Remove(item);

            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<KhoVatTuVm>> GetAllPaging(GetKhoVatTuPagingRequest request)
        {
            //1. Select join
            var query = from p in _context.DanhMucKhoVatTus
                        select new { p };

            //2. filter
            if (!string.IsNullOrEmpty(request.MaKho))
                query = query.Where(x => x.p.MaKho.Equals(request.MaKho));

            if (!string.IsNullOrEmpty(request.TenKho))
                query = query.Where(x => x.p.TenKho.Contains(request.TenKho));

            if (!string.IsNullOrEmpty(request.GhiChu))
                query = query.Where(x => x.p.GhiChu.Contains(request.GhiChu));

            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new KhoVatTuVm()
                {
                    Id = x.p.Id,
                    MaKho = x.p.MaKho,
                    TenKho = x.p.TenKho,
                    DiaChi = x.p.DiaChi,
                    ThuKho = x.p.ThuKho,
                    GhiChu = x.p.GhiChu
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<KhoVatTuVm>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }

        public async Task<KhoVatTuVm> GetById(int Id)
        {
            var item = await _context.DanhMucKhoVatTus.FindAsync(Id);

            var dodayViewModel = new KhoVatTuVm()
            {
                Id = item.Id,
                MaKho = item.MaKho,
                TenKho = item.TenKho,
                DiaChi = item.DiaChi,
                ThuKho = item.ThuKho,
                GhiChu = item.GhiChu
            };
            return dodayViewModel;
        }
        public async Task<int> Update(KhoVatTuUpdateRequest request)
        {
            var item = await _context.DanhMucKhoVatTus.FindAsync(request.Id);

            if (item == null) throw new ESaleException($"Không tìm thấy đối tượng : {request.Id}");

            item.Id = item.Id;
            item.MaKho = request.MaKho;
            item.TenKho = request.TenKho;
            item.DiaChi = request.DiaChi;
            item.ThuKho = request.ThuKho;
            item.GhiChu = request.GhiChu;

            return await _context.SaveChangesAsync();
        }


    }
}