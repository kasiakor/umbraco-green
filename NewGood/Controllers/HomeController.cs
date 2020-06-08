using NewGood.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Mvc;
using System.Linq;
using Archetype;
using Archetype.Models;

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
           List<FeaturedItem> model = new List<FeaturedItem> ();
            IPublishedContent homePage = CurrentPage.AncestorOrSelf(1).DescendantsOrSelf().Where(x => x.DocumentTypeAlias == "home").FirstOrDefault();

            //Get property from the homepage
            //From ArchetypeMode model get all the fieldsets and put them into FeaturedItem class
            ArchetypeModel featuredItems = homePage.GetPropertyValue<ArchetypeModel>("featuredItems");

            foreach(ArchetypeFieldsetModel fieldset in featuredItems)
            {

                string name = fieldset.GetValue<string>("name");
                string category = fieldset.GetValue<string>("category");

                //imageUrl
                int imageId = fieldset.GetValue<int>("image");
                //gets the value of media picker
                var mediaItem = Umbraco.Media(imageId);
                string imageUrl = mediaItem.Url;


                //linkUrl
                int pageId = fieldset.GetValue<int>("page");
                IPublishedContent page = Umbraco.TypedContent(pageId);
                string linkUrl = page.Url;


                model.Add(new FeaturedItem(name, category, imageUrl, linkUrl));
            }
            return PartialView("~/Views/Partials/Home/_Featured.cshtml", model);
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