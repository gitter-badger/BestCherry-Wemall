using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Admin.Show
{
    public partial class ProductList : System.Web.UI.Page
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
                Response.Redirect("ProductEdit.aspx?code=" + code);
            }
            else if (e.CommandName == "Delete")
            {

            }
        }

        public void BindGrid()
        {
            rptList.DataSource = WebBLL.GetCherryByName(namelike.Value);
            rptList.DataBind();
        }

        public void Search_click(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}