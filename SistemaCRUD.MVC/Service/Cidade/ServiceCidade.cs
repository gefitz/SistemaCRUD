using Newtonsoft.Json;
using SistemaCRUD.MVC.Models;
using SistemaCRUD.MVC.Service.Cidade.Interface;

namespace SistemaCRUD.MVC.Service.Cidade
{
    public class ServiceCidade : IServiceCidade
    {
        private readonly IHttpClientFactory _httpClient;
        private const string apicidades = "/api/Cidade";

        public ServiceCidade(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CidadeModel>> GetCidadeList(int id)
        {
            var client = _httpClient.CreateClient("ApiCRUD");
            List<CidadeModel> cidades = new List<CidadeModel>();
            using (var response = await client.GetAsync(apicidades+ "?id="+ id))
            {
                if (response.IsSuccessStatusCode)
                {
                    CidadeModel cidade = new CidadeModel();
                    var jsonBody = await response.Content.ReadAsStringAsync();
                    cidades = JsonConvert.DeserializeObject<List<CidadeModel>>(jsonBody); ;
                }
            }
            return cidades;
        }
    }
}
