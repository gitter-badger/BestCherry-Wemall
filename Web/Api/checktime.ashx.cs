using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cherry.api
{
    /// <summary>
    /// checktime 的摘要说明
    /// </summary>
    public class checktime : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Cache.SetNoStore();
            string txt = "0";
            try
            {
                string code = context.Request.QueryString["code"];
                string activityid = context.Request.QueryString["activityid"];
                DateTime d1 = DateTime.Now;
                DateTime d2 = DateTime.ParseExact(WebBLL.GetActivityPro(code,new Guid(activityid))[0].BUYTIME, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
                //DateTime d2 = DateTime.Now;
                if (d1.CompareTo(d2) <= 0)
                {
                    TimeSpan d3 = d2.Subtract(d1);
                    txt = "距开始" + d3.Hours.ToString() + "小时" + d3.Minutes.ToString() + "分钟" + d3.Seconds.ToString() + "秒";
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                context.Response.Write(txt);
                context.Response.End();
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}