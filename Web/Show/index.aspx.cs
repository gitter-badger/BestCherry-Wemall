using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Show
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("sale.aspx?timeBuyCode=" + Common.get_config("timeBuyCode") + "&normalCode=" + Common.get_config("normalCode") + "&pollCode=" + Common.get_config("pollCode"));
        }
    }
}