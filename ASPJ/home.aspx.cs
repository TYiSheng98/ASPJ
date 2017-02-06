using ASPJ.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPJ
{
    public partial class home : System.Web.UI.Page
    {
        String userid;
        protected void Page_Load(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationUser user = manager.FindById(User.Identity.GetUserId());
            userid = user.Id;

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

        protected void Button1_Click(object sender, EventArgs e)
        {
            haha("4");
            Response.Redirect(Request.RawUrl);
        }
        public void haha(String type)
        {
            using (SqlConnection connection123 = new
       SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
       "NotificationConnectionString1"].ConnectionString))
            {
                connection123.Open();
                SqlCommand command = new SqlCommand();

                command.CommandText = "INSERT INTO [dbo].[notification] (receiver,message,type,status,timepost) VALUES (@1,@2,@3,@4,@5);";
                command.Parameters.Add(new SqlParameter("@1", userid));
                command.Parameters.Add(new SqlParameter("@2", "Your account settings was recently modified."));
                command.Parameters.Add(new SqlParameter("@3", "4"));
                command.Parameters.Add(new SqlParameter("@4", "no"));
                command.Parameters.Add(new SqlParameter("@5", DateTime.Now.ToString()));
                command.Connection = connection123;

                command.ExecuteNonQuery();
                connection123.Close();
            }
        }
    }
}