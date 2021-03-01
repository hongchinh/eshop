using eShopSolution.Application.Common;
using eShopSolution.Data.EF;
using eShopSolution.Data.Entities;
using eShopSolution.Utilities.Exceptions;
using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.DanhMuc.HangHoas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.Application.DanhMuc.HangHoas
{
    public class HangHoaService : IHangHoaService
    {
        private readonly EShopDbContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";

        public HangHoaService(EShopDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<int> Create(HangHoaCreateRequest request)
        {

            var hangHoa = new DanhMucHangHoa()
            {
                MaHangHoa = request.MaHangHoa,
                TenHangHoa = request.TenHangHoa,
                DonViTinh = request.DonViTinh,
                MaNhomHang = request.MaNhomHang,
                TenNhomHang = request.TenNhomHang,
                QuyCach = request.QuyCach,
                TyTrong = request.TyTrong,
                DonGia = request.DonGia,
                GiaNhap = request.GiaNhap,
                GiaXuat = request.GiaXuat,
                TyLeChietKhau = request.TyLeChietKhau,
                GiaBanLe = request.GiaBanLe,
                TyLeVat = request.TyLeVat,
                LoaiThue = request.LoaiThue,
                SoLuongToiThieu = request.SoLuongToiThieu,
                SoLuongToiDa = request.SoLuongToiDa,
                MaDonViSuDung = request.MaDonViSuDung,
                KhoRongTon = request.KhoRongTon,
                ChieuDai = request.ChieuDai,
                LoaiTon = request.LoaiTon,
                MauSac = request.MauSac,
                DoDay = request.DoDay,
                ChungLoai = request.ChungLoai,
                HangHoa = request.HangHoa,
                NgayTao = DateTime.Now,
            };

            _context.DanhMucHangHoas.Add(hangHoa);
            await _context.SaveChangesAsync();
            return hangHoa.Id;
        }

        public async Task<int> Delete(int hangHoaId)
        {
            var hanghoa = await _context.DanhMucHangHoas.FindAsync(hangHoaId);

            if (hanghoa == null) throw new EShopException($"Cannot find a product: {hangHoaId}");

            _context.DanhMucHangHoas.Remove(hanghoa);

            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<HangHoaVm>> GetAllPaging(GetHangHoaPagingRequest request)
        {
            //1. Select join
            var query = from p in _context.DanhMucHangHoas
                        select new { p };
                       
            //2. filter
            if (!string.IsNullOrEmpty(request.MaHangHoa))
                query = query.Where(x => x.p .MaHangHoa.Contains(request.MaHangHoa));

            if (!string.IsNullOrEmpty(request.TenHangHoa))
                query = query.Where(x => x.p.TenHangHoa.Contains(request.TenHangHoa));

            if (!string.IsNullOrEmpty(request.DonViTinh))
                query = query.Where(x => x.p.DonViTinh.Contains(request.DonViTinh));

            //3. Paging
            int totalRow = await query.CountAsync();

           


            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new HangHoaVm()
                {
                    Id = x.p.Id,
                    MaHangHoa = x.p.MaHangHoa,
                    TenHangHoa = x.p.TenHangHoa,
                    DonViTinh = x.p.DonViTinh,
                    MaNhomHang = x.p.MaNhomHang,
                    TenNhomHang = x.p.TenNhomHang,
                    TyTrong =x.p.TyTrong,
                    QuyCach = x.p.QuyCach,
                    DonGia = x.p.DonGia,
                    GiaNhap = x.p.GiaNhap,
                    GiaXuat = x.p.GiaXuat,
                     
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<HangHoaVm>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }

        public async Task<HangHoaVm> GetById(int hangHoaId)
        {
            var product = await _context.DanhMucHangHoas.FindAsync(hangHoaId);


            var hanghoaViewModel = new HangHoaVm()
            {
                MaHangHoa = product.MaHangHoa,
                TenHangHoa = product.TenHangHoa,
                DonViTinh = product.DonViTinh,
                MaNhomHang = product.MaNhomHang,
                TenNhomHang = product.TenNhomHang,
                QuyCach = product.QuyCach,
                TyTrong = product.TyTrong,
                DonGia = product.DonGia,
                GiaNhap = product.GiaNhap,
                GiaXuat = product.GiaXuat,
                TyLeChietKhau = product.TyLeChietKhau,
                GiaBanLe = product.GiaBanLe,
                TyLeVat = product.TyLeVat,
                LoaiThue = product.LoaiThue,
                SoLuongToiThieu = product.SoLuongToiThieu,
                SoLuongToiDa = product.SoLuongToiDa,
                MaDonViSuDung = product.MaDonViSuDung,
                KhoRongTon = product.KhoRongTon,
                ChieuDai = product.ChieuDai,
                LoaiTon = product.LoaiTon,
                MauSac = product.MauSac,
                DoDay = product.DoDay,
                ChungLoai = product.ChungLoai,
                HangHoa = product.HangHoa,
            };
            return hanghoaViewModel;
        }
        public async Task<int> Update(HangHoaUpdateRequest request)
        {
            var hanghoa = await _context.DanhMucHangHoas.FindAsync(request.Id);

            if (hanghoa == null) throw new EShopException($"Cannot find a product with id: {request.Id}");

            hanghoa.MaHangHoa = request.MaHangHoa;
            hanghoa.TenHangHoa = request.TenHangHoa;
            hanghoa.DonViTinh = request.DonViTinh;
            hanghoa.MaNhomHang = request.MaNhomHang;
            hanghoa.TenNhomHang = request.TenNhomHang;
            hanghoa.QuyCach = request.QuyCach;
            hanghoa.TyTrong = request.TyTrong;
            hanghoa.DonGia = request.DonGia;
            hanghoa.GiaNhap = request.GiaNhap;
            hanghoa.GiaXuat = request.GiaXuat;
            hanghoa.TyLeChietKhau = request.TyLeChietKhau;
            hanghoa.GiaBanLe = request.GiaBanLe;
            hanghoa.TyLeVat = request.TyLeVat;
            hanghoa.LoaiThue = request.LoaiThue;
            hanghoa.SoLuongToiThieu = request.SoLuongToiThieu;
            hanghoa.SoLuongToiDa = request.SoLuongToiDa;
            hanghoa.MaDonViSuDung = request.MaDonViSuDung;
            hanghoa.KhoRongTon = request.KhoRongTon;
            hanghoa.ChieuDai = request.ChieuDai;
            hanghoa.LoaiTon = request.LoaiTon;
            hanghoa.MauSac = request.MauSac;
            hanghoa.DoDay = request.DoDay;
            hanghoa.ChungLoai = request.ChungLoai;
            hanghoa.HangHoa = request.HangHoa;
            hanghoa.NgayTao = DateTime.Now;
            
            return await _context.SaveChangesAsync();
        }

        
    }
}