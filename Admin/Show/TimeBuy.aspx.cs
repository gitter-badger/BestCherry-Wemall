using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin.Show
{
    public partial class TimeBuy : AdminPage
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
                if (WebBLL.DelActivity(new Guid(code)) == true)
                {
                    ShowAlert("删除成功");
                }
                else
                {
                    ShowAlert("删除失败");
                }
                BindGrid();
            }
            else if (e.CommandName == "Connect")
            {
                Response.Redirect("ConnectPro.aspx?code=" + code);
            }
            else if (e.CommandName == "Reset")
            {
                if(WebBLL.ResetActivity(new Guid(code))==true)
                {
                    ShowAlert("重置成功");
                }
                else
                {
                    ShowAlert("重置失败");
                }
            }
        }

        public void BindGrid()
        {
            rptList.DataSource = WebBLL.GetActivityByName(namelike.Value,1);
            rptList.DataBind();
        }

        public void Search_click(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}