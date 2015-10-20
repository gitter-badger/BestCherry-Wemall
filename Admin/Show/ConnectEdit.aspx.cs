using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin.Show
{
    public partial class ConnectEdit : System.Web.UI.Page
    {
        public static string code = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string ID = Request.QueryString["ID"];
            code = Request.QueryString["code"];
            if (!IsPostBack)
            {
                List<Model.ActivityPro> list = WebBLL.GetActivityPro(new Guid(ID));
                if (list.Count != 0)
                {
                    buytime.Value = list[0].BUYTIME.ToString();
                    num.Value = list[0].NUM.ToString();
                    imagepath.Value = list[0].IMAGEPATH.ToString();
                    desimgpath.Value = list[0].DESIMGPATH.ToString();
                    id.Value = list[0].ID.ToString();
                }
            }
        }

        public void Save_click(object sender, EventArgs e)
        {
            WebBLL.UpdateActivityPro(new Guid(id.Value),buytime.Value,num.Value,imagepath.Value,desimgpath.Value);
            Response.Redirect("ConnectPro.aspx?code=" + code);
        }
    }
}