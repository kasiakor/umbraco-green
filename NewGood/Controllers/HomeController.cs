using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace NewGood.Controllers
{
    public class HomeController : SurfaceController
    {
        public ActionResult RenderBanner()
        {
            return PartialView("~/Views/Partials/Home/_Banner.cshtml");
        }

        public ActionResult RenderIntro()
        {
            return PartialView("~/Views/Partials/Home/_Intro.cshtml");
        }

        public ActionResult RenderFeatured()
        {
            return PartialView("~/Views/Partials/Home/_Featured.cshtml");
        }

        public ActionResult RenderBlog()
        {
            return PartialView("~/Views/Partials/Home/_Blog.cshtml");
        }

        public ActionResult RenderTestimonials()
        {
            return PartialView("~/Views/Partials/Home/_Testimonials.cshtml");
        }
    }
}