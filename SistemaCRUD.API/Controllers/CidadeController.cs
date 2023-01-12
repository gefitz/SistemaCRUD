using Microsoft.AspNetCore.Mvc;
using SistemaCRUD.API.DTOS;
using SistemaCRUD.API.Service.Cidade.Interface;

namespace SistemaCRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadeController : ControllerBase
    {
        private readonly IServiceCidade _service;

        public CidadeController(IServiceCidade service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Insert(CidadeDTO cidade)
        {
            if (cidade is null)
                return BadRequest("Favor Inserir as informaçoes ");
            await _service.Insert(cidade);
            return Ok();
        }
    }
}
