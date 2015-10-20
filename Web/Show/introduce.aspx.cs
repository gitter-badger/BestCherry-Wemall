using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Show
{
    public partial class introduce : WebPage
    {
        public string type = "";
        public string code = "";
        public string activityid = "";
        public string desimgpath = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                code = Request.QueryString["procode"];
                type = Request.QueryString["type"];
                activityid = Request.QueryString["activityid"];
                if (!WebBLL.CheckActivity(code, new Guid(activityid), type))
                {
                    GoNoFound();
                }
                Model.ActivityPro activityPro = WebBLL.GetActivityPro(code, new Guid(activityid))[0];
                if (activityPro.DESIMGPATH.Trim() == "")
                {
                    Response.Redirect("buy.aspx?procode=" + code + "&type=" + type + "&activityid=" + activityid, false);
                }
                else
                {
                    desimgpath = activityPro.DESIMGPATH;
                }
            }
            catch (Exception ex)
            {
                GoNoFound();
            }
        }
    }
}