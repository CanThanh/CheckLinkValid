using CefSharp;
using CefSharp.WinForms;
using Fizzler.Systems.HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckLinkValid
{
    public partial class ProcessRapidgator : Form
    {
        private List<string> ListFileName;
        private List<string> ListFileNotFound;
        private ChromiumWebBrowser browser;

        public ProcessRapidgator()
        {
            InitializeComponent();
            InitChrome();
            InitList();
        }

        private void InitList()
        {
            ListFileNotFound = new List<string>();
        }

        public void SetListFileName(List<string> listFileName)
        {
            ListFileName = listFileName;
        }

        private void InitChrome()
        {
            browser = new ChromiumWebBrowser(CommonConstants.RapidgatorLoginUrl);
            browser.FrameLoadEnd += chrome_FrameLoadEnd;
            pChrome.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;
        }

        private string GetHTMLFromWebBrowser()
        {
            Task<String> taskHtml = browser.GetBrowser().MainFrame.GetSourceAsync();
            string response = taskHtml.Result;
            return response;
        }

        private void chrome_FrameLoadEnd(object sender, CefSharp.FrameLoadEndEventArgs e)
        {
            browser.EvaluateScriptAsync("document.querySelector('input[id=LoginForm_email]').value='" + CommonConstants.RapidgatorUserName + "';");
            browser.EvaluateScriptAsync("document.querySelector('input[id=LoginForm_password]').value='" + CommonConstants.RapidgatorPassWord + "';");
            browser.ExecuteScriptAsync("document.getElementById('agr').click();");
            //browser.ExecuteScriptAsync("document.forms.registration.submit();");
        }

        private void btnProcessFile_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in ListFileName)
                {
                    ProcessFileNotValid(item);
                }
				WriteFile();
                this.Close();
                MessageBox.Show("Đã xử lý xong toàn bộ danh sách file");
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi xảy ra. Vui lòng thao tác lại");
            }
        }

        private void ProcessFileNotValid(string fileName)
        {
            try
            {
                browser.EvaluateScriptAsync("document.querySelector('input[class=find-text-box]').value='" + fileName + "';");
                browser.ExecuteScriptAsync("findFile();");
                Thread.Sleep(5000);
                var strHtml = GetHTMLFromWebBrowser();
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(strHtml);
                if (doc != null && doc.DocumentNode != null)
                {
                    var tableRows = doc.DocumentNode.QuerySelectorAll("table.items > tbody > tr").ToList();
                    if (tableRows.Count >= 2)
                    {
                        var itemId = tableRows[1].QuerySelector("td > input.select-checkbox").Attributes["id"].Value;
                        browser.ExecuteScriptAsync("document.getElementById('" + itemId + "').click();");
                        browser.ExecuteScriptAsync("checkBeforeMove();");
                        browser.ExecuteScriptAsync("paste();");
			Thread.Sleep(3000);
                    }
                    else
                    {
                        var tableColumns = tableRows[0].QuerySelectorAll("td").ToList();
                        if (tableColumns.Count > 1)
                        {
                            var itemId = tableRows[0].QuerySelector("td > input.select-checkbox").Attributes["id"].Value;
                            browser.ExecuteScriptAsync("document.getElementById('" + itemId + "').click();");
                            browser.ExecuteScriptAsync("checkBeforeCopy();");
                            browser.ExecuteScriptAsync("copyPaste();");
			    Thread.Sleep(3000);
                        }
                        else
                        {
                            ListFileNotFound.Add(fileName);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void btnGoMyFiles_Click(object sender, EventArgs e)
        {
            browser.Load(CommonConstants.RapidgatorMyFileUrl);
        }

        private void WriteFile()
        {
            try
            {
                var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                if (!Directory.Exists(CommonConstants.LogFolder))
                {
                    Directory.CreateDirectory(path+"\\" + CommonConstants.LogFolder);
                }
                var fileName = DateTime.Now.ToString("yyyyMMddHHmmss");
                TextWriter textWriter = new StreamWriter(path + "\\" + CommonConstants.LogFolder + "\\" + fileName + ".txt");
                foreach (var item in ListFileNotFound)
                {
                    textWriter.WriteLine(item);
                }
                textWriter.Dispose();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
