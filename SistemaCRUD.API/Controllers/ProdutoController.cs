using Microsoft.AspNetCore.Mvc;
using SistemaCRUD.API.DTOS;
using SistemaCRUD.API.Service.Produto.Interface;

namespace SistemaCRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IServiceProduto _service;

        public ProdutoController(IServiceProduto service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Insert(ProdutoDTO produto)
        {
            if (produto is null)
                return BadRequest("Favor inserir as Informações");
            await _service.Insert(produto);
            return Ok();
        }
        [HttpGet]
        public async Task<IEnumerable<ProdutoDTO>> GetAll()
        {
            return await _service.SelectAll();
        }
        [HttpGet("{id}")]
        public async Task<ProdutoDTO> GetId(int id)
        {
            return await _service.SelectId(id);
        }
        [HttpPut]
        public async Task<IActionResult> Update(ProdutoDTO produto)
        {
            if (produto is null)
                return BadRequest("Favor inserir as Informações");
            if (await _service.Update(produto))
                return Ok();
            return BadRequest("Infelizmente não foi possivel atualizar essas informãções no banco");
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}
