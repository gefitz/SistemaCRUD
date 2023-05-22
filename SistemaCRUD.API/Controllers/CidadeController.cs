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
        [HttpGet]
        public async Task<IEnumerable<CidadeDTO>> SelectAll(int id)
        {
            return await _service.SelectAll(id);
        }
        [HttpGet("{id}")]
        public async Task<CidadeDTO> SelectId(int id)
        {
            return await _service.SelectById(id);
        }
        [HttpGet("IdEstado{id}")]
        public async Task<IEnumerable<CidadeDTO>> SelectIdEstado(int id)
        {
            return await _service.SelectIdEstado(id);
        }
    }
}
