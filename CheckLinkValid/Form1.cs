using CefSharp;
using CefSharp.WinForms;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckLinkValid
{
    public partial class Form1 : Form
    {
        private List<ValidateLink> ListLinkValid;
        private List<ValidateLink> ListLinkNotValid;
        private List<string> UrlChecked;
        private ChromiumWebBrowser browser;
        public Form1()
        {
            InitializeComponent();
            InitList();
            InitChrome();
        }

        private void InitChrome()
        {
            txtUrl.Text = CommonConstants.Url;
            browser = new ChromiumWebBrowser(txtUrl.Text);
            browser.FrameLoadEnd += chrome_FrameLoadEnd;
            pChrome.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;
        }

        private void InitList()
        {
            ListLinkValid = new List<ValidateLink>();
            ListLinkNotValid = new List<ValidateLink>();
            UrlChecked = new List<string>();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                ListLinkValid.Clear();
                ListLinkNotValid.Clear();
                UrlChecked.Clear();
                lblStartTime.Text = DateTime.Now.ToString();
                if (!string.IsNullOrEmpty(txtUrl.Text.Trim()))
                {
                    if (ckAdminPage.Checked)
                    {
                        var strHtml = GetHTMLFromWebBrowser();
                        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                        doc.LoadHtml(strHtml);
                        if(doc != null && doc.DocumentNode != null)
                        {
                            var listItem = doc.DocumentNode.SelectNodes("//div[@class='row-actions']//span[@class='view']//a");
                            foreach (var item in listItem)
                            {
                                var url = item.GetAttributeValue("href", String.Empty);
                                CheckLinkValid(url, true);
                            }
                        }
                    }
                    else
                    {
                        CheckLinkValid(txtUrl.Text);
                    }
                }
                lblEndTime.Text = DateTime.Now.ToString();
                lblError.Text = ListLinkNotValid.Count + "/" + (ListLinkValid.Count + ListLinkNotValid.Count);
                listBoxLinkNotValid.Items.Clear();
                var index = 1;
                foreach (var item in ListLinkNotValid)
                {
                    listBoxLinkNotValid.Items.Add(index++ + "\tId: " + item.ItemId + "\tRapidgator file name: " + item.NameLinkCheck);
                }
                MessageBox.Show("Đã hoàn thành");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra. Vui lòng kiểm tra lại");
            }                       
        }

        private void CheckLinkValid(string url, bool isPageAdmin = false)
        {
            try
            {
                if (!string.IsNullOrEmpty(url) && !UrlChecked.Contains(url))
                {
                    if (!isPageAdmin && (ListLinkNotValid.Count + ListLinkValid.Count) == 20)
                    {
                        return;
                    }
                    UrlChecked.Add(url);
                    HtmlWeb web = new HtmlWeb();
                    HtmlAgilityPack.HtmlDocument doc = web.Load(url);
                    if(doc != null && doc.DocumentNode != null)
                    {
                        var itemCheck = new ValidateLink();
                        itemCheck.ItemLink = url;
                        var itemId = doc.DocumentNode.SelectSingleNode("//article").GetAttributeValue("id", "0");
                        itemCheck.ItemId = int.Parse(itemId.Replace("post-", ""));
                        itemCheck.ItemName = doc.DocumentNode.SelectSingleNode("//h1[@class='entry-title']").InnerHtml;
                        var linkPrevious = doc.DocumentNode.SelectSingleNode("//div[@class='nav-previous']//a");
                        if (linkPrevious != null)
                        {
                            itemCheck.LinkPrevious = linkPrevious.GetAttributeValue("href", "Not found");
                        }
                        var linkNext = doc.DocumentNode.SelectSingleNode("//div[@class='nav-next']//a");
                        if (linkNext != null)
                        {
                            itemCheck.LinkNext = linkNext.GetAttributeValue("href", "Not found");
                        }
                        var tagA = doc.DocumentNode.SelectSingleNode("//div[@class='entry-content']//a");
                        itemCheck.HrefLinkCheck = tagA.GetAttributeValue("href", "Not found");
                        itemCheck.NameLinkCheck = tagA.InnerHtml;
                        doc = web.Load(itemCheck.HrefLinkCheck);
                        var strHtml = doc.DocumentNode.SelectSingleNode("//head/title").InnerHtml;
                        if (strHtml.Contains(CommonConstants.TitleError))
                        {
                            itemCheck.IsValid = false;
                            ListLinkNotValid.Add(itemCheck);
                        }
                        else
                        {
                            itemCheck.IsValid = true;
                            ListLinkValid.Add(itemCheck);
                        }
                        if (!isPageAdmin && (ListLinkNotValid.Count + ListLinkValid.Count) <= 20)
                        {
                            CheckLinkValid(itemCheck.LinkPrevious);
                            CheckLinkValid(itemCheck.LinkNext);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnInitChrome_Click(object sender, EventArgs e)
        {
            browser.Load(txtUrl.Text);
        }

        private string GetHTMLFromWebBrowser()
        {
            browser.GetBrowser().MainFrame.ViewSource();
            Task<String> taskHtml = browser.GetBrowser().MainFrame.GetSourceAsync();
            string response = taskHtml.Result;
            return response;
        }

        private void chrome_FrameLoadEnd(object sender, CefSharp.FrameLoadEndEventArgs e)
        {
            browser.EvaluateScriptAsync("document.querySelector('input[id=user_login]').value='" + CommonConstants.UserName + "';");
            browser.EvaluateScriptAsync("document.querySelector('input[id=user_pass]').value='" + CommonConstants.PassWord + "';");
            browser.ExecuteScriptAsync("document.getElementById('rememberme').click();");
            browser.ExecuteScriptAsync("document.getElementById('wp-submit').click();");
        }

        private void btnProcessRapidgator_Click(object sender, EventArgs e)
        {
            var listFileName = ListLinkNotValid.Select(x => x.NameLinkCheck).ToList();
            if (listFileName.Count > 0)
            {
                ProcessRapidgator processRapidgator = new ProcessRapidgator();
                processRapidgator.SetListFileName(listFileName);
                processRapidgator.TopMost = true;
                processRapidgator.Show();
            }
            else
            {
                MessageBox.Show("Không có file nào bị lỗi.");
            }

        }
    }
}
