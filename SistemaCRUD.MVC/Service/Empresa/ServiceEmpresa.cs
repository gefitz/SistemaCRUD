using AutoMapper;
using Newtonsoft.Json;
using SistemaCRUD.MVC.Models;
using SistemaCRUD.MVC.Service.Empresa.Interface;
using System.Text;
using System.Text.Json;

namespace SistemaCRUD.MVC.Service.Empresa
{
    public class ServiceEmpresa : IServiceEmpresa
    {
        private readonly IHttpClientFactory _httpClient;
        private const string apiempresa = "/api/Empresa";
        private readonly JsonSerializerOptions _options;

        public ServiceEmpresa(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
            _options = new JsonSerializerOptions{ PropertyNameCaseInsensitive = true };
        }

        public async Task<bool> Delete(int id)
        {
            EmpresaModel empresas = new EmpresaModel();
            var client = _httpClient.CreateClient("ApiCRUD");
            using (var response = await client.DeleteAsync(apiempresa +"?id=" +id))
            {
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task Insert(EmpresaModel empresa)
        {
            var client = _httpClient.CreateClient("ApiCRUD");
            StringContent content = new StringContent(System.Text.Json.JsonSerializer.Serialize(empresa), Encoding.UTF8, "application/json");
            using(var response = await client.PostAsync(apiempresa, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    empresa = await System.Text.Json.JsonSerializer
                               .DeserializeAsync<EmpresaModel>(apiResponse, _options);
                }
            }
            
        }

        public async Task<IEnumerable<EmpresaModel>> SelectAll()
        {
            List<EmpresaModel> empresas = new List<EmpresaModel>();
            var client = _httpClient.CreateClient("ApiCRUD");
            using (var response = await client.GetAsync(apiempresa))
            {
                if (response.IsSuccessStatusCode)
                {
                    var jsonBody = await response.Content.ReadAsStringAsync();
                    empresas = JsonConvert.DeserializeObject<List<EmpresaModel>>(jsonBody);
                }
            }
            return empresas;
        }

        public async Task<EmpresaModel> SelectId(int id)
        {
            EmpresaModel empresas = new EmpresaModel();
            var client = _httpClient.CreateClient("ApiCRUD");
            using (var response = await client.GetAsync(apiempresa + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    var jsonBody = await response.Content.ReadAsStringAsync();
                    empresas = JsonConvert.DeserializeObject<EmpresaModel>(jsonBody);
                }
            }
            return empresas;
        }

        public async Task<bool> Update(EmpresaModel empresa)
        {
            var client = _httpClient.CreateClient("ApiCRUD");
            StringContent content = new StringContent(System.Text.Json.JsonSerializer.Serialize(empresa), Encoding.UTF8, "application/json");
            using (var response = await client.PutAsync(apiempresa, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
