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
            List<FeaturedItem> model = new List<FeaturedItem>();
            //IPublishedContent homePage = CurrentPage.AncestorOrSelf(1).DescendantsOrSelf().Where(x => x.DocumentTypeAlias == "home").FirstOrDefault();
            IPublishedContent homePage = CurrentPage.AncestorOrSelf("home");

            //Get property from the homepage
            //From ArchetypeMode model get all the fieldsets and put them into FeaturedItem class
            ArchetypeModel featuredItems = homePage.GetPropertyValue<ArchetypeModel>("featuredItems");

            foreach (ArchetypeFieldsetModel fieldset in featuredItems)
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

            IPublishedContent homePage = CurrentPage.AncestorOrSelf("home");

            string title = homePage.GetPropertyValue<string>("blogPreviewTitle");
            string introduction = homePage.GetPropertyValue("blogPreviewIntro").ToString();

            BlogPreview model = new BlogPreview(title, introduction);

            return PartialView("~/Views/Partials/Home/_Blog.cshtml", model);
        }

        public ActionResult RenderTestimonials()
        {
            IPublishedContent homePage = CurrentPage.AncestorOrSelf("home");

            string title = homePage.GetPropertyValue<string>("testimonialsTitle");
            string introduction = homePage.GetPropertyValue("testimonialsIntro").ToString();

            List<Testimonial> testimonials = new List<Testimonial>();
            ArchetypeModel testimonialsList = homePage.GetPropertyValue<ArchetypeModel>("testimonialsList");
            if (testimonialsList != null)
            {
                foreach (ArchetypeFieldsetModel testimonial in testimonialsList)
                {

                    string name = testimonial.GetValue<string>("name");
                    string quote = testimonial.GetValue<string>("quote");

                    testimonials.Add(new Testimonial(name, quote));
                }
            }

            Testimonials model = new Testimonials(title, introduction, testimonials);
            return PartialView("~/Views/Partials/Home/_Testimonials.cshtml", model);
        }
    }
}