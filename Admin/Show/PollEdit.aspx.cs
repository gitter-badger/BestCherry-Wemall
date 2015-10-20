using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin.Show
{
    public partial class PollEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string codeStr = Request.QueryString["code"];
            if (!IsPostBack)
            {
                List<Model.Activity> list = WebBLL.GetActivity(codeStr);
                if (list.Count != 0)
                {
                    name.Value = list[0].NAME.ToString();
                    code.Value = list[0].CODE.ToString();
                    id.Value = list[0].ID.ToString();
                }
            }
        }

        public void Save_click(object sender, EventArgs e)
        {
            WebBLL.UpdateActivity(new Guid(id.Value), name.Value, "3", code.Value);
            Response.Redirect("Poll.aspx");
        }
    }
}