using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewGood.Models
{
    public class BlogPostList
    {
        public string Name { get; set; }
        public string Introduction { get; set; }
        public string ImageUrl { get; set; }
        public string LinkUrl { get; set; }

        public BlogPostList(string name, string introduction, string imageUrl, string linkUrl)
        {
            Name = name;
            Introduction = introduction;
            ImageUrl = imageUrl;
            LinkUrl = linkUrl;
        }
    }
}