using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cherry.api
{
    /// <summary>
    /// checknum 的摘要说明
    /// </summary>
    public class checknum : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Cache.SetNoStore();
            int count = 0;
            try
            {
                string code = "500";
                int num = 0;
                count = 30 - num;
                if (count < 0)
                {
                    count = 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                context.Response.Write(count.ToString());
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