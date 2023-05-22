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

        [HttpGet("{id}")]

        public async Task<EstadoDTO> GetId(int id)
        {
            return await _service.GetId(id);
        }
    }
}
