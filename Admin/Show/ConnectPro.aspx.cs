using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin.Show
{
    public partial class ConnectPro : System.Web.UI.Page
    {
        public static string codeStr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                codeStr=Request.QueryString["code"];
                List<Model.Activity> list = WebBLL.GetActivity(codeStr);
                if (list.Count != 0)
                {
                    name.InnerText = list[0].NAME;
                    activityID.Value = list[0].ID.ToString();
                    type.Value = list[0].TYPE.ToString();
                    BindGrid(list[0].ID);
                    BindDropList();
                }
            }
        }

        public void BindDropList()
        {
            productlist.DataSource = WebBLL.GetAllProduct();
            productlist.DataValueField = "CODE";
            productlist.DataTextField = "TITLE";
            productlist.DataBind();
        }

        public void BindGrid(Guid id)
        {
            using (Model.BestCherryEntities entitys = new Model.BestCherryEntities())
            {
                var bcilist = (from s in entitys.BestCherryInfoes
                               join r
                                   in entitys.ActivityProes on s.CODE equals r.PROCODE into g
                               from o in g.DefaultIfEmpty()
                               select new
                               {
                                   o.PROID,
                                   s.TITLE,
                                   s.CODE,
                                   o.ACTIVITYID,
                                   o.BUYTIME,
                                   o.NUM,
                                   o.IMAGEPATH,
                                   o.ID,
                                   o.DESIMGPATH
                               }).Where(a => a.ACTIVITYID == id).ToList();
                rptList.DataSource = bcilist;
                rptList.DataBind();
            }
        }

        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string code = e.CommandArgument.ToString(); ;
            if (e.CommandName == "Edit")
            {
                Response.Redirect("ConnectEdit.aspx?ID=" + code+"&code="+codeStr);
            }
            else if (e.CommandName == "Delete")
            {
                WebBLL.DeleteActivityPro(new Guid(code));
                Response.Redirect("ConnectPro.aspx?code=" + codeStr);
            }
        }
    }
}