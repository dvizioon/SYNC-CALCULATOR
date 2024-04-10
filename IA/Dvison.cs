using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Calculadora_C_.DvisonIa
{
    partial class OpenIa
    {
        private readonly HttpClient _httpClient;

        public OpenIa()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://127.0.0.1:5000/api/"); // Substitua pelo endereço correto da sua API
        }

        public async Task<string> EnviarAlturaEPeso(string altura, string peso)
        {
            try
            {
                // Construir o objeto JSON com altura e peso
                var requestData = new
                {
                    altura = altura,
                    peso = peso
                };

                // Serializar o objeto em JSON
                string jsonRequest = Newtonsoft.Json.JsonConvert.SerializeObject(requestData);

                // Criar o conteúdo da requisição POST
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                // Fazer a requisição HTTP POST para a URL da API
                HttpResponseMessage response = await _httpClient.PostAsync("question", content);

                // Verificar se a requisição foi bem-sucedida
                if (response.IsSuccessStatusCode)
                {
                    // Ler e retornar o conteúdo da resposta como uma string
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    // Retornar uma mensagem de erro caso a requisição não seja bem-sucedida
                    return $"Erro: {response.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                // Capturar e retornar qualquer exceção ocorrida durante a requisição
                return $"Erro: {ex.Message}";
            }
        }
    }
}
