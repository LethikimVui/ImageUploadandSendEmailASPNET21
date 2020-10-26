using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.ValueObjects
{
    public class VImage
    {
        [Display(Name = "SAP")]
        public string Id { get; set; }
        [Display(Name = "Image")]
        public string Link { get; set; }
    }
}
