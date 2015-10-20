using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Api
{
    /// <summary>
    /// getSMS 的摘要说明
    /// </summary>
    public class getSMS : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string cardno = context.Request.QueryString["cardno"];
            string orderid = context.Request.QueryString["orderid"];
            //首先先检测这张卡是否开通银联全渠道支付
            string queryOpenStatusStr = Common.HttpPost("../UNIONMethod/SendSMS.aspx", "cardno=" + cardno + "&orderid=" + orderid);
            context.Response.Write(queryOpenStatusStr);
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