using System;
using System.Text;
using System.Web.Mvc;

namespace vkDialogViewer.Controllers
{
    public class BaseController : Controller
    {
        protected override JsonResult Json(object data, string contentType,Encoding encoding,  JsonRequestBehavior behavior)
        {
           return new JsonResult()
            {
                Data = data,
                ContentType = "application/json;charset=UTF-8",
                ContentEncoding = Encoding.UTF8,
                JsonRequestBehavior = behavior,
                MaxJsonLength = Int32.MaxValue
            };
        }
    }
}
