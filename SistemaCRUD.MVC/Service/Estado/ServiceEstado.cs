using Newtonsoft.Json;
using SistemaCRUD.MVC.Models;
using SistemaCRUD.MVC.Service.Estado.Interface;
using System.Net.Http;

namespace SistemaCRUD.MVC.Service.Estado
{
    public class ServiceEstado : IServiceEstado
    {
        private readonly IHttpClientFactory _httpClient;
        private const string apiestados = "/api/Estado/";

        public ServiceEstado(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;

        }

        public async Task<IEnumerable<EstadoModel>> GetAll()
        {
            var client = _httpClient.CreateClient("ApiCRUD");
            List<EstadoModel> estados = new List<EstadoModel>();
            using (var response = await client.GetAsync(apiestados))
            {
                if (response.IsSuccessStatusCode)
                {
                    var jsonBody = await response.Content.ReadAsStringAsync();
                    estados = JsonConvert.DeserializeObject<List<EstadoModel>>(jsonBody);
                }
            }
            return estados;
        }

        public async Task<EstadoModel> GetId(int id)
        {
            return null; //await _estadoData.Select(id);
        }
    }
}
