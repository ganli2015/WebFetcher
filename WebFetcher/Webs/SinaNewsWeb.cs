using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WebFetcher
{
    public class SinaNewsWeb:  Web
    {

        string _url= "http://news.sina.com.cn/";
        
        static SinaNewsWeb _instance;

        SinaNewsWeb()
        {
            SetExclusiveTitles();
        }

        static public SinaNewsWeb GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SinaNewsWeb();
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

        void SetExclusiveTitles()
        {
            _exclusives.Add("视频");
            _exclusives.Add("列国志 | ");
            _exclusives.Add("更多新闻>");
            _exclusives.Add("返回>>");

        }

        override protected void Web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser web = (WebBrowser)sender;

            //             if (web.ReadyState != WebBrowserReadyState.Complete)
            //                 return; 

            ExtractTitleByID(web,"syncad_1");
            ExtractTitleByID(web,"ad_entry_b2");
            ExtractTitleByID(web,"blk_new_gnxw");

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

            ExtractParagraphByID(web, "artibody");

            if (web.ReadyState == WebBrowserReadyState.Complete)
            {
                web.Dispose();
            }
        }
        
    }
}
