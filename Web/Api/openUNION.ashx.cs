using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Api
{
    /// <summary>
    /// openUNION 的摘要说明
    /// </summary>
    public class openUNION : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string cardno = context.Request.QueryString["cardno"];
            string orderid = context.Request.QueryString["orderid"];
            //首先先检测这张卡是否开通银联全渠道支付
            string queryOpenStatusStr=Common.HttpPost("../UNIONMethod/QueryOpenStatus.aspx", "cardno=" + cardno + "&orderid=" + orderid);
            //未开通直接进入后台交易
            if (queryOpenStatusStr=="0")
            {
                context.Response.Redirect("../UNIONMethod/QueryOpenStatus.aspx?cardno=" + cardno + "&orderid=" + orderid);
            }
            else
            {
                context.Response.Write("0");
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