using BLL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin.Show
{
    public partial class HavePay : AdminPage
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

        public void Export_click(object sender, EventArgs e)
        {
            NPOIHelper.ListColumnsName = new SortedList(new NoSort());
            NPOIHelper.ListColumnsName.Add("ID", "导入物流凭证请勿修改");
            NPOIHelper.ListColumnsName.Add("CONSIGNEE", "姓名");
            NPOIHelper.ListColumnsName.Add("MOBILE", "手机号");
            NPOIHelper.ListColumnsName.Add("ALLADDRESS", "地址");
            NPOIHelper.ListColumnsName.Add("ORDERLIST", "订单内容");
            NPOIHelper.ListColumnsName.Add("PAYDATE", "付款时间");
            NPOIHelper.ListColumnsName.Add("AMOUNT", "付款金额");
            NPOIHelper.ListColumnsName.Add("REMARK", "送货备注");
            NPOIHelper.ListColumnsName.Add("LOGISTICS", "物流号");
            Response.Clear();
            Response.BufferOutput = false;
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            string filename = typeList.SelectedItem.Text + "-" + activityList.SelectedItem.Text+"-"+time.Value+"已付款订单列表";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + filename + ".xls");
            Response.ContentType = "application/ms-excel";
            NPOIHelper.ExportExcel(Common.ToDataTable<Model.OrderInfo>(Common.GetAllAdress(WebBLL.GetOrderInfoListByName(namelike.Value, new Guid(activityList.SelectedValue.ToString()), true,time.Value.Replace("-","")))), Response.OutputStream);
            Response.Close();
        }

        public void BindGrid()
        {
            rptList.DataSource = WebBLL.GetOrderInfoListByName(namelike.Value, new Guid(activityList.SelectedValue.ToString()), true, time.Value.Replace("-", ""));
            rptList.DataBind();
        }

        public void Import_click(object sender, EventArgs e)
        {
            var Upload = new UploadFile();
            Upload.Save("file");
            if (Upload.Error)
            {
                ShowAlert(Upload.Message);
            }
            else
            {
                NPOIHelper.ImportExcel(Server.MapPath(Upload.FilePath+"\\"+Upload.FileInfo["filepath"]));
                BindGrid();
                ShowAlert("导入成功");
            }
        }
    }
}