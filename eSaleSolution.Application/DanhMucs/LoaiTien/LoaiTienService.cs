using eSaleSolution.Application.Common;
using eSaleSolution.Data.EF;
using eSaleSolution.Data.Entities;
using eSaleSolution.Utilities.Exceptions;
using eSaleSolution.ViewModels.Common;
using eSaleSolution.ViewModels.DanhMuc.LoaiTiens;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace eSaleSolution.Application.DanhMuc.LoaiTiens
{
    public class LoaiTienService : ILoaiTienService
    {
        private readonly ESaleDbContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";

        public LoaiTienService(ESaleDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<int> Create(LoaiTienCreateRequest request)
        {
            var item = new DanhMucLoaiTien()
            {
                KyHieu = request.KyHieu,
                LoaiTien = request.LoaiTien,
                MaDonViSuDung = request.MaDonViSuDung,
            };

            _context.DanhMucLoaiTiens.Add(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }

        public async Task<int> Delete(int Id)
        {
            var item = await _context.DanhMucLoaiTiens.FindAsync(Id);

            if (item == null) throw new ESaleException($"Không tìm thấy đối tượng: {Id}");

            _context.DanhMucLoaiTiens.Remove(item);

            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<LoaiTienVm>> GetAllPaging(GetLoaiTienPagingRequest request)
        {
            //1. Select join
            var query = from p in _context.DanhMucLoaiTiens
                        select new { p };

            //2. filter
            if (!string.IsNullOrEmpty(request.KyHieu))
                query = query.Where(x => x.p.KyHieu.Contains(request.KyHieu));

            if (!string.IsNullOrEmpty(request.LoaiTien))
                query = query.Where(x => x.p.LoaiTien.Contains(request.LoaiTien));


            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new LoaiTienVm()
                {
                    Id = x.p.Id,
                    KyHieu = x.p.KyHieu,
                    LoaiTien = x.p.LoaiTien,
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<LoaiTienVm>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }

        public async Task<LoaiTienVm> GetById(int Id)
        {
            var doday = await _context.DanhMucLoaiTiens.FindAsync(Id);

            var dodayViewModel = new LoaiTienVm()
            {
                KyHieu = doday.KyHieu,
                LoaiTien = doday.LoaiTien,
            };
            return dodayViewModel;
        }
        public async Task<int> Update(LoaiTienUpdateRequest request)
        {
            var item = await _context.DanhMucLoaiTiens.FindAsync(request.Id);

            if (item == null) throw new ESaleException($"Không tìm thấy đối tượng : {request.Id}");

            item.KyHieu = request.KyHieu;
            item.LoaiTien  = request.LoaiTien;

            return await _context.SaveChangesAsync();
        }


    }
}