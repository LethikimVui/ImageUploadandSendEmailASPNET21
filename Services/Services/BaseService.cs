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
            //HttpClientHandler clienthandler = new HttpClientHandler();
            //clienthandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslpolicyerrors) => { return true; };
            //httpClient = new HttpClient(clienthandler);
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://vnhcmm0teapp02/image/");
            //httpClient.BaseAddress = new Uri("http://localhost:63979/");



        }
    }
}
