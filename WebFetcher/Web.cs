using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WebFetcher
{
    public abstract class Web
    {
        protected ListBox _Titlebox;
        protected ListBox _Contentbox;
        protected Dictionary<string, WebElement> _webElements = new Dictionary<string, WebElement>();
        protected List<string> _exclusives = new List<string>();
        protected List<string> _subwebContent = new List<string>();
        protected WebBrowser _contentBrowser;
        protected WebBrowser _titleBrowser;

        public void SetTitleBox(ListBox listbox)
        {
            _Titlebox = listbox;
        }
        public void SetContentBox(ListBox listbox)
        {
            _Contentbox = listbox;
        }

        public string GetLink(string title)
        {
            if (_webElements.ContainsKey(title))
            {
                return _webElements[title].Link;
            }
            else
            {
                throw new Exception();
            }
        }

        public List<string> GetTitles()
        {
            List<string> res = new List<string>();
            foreach (KeyValuePair<string, WebElement> pair in _webElements)
            {
                res.Add(pair.Key);
            }
            return res;
        }

        public void DisplayTitles()
        {
            _Titlebox.Items.Clear();

            _Titlebox.Items.Add("Waiting...");

            _webElements.Clear();
            if (_titleBrowser != null)
            {
                _titleBrowser.Dispose();
            }
            _titleBrowser = new WebBrowser();
            _titleBrowser.Navigate(GetURL());
            _titleBrowser.ScriptErrorsSuppressed = true;
            _titleBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(Web_DocumentCompleted);
        }

        public void DisplayContent(string title)
        {
            if (!_webElements.ContainsKey(title))
            {
                throw new Exception();
            }

            _subwebContent.Clear();
            string suburl = _webElements[title].Link;

            if (_contentBrowser != null)
            {
                _contentBrowser.Dispose();
            }
            _contentBrowser = new WebBrowser();
            _contentBrowser.Navigate(suburl);
            _contentBrowser.ScriptErrorsSuppressed = true;
            _contentBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(SubWeb_DocumentCompleted);

        }

        abstract protected string GetURL();

        abstract protected void Web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e);
        
        abstract protected void SubWeb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e);

        virtual protected void ExtractTitles(HtmlElement parentElement)
        {
            HtmlElementCollection titleList = parentElement.GetElementsByTagName("a");
            foreach (HtmlElement elem in titleList)
            {
                string str = elem.InnerText;
                if (str == null) continue;
                if (str != "")
                {
                    if (_webElements.ContainsKey(str)) continue;
                    if (_exclusives.Contains(str)) continue;

                    _Titlebox.Items.Add(str);
                    _Titlebox.Items.Add("");

                    string link = elem.GetAttribute("href");
                    WebElement webElem = new WebElement(str, link);

                    _webElements[str] = webElem;
                }
            }
        }

        virtual protected void ExtractTitleByID(WebBrowser web,string ID)
        {
            HtmlElement collection = web.Document.GetElementById(ID);
            if (collection == null)
            {
                return;
            }

            if (_Titlebox.Items.Count == 0)
            {
                return;
            }
            string waitMessage = _Titlebox.Items[0] as string;
            if (waitMessage == "Waiting...")
            {
                _Titlebox.Items.Clear();
            }

            ExtractTitles(collection);
        }

        virtual protected void ExtractTitleByDivClass(WebBrowser web,string classname)
        {
            HtmlElementCollection collection = web.Document.GetElementsByTagName("div");
            if (collection == null)
            {
                return;
            }

            HtmlElement elemList = CommonFunctions.GetElemWithClass(collection, classname);
            if (elemList == null)
            {
                return;
            }

            if (_Titlebox.Items.Count == 0)
            {
                return;
            }
            string waitMessage = _Titlebox.Items[0] as string;
            if (waitMessage == "Waiting...")
            {
                _Titlebox.Items.Clear();
            }

            ExtractTitles(elemList);
        }

        virtual protected void ExtractParagraphByID(WebBrowser web,string ID)
        {
            HtmlElement artibody = web.Document.GetElementById(ID);
            if (artibody == null)
            {
                return;
            }

            HtmlElementCollection elementCollection = artibody.GetElementsByTagName("p");
            foreach (HtmlElement elem in elementCollection)
            {
                string content = elem.InnerText;

                if (content == "" || content == null) continue;
                if (_subwebContent.Contains(content)) continue;

                List<string> split = CommonFunctions.EqualStepSplitString(content, 18);
                split.ForEach(delegate(string str)
                {
                    _Contentbox.Items.Add(str);
                });
                _subwebContent.Add(content);
            }
        }

        virtual protected void ExtractParagraphByDivClass(WebBrowser web, string classname)
        {
            HtmlElementCollection collection = web.Document.GetElementsByTagName("div");
            if (collection == null)
            {
                return;
            }
            HtmlElement contentElem = CommonFunctions.GetElemWithClass(collection, classname);
            if (contentElem == null)
            {
                return;
            }

            HtmlElementCollection elementCollection = contentElem.GetElementsByTagName("p");
            foreach (HtmlElement elem in elementCollection)
            {
                string content = elem.InnerText;

                if (content == "" || content == null) continue;
                if (_subwebContent.Contains(content)) continue;

                List<string> split = CommonFunctions.EqualStepSplitString(content, 18);
                split.ForEach(delegate(string str)
                {
                    _Contentbox.Items.Add(str);
                });
                _subwebContent.Add(content);
            }

//             string content = contentElem.InnerText;
// 
//             if (content == "" || content == null) return;
//             if (_subwebContent.Contains(content)) return;
// 
//             List<string> split = CommonFunctions.EqualStepSplitString(content, 18);
//             split.ForEach(delegate(string str)
//             {
//                 _Contentbox.Items.Add(str);
//             });
//             _subwebContent.Add(content);
        }
    }
}
