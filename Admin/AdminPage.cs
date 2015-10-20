using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin
{
    abstract public class AdminPage : System.Web.UI.Page
    {
        protected AdminPage()
        {
        }

        public void GoNoFound()
        {
            Response.Redirect("nofound.aspx");
        }

        public void ShowAlert(string msg)
        {
            string js = @"<Script language='JavaScript'>
alert('"+msg+"');</Script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert", js); 
        }
    }
}