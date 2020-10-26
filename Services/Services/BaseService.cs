using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class BaseService
    {
        protected HttpClient httpClient = null;

        public BaseService()
        {
            //HttpClientHandler clientHandler = new HttpClientHandler();
            //clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            //httpClient = new HttpClient(clientHandler);
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:63979/");

        }
    }
}
