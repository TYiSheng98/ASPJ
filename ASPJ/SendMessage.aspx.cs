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
    public partial class SendMessage : System.Web.UI.Page
    {
        String receivername;
        String re;
        String userid;
        protected void Page_Load(object sender, EventArgs e)
        {
            bool val1 = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            if (val1 == true)
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                ApplicationUser user = manager.FindById(User.Identity.GetUserId());
                userid = user.Id;
                receivername = getname(Request.QueryString["ownerid"]);
                re = Request.QueryString["re"];
                inputEmail.Text = receivername;
                subject.Text = re;
            }
            else
                Response.Redirect("~/Account/Login.aspx");
        }

        protected void SendB_Click(object sender, EventArgs e)
        {
            if (userid == receivername)
            {


                Response.Redirect("error");
            }

            else
            {
                haha("2", textArea.Text);
                Response.Redirect("Default.aspx");
            }

        }

        protected void ResetB_Click(object sender, EventArgs e)
        {
            
            textArea.Text = "";
        }
        public string getname(String id)
        {
            String name;
            using (SqlConnection connection1 = new
 SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
 "DefaultConnection"].ConnectionString))
            {

                connection1.Open();
                String query3 = "SELECT UserName from [dbo].[AspNetUsers]where Id ='" + id + "'";
                SqlCommand q = new SqlCommand(query3, connection1);
                name = (string)(q.ExecuteScalar());
                connection1.Close();
            }
            return name;
        }
        public void haha(String type, String txt)
        {
            using (SqlConnection connection123 = new
       SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
       "NotificationConnectionString1"].ConnectionString))
            {
                connection123.Open();
                SqlCommand command = new SqlCommand();
                //need to insert review/comment ID from JC
                command.CommandText = "INSERT INTO [dbo].[notification] (sender,receiver,filename,type,status,message,timepost) VALUES (@1,@2,@3,@4,@5,@6,@7);";
                command.Parameters.Add(new SqlParameter("@1", userid));
                command.Parameters.Add(new SqlParameter("@2", Request.QueryString["ownerid"]));
                command.Parameters.Add(new SqlParameter("@3", re));
                command.Parameters.Add(new SqlParameter("@4", type));
                command.Parameters.Add(new SqlParameter("@5", "no"));
                command.Parameters.Add(new SqlParameter("@6", txt));
                command.Parameters.Add(new SqlParameter("@7", DateTime.Now.ToString()));
                command.Connection = connection123;

                command.ExecuteNonQuery();
                connection123.Close();
            }
        }
        public void MsgBox(String msg)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language='javascript'>alert('" + msg + "')</script>");
        }
    }
}