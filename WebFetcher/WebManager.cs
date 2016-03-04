using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebFetcher
{
//     public enum WebName
//     {
//         SinaNews,
//         cnBetaScience,
//         IFeng,
//         NBAHupu
//     }

    public class WebManager
    {
        Dictionary<string, Web> _currentWebs=new Dictionary<string, Web>();

        static WebManager _instance;

        public WebManager()
        {

        }

        public static WebManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new WebManager();
                return _instance;
            }
            else
            {
                return _instance;
            }
        }

        public void Register(string name)
        {
            switch (name)
            {
                case "新浪新闻":
                    {
                        _currentWebs.Add(name, SinaNewsWeb.GetInstance());
                        break;
                    }
                case "cnBeta科学":
                    {
                        _currentWebs.Add(name, cnBETAScienceWeb.GetInstance());
                        break;
                    }
                case "凤凰网":
                    {
                        _currentWebs.Add(name, IFengWeb.GetInstance());

                        break;
                    }
                case "NBA虎扑":
                    {
                        _currentWebs.Add(name, NBAHupuWeb.GetInstance());
                        break;
                    }
                case "步行街":
                    {
                        _currentWebs.Add(name, BuXingJieWeb.GetInstance());
                        break;
                    }
                default:
                    {
                        throw new ArgumentOutOfRangeException();
                    }
            }

        }

        public Web GetWeb(string name)
        {
            if (_currentWebs.ContainsKey(name))
            {
                return _currentWebs[name];
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
