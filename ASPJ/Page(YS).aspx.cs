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
    public partial class Page : System.Web.UI.Page
    {
        String name;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session.Text = name;
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationUser user = manager.FindById(User.Identity.GetUserId());
            name = user.UserName.ToString();
            //MsgBox(name);
        }
       

        //well i dont namenow where to put this part at eugene codes...
        protected void purchaseb_Click(object sender, EventArgs e)
        {
            if (name == Itemowner.Text)
            {

                //MsgBox("same name");
                Response.Redirect("error");
            }

            else
            {
                haha("1");
                MsgBox("Sucess");
            }

        }
        

        public void MsgBox(String msg)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language='javascript'>alert('" + msg + "')</script>");
        }

        protected void smsg_Click(object sender, EventArgs e)
        {
            if (name == Itemowner.Text)
            {

                //MsgBox("same name");
                Response.Redirect("error");
            }

            else
            {
                haha("2");
                MsgBox("Sucess");
            }
        }
        //method for type 1&2 need to insert externalid for type 2 
        public void haha(String type)
        {
            using (SqlConnection connection123 = new
       SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
       "NotificationConnectionString1"].ConnectionString))
            {
                connection123.Open();
                SqlCommand command = new SqlCommand();

                command.CommandText = "INSERT INTO [dbo].[notification] (sender,receiver,filename,type,status,timepost) VALUES (@1,@2,@3,@4,@5,@6);";
                command.Parameters.Add(new SqlParameter("@1", name));
                command.Parameters.Add(new SqlParameter("@2", Itemowner.Text));
                //below is file name/page
                command.Parameters.Add(new SqlParameter("@3", "SHIT"));
                command.Parameters.Add(new SqlParameter("@4", type));
                command.Parameters.Add(new SqlParameter("@5", "no"));
                command.Parameters.Add(new SqlParameter("@6", DateTime.Now.ToString()));
                command.Connection = connection123;

                command.ExecuteNonQuery();
                connection123.Close();
            }
        }
        //method for type 3
        public void haha(String type,String txt)
        {
            using (SqlConnection connection123 = new
       SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
       "NotificationConnectionString1"].ConnectionString))
            {
                connection123.Open();
                SqlCommand command = new SqlCommand();
                //need to insert review/comment ID from JC
                command.CommandText = "INSERT INTO [dbo].[notification] (sender,receiver,filename,type,status,message,timepost) VALUES (@1,@2,@3,@4,@5,@6,@7);";
                command.Parameters.Add(new SqlParameter("@1", name));
                command.Parameters.Add(new SqlParameter("@2", Itemowner.Text));
                command.Parameters.Add(new SqlParameter("@3", "SHIT"));
                command.Parameters.Add(new SqlParameter("@4", type));
                command.Parameters.Add(new SqlParameter("@5", "no"));
                command.Parameters.Add(new SqlParameter("@6", txt));
                command.Parameters.Add(new SqlParameter("@7", DateTime.Now.ToString()));
                command.Connection = connection123;

                command.ExecuteNonQuery();
                connection123.Close();
            }
        }

        protected void CButton_Click(object sender, EventArgs e)
        {

            if (name == Itemowner.Text)
            {

                //MsgBox("same name");
                Response.Redirect("error");
            }

            else
            {
                haha("1");
                MsgBox("Sucess");
            }
        }
    }

   
    
}