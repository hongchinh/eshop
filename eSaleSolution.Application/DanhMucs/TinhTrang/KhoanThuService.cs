using eSaleSolution.Application.Common;
using eSaleSolution.Data.EF;
using eSaleSolution.Data.Entities;
using eSaleSolution.Utilities.Exceptions;
using eSaleSolution.ViewModels.Common;
using eSaleSolution.ViewModels.DanhMuc.TinhTrangs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace eSaleSolution.Application.DanhMuc.TinhTrangs
{
    public class TinhTrangService : ITinhTrangService
    {
        private readonly ESaleDbContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";

        public TinhTrangService(ESaleDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<int> Create(TinhTrangCreateRequest request)
        {
            var item = new DanhMucTinhTrang()
            {
                MaSo = request.MaSo,
                ChiTieu = request.ChiTieu,
                MaDonViSuDung = request.MaDonViSuDung,
            };

            _context.DanhMucTinhTrangs.Add(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }

        public async Task<int> Delete(int Id)
        {
            var item = await _context.DanhMucTinhTrangs.FindAsync(Id);

            if (item == null) throw new ESaleException($"Không tìm thấy đối tượng: {Id}");

            _context.DanhMucTinhTrangs.Remove(item);

            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<TinhTrangVm>> GetAllPaging(GetTinhTrangPagingRequest request)
        {
            //1. Select join
            var query = from p in _context.DanhMucTinhTrangs
                        select new { p };

            //2. filter
            if (!string.IsNullOrEmpty(request.MaSo))
                query = query.Where(x => x.p.MaSo.Equals(request.MaSo));

            if (!string.IsNullOrEmpty(request.ChiTieu))
                query = query.Where(x => x.p.ChiTieu.Contains(request.ChiTieu));
             

            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new TinhTrangVm()
                {
                    Id = x.p.Id,
                    MaSo = x.p.MaSo,
                    ChiTieu= x.p.ChiTieu
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<TinhTrangVm>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }

        public async Task<TinhTrangVm> GetById(int Id)
        {
            var doday = await _context.DanhMucTinhTrangs.FindAsync(Id);

            var dodayViewModel = new TinhTrangVm()
            {
                MaSo = doday.MaSo,
                ChiTieu = doday.ChiTieu,
            };
            return dodayViewModel;
        }
        public async Task<int> Update(TinhTrangUpdateRequest request)
        {
            var item = await _context.DanhMucTinhTrangs.FindAsync(request.Id);

            if (item == null) throw new ESaleException($"Không tìm thấy đối tượng : {request.Id}");

            item.MaSo = request.MaSo;
            item.ChiTieu = request.ChiTieu;

            return await _context.SaveChangesAsync();
        }


    }
}