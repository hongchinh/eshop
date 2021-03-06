using eSaleSolution.Application.Common;
using eSaleSolution.Data.EF;
using eSaleSolution.Data.Entities;
using eSaleSolution.Utilities.Exceptions;
using eSaleSolution.ViewModels.Common;
using eSaleSolution.ViewModels.NhapXuats;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace eSaleSolution.Application.NhapXuats
{
    public class NhapXuatService : INhapXuatService
    {
        private readonly ESaleDbContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";

        public NhapXuatService(ESaleDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<int> Create(NhapXuatCreateRequest request)
        {
            var item = new NhapXuat()
            {
              
                GhiChu = request.GhiChu,
                MaDonViSuDung = request.MaDonViSuDung,
            };

            _context.NhapXuats.Add(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }

        public async Task<int> Delete(int Id)
        {
            var item = await _context.NhapXuats.FindAsync(Id);

            if (item == null) throw new ESaleException($"Không tìm thấy đối tượng: {Id}");

            _context.NhapXuats.Remove(item);

            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<NhapXuatVm>> GetAll(GetNhapXuatRequest request)
        {
            //1. Select join
            var query = from p in _context.NhapXuats
                        where p.MaDonViSuDung.Equals(request.MaDonViSuDung)
                        select new { p };

            //2. filter
            if (!string.IsNullOrEmpty(request.SoChungTu))
                query = query.Where(x => x.p.SoChungTu.Contains(request.SoChungTu));

            

            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query
                .Select(x => new NhapXuatVm()
                {
                    Id = x.p.Id,
                    GhiChu = x.p.GhiChu
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<NhapXuatVm>()
            {
                TotalRecords = totalRow,
                Items = data
            };
            return pagedResult;
        }

        public async Task<NhapXuatVm> GetById(int Id)
        {
            var item = await _context.NhapXuats.FindAsync(Id);

            var viewModel = new NhapXuatVm()
            {
               Id= item.Id,
                GhiChu = item.GhiChu
            };
            return viewModel;
        }
        public async Task<int> Update(NhapXuatUpdateRequest request)
        {
            var item = await _context.NhapXuats.FindAsync(request.Id);

            if (item == null) throw new ESaleException($"Không tìm thấy đối tượng : {request.Id}");

            item.SoChungTu = request.SoChungTu;
            item.NgayCt = request.NgayCt;
            item.GhiChu = request.GhiChu;

            return await _context.SaveChangesAsync();
        }


    }
}