using eSaleSolution.Application.Common;
using eSaleSolution.Data.EF;
using eSaleSolution.Data.Entities;
using eSaleSolution.Utilities.Exceptions;
using eSaleSolution.ViewModels.Common;
using eSaleSolution.ViewModels.DanhMuc.NhomDonVis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace eSaleSolution.Application.DanhMuc.NhomDonVis
{
    public class NhomDonViService : INhomDonViService
    {
        private readonly ESaleDbContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";

        public NhomDonViService(ESaleDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<int> Create(NhomDonViCreateRequest request)
        {
            var item = new DanhMucNhomDonVi()
            {
                MaNhom = request.MaNhom,
                TenNhom = request.TenNhom,
                GhiChu = request.GhiChu,
                MaDonViSuDung = request.MaDonViSuDung,
            };

            _context.DanhMucNhomDonVis.Add(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }

        public async Task<int> Delete(int Id)
        {
            var item = await _context.DanhMucNhomDonVis.FindAsync(Id);

            if (item == null) throw new ESaleException($"Không tìm thấy đối tượng: {Id}");

            _context.DanhMucNhomDonVis.Remove(item);

            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<NhomDonViVm>> GetAllPaging(GetNhomDonViPagingRequest request)
        {
            //1. Select join
            var query = from p in _context.DanhMucNhomDonVis
                        select new { p };

            //2. filter
            if (!string.IsNullOrEmpty(request.MaNhom))
                query = query.Where(x => x.p.MaNhom.Equals(request.MaNhom));

            if (!string.IsNullOrEmpty(request.TenNhom))
                query = query.Where(x => x.p.TenNhom.Contains(request.TenNhom));

            if (!string.IsNullOrEmpty(request.GhiChu))
                query = query.Where(x => x.p.GhiChu.Contains(request.GhiChu));

            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new NhomDonViVm()
                {
                    Id = x.p.Id,
                    MaNhom = x.p.MaNhom,
                    TenNhom = x.p.TenNhom,
                    GhiChu = x.p.GhiChu
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<NhomDonViVm>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }

        public async Task<NhomDonViVm> GetById(int Id)
        {
            var doday = await _context.DanhMucNhomDonVis.FindAsync(Id);

            var dodayViewModel = new NhomDonViVm()
            {
                MaNhom  = doday.MaNhom,
                TenNhom  = doday.TenNhom,
                GhiChu = doday.GhiChu
            };
            return dodayViewModel;
        }
        public async Task<int> Update(NhomDonViUpdateRequest request)
        {
            var item = await _context.DanhMucNhomDonVis.FindAsync(request.Id);

            if (item == null) throw new ESaleException($"Không tìm thấy đối tượng : {request.Id}");

            item.MaNhom = request.MaNhom;
            item.TenNhom = request.TenNhom;
            item.GhiChu = request.GhiChu;

            return await _context.SaveChangesAsync();
        }


    }
}