using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;
using System.Web.Mvc;

namespace InstaForexAPIServices.Controllers.Route
{
    public class IFXGameController : Controller
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public RedirectResult RedirectToSwaggerUi()
        {
            return Redirect("/swagger/ui/index?filter=Lesson");
        }
    }
}
