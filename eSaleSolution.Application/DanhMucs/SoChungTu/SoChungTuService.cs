using eSaleSolution.Application.Common;
using eSaleSolution.Data.EF;
using eSaleSolution.Data.Entities;
using eSaleSolution.Utilities.Exceptions;
using eSaleSolution.ViewModels.Common;
using eSaleSolution.ViewModels.DanhMuc.SoChungTus;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace eSaleSolution.Application.DanhMuc.SoChungTus
{
    public class SoChungTuService : ISoChungTuService
    {
        private readonly ESaleDbContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";

        public SoChungTuService(ESaleDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<int> Create(SoChungTuCreateRequest request)
        {
            var item = new DanhMucSoChungTu()
            {
                LoaiChungTu = request.LoaiChungTu,
                KyHieuChungTu = request.KyHieuChungTu,
                DoDai = request.DoDai,
                MaDonViSuDung = request.MaDonViSuDung,
            };

            _context.DanhMucSoChungTus.Add(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }

        public async Task<int> Delete(int Id)
        {
            var item = await _context.DanhMucSoChungTus.FindAsync(Id);

            if (item == null) throw new ESaleException($"Không tìm thấy đối tượng: {Id}");

            _context.DanhMucSoChungTus.Remove(item);

            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<SoChungTuVm>> GetAllPaging(GetSoChungTuPagingRequest request)
        {
            //1. Select join
            var query = from p in _context.DanhMucSoChungTus
                        select new { p };

            //2. filter
            if (!string.IsNullOrEmpty(request.LoaiChungTu))
                query = query.Where(x => x.p.LoaiChungTu.Contains(request.LoaiChungTu));

            if (!string.IsNullOrEmpty(request.KyHieuChungTu))
                query = query.Where(x => x.p.KyHieuChungTu.Contains(request.KyHieuChungTu));


            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new SoChungTuVm()
                {
                    Id = x.p.Id,
                    LoaiChungTu = x.p.LoaiChungTu,
                    KyHieuChungTu = x.p.KyHieuChungTu,
                    DoDai = x.p.DoDai
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<SoChungTuVm>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }

        public async Task<SoChungTuVm> GetById(int Id)
        {
            var doday = await _context.DanhMucSoChungTus.FindAsync(Id);

            var dodayViewModel = new SoChungTuVm()
            {
                LoaiChungTu = doday.LoaiChungTu,
                KyHieuChungTu = doday.KyHieuChungTu,
                DoDai = doday.DoDai
            };
            return dodayViewModel;
        }
        public async Task<int> Update(SoChungTuUpdateRequest request)
        {
            var item = await _context.DanhMucSoChungTus.FindAsync(request.Id);

            if (item == null) throw new ESaleException($"Không tìm thấy đối tượng : {request.Id}");

            item.LoaiChungTu = request.LoaiChungTu;
            item.KyHieuChungTu = request.KyHieuChungTu;
            item.DoDai = request.DoDai;

            return await _context.SaveChangesAsync();
        }


    }
}