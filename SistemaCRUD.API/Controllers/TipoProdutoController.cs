using Microsoft.AspNetCore.Mvc;
using SistemaCRUD.API.DTOS;
using SistemaCRUD.API.Service.TipoProduto.Interface;

namespace SistemaCRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoProdutoController : ControllerBase
    {
        private readonly IServiceTipoProduto _service;

        public TipoProdutoController(IServiceTipoProduto service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Insert(TipoProdutoDTO tipoProduto)
        {
            if (tipoProduto is null)
                return BadRequest("Favor Inserir as informaçoes");
            await _service.Insert(tipoProduto);
            return Ok();
        }
        [HttpGet]
        public async Task<IEnumerable<TipoProdutoDTO>> SelectAll()
        {
            return await _service.SelectAll();
        }
        [HttpGet("{id}")]
        public async Task<TipoProdutoDTO> SelectId(int id)
        {
            return await _service.SelectId(id);
        }
        [HttpPut]
        public async Task<IActionResult> Updade(TipoProdutoDTO tipoProduto)
        {
            if (tipoProduto is null)
                return BadRequest("Favor Inserin as informações");
            await _service.Update(tipoProduto);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}
