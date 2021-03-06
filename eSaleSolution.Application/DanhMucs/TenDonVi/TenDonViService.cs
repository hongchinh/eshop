using AutoMapper;
using eSaleSolution.Application.Common;
using eSaleSolution.Data.Data;
using eSaleSolution.Data.EF;
using eSaleSolution.Data.Entities;
using eSaleSolution.Utilities.Exceptions;
using eSaleSolution.ViewModels.Common;
using eSaleSolution.ViewModels.DanhMuc.TenDonVis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eSaleSolution.Application.DanhMuc.TenDonVis
{
    public class TenDonViService : ITenDonViService
    {
        private readonly ESaleDbContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";
        private readonly IMapper _mapper;

        public TenDonViService(ESaleDbContext context, IStorageService storageService, IMapper mapper)
        {
            _context = context;
            _storageService = storageService;
            _mapper = mapper;
           
        }

        public async Task<int> Create(TenDonViCreateRequest request)
        {
             var item = _mapper.Map<DanhMucTenDonVi>(request);
            //var item = new DanhMucTenDonVi()
            //{
            //    MaDonVi = request.MaDonVi,
            //    TenDonVi = request.TenDonVi,
            //    DiaChi = request.DiaChi,
            //    DienThoai = request.DienThoai,
            //    Email = request.Email,
            //    MaSoThue = request.MaSoThue,
            //    SoTaiKhoan = request.SoTaiKhoan,
            //    NoiMoTaiKhoan = request.NoiMoTaiKhoan,
            //    MaNhom = request.MaNhom,
            //    TenNhom = request.TenNhom,
            //    MaKhuVuc = request.MaKhuVuc,
            //    TenKhuVuc = request.TenKhuVuc,
            //    HanMucThanhToan = request.HanMucThanhToan,
            //    TheoDoi = request.TheoDoi,
            //    MaQuanLy = request.MaQuanLy,
            //    TenQuanLy = request.TenQuanLy,
            //    MaDonViSuDung = request.MaDonViSuDung,
            //};

            _context.DanhMucTenDonVis.Add(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }

        public async Task<int> Delete(int Id)
        {
            var item = await _context.DanhMucTenDonVis.FindAsync(Id);

            if (item == null) throw new ESaleException($"Không tìm thấy đối tượng: {Id}");

            _context.DanhMucTenDonVis.Remove(item);

            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<TenDonViVm>> GetAllPaging(GetTenDonViPagingRequest request)
        {
            //1. Select join
            var query = from p in _context.DanhMucTenDonVis
                        select p;
            
            //2. filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.MaDonVi.Contains(request.Keyword) ||
                        x.TenDonVi.Contains(request.Keyword) || x.DiaChi.Contains(request.Keyword) || x.DienThoai.Contains(request.Keyword));

            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize).ToListAsync();

            var item = _mapper.Map<TenDonViVm[]>(data);
             
            //4. Select and projection
            var pagedResult = new PagedResult<TenDonViVm>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = item.ToList()
            };
            return pagedResult;
        }

        public async Task<TenDonViVm> GetById(int Id)
        {
            var item = await _context.DanhMucTenDonVis.FindAsync(Id);

            var donviViewModel = _mapper.Map<TenDonViVm>(item);
          
            return donviViewModel;
        }
        public async Task<int> Update(TenDonViUpdateRequest request)
        {
            var item = await _context.DanhMucTenDonVis.FindAsync(request.Id);

            if (item == null) throw new ESaleException($"Không tìm thấy đối tượng : {request.Id}");

            item.Id = item.Id;
            //item.Stt = item.Stt;
            item.MaDonVi = item.MaDonVi;
            item.TenDonVi = item.TenDonVi;
            item.DiaChi = item.DiaChi;
            item.DienThoai = item.DienThoai;
            item.Email = item.Email;
            item.Website = item.Website;
            item.MaSoThue = item.MaSoThue;
            item.SoTaiKhoan = item.SoTaiKhoan;
            item.NoiMoTaiKhoan = item.NoiMoTaiKhoan;
            item.Selectted = item.Selectted;
            item.MaNhom = item.MaNhom;
            item.TenNhom = item.TenNhom;
            item.MaTinh = item.MaTinh;
            item.TenTinh = item.TenTinh;
            item.MaQuanLy = item.MaQuanLy;
            item.TenQuanLy = item.TenQuanLy;
            item.TheoDoi = item.TheoDoi;
            item.Loai = item.Loai;


            return await _context.SaveChangesAsync();
        }


    }
}