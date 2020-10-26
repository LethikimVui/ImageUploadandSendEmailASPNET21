using SharedObjects.Common;
using SharedObjects.Models;
using SharedObjects.ValueObjects;
using SharedObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IImageServices
    {
        Task<List<VImage>> GetAll();
        Task<ResponseResult> AddImage(IImages model);

    }
}
