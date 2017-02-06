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
        String userid;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session.Text = name;
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationUser user = manager.FindById(User.Identity.GetUserId());
            userid = user.Id;
            filename.InnerHtml = "FileName";
            //MsgBox(name);
        }
       

        //well i dont namenow where to put this part at eugene codes...
        protected void purchaseb_Click(object sender, EventArgs e)
        {
            if (userid == Itemownerid.Value)
            {

                //MsgBox("same name");
                Response.Redirect("error");
            }

            else
            {
                haha("1");
                MsgBox("Sucess");
                Response.Redirect(Request.RawUrl);
            }

        }
        

        public void MsgBox(String msg)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language='javascript'>alert('" + msg + "')</script>");
        }

        protected void smsg_Click(object sender, EventArgs e)
        {
            Response.Redirect("SendMessage.aspx?ownerid=" + Itemownerid.Value + "&re="+filename.InnerHtml);
            //if (userid == Itemowner.Text)
            //{

            //    //MsgBox("same name");
            //    Response.Redirect("error");
            //}

            //else
            //{
            //    haha("2");
            //    MsgBox("Sucess");
            //}
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
                command.Parameters.Add(new SqlParameter("@1", userid));
                command.Parameters.Add(new SqlParameter("@2", Itemownerid.Value));
                //below is file name/page
                command.Parameters.Add(new SqlParameter("@3", filename.InnerHtml));
                command.Parameters.Add(new SqlParameter("@4", type));
                command.Parameters.Add(new SqlParameter("@5", "no"));
                command.Parameters.Add(new SqlParameter("@6", DateTime.Now.ToString()));
                command.Connection = connection123;

                command.ExecuteNonQuery();
                
                if (type == "1")
                {
                    SqlCommand command1 = new SqlCommand();

                    command1.CommandText = "INSERT INTO [dbo].[notification] (receiver,filename,type,status,timepost) VALUES (@1,@2,@3,@4,@5);";
                    command1.Parameters.Add(new SqlParameter("@1", userid));
                    
                    command1.Parameters.Add(new SqlParameter("@2", filename.InnerHtml));
                    command1.Parameters.Add(new SqlParameter("@3", "5"));
                    command1.Parameters.Add(new SqlParameter("@4", "no"));
                    command1.Parameters.Add(new SqlParameter("@5", DateTime.Now.ToString()));
                    command1.Connection = connection123;

                    command1.ExecuteNonQuery();
                    connection123.Close();
                }
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
                command.Parameters.Add(new SqlParameter("@1", userid));
                command.Parameters.Add(new SqlParameter("@2", Itemownerid.Value));
                command.Parameters.Add(new SqlParameter("@3", filename.InnerText));
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

           
                haha("3", TextBox1.Text);
                MsgBox("Sucess");
            
        }
    }

   
    
}