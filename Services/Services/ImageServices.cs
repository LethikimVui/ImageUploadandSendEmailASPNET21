using Newtonsoft.Json;
using Services.Interfaces;
using SharedObjects.Common;
using SharedObjects.Models;
using SharedObjects.ValueObjects;
using SharedObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ImageServices : BaseService, IImageServices
    {
        public async Task<ResponseResult> AddImage(IImages model)
        {
            ResponseResult responseResult = new ResponseResult();
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            using (var response = await httpClient.PostAsync("api/Image/add", content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                responseResult = JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
            }
            return responseResult;
        }

        public async Task<List<VImage>> GetAll()
        {
            List<VImage> images = new List<VImage>();

            using (var response = await httpClient.GetAsync("api/Image/get-all"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                images = JsonConvert.DeserializeObject<List<VImage>>(apiResponse);
            }
            return images;
        }
    }
}
