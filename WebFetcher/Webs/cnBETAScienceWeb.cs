using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WebFetcher
{
    public class cnBETAScienceWeb: Web
    {
        string _url = "http://www.cnbeta.com/topics/448.htm";

        static cnBETAScienceWeb _instance;

        cnBETAScienceWeb()
        {
            SetExclusiveTitles();
        }

        static public cnBETAScienceWeb GetInstance()
        {
            if (_instance == null)
            {
                _instance = new cnBETAScienceWeb();
                return _instance;
            }
            else
            {
                return _instance;
            }
        }

        protected override string GetURL()
        {
            return _url;
        }

        override protected void Web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser web = (WebBrowser)sender;

            ExtractTitleByDivClass(web, "all_news_wildlist");

            if (web.ReadyState == WebBrowserReadyState.Complete)
            {
                web.Dispose();
            }
        }

        override protected void SubWeb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser web = (WebBrowser)sender;

            //             if (web.ReadyState != WebBrowserReadyState.Complete)
            //                 return;

            ExtractParagraphByDivClass(web, "content");
            
            if (web.ReadyState == WebBrowserReadyState.Complete)
            {
                web.Dispose();
            }
        }

        void SetExclusiveTitles()
        {
            _exclusives.Add("详细内容");

        }
    }
}
