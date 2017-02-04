using ASPJ.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections;
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
            //MsgBox(name);
        }
       

        //well i dont namenow where to put this part at eugene codes...
        protected void purchaseb_Click(object sender, EventArgs e)
        {
            if (userid == Itemowner.Text)
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
            if (userid == Itemowner.Text)
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
                ArrayList a = new ArrayList();
                String random = Cryptography_ys_.GenerateIdentifier(40);
                a.Add(Cryptography_ys_.EncryptionOfData(userid, random));
                //a.Add(Cryptography_ys_.EncryptionOfData(Itemowner.Text, random));
                a.Add(Cryptography_ys_.EncryptionOfData("SHIT", random));
                a.Add(Cryptography_ys_.EncryptionOfData(type.ToString(), random));
                //a.Add(Cryptography_ys_.EncryptionOfData("no", random));
                a.Add(Cryptography_ys_.EncryptionOfData(DateTime.Now.ToString(), random));
                a.Add(random);
                command.CommandText = "INSERT INTO [dbo].[notification] (sender,receiver,filename,type,status,timepost,word) VALUES (@1,@2,@3,@4,@5,@6,@7);";
                
                    command.Parameters.Add(new SqlParameter("@1", a[0]));
                    command.Parameters.Add(new SqlParameter("@2", Itemowner.Text));
                    //below is file name/page
                    command.Parameters.Add(new SqlParameter("@3", a[1]));
                    command.Parameters.Add(new SqlParameter("@4", a[2]));
                    command.Parameters.Add(new SqlParameter("@5", "no"));
                    command.Parameters.Add(new SqlParameter("@6", a[3]));
                command.Parameters.Add(new SqlParameter("@7", a[4]));
                command.Connection = connection123;
                command.ExecuteNonQuery();                
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
                ArrayList a = new ArrayList();
                String random = Cryptography_ys_.GenerateIdentifier(40);
                a.Add(Cryptography_ys_.EncryptionOfData(userid, random));
                //a.Add(Cryptography_ys_.EncryptionOfData(Itemowner.Text, random));
                a.Add(Cryptography_ys_.EncryptionOfData("SHIT", random));
                a.Add(Cryptography_ys_.EncryptionOfData(type.ToString(), random));
                //a.Add(Cryptography_ys_.EncryptionOfData("no", random));
                a.Add(Cryptography_ys_.EncryptionOfData(DateTime.Now.ToString(), random));
                a.Add(random);
                a.Add(Cryptography_ys_.EncryptionOfData(TextBox1.Text, random));
                command.CommandText = "INSERT INTO [dbo].[notification] (sender,receiver,filename,type,status,timepost,word) VALUES (@1,@2,@3,@4,@5,@6,@7,@8);";

                command.Parameters.Add(new SqlParameter("@1", a[0]));
                command.Parameters.Add(new SqlParameter("@2", Itemowner.Text));
                //below is file name/page
                command.Parameters.Add(new SqlParameter("@3", a[1]));
                command.Parameters.Add(new SqlParameter("@4", a[2]));
                command.Parameters.Add(new SqlParameter("@5", "no"));
                command.Parameters.Add(new SqlParameter("@6", a[3]));
                command.Parameters.Add(new SqlParameter("@7", a[4]));
                command.Parameters.Add(new SqlParameter("@8", a[5]));
                command.Connection = connection123;
                command.ExecuteNonQuery();
            }
        }

        protected void CButton_Click(object sender, EventArgs e)
        {

            if (userid == Itemowner.Text)
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