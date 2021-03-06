using AutoMapper;
using eSaleSolution.ApiIntegration;
using eSaleSolution.Utilities.Constants;
using eSaleSolution.ViewModels.DanhMuc.TenDonVis;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eSaleSolution.AdminApp.Controllers
{
    public class TenDonViController : Controller
    {
        private readonly ITenDonVisApiClient _tendonviApiClient;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ICategoryApiClient _categoryApiClient;

        public TenDonViController(ITenDonVisApiClient hanghoaApiClient,
            IConfiguration configuration,
            ICategoryApiClient categoryApiClient,
            IMapper mapper)
        {
            _configuration = configuration;
            _tendonviApiClient = hanghoaApiClient;
            _categoryApiClient = categoryApiClient;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
           
            var request = new GetTenDonViPagingRequest()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Keyword = keyword,
               
            };
            var data = await _tendonviApiClient.GetPagings(request);
            ViewBag.Keyword = keyword;

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
        public async Task<IActionResult> Create([FromForm] TenDonViCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _tendonviApiClient.Create(request);
            if (result)
            {
                TempData["result"] = "Thêm mới đơn vị thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm  đơn vị thất bại");
            return View(request);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _tendonviApiClient.GetById(id);
           
            return View(item);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit([FromForm] TenDonViUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _tendonviApiClient.Update(request);
            if (result)
            {
                TempData["result"] = "Cập nhật Đơn vi thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Cập nhật Đơn vi thất bại");
            return View(request);
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(new TenDonViDeleteRequest()
            {
                Id = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TenDonViDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _tendonviApiClient.Delete(request.Id);
            if (result)
            {
                TempData["result"] = "Xóa đơn vị thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Xóa không thành công");
            return View(request);
        }
    }
}
