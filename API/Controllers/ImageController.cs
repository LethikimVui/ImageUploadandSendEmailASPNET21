using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedObjects.Common;
using SharedObjects.StoreProcedures;
using SharedObjects.ValueObjects;
using SharedObjects.ViewModels;
using SharedObjects.Models;
using API.Models;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ImageController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet("get-all")]
        public async Task<List<VImage>> GetAll()
        {
            var result = await context.Query<VImage>().AsNoTracking().FromSql(SPImage.GetAllImage).ToListAsync();

            return result;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add( IImages model)
        {
            try
            {
                await context.Database.ExecuteSqlCommandAsync(SPImage.AddImage, model.Id, model.Link);
                return Ok(new ResponseResult(200));
            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseResult(400, ex.Message));
            }
        }
    }
}
