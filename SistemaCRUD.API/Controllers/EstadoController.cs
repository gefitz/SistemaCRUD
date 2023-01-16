using Microsoft.AspNetCore.Mvc;
using SistemaCRUD.API.DTOS;
using SistemaCRUD.API.Service.Estado.Interface;

namespace SistemaCRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly IServiceEstado _service;

        public EstadoController(IServiceEstado service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<EstadoDTO>> GetAll()
        {

            return await _service.GetAll();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(EstadoDTO estado)
        {
            if (await _service.Insert(estado))
            {
                return Ok();
            }
            var listEstados = await _service.GetAll();
            foreach (var item in listEstados)
            {
                if (item.Nome.Equals(estado.Nome) || item.Sigla.Equals(estado.Sigla))
                {
                    estado.IdEstado = item.IdEstado;
                    estado.Nome = item.Nome;
                    estado.Sigla = item.Sigla;
                }

            }
            return Ok(estado);
            
        }
        [HttpGet("{id}")]

        public async Task<EstadoDTO> GetId(int id)
        {
            return await _service.GetId(id);
        }
        [HttpPut]
        public async Task<IActionResult> PutEstado([FromBody] EstadoDTO estado)
        {
            if (estado is null)
            {
                BadRequest();
            }
            await _service.Update(estado);
            return Ok(estado);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok("Succes");
        }
    }
}
