using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Show
{
    public partial class nofound : System.Web.UI.Page
    {
        public string msg = "没有找到你要的页面";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["msg"]!=null)
            {
                msg = Request.QueryString["msg"];
            }
        }
    }
}