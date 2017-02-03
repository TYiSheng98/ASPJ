using ASPJ.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
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
        String k;
        protected void Page_Load(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationUser user = manager.FindById(User.Identity.GetUserId());
            k = user.UserName.ToString();
            
        }

        protected void noti_Click(object sender, EventArgs e)
        {
            Response.Redirect("Notification.aspx");
        }

        protected void filepage_Click(object sender, EventArgs e)
        {
            Response.Redirect("Page(YS).aspx");
        }
        protected void DoMyOnClickCall(object sender, EventArgs e)
        {
            MsgBox("HOOOO");
        }
        public void MsgBox(String msg)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language='javascript'>alert('" + msg + "')</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Button D = (Button)sender;
            MsgBox(D.ID);
        }
        
    }
}