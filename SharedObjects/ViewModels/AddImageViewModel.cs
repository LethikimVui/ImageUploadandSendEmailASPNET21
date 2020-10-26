using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.ViewModels
{
    public class AddImageViewModel
    {
        [Required(ErrorMessage = "Please enter Id")]
        [Display(Name = "Id")]
        public string Id { get; set; }
        [Required(ErrorMessage = "Please select Link")]
        [Display(Name = "Image")]
        //[FileExtensions(Extensions = "png,jpg,jpeg,gif")]
        public IFormFile Link { get; set; }
    }
}
