using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Show
{
    public partial class buy: WebPage
    {
        public List<BestCherryInfo> dt = null;
        public string type = "";
        public int count = 0;
        public string code = "";
        public string activityid = "";
        public int sum = 0;
        public string tell = "";
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
                if (type == "1")
                {
                    dt = WebBLL.GetCherry(code);
                    int num = WebBLL.GetSuccessOrderInfoListByCode(code);
                    sum = int.Parse(WebBLL.GetActivityPro(code, new Guid(activityid))[0].NUM.ToString());
                    count = sum - num;
                    if (count < 0)
                    {
                        count = 0;
                    }
                }
                else if (type == "2")
                {
                    dt = WebBLL.GetNormalCherry(new Guid(activityid));
                }
                else
                {
                    GoNoFound();
                }
                if (dt.Count == 0)
                {
                    GoNoFound();
                }
            }
            catch (Exception)
            {
                GoNoFound();
            }
        }
    }
}