using Newtonsoft.Json;
using SoftGallery.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftGallery.Dominio.Servicos
{
    public class ProdutoServico
    {

        private readonly HttpClient _httpClient;
        private string _token;
        private DateTime _tokenExpiracao;

        public ProdutoServico(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private async Task<string> ObterToken()
        {
            if (!string.IsNullOrEmpty(_token) && DateTime.UtcNow < _tokenExpiracao)
            {
                return _token;
            }

            var login = new
            {
                Grupo = "unimar",
                Login = "unimar",
                Senha = "unimar"
            };

            var content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "aplication/json");
            var response = await _httpClient.PostAsync("https://production.bredasapi.com.br/overall/auth/usuario", content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Falha ao autenticar na API");
            }

            var responseJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AuthResponse>(responseJson);
            _token = result.Data.AccessToken;
            _tokenExpiracao = result.Data.ExpireDate;

            return _token;
           
        }

        public async Task<List<Produto>> ObterProdutoComSecao()
        {

        }
    }
}
