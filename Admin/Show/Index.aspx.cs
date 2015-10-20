using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin.Show
{
    public partial class Index : System.Web.UI.Page
    {
        public int notPay = 0;
        public int havePay = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            notPay = WebBLL.GetOrderInfoNotPay();
            havePay = WebBLL.GetOrderInfoHavePay();
        }
    }
}