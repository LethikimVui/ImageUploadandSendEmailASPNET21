using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.StoreProcedures
{
    public class SPImage
    {
        public static string GetAllImage = "SP_GetAllImage";
        public static string AddImage = "SP_AddImage @p0,@p1";
    }
}
