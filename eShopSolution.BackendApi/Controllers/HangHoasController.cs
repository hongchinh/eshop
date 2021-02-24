using eShopSolution.Application.DanhMuc.HangHoas;
using eShopSolution.ViewModels.DanhMuc.HangHoas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eShopSolution.BackendApi.Controllers
{
    public class HangHoasController : Controller
    {
        private readonly IHangHoaService _hangHoaService;

        public HangHoasController(IHangHoaService hangHoaService)
        {
            _hangHoaService = hangHoaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetListPagging([FromQuery] GetHangHoaPagingRequest request)
        {
            var hanghoas = await _hangHoaService.GetAllPaging(request);
            return Ok(hanghoas);
        }

        [HttpGet("{hanghoaId}")]
        public async Task<IActionResult> GetById(int hanghoaId)
        {
            var hanghoas = await _hangHoaService.GetById(hanghoaId);
            if (hanghoas == null)
                return BadRequest();
            return Ok(hanghoas);
        }


        [HttpPost]
        [Consumes("multipart/form-data")]
        [Authorize]
        public async Task<IActionResult> Create([FromForm] HangHoaCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var hanghoaId = await _hangHoaService.Create(request);
            if (hanghoaId == 0)
                return BadRequest();

            var hanghoa = await _hangHoaService.GetById(hanghoaId);

            return CreatedAtAction(nameof(GetById), new { id = hanghoaId }, hanghoa);
        }

        [HttpPut("{hanghoaId}")]
        [Consumes("multipart/form-data")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int hanghoaId, [FromForm] HangHoaUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            request.Id = hanghoaId;
            var affectedResult = await _hangHoaService.Update(request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("{hanghoaId}")]
        [Authorize]
        public async Task<IActionResult> Delete(int hanghoaId)
        {
            var affectedResult = await _hangHoaService.Delete(hanghoaId);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }

    }
}
