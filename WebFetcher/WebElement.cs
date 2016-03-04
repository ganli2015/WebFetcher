using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebFetcher
{
    public class WebElement
    {
        public string Title { set; get; }
        public string Link { set; get; }

        public WebElement(string title, string link)
        {
            Title = title;
            Link = link;
        }
    }
}

