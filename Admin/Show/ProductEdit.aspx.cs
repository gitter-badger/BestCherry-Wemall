using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin.Show
{
    public partial class ProductEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string codeStr = Request.QueryString["code"];
            if (!IsPostBack)
            {
                List<Model.BestCherryInfo> list = WebBLL.GetCherry(codeStr);
                if (list.Count != 0)
                {
                    name.Value = list[0].TITLE.ToString();
                    color.Value = list[0].COLOR.ToString();
                    price.Value = list[0].PRICE.ToString();
                    memberprice.Value = list[0].MEMBERPRICE.ToString();
                    imgpath.Value = list[0].IMAGEPATH.ToString();
                    smalltitle.Value = list[0].SMALLTITLE.ToString();
                    code.Value = list[0].CODE.ToString();
                    id.Value = list[0].ID.ToString();
                }
            }
        }

        public void Save_click(object sender, EventArgs e)
        {
            WebBLL.UpdateICBCCherryInfo(new Guid(id.Value),name.Value, color.Value, price.Value, memberprice.Value, imgpath.Value, smalltitle.Value, code.Value, "");
            Response.Redirect("ProductList.aspx");
        }
    }
}