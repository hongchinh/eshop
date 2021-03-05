using eSaleSolution.Application.Common;
using eSaleSolution.Data.EF;
using eSaleSolution.Data.Entities;
using eSaleSolution.Utilities.Exceptions;
using eSaleSolution.ViewModels.Common;
using eSaleSolution.ViewModels.DanhMuc.DonViTrucThuocs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace eSaleSolution.Application.DanhMuc.DonViTrucThuocs
{
    public class DonViTrucThuocService : IDonViTrucThuocService
    {
        private readonly ESaleDbContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";

        public DonViTrucThuocService(ESaleDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<int> Create(DonViTrucThuocCreateRequest request)
        {
            var item = new DanhMucDonViTrucThuoc()
            {
                MaDonVi = request.MaDonVi,
                TenDonVi = request.TenDonVi,
                DiaChi = request.DiaChi,
                GhiChu = request.GhiChu,
                MaDonViSuDung = request.MaDonViSuDung,
            };

            _context.DanhMucDonViTrucThuocs.Add(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }

        public async Task<int> Delete(int Id)
        {
            var item = await _context.DanhMucDonViTrucThuocs.FindAsync(Id);

            if (item == null) throw new ESaleException($"Không tìm thấy đối tượng: {Id}");

            _context.DanhMucDonViTrucThuocs.Remove(item);

            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<DonViTrucThuocVm>> GetAllPaging(GetDonViTrucThuocPagingRequest request)
        {
            //1. Select join
            var query = from p in _context.DanhMucDonViTrucThuocs
                        select new { p };

            //2. filter
            if (!string.IsNullOrEmpty(request.MaDonVi))
                query = query.Where(x => x.p.MaDonVi.Equals(request.MaDonVi));

            if (!string.IsNullOrEmpty(request.TenDonVi))
                query = query.Where(x => x.p.TenDonVi.Contains(request.TenDonVi));

            if (!string.IsNullOrEmpty(request.DiaChi))
                query = query.Where(x => x.p.DiaChi.Contains(request.DiaChi));

            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new DonViTrucThuocVm()
                {
                    Id = x.p.Id,
                    MaDonVi = x.p.MaDonVi,
                    TenDonVi = x.p.TenDonVi,
                    DiaChi = x.p.DiaChi,
                    GhiChu = x.p.GhiChu
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<DonViTrucThuocVm>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }

        public async Task<DonViTrucThuocVm> GetById(int Id)
        {
            var doday = await _context.DanhMucDonViTrucThuocs.FindAsync(Id);

            var dodayViewModel = new DonViTrucThuocVm()
            {
                MaDonVi = doday.MaDonVi,
                TenDonVi = doday.TenDonVi,
                DiaChi = doday.DiaChi,
                GhiChu = doday.GhiChu
            };
            return dodayViewModel;
        }
        public async Task<int> Update(DonViTrucThuocUpdateRequest request)
        {
            var item = await _context.DanhMucDonViTrucThuocs.FindAsync(request.Id);

            if (item == null) throw new ESaleException($"Không tìm thấy đối tượng : {request.Id}");

            item.MaDonVi = request.MaDonVi;
            item.TenDonVi = request.TenDonVi;
            item.DiaChi = request.DiaChi;
            item.GhiChu = request.GhiChu;

            return await _context.SaveChangesAsync();
        }


    }
}