using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace WebFetcher
{
    public partial class MainForm : Form
    {
        Web _myWeb;
        WebManager _webManager;
        List<string> _currentWebNames = new List<string>();

        public MainForm()
        {
            InitializeComponent();

            _currentWebNames.Add("新浪新闻");
            _currentWebNames.Add("cnBeta科学");
            _currentWebNames.Add("凤凰网");
            _currentWebNames.Add("NBA虎扑");
            _currentWebNames.Add("步行街");

            _webManager = WebManager.GetInstance();
            _currentWebNames.ForEach(delegate(string name)
            {
                _webManager.Register(name);
                comboBox_WebSelect.Items.Add(name);
            });
            comboBox_WebSelect.SelectedIndex = 0;

        }

        private void button_fetch_Click(object sender, EventArgs e)
        {
            _myWeb.DisplayTitles();
        }

        private void listBox_MessageBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            int index = this.listBox_Title.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                string title = listBox_Title.SelectedItem as string;
                if (title == "") return;

                string link = _myWeb.GetLink(title);
                System.Diagnostics.Process.Start(link);
            }
        }

        private void comboBox_WebSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox_Title.Items.Clear();

            string webName = comboBox_WebSelect.SelectedItem as string;
            try
            {
                _myWeb = _webManager.GetWeb(webName);
            }
            catch
            {
                MessageBox.Show("网站名未注册！");
            }
            _myWeb.SetTitleBox(listBox_Title);
            _myWeb.SetContentBox(listBox_Content);

            List<string> titles = _myWeb.GetTitles();
            titles.ForEach(delegate(string str)
            {
                listBox_Title.Items.Add(str);
                listBox_Title.Items.Add("");
            });
        }

        private void listBox_Title_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int index = this.listBox_Title.IndexFromPoint(e.Location);
                if (index != System.Windows.Forms.ListBox.NoMatches)
                {
                    string title = listBox_Title.SelectedItem as string;
                    if (title == "") return;

                    listBox_Content.Items.Clear();
                    _myWeb.DisplayContent(title);
                }
            }
        }

       

    }
}
