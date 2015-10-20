using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin.Show
{
    public partial class Poll : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string code = e.CommandArgument.ToString(); ;
            if (e.CommandName == "Edit")
            {
                Response.Redirect("TimeEdit.aspx?code=" + code);
            }
            else if (e.CommandName == "Delete")
            {

            }
            else if (e.CommandName == "Connect")
            {
                Response.Redirect("ConnectPro.aspx?code=" + code);
            }
        }

        public void BindGrid()
        {
            rptList.DataSource = WebBLL.GetActivityByName(namelike.Value, 3);
            rptList.DataBind();
        }

        public void Search_click(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}