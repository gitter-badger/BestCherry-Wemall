﻿using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin.Show
{
    public partial class NormalAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void Save_click(object sender, EventArgs e)
        {
            WebBLL.InsertActivity(name.Value, "2", code.Value);
            Response.Redirect("NormalPro.aspx");
        }
    }
}