using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Show
{
    public partial class querylogistics : WebPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string code = Request.QueryString["logisticsCode"];
            string url = "http://etrace.9625taqbin.com/gli_trace/GDXTX010S10Action_doDetail.action?jvCd=94ba0ba9e8ac3570&sTimeDifference=671cb6bcdedd72c7&sSelectedLanguage=9cd74637e1e5ac7d&sCountryCd=6d6d1b0c52b48650&sLanguageMode=0&CHAR_SET=be165cd2fecde48c&sDefCharSet=be165cd2fecde48c&sCharSetCsv=cd754bdefece0e58&action%3AGDXTX010S10Action_doSearch=%E5%BC%80%E5%A7%8B%E6%9F%A5%E8%AF%A2&tTrackingNoInputVal1=" + code + "&tTrackingNoInputVal2=&tTrackingNoInputVal3=&tTrackingNoInputVal4=&tTrackingNoInputVal5=&tTrackingNoInputVal6=&tTrackingNoInputVal7=&tTrackingNoInputVal8=&tTrackingNoInputVal9=&tTrackingNoInputVal10=";
            Search(url);
        }

        public string GetSmallTile(string orderlist)
        {
            return Common.GetNotAllTitle(orderlist);
        }

        public void Search_click(object sender, EventArgs e)
        {
            rptLogistics.DataSource = null;
            rptLogistics.DataBind();
        }

        private void Search(string url)
        {
            string rl;
            WebRequest webRequest = WebRequest.Create(url.Trim());

            WebResponse webResponse = webRequest.GetResponse();

            Stream resStream = webResponse.GetResponseStream();

            StreamReader sr = new StreamReader(resStream, Encoding.UTF8);
            StringBuilder sb = new StringBuilder();
            while ((rl = sr.ReadLine()) != null)
            {
                sb.Append(rl);
            }
            string str = sb.ToString().ToLower();
            string str_get = mid(str, "<table class=\"meisai\" width=\"900\">", "</table>");//获取到的物流信息
            int start = 0;
            int index = 0;
            string time = "";
            DataTable dt = new DataTable();
            dt.Columns.Add("STATUS");
            dt.Columns.Add("TIME");
            dt.Columns.Add("NAME");
            DataRow dr = dt.NewRow();
            while (true)
            {
                index++;
                if (index == 5)
                {
                    time = "";
                    dt.Rows.Add(dr);
                    dr = dt.NewRow();
                }
                if (str_get == null)
                    break;
                string strResult = mid(str_get, "<td", "</td>", out start);
                if (strResult == null)
                    break;
                else
                {
                    str_get = str_get.Substring(start);
                    if (index == 5)
                    {
                        index = 0;
                        continue;
                    }
                    string getStr = strResult.Replace("class=\"even\">", "").Replace("class=\"odd\">", "").Replace("</td", "").Replace("/td>", "").Trim();
                    if (index == 1)
                    {
                        dr["STATUS"] = getStr;
                    }
                    if (index == 2)
                    {
                        time = getStr;
                    }
                    if (index == 3)
                    {
                        time += " " + getStr;
                    }
                    if (index == 4)
                    {
                        dr["NAME"] = getStr;
                        dr["TIME"] = time;
                    }
                }
            }
            if (dt.Rows.Count==0)
            {
                GoNoFound("暂无物流信息");
            }
            rptLogistics.DataSource = dt;
            rptLogistics.DataBind();
        }

        private string mid(string istr, string startString, string endString)
        {
            int iBodyStart = istr.IndexOf(startString, 0);               //开始位置
            if (iBodyStart == -1)
                return null;
            iBodyStart += startString.Length;                           //第一次字符位置起的长度
            int iBodyEnd = istr.IndexOf(endString, iBodyStart);         //第二次字符在第一次字符位置起的首次位置
            if (iBodyEnd == -1)
                return null;
            iBodyEnd += endString.Length;                              //第二次字符位置起的长度
            string strResult = istr.Substring(iBodyStart, iBodyEnd - iBodyStart - 1);
            return strResult;
        }


        private string mid(string istr, string startString, string endString, out int iBodyEnd)
        {
            //初始化out参数,否则不能return
            iBodyEnd = 0;

            int iBodyStart = istr.IndexOf(startString, 0);               //开始位置
            if (iBodyStart == -1)
                return null;
            iBodyStart += startString.Length;                           //第一次字符位置起的长度
            iBodyEnd = istr.IndexOf(endString, iBodyStart);         //第二次字符在第一次字符位置起的首次位置
            if (iBodyEnd == -1)
                return null;
            iBodyEnd += endString.Length;                              //第二次字符位置起的长度
            string strResult = istr.Substring(iBodyStart, iBodyEnd - iBodyStart - 1);
            return strResult;
        }
    }
}