using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPJ
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void noti_Click(object sender, EventArgs e)
        {
            Response.Redirect("Notification.aspx");
        }

        protected void p_Click(object sender, EventArgs e)
        {
            Response.Redirect("Page.aspx");
        }
    }
}