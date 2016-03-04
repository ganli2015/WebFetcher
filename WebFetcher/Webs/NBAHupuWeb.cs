using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WebFetcher
{
    public class NBAHupuWeb:Web
    {
        string _url = "http://nba.hupu.com/";

        static NBAHupuWeb _instance;

        public NBAHupuWeb()
        {
        }

        static public NBAHupuWeb GetInstance()
        {
            if (_instance == null)
            {
                _instance = new NBAHupuWeb();
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

            ExtractTitleByDivClass(web, "text");

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

            ExtractParagraphByDivClass(web, "artical-main-content");

            if (web.ReadyState == WebBrowserReadyState.Complete)
            {
                web.Dispose();
            }
        }
    }
}
