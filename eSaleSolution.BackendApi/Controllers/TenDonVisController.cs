using eSaleSolution.Application.DanhMuc.TenDonVis;
using eSaleSolution.ViewModels.DanhMuc.TenDonVis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eSaleSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenDonVisController : Controller
    {
        private readonly ITenDonViService _tenDonViService;

        public TenDonVisController(ITenDonViService tenDonViService)
        {
            _tenDonViService = tenDonViService;
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetListPagging([FromQuery] GetTenDonViPagingRequest request)
        {
            var hanghoas = await _tenDonViService.GetAllPaging(request);
            return Ok(hanghoas);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var hanghoas = await _tenDonViService.GetById(Id);
            if (hanghoas == null)
                return BadRequest();
            return Ok(hanghoas);
        }


        [HttpPost]
        [Consumes("multipart/form-data")]
        [Authorize]
        public async Task<IActionResult> Create([FromForm] TenDonViCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var id = await _tenDonViService.Create(request);
            if (id == 0)
                return BadRequest();

            var hanghoa = await _tenDonViService.GetById(id);

            return CreatedAtAction(nameof(GetById), new { id = id }, hanghoa);
        }

        [HttpPut("{Id}")]
        [Consumes("multipart/form-data")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int Id, [FromForm] TenDonViUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            request.Id = Id;
            var affectedResult = await _tenDonViService.Update(request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("{Id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int Id)
        {
            var affectedResult = await _tenDonViService.Delete(Id);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }

    }
}
