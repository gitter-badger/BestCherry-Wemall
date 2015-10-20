using BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;

namespace Admin.Services
{
    /// <summary>
    /// AddPro 的摘要说明
    /// </summary>
    public class AddPro : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            Guid activityID=new Guid(context.Request.QueryString["activityID"]);
            string code = context.Request.QueryString["code"];
            string buytime = context.Request.QueryString["buytime"] == null ? "" : context.Request.QueryString["buytime"];
            string num = context.Request.QueryString["num"] == null ? "0" : context.Request.QueryString["num"];
            string imagepath = context.Request.QueryString["imagepath"] == null ? "" : context.Request.QueryString["imagepath"];
            string desimgpath = context.Request.QueryString["desimgpath"] == null ? "" : context.Request.QueryString["desimgpath"];
            WebBLL.InsertActivityPro(activityID, code, Guid.Empty, buytime, num, imagepath, desimgpath);
            HttpContext.Current.Response.Write("success");  
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