using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace NewGood.Controllers
{
    public class HomeController : SurfaceController
    {
        public ActionResult RenderFeatured()
        {
            return PartialView("~/Views/Partials/Home/_Featured.cshtml");
        }
    }
}