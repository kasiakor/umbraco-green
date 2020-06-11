using NewGood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace NewGood.Controllers
{
    public class BlogController : SurfaceController
    {
        public ActionResult RenderPostList(int numberOfItems)
        {
            List<BlogPostList> model = new List<BlogPostList>();
            IPublishedContent blogPage = CurrentPage.AncestorOrSelf(1).DescendantsOrSelf().Where(x => x.DocumentTypeAlias == "blog").FirstOrDefault();

            foreach (IPublishedContent page in blogPage.Children.OrderByDescending(x => x.UpdateDate).Take(numberOfItems))
            {

                //string name = page.GetPropertyValue<string>("title") or:

                string name = page.Name;
                string introduction = page.GetPropertyValue<string>("articleIntro");

                //imageUrl
                int imageId = page.GetPropertyValue<int>("articleImage");
                //gets the value of media picker
                var mediaItem = Umbraco.Media(imageId);
                string imageUrl = mediaItem.Url;

                //linkUrl
                string linkUrl = page.Url;


                model.Add(new BlogPostList(name, introduction, imageUrl, linkUrl));
            }
            return PartialView("~/Views/Partials/Blog/_PostList.cshtml", model);
        }
    }
}