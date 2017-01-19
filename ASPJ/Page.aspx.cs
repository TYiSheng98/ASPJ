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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void likeb_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection123 = new
        SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
        "NotificationConnectionString1"].ConnectionString))
            {
                connection123.Open();
                SqlCommand command = new SqlCommand();

                command.CommandText = "INSERT INTO [dbo].[notification] (sender,receiver,filename,type,status) VALUES (@1,@2,@3,@4,@5);";
                command.Parameters.Add(new SqlParameter("@1", session.SName));
                command.Parameters.Add(new SqlParameter("@2", "gg"));
                command.Parameters.Add(new SqlParameter("@3", "gg page"));
                command.Parameters.Add(new SqlParameter("@4", "1"));
                command.Parameters.Add(new SqlParameter("@5", "no"));
                command.Connection = connection123;

                command.ExecuteNonQuery();
                connection123.Close();
            }
            MsgBox("you liked this page!");
           
        }
        public void MsgBox(String msg)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language='javascript'>alert('" + msg + "')</script>");
        }
    }

//    protected void likeb_Click(object sender, EventArgs e)
//    {
//        String la = Label3.Text;
//        MsgBox(session.SName);
//        using (SqlConnection connection123 = new
//SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
//"NotificationConnectionString1"].ConnectionString))
//        {
//            connection123.Open();
//            SqlCommand command = new SqlCommand();

//            command.CommandText = "INSERT INTO [dbo].[Notification] (Type, Sender,Receiver,Message,Status) VALUES (@0,@1,@2,@3,@4);";
//            command.Parameters.Add(new SqlParameter("@0", 1));
//            command.Parameters.Add(new SqlParameter("@1", session.SName));
//            command.Parameters.Add(new SqlParameter("@2", "JC"));
//            command.Parameters.Add(new SqlParameter("@3", ""));
//            command.Parameters.Add(new SqlParameter("@4", "No"));

//            command.Connection = connection123;

//            command.ExecuteNonQuery();
//            connection123.Close();
//        }
//    }


    
    
}