using eShopSolution.ApiIntegration;
using eShopSolution.Utilities.Constants;
using eShopSolution.ViewModels.DanhMuc.HangHoas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.AdminApp.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly IHangHoasApiClient _hanghoaApiClient;
        private readonly IConfiguration _configuration;

        private readonly ICategoryApiClient _categoryApiClient;

        public HangHoaController(IHangHoasApiClient hanghoaApiClient,
            IConfiguration configuration,
            ICategoryApiClient categoryApiClient)
        {
            _configuration = configuration;
            _hanghoaApiClient = hanghoaApiClient;
            _categoryApiClient = categoryApiClient;
        }

        public async Task<IActionResult> Index(string mahanghoa, string tenhanghoa, string donvitinh, int pageIndex = 1, int pageSize = 10)
        {
           
            var request = new GetHangHoaPagingRequest()
            {
                MaHangHoa = mahanghoa,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TenHangHoa = tenhanghoa,
                DonViTinh = donvitinh
            };
            var data = await _hanghoaApiClient.GetPagings(request);
            ViewBag.MaHangHoa = mahanghoa;
            ViewBag.TenHangHoa = tenhanghoa;
            ViewBag.DonViTinh = donvitinh;

            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data);
        }

        [HttpGet]
        public IActionResult Create(string madonvisudung)
        {
            ViewBag.MaDonViSuDung = madonvisudung;
            return View();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] HangHoaCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _hanghoaApiClient.CreateHangHoa(request);
            if (result)
            {
                TempData["result"] = "Thêm mới hàng hóa thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm hàng hóa thất bại");
            return View(request);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {


            var product = await _hanghoaApiClient.GetById(id);
            var editVm = new HangHoaUpdateRequest()
            {
                Id = product.Id,
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
            return View(editVm);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit([FromForm] HangHoaUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _hanghoaApiClient.UpdateHangHoa(request);
            if (result)
            {
                TempData["result"] = "Cập nhật Hàng hóa thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Cập nhật Hàng hóa thất bại");
            return View(request);
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(new HangHoaDeleteRequest()
            {
                Id = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(HangHoaDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _hanghoaApiClient.DeleteHangHoa(request.Id);
            if (result)
            {
                TempData["result"] = "Xóa sản phẩm thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Xóa không thành công");
            return View(request);
        }
    }
}
