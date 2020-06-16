using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewGood.Models
{
    public class Testimonials
    {
        public string Title { get; set; }
        public string Introduction { get; set; }
        public List<Testimonial> TestimonialsList { get; set; }
        public bool HasTestimonials { get { return TestimonialsList != null && TestimonialsList.Count > 0; } }
        public string ColumnClass
        {
            get
            {
                switch (TestimonialsList.Count)
                {
                    case 1:
                        return "col-md-12";
                    case 2:
                        return "col-md-6";
                    case 3:
                        return "col-md-4";
                    default:
                        return "col-md-3";
                }
            }
        }

        public Testimonials(string title, string introduction, List<Testimonial> testimonialsList)
        {
            Title = title;
            Introduction = introduction;
            TestimonialsList = testimonialsList;
        }
    }
}