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
                return BadRequest("Favor Inserir as informaçoes");
            await _service.Insert(cidade);
            return Ok();
        }
        [HttpGet]
        public async Task<IEnumerable<CidadeDTO>> SelectAll()
        {
            return await _service.SelectAll();
        }
        [HttpGet("{id}")]
        public async Task<CidadeDTO> SelectId(int id)
        {
            return await _service.SelectById(id);
        }
        [HttpPut]
        public async Task<IActionResult> Updade(CidadeDTO cidade)
        {
            if (cidade is null)
                return BadRequest("Favor Inserin as informações");
            await _service.Update(cidade);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult>Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}
