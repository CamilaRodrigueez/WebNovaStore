
using Common.Utils.Constant;
using Domain.DTO;
using Domain.DTO.Account;
using Domain.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class RestServices: IRestServices
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;
        private string _basePath;
        
        public RestServices(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
                _httpClientFactory = httpClientFactory;
                _config = config;
                _basePath = config.GetSection("ApiNovaSoft").GetSection("UrlBaseApi").Value;
        }
        private async Task<string> EnviarAsync(HttpMethod method,string url, string jsonRequest = null, string token = "")
        {
            var peticion = new HttpRequestMessage(method, url);

            if (!string.IsNullOrEmpty(jsonRequest))
            {
                peticion.Content = new StringContent(jsonRequest, Encoding.UTF8, Const.MEDIA_TYPE_JSON);
            }
            

            var cliente = _httpClientFactory.CreateClient();
            //Aquí valida el token
            if (token != null && token.Length != 0)
            {
                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
            HttpResponseMessage response = await cliente.SendAsync(peticion);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return null;
            }

        }

        private async Task<string> GenerarToken()
        {
            string urlLogin = _config.GetSection("ApiNovaSoft").GetSection("RutaLogin").Value;
            var parameters = new
            {
                userLogin = Credential.USER_LOGIN,
                password =Credential.PASSWORD,
                connectionName =Credential.CONECTION_NAME
            };
            string jsonRequest = JsonConvert.SerializeObject(parameters);
            string responseBodyString = await EnviarAsync(HttpMethod.Post, _basePath+urlLogin, jsonRequest);

            if (responseBodyString.Contains("token"))
            {
                TokenDto obj = JsonConvert.DeserializeObject<TokenDto>(responseBodyString);
                string token = obj.token;
                return token;
            }
            return responseBodyString;
        }

        public async Task<List<AccountsParams>> GetAllAccounts()
        {
            IEnumerable<AccountsParams> listAccounts = null;
            string urlAccounts = _config.GetSection("ApiNovaSoft").GetSection("RutaAccounts").Value;
            string token = await GenerarToken();
            var result = await EnviarAsync(HttpMethod.Get, _basePath + urlAccounts, null, token);
            if (result != null)
            {
                listAccounts = JsonConvert.DeserializeObject<IEnumerable<AccountsParams>>(result);
            }
            return listAccounts.ToList();
        }

        public async Task<GenericResponse> CreateAccountAsync(List<AccountsParams> accountsParamsInsert)
        {
            GenericResponse genericResponse = new GenericResponse();
            string urlAccounts = _config.GetSection("ApiNovaSoft").GetSection("RutaAccounts").Value;
            string token = await GenerarToken();
            string jsonRequest = JsonConvert.SerializeObject(accountsParamsInsert);
            var result = await EnviarAsync(HttpMethod.Post, _basePath + urlAccounts, jsonRequest, token);
            if (result != null)
            {
                genericResponse = JsonConvert.DeserializeObject<GenericResponse>(result);
                return genericResponse;

            }
            return genericResponse;
        }

    }
}
