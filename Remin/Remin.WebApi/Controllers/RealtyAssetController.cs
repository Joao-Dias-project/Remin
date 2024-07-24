using Microsoft.AspNetCore.Mvc;
using Remin.Application.Services.Contracts.ServiceContracts;
using Remin.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Remin.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealtyAssetController : ControllerBase
    {
        private readonly IRealtyAssetService _service;

        public RealtyAssetController(IRealtyAssetService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> RetrieveAll()
        {
            return Ok(await _service.RetrieveAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Retrieve(int id)
        {
            return Ok(await _service.Retrieve(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(RealtyAsset realtyAsset)
        {
            return Ok(await _service.Create(realtyAsset));
        }

        [HttpPut]
        public async Task<IActionResult> Update(RealtyAsset realtyAsset)
        {
            return Ok(await _service.Update(realtyAsset, realtyAsset.Id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }
    }
}
