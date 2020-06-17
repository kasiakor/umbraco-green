using Archetype.Models;
using NewGood.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace NewGood.Controllers
{
    public class GuideController : SurfaceController
    {
        public ActionResult RenderGuide()
        {
            List<GuideItem> model = new List<GuideItem>();
            IPublishedContent guidePage = CurrentPage.AncestorOrSelf("guide");

            ArchetypeModel guideItems = guidePage.GetPropertyValue<ArchetypeModel>("guideItems");

            foreach (ArchetypeFieldsetModel fieldset in guideItems)
            {

                string category = fieldset.GetValue<string>("category");
                string description = fieldset.GetValue<string>("description");

                model.Add(new GuideItem(category, description));
            }
            return PartialView("~/Views/Partials/Guide/_Guide.cshtml", model);
        }
    }
}