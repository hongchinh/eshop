using eSaleSolution.Application.Common;
using eSaleSolution.Data.EF;
using eSaleSolution.Data.Entities;
using eSaleSolution.Utilities.Exceptions;
using eSaleSolution.ViewModels.Common;
using eSaleSolution.ViewModels.DanhMuc.MauSacs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace eSaleSolution.Application.DanhMuc.MauSacs
{
    public class MauSacService : IMauSacService
    {
        private readonly ESaleDbContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";

        public MauSacService(ESaleDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<int> Create(MauSacCreateRequest request)
        {
            var item = new DanhMucMauSac()
            {
                MaSo = request.MaSo,
                ChiTieu = request.ChiTieu,
                GhiChu = request.GhiChu,
                MaDonViSuDung = request.MaDonViSuDung,
            };

            _context.DanhMucMauSacs.Add(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }

        public async Task<int> Delete(int Id)
        {
            var item = await _context.DanhMucMauSacs.FindAsync(Id);

            if (item == null) throw new ESaleException($"Không tìm thấy đối tượng: {Id}");

            _context.DanhMucMauSacs.Remove(item);

            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<MauSacVm>> GetAllPaging(GetMauSacPagingRequest request)
        {
            //1. Select join
            var query = from p in _context.DanhMucMauSacs
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
                .Select(x => new MauSacVm()
                {
                    Id = x.p.Id,
                    ChiTieu = x.p.ChiTieu,
                    MaSo = x.p.MaSo,
                    GhiChu = x.p.GhiChu
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<MauSacVm>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }

        public async Task<MauSacVm> GetById(int Id)
        {
            var doday = await _context.DanhMucMauSacs.FindAsync(Id);

            var dodayViewModel = new MauSacVm()
            {
                MaSo = doday.MaSo,
                ChiTieu = doday.ChiTieu,
                GhiChu = doday.GhiChu
            };
            return dodayViewModel;
        }
        public async Task<int> Update(MauSacUpdateRequest request)
        {
            var item = await _context.DanhMucMauSacs.FindAsync(request.Id);

            if (item == null) throw new ESaleException($"Không tìm thấy đối tượng : {request.Id}");

            item.MaSo = request.MaSo;
            item.ChiTieu = request.ChiTieu;
            item.GhiChu = request.GhiChu;

            return await _context.SaveChangesAsync();
        }


    }
}