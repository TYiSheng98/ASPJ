﻿using System;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Text = session.SName;
        }

        protected void likeb_Click(object sender, EventArgs e)
        {
            //    using (SqlConnection connection123 = new
            //SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
            //"NotificationConnectionString1"].ConnectionString))
            //    {
            //        connection123.Open();
            //        SqlCommand command = new SqlCommand();

            //        command.CommandText = "INSERT INTO [dbo].[notification] (sender,receiver,filename,type,status) VALUES (@1,@2,@3,@4,@5);";
            //        command.Parameters.Add(new SqlParameter("@1", session.SName));
            //        command.Parameters.Add(new SqlParameter("@2", Itemowner.Text));
            //        command.Parameters.Add(new SqlParameter("@3", "gg page"));
            //        command.Parameters.Add(new SqlParameter("@4", "1"));
            //        command.Parameters.Add(new SqlParameter("@5", "no"));
            //        command.Connection = connection123;

            //        command.ExecuteNonQuery();
            //        connection123.Close();
            //    }
            //    MsgBox("you liked this page!");
            haha("1");

        }
        protected void purchaseb_Click(object sender, EventArgs e)
        {
            
            //    using (SqlConnection connection123 = new
            //SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
            //"NotificationConnectionString1"].ConnectionString))
            //    {
            //        connection123.Open();
            //        SqlCommand command = new SqlCommand();

            //        command.CommandText = "INSERT INTO [dbo].[notification] (sender,receiver,filename,type,status) VALUES (@1,@2,@3,@4,@5);";
            //        command.Parameters.Add(new SqlParameter("@1", session.SName));
            //        command.Parameters.Add(new SqlParameter("@2", Itemowner.Text));
            //        command.Parameters.Add(new SqlParameter("@3", "gg page"));
            //        command.Parameters.Add(new SqlParameter("@4", "2"));
            //        command.Parameters.Add(new SqlParameter("@5", "no"));
            //        command.Connection = connection123;

            //        command.ExecuteNonQuery();
            //        connection123.Close();
            //    }
        }

        public void MsgBox(String msg)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language='javascript'>alert('" + msg + "')</script>");
        }

        protected void commb_Click(object sender, EventArgs e)
        {
            haha("2");
        }
        public void haha(String type)
        {
            using (SqlConnection connection123 = new
       SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
       "NotificationConnectionString1"].ConnectionString))
            {
                connection123.Open();
                SqlCommand command = new SqlCommand();

                command.CommandText = "INSERT INTO [dbo].[notification] (sender,receiver,filename,type,status,timepost) VALUES (@1,@2,@3,@4,@5,@6);";
                command.Parameters.Add(new SqlParameter("@1", session.SName));
                command.Parameters.Add(new SqlParameter("@2", Itemowner.Text));
                command.Parameters.Add(new SqlParameter("@3", "SHIT"));
                command.Parameters.Add(new SqlParameter("@4", type));
                command.Parameters.Add(new SqlParameter("@5", "no"));
                command.Parameters.Add(new SqlParameter("@6", DateTime.Now.ToString()));
                command.Connection = connection123;

                command.ExecuteNonQuery();
                connection123.Close();
            }
        }
        public void haha(String type,String txt)
        {
            using (SqlConnection connection123 = new
       SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
       "NotificationConnectionString1"].ConnectionString))
            {
                connection123.Open();
                SqlCommand command = new SqlCommand();

                command.CommandText = "INSERT INTO [dbo].[notification] (sender,receiver,filename,type,status,message,timepost) VALUES (@1,@2,@3,@4,@5,@6,@7);";
                command.Parameters.Add(new SqlParameter("@1", session.SName));
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
            haha("3", TextBox1.Text);
            MsgBox("Sucess");
            TextBox1.Text = "";
        }
    }

   
    
}