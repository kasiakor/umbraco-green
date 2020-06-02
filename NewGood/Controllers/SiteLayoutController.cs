using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace NewGood
{
    public class SiteLayoutController : SurfaceController
    {
        public ActionResult RenderHeader()
        {
            return PartialView("~/Views/Partials/SiteLayout/_Header.cshtml");
        }
    }
}