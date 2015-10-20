using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Api
{
    /// <summary>
    /// poll 的摘要说明
    /// </summary>
    public class poll : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Cache.SetNoStore();
            int non = 0;
            try
            {
                string ID = context.Request.QueryString["ID"];
                WebBLL.UpdatePoll(new Guid(ID));
                non = 1;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                context.Response.Write(non);
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