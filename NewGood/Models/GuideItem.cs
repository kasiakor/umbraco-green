using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewGood.Models
{
    public class GuideItem
    {
        public string Category { get; set; }
        public string Description { get; set; }
        public GuideItem(string category, string description)
        {
            Category = category;
            Description = description;
        }
    }
}