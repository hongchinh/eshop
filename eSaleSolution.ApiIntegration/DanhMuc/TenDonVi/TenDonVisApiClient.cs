using eSaleSolution.Utilities.Constants;
using eSaleSolution.ViewModels.Catalog.Products;
using eSaleSolution.ViewModels.Common;
using eSaleSolution.ViewModels.DanhMuc.TenDonVis;
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

namespace eSaleSolution.ApiIntegration
{
    public class TenDonVisApiClient : BaseApiClient, ITenDonVisApiClient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public TenDonVisApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> Create(TenDonViCreateRequest request)
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

            requestContent.Add(new StringContent(request.MaDonVi.ToString()), "MaDonVi");
            requestContent.Add(new StringContent(request.TenDonVi.ToString()), "TenDonVi");
            requestContent.Add(new StringContent(request.DiaChi.ToString()), "DiaChi");
            requestContent.Add(new StringContent(request.DienThoai.ToString()), "DienThoai");
            requestContent.Add(new StringContent(request.Email.ToString()), "Email");
            requestContent.Add(new StringContent(request.TenNhom.ToString()), "TenNhom");
            requestContent.Add(new StringContent(request.Website.ToString()), "Website");
            requestContent.Add(new StringContent(request.MaSoThue.ToString()), "MaSoThue");
            requestContent.Add(new StringContent(request.SoTaiKhoan.ToString()), "SoTaiKhoan");
            requestContent.Add(new StringContent(request.NoiMoTaiKhoan.ToString()), "NoiMoTaiKhoan");
            requestContent.Add(new StringContent(request.MaNhom.ToString()), "MaNhom");
            requestContent.Add(new StringContent(request.TenNhom.ToString()), "TenNhom");
            requestContent.Add(new StringContent(request.MaTinh.ToString()), "MaTinh");
            requestContent.Add(new StringContent(request.TenTinh.ToString()), "TenTinh");
            requestContent.Add(new StringContent(request.MaQuanLy.ToString()), "MaQuanLy");
            requestContent.Add(new StringContent(request.MaDonViSuDung.ToString()), "MaDonViSuDung");
            requestContent.Add(new StringContent(request.TenQuanLy.ToString()), "TenQuanLy");
            requestContent.Add(new StringContent(request.MaKhuVuc.ToString()), "MaKhuVuc");
            requestContent.Add(new StringContent(request.TenKhuVuc.ToString()), "TenKhuVuc");
            requestContent.Add(new StringContent(request.HanMucThanhToan.ToString()), "HanMucThanhToan");

            var response = await client.PostAsync($"/api/TenDonVis/", requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Update(TenDonViUpdateRequest request)
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

            requestContent.Add(new StringContent(request.MaDonVi.ToString()), "MaDonVi");
            requestContent.Add(new StringContent(request.TenDonVi.ToString()), "TenDonVi");
            requestContent.Add(new StringContent(request.DiaChi.ToString()), "DiaChi");
            requestContent.Add(new StringContent(request.DienThoai.ToString()), "DienThoai");
            requestContent.Add(new StringContent(request.Email.ToString()), "Email");
            requestContent.Add(new StringContent(request.TenNhom.ToString()), "TenNhom");
            requestContent.Add(new StringContent(request.Website.ToString()), "Website");
            requestContent.Add(new StringContent(request.MaSoThue.ToString()), "MaSoThue");
            requestContent.Add(new StringContent(request.SoTaiKhoan.ToString()), "SoTaiKhoan");
            requestContent.Add(new StringContent(request.NoiMoTaiKhoan.ToString()), "NoiMoTaiKhoan");
            requestContent.Add(new StringContent(request.MaNhom.ToString()), "MaNhom");
            requestContent.Add(new StringContent(request.TenNhom.ToString()), "TenNhom");
            requestContent.Add(new StringContent(request.MaTinh.ToString()), "MaTinh");
            requestContent.Add(new StringContent(request.TenTinh.ToString()), "TenTinh");
            requestContent.Add(new StringContent(request.MaQuanLy.ToString()), "MaQuanLy");
            requestContent.Add(new StringContent(request.MaDonViSuDung.ToString()), "MaDonViSuDung");
            requestContent.Add(new StringContent(request.TenQuanLy.ToString()), "TenQuanLy");
            requestContent.Add(new StringContent(request.MaKhuVuc.ToString()), "MaKhuVuc");
            requestContent.Add(new StringContent(request.TenKhuVuc.ToString()), "TenKhuVuc");
            requestContent.Add(new StringContent(request.HanMucThanhToan.ToString()), "HanMucThanhToan");

            var response = await client.PutAsync($"/api/tendonvis/" + request.Id, requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<PagedResult<TenDonViVm>> GetPagings(GetTenDonViPagingRequest request)
        {
            var data = await GetAsync<PagedResult<TenDonViVm>>(
                $"/api/tendonvis/paging?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}");
            return data;
        }

        public async Task<TenDonViVm> GetById(int id)
        {
            var data = await GetAsync<TenDonViVm>($"/api/tendonvis/{id}");

            return data;
        }
  
        public async Task<bool> Delete(int id)
        {
            return await Delete($"/api/tendonvis/" + id);
        }
    }
}