using ASPJ.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPJ
{
    public partial class ViewMessage : System.Web.UI.Page
    {
        private string MSG;
        private string userid;
        protected void Page_Load(object sender, EventArgs e)
        {
            bool val1 = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            if (val1 == true)
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                ApplicationUser user = manager.FindById(User.Identity.GetUserId());
                userid = user.Id;
                MSG = Request.QueryString["msg"];
                h(MSG);
                //subject.Text = receivername;
            }
            else
                Response.Redirect("~/Account/Login.aspx");
        }
        public void h(String msg)
        {
            using (SqlConnection connection = new
   SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
   "NotificationConnectionString1"].ConnectionString))
            {

                connection.Open();
                String query1 = " SELECT sender,filename,message,timepost from [dbo].[notification]where message ='" + msg + "' ";

                SqlCommand cc1 = new SqlCommand(query1, connection);
                SqlDataAdapter da = new SqlDataAdapter(cc1);
                DataTable dt = new DataTable();
                dt.Clear();
                da.Fill(dt);
                connection.Close();


                notify ha = new notify();
                ha.send = dt.Rows[0][0].ToString();
                ha.filename = dt.Rows[0][1].ToString();
                ha.msg = dt.Rows[0][2].ToString();
                ha.datet = dt.Rows[0][3].ToString();
                String n = getname(ha.send);
                Label1.Text = "From: " + n;
                Label2.Text = "RE: " + ha.filename;
                Label3.Text = "Message: " + ha.msg;
                Label4.Text = "Sent at :" + ha.datet;

            }
        }
        public string getname(string id)
        {
            String k;
            using (SqlConnection connection1 = new
  SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
  "DefaultConnection"].ConnectionString))
            {

                connection1.Open();
                String query3 = "SELECT UserName from [dbo].[AspNetUsers]where Id ='" + id + "'";
                SqlCommand q = new SqlCommand(query3, connection1);
                k = (string)(q.ExecuteScalar());
                connection1.Close();
            }
            return k;
        }
    }
}