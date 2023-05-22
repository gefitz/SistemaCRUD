using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaCRUD.MVC.Models;
using SistemaCRUD.MVC.Service.Cidade.Interface;
using SistemaCRUD.MVC.Service.Empresa.Interface;
using SistemaCRUD.MVC.Service.Estado.Interface;

namespace SistemaCRUD.MVC.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly ILogger<EmpresaController> _logger;
        private readonly IServiceEstado _estadoservice;
        private readonly IServiceEmpresa _service;
        private readonly IServiceCidade _cidadeService;

        public EmpresaController(ILogger<EmpresaController> logger, IServiceEstado estadoService, IServiceEmpresa service, IServiceCidade cidade)
        {
            _logger = logger;
            _estadoservice = estadoService;
            _service = service;
            _cidadeService = cidade;

        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<EmpresaModel> empresas = await _service.SelectAll();
            return View(empresas);
        }
        [HttpGet]
        public async Task<IActionResult> Cadastrar(int id)
        {
            EmpresaModel empresa = new EmpresaModel();
            //Verefica e Busca empresa
            if (id != 0)
            {
                empresa = await _service.SelectId(id);
                empresa.IdEstado = empresa.Cidade.Estado.IdEstado;
                empresa.IdCidade = empresa.Cidade.IdCidade;
                var estados = await _estadoservice.GetAll();
                ViewBag.Estados = new SelectList(estados, "IdEstado", "Nome");
                var cidade = await _cidadeService.GetCidadeList(empresa.IdEstado);
                ViewBag.Cidades = new SelectList(cidade, "IdCidade", "Nome");
            }
            else
            {

                //Coloca uma Lista de estados para ser chamado no Select no HTML
                var estados = await _estadoservice.GetAll();
                if (estados.Any())
                {
                    ViewBag.Estados = new SelectList(estados, "IdEstado", "Nome");
                }

                else
                    ViewBag.Estados = null;
            }

            return View(empresa);
        }
        [HttpPost]
        public async Task<IActionResult> Cadastrar(EmpresaModel empresa)
        {
            if (ModelState.IsValid)
            {
                _service.Insert(empresa);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var estados = await _estadoservice.GetAll();
                if (estados.Any())
                    ViewBag.Estados = new SelectList(estados, "IdEstado", "Nome");
            }
            return View(empresa);
        }
        [HttpPost]
        public async Task<IActionResult> Update(EmpresaModel empresa)
        {
            if (ModelState.IsValid)
            {
               await _service.Update(empresa);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                Cadastrar(empresa.IdEmpresa);
            }
            return View(empresa);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _service.Delete(id))
                return RedirectToAction(nameof(Index));

            return BadRequest();
        }
    }
}
