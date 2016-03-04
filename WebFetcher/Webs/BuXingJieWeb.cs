using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WebFetcher
{
    public class BuXingJieWeb:Web
    {
        string _url = "http://bbs.hupu.com/bxj";

        static BuXingJieWeb _instance;

        List<string> _ignoreStrings=new List<string>();

        public BuXingJieWeb()
        {
            _ignoreStrings.Add("影视区");
            _ignoreStrings.Add("动漫区");
            _ignoreStrings.Add("音乐区");
        }

        static public BuXingJieWeb GetInstance()
        {
            if (_instance == null)
            {
                _instance = new BuXingJieWeb();
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

            ExtractTitleByID(web, "pl");

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

            HtmlElementCollection collection = web.Document.GetElementsByTagName("table");
            if (collection == null)
            {
                return;
            }
            HtmlElement contentElem = CommonFunctions.GetElemWithClass(collection, "case");
            if (contentElem == null)
            {
                return;
            }


            string matchString="http://bbs.hupu.com/bxj";
            HtmlElementCollection elementCollection = contentElem.GetElementsByTagName("td");
            foreach (HtmlElement elem in elementCollection)
            {
                string content = elem.InnerText;

                if (content == "" || content == null) continue;
                if (_subwebContent.Contains(content)) continue;

                //剪除正文前的内容
                string trimContent=content.Substring(content.LastIndexOf(matchString)+matchString.Length);

                List<string> split = CommonFunctions.EqualStepSplitString(trimContent, 18);
                split.ForEach(delegate(string str)
                {
                    _Contentbox.Items.Add(str);
                });
                _subwebContent.Add(content);
            }

            if (web.ReadyState == WebBrowserReadyState.Complete)
            {
                web.Dispose();
            }
        }

        override protected void ExtractTitles(HtmlElement parentElement)
        {
            HtmlElementCollection tdList = parentElement.GetElementsByTagName("td");
            List<HtmlElement> titleList = new List<HtmlElement>();
            foreach (HtmlElement elem in tdList)
            {
                if (elem.GetAttribute("classname") == "p_title")
                {
                    titleList.Add(elem);
                }
            }

            titleList.ForEach(delegate(HtmlElement elem)
            {
                HtmlElementCollection aCollection = elem.GetElementsByTagName("a");

                foreach (HtmlElement a in aCollection)
                {
                    if (_ignoreStrings.Contains(a.InnerText))
                    {
                        continue;
                    }

                    string str = a.InnerText;
                    if (str == null) return;
                    if (str != "")
                    {
                        if (_webElements.ContainsKey(str)) return;
                        if (_exclusives.Contains(str)) return;

                        _Titlebox.Items.Add(str);
                        _Titlebox.Items.Add("");

                        string link = a.GetAttribute("href");
                        WebElement webElem = new WebElement(str, link);

                        _webElements[str] = webElem;
                    }

                    break;
                }
                
            });
        }
    }
}
