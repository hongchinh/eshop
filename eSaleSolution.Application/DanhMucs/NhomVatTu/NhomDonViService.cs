using eSaleSolution.Application.Common;
using eSaleSolution.Data.EF;
using eSaleSolution.Data.Entities;
using eSaleSolution.Utilities.Exceptions;
using eSaleSolution.ViewModels.Common;
using eSaleSolution.ViewModels.DanhMuc.NhomVatTus;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace eSaleSolution.Application.DanhMuc.NhomVatTus
{
    public class NhomVatTuService : INhomVatTuService
    {
        private readonly ESaleDbContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";

        public NhomVatTuService(ESaleDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<int> Create(NhomVatTuCreateRequest request)
        {
            var item = new DanhMucNhomVatTu()
            {
                MaNhom = request.MaNhom,
                MaNhomHang = request.MaNhomHang,
                TenNhomHang = request.TenNhomHang,
                KyHieu = request.KyHieu,
                GhiChu = request.GhiChu,
                MaDonViSuDung = request.MaDonViSuDung,
            };

            _context.DanhMucNhomVatTus.Add(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }

        public async Task<int> Delete(int Id)
        {
            var item = await _context.DanhMucNhomVatTus.FindAsync(Id);

            if (item == null) throw new ESaleException($"Không tìm thấy đối tượng: {Id}");

            _context.DanhMucNhomVatTus.Remove(item);

            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<NhomVatTuVm>> GetAllPaging(GetNhomVatTuPagingRequest request)
        {
            //1. Select join
            var query = from p in _context.DanhMucNhomVatTus
                        select new { p };

            //2. filter
            if (!string.IsNullOrEmpty(request.MaNhom))
                query = query.Where(x => x.p.MaNhom.Equals(request.MaNhom));

            if (!string.IsNullOrEmpty(request.MaNhomHang))
                query = query.Where(x => x.p.MaNhomHang.Contains(request.MaNhomHang));
            
            if (!string.IsNullOrEmpty(request.TenNhomHang))
                query = query.Where(x => x.p.TenNhomHang.Contains(request.TenNhomHang));

            if (!string.IsNullOrEmpty(request.KyHieu))
                query = query.Where(x => x.p.KyHieu.Contains(request.KyHieu));

            if (!string.IsNullOrEmpty(request.GhiChu))
                query = query.Where(x => x.p.GhiChu.Contains(request.GhiChu));

            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new NhomVatTuVm()
                {
                    Id = x.p.Id,
                    MaNhom = x.p.MaNhom,
                    MaNhomHang  = x.p.MaNhomHang,
                    TenNhomHang = x.p.TenNhomHang,
                    KyHieu = x.p.KyHieu,
                    GhiChu = x.p.GhiChu
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<NhomVatTuVm>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }

        public async Task<NhomVatTuVm> GetById(int Id)
        {
            var doday = await _context.DanhMucNhomVatTus.FindAsync(Id);

            var dodayViewModel = new NhomVatTuVm()
            {
                MaNhom  = doday.MaNhom,
                MaNhomHang = doday.MaNhomHang,
                TenNhomHang = doday.TenNhomHang,
                KyHieu = doday.KyHieu,
                GhiChu = doday.GhiChu
            };
            return dodayViewModel;
        }
        public async Task<int> Update(NhomVatTuUpdateRequest request)
        {
            var item = await _context.DanhMucNhomVatTus.FindAsync(request.Id);

            if (item == null) throw new ESaleException($"Không tìm thấy đối tượng : {request.Id}");

            item.MaNhom = request.MaNhom;
            item.MaNhomHang = request.MaNhomHang;
            item.TenNhomHang = request.TenNhomHang;
            item.KyHieu = request.KyHieu;
            item.GhiChu = request.GhiChu;

            return await _context.SaveChangesAsync();
        }


    }
}