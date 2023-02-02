using Microsoft.AspNetCore.Mvc;
using SistemaCRUD.API.DTOS;
using SistemaCRUD.API.Service.Empresa.Interface;

namespace SistemaCRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IServiceEmpresa _service;

        public EmpresaController(IServiceEmpresa service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Insert(EmpresaDTO empresa)
        {
            if (empresa is null)
                return BadRequest("Favor inserir as Informações");
            await _service.Insert(empresa);
            return Ok();
        }
        [HttpGet]
        public async Task<IEnumerable<EmpresaDTO>> GetAll()
        {
            return await _service.SelectAll();
        }
        [HttpGet("{id}")]
        public async Task<EmpresaDTO> GetId(int id)
        {
            return await _service.SelectId(id);
        }
        [HttpPut]
        public async Task<IActionResult> Update(EmpresaDTO empresa)
        {
            if(empresa is null)
                return BadRequest("Favor inserir as Informações");
            if (await _service.Update(empresa))
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
