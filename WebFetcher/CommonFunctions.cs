using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WebFetcher
{
    public class CommonFunctions
    {
        public static List<string> EqualStepSplitString(string str, int step)
        {
            List<string> res = new List<string>();
            for (int i = 0; i < str.Length; )
            {
                if (str.Length - i < step)
                {
                    res.Add(str.Substring(i, str.Length - i));
                }
                else
                {
                    res.Add(str.Substring(i, step));
                }
                i += step;
            }
            return res;
        }

        public static HtmlElement GetElemWithClass(HtmlElementCollection collection, string classname)
        {
            foreach (HtmlElement elem in collection)
            {
                string classs = elem.GetAttribute("classname");
                if (elem.GetAttribute("classname") == classname)
                {
                    return elem;
                }
            }

            return null;
        }
    }
}
