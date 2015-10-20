using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin.Show
{
    public partial class Printer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropTypeList();
                BindDropActivityList();
                BindGrid();
            }
        }

        public void BindDropTypeList()
        {
            Dictionary<string, string> list = new Dictionary<string, string>();
            list.Add("限时购", "1");
            list.Add("正常商品", "2");

            typeList.DataSource = list;
            typeList.DataValueField = "value";
            typeList.DataTextField = "key";
            typeList.DataBind();
        }

        public void BindDropActivityList()
        {
            List<Model.Activity> list = WebBLL.GetActivityesByType(int.Parse(typeList.SelectedValue));
            activityList.DataSource = list;
            activityList.DataValueField = "ID";
            activityList.DataTextField = "NAME";
            activityList.DataBind();
        }

        public void Type_click(object sender, EventArgs e)
        {
            BindDropActivityList();
            BindGrid();
        }

        public void Search_click(object sender, EventArgs e)
        {
            BindGrid();
        }

        public void BindGrid()
        {
            rptList.DataSource = WebBLL.GetOrderInfoListByNameOrderByNotPrinted(namelike.Value, new Guid(activityList.SelectedValue.ToString()), true,check.Checked);
            rptList.DataBind();
        }
    }
}