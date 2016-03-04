using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WebFetcher
{
    public class IFengWeb:Web
    {
        string _url = "http://www.ifeng.com/";

        static IFengWeb _instance;

        IFengWeb()
        {
        }

        static public IFengWeb GetInstance()
        {
            if (_instance == null)
            {
                _instance = new IFengWeb();
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

            ExtractTitleByID(web, "headLineDefault");

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

            ExtractParagraphByID(web, "main_content");

            if (web.ReadyState == WebBrowserReadyState.Complete)
            {
                web.Dispose();
            }
        }
    }
}
