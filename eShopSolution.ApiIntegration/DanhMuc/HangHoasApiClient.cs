using eShopSolution.Utilities.Constants;
using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.DanhMuc.HangHoas;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.ApiIntegration
{
    public class HangHoasApiClient : BaseApiClient, IHangHoasApiClient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public HangHoasApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> CreateHangHoa(HangHoaCreateRequest request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

            var languageId = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();


            requestContent.Add(new StringContent(request.MaHangHoa.ToString()), "MaHangHoa");
            requestContent.Add(new StringContent(request.TenHangHoa.ToString()), "TenHangHoa");
            requestContent.Add(new StringContent(request.DonViTinh.ToString()), "DonViTinh");
            requestContent.Add(new StringContent(request.MaNhomHang.ToString()), "MaNhomHang");
            requestContent.Add(new StringContent(request.TenNhomHang.ToString()), "TenNhomHang");
            requestContent.Add(new StringContent(request.TyTrong.ToString()), "TyTrong");
            requestContent.Add(new StringContent(request.DonGia.ToString()), "DonGia");
            requestContent.Add(new StringContent(request.GiaNhap.ToString()), "GiaNhap");
            requestContent.Add(new StringContent(request.GiaXuat.ToString()), "GiaXuat");
            requestContent.Add(new StringContent(request.TyLeChietKhau.ToString()), "TyLeChietKhau");
            requestContent.Add(new StringContent(request.GiaBanLe.ToString()), "GiaBanLe");
            requestContent.Add(new StringContent(request.TyLeVat.ToString()), "TyLeVat");
            requestContent.Add(new StringContent(request.LoaiThue.ToString()), "LoaiThue");
            requestContent.Add(new StringContent(request.SoLuongToiThieu.ToString()), "SoLuongToiThieu");
            requestContent.Add(new StringContent(request.SoLuongToiDa.ToString()), "SoLuongToiDa");
            requestContent.Add(new StringContent(request.MaDonViSuDung.ToString()), "MaDonViSuDung");
            requestContent.Add(new StringContent(request.KhoRongTon.ToString()), "KhoRongTon");
            requestContent.Add(new StringContent(request.LoaiTon.ToString()), "LoaiTon");
            requestContent.Add(new StringContent(request.MauSac.ToString()), "MauSac");
            requestContent.Add(new StringContent(request.DoDay.ToString()), "DoDay");
            requestContent.Add(new StringContent(request.ChungLoai.ToString()), "ChungLoai");
            requestContent.Add(new StringContent(request.HangHoa.ToString()), "HangHoa");

            var response = await client.PostAsync($"/api/hanghoas/", requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateHangHoa(HangHoaUpdateRequest request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

            var languageId = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();

            requestContent.Add(new StringContent(request.MaHangHoa.ToString()), "MaHangHoa");
            requestContent.Add(new StringContent(request.TenHangHoa.ToString()), "TenHangHoa");
            requestContent.Add(new StringContent(request.DonViTinh.ToString()), "DonViTinh");
            requestContent.Add(new StringContent(request.MaNhomHang.ToString()), "MaNhomHang");
            requestContent.Add(new StringContent(request.TenNhomHang.ToString()), "TenNhomHang");
            requestContent.Add(new StringContent(request.TyTrong.ToString()), "TyTrong");
            requestContent.Add(new StringContent(request.DonGia.ToString()), "DonGia");
            requestContent.Add(new StringContent(request.GiaNhap.ToString()), "GiaNhap");
            requestContent.Add(new StringContent(request.GiaXuat.ToString()), "GiaXuat");
            requestContent.Add(new StringContent(request.TyLeChietKhau.ToString()), "TyLeChietKhau");
            requestContent.Add(new StringContent(request.GiaBanLe.ToString()), "GiaBanLe");
            requestContent.Add(new StringContent(request.TyLeVat.ToString()), "TyLeVat");
            requestContent.Add(new StringContent(request.LoaiThue.ToString()), "LoaiThue");
            requestContent.Add(new StringContent(request.SoLuongToiThieu.ToString()), "SoLuongToiThieu");
            requestContent.Add(new StringContent(request.SoLuongToiDa.ToString()), "SoLuongToiDa");
            requestContent.Add(new StringContent(request.MaDonViSuDung.ToString()), "MaDonViSuDung");
            requestContent.Add(new StringContent(request.KhoRongTon.ToString()), "KhoRongTon");
            requestContent.Add(new StringContent(request.LoaiTon.ToString()), "LoaiTon");
            requestContent.Add(new StringContent(request.MauSac.ToString()), "MauSac");
            requestContent.Add(new StringContent(request.DoDay.ToString()), "DoDay");
            requestContent.Add(new StringContent(request.ChungLoai.ToString()), "ChungLoai");
            requestContent.Add(new StringContent(request.HangHoa.ToString()), "HangHoa");

            var response = await client.PutAsync($"/api/hanghoas/" + request.Id, requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<PagedResult<HangHoaVm>> GetPagings(GetHangHoaPagingRequest request)
        {
            var data = await GetAsync<PagedResult<HangHoaVm>>(
                $"/api/hanghoas/paging?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}");
                 

            return data;
        }

        public async Task<HangHoaVm> GetById(int id)
        {
            var data = await GetAsync<HangHoaVm>($"/api/hanghoas/{id}");

            return data;
        }
  
        public async Task<bool> DeleteHangHoa(int id)
        {
            return await Delete($"/api/hanghoas/" + id);
        }
    }
}