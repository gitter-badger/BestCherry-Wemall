using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin.Services
{
    /// <summary>
    /// AddLogistics 的摘要说明
    /// </summary>
    public class AddLogistics : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            Guid ID = new Guid(context.Request.QueryString["ID"]);
            string Logistics = context.Request.QueryString["Logistics"];
            WebBLL.UpdateLogistics(ID, Logistics);
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