using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml;

namespace Cherry.api
{
    /// <summary>
    /// checkmobilelist 的摘要说明
    /// </summary>
    public class checkmobilelist : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Cache.SetNoStore();
            int count = 0;
            try
            {
                string mobile = context.Request.QueryString["mobile"];
                count = 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                context.Response.Write(count);
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