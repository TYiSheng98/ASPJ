using ASPJ.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ASPJ
{

    public partial class Notification : System.Web.UI.Page
    {

        int a;
        String userid;
        protected void Page_Load(object sender, EventArgs e)
        {
            bool val1 = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            if (val1 == true)
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                ApplicationUser user = manager.FindById(User.Identity.GetUserId());
                //name = user.UserName.ToString();
                userid = user.Id;
                //MsgBox(name);

                Inital.Text = "Page loaded at: " + DateTime.Now.ToLongTimeString();
                if (IsPostBack)
                {

                    string click = Request["__EVENTTARGET"];//contrl
                    if (click == "lala")
                    {
                        string parameter = Request["__EVENTARGUMENT"]; // parameter

                        //MsgBox(parameter);
                        updatestatus(parameter);
                        getnotifications();

                    }
                    //else if (clicked == "haha")
                    //{
                    //    string parameter = Request["__EVENTARGUMENT"]; // parameter

                    //    MsgBox(parameter);


                    //}



                }
                getnotifications();
            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }

        }

        protected void TimerforN_Tick(object sender, EventArgs e)
        {
            getnotifications();
            
            loop.Text = "Page refreshed at: " + DateTime.Now.ToLongTimeString();


        }
        public int getnotifycounter()
        {
            int newnotify;
            using (SqlConnection connection = new
   SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
   "NotificationConnectionString1"].ConnectionString))
            {
                connection.Open();
                String query2 = " SELECT count(*) from [dbo].[notification]where receiver ='" + userid + "' and status='no'";
                SqlCommand q = new SqlCommand(query2, connection);
                newnotify = (int)(q.ExecuteScalar());
                connection.Close();
                
            }
            return newnotify;
        }
        public void getnotifications()
        {
            tabs.Controls.Clear();
            ArrayList list = new ArrayList();
            String rid;

            using (SqlConnection connection = new
   SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
   "NotificationConnectionString1"].ConnectionString))
            {
                connection.Open();
                String query1 =" SELECT sender,filename,type,id,status,message,timepost,externalid,word from [dbo].[notification]where receiver ='" + userid + "' order by id desc";
                String query0 = " SELECT count(*) from [dbo].[notification]where receiver ='" + userid + "'";
                String query2 = " SELECT count(*) from [dbo].[notification]where receiver ='" + userid + "' and status='no'";
                
                SqlCommand cc = new SqlCommand(query0, connection);
                a= (int)(cc.ExecuteScalar());
                //SqlCommand q = new SqlCommand(query2, connection);
                //int newnotify = (int)(q.ExecuteScalar());
                int count = getnotifycounter();
                NO.Value = count.ToString();
                //counter.InnerHtml = count.ToString();
                if (count > 1)
                {
                    header.InnerText = "You have " + count + " unread notifications!";
                }
                else if (count == 1)
                {
                    header.InnerText = "You have " + count + " unread notification!";
                }
                else
                {
                    header.InnerText = "You have no unread notifications!";
                    //counter.InnerHtml = "";
                }

                
                //MsgBox("You have no new notifications!");
                //header.InnerText = "You have " + newnotify + " unread notifications!";
                SqlCommand cc1 = new SqlCommand(query1, connection);

                SqlDataAdapter da = new SqlDataAdapter(cc1);
                DataTable dt = new DataTable();
                dt.Clear();
                da.Fill(dt);
                connection.Close();
                
                for (int i = 0; i < this.a; i++)
                {

                    notify ha = new notify();
                    ha.passwd = dt.Rows[i][8].ToString();
                    ha.send = Cryptography_ys_.DecryptOfData(dt.Rows[i][0].ToString(), ha.passwd);
                    ha.filename = Cryptography_ys_.DecryptOfData(dt.Rows[i][1].ToString(), ha.passwd);
                    ha.type = Cryptography_ys_.DecryptOfData(dt.Rows[i][2].ToString(), ha.passwd);
                    ha.id = int.Parse(dt.Rows[i][3].ToString());
                    ha.status= dt.Rows[i][4].ToString();
                    ha.msg = Cryptography_ys_.DecryptOfData(dt.Rows[i][5].ToString(), ha.passwd);
                    ha.datet = Cryptography_ys_.DecryptOfData(dt.Rows[i][6].ToString(), ha.passwd);
                    //GET FROM JC
                    ha.EID= dt.Rows[i][7].ToString();
                    if (ha.EID == "") {
                        ha.EID = "0";
                    }
                   
                    list.Add(ha);
                    HtmlGenericControl li = new HtmlGenericControl("li");
                    li.Attributes.Add("id", ha.id.ToString());
                    
                    if (ha.status == "no")
                    {
                        li.Style.Add("background-color", "#ffe0b3");
                        
                    }
                    else
                    {
                        li.Style.Add("background-color", "lightblue");
                    }
                    li.Attributes.Add("onclick", "CLICK(" + ha.id.ToString() + "," + ha.type + "," + ha.EID + ")");
                    tabs.Controls.Add(li);
                    HtmlGenericControl h6 = new HtmlGenericControl("h6");
                    DateTime datetime = DateTime.Parse(ha.datet);

                    h6.InnerHtml = TimeAgo(datetime);
                    li.Controls.Add(h6);

                    HtmlGenericControl h5 = new HtmlGenericControl("h5");
                    HtmlGenericControl s0 = new HtmlGenericControl("span");
                    h5.Controls.Add(s0);
                    using (SqlConnection connection1 = new
  SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
  "DefaultConnection"].ConnectionString))
                    {

                        connection1.Open();
                        String query3 = "SELECT UserName from [dbo].[AspNetUsers]where Id ='" + ha.send + "'";
                        SqlCommand q = new SqlCommand(query3, connection1);
                        rid = (string)(q.ExecuteScalar());
                        connection1.Close();
                    }
                    HtmlGenericControl s1 = new HtmlGenericControl("span");
                    HtmlGenericControl a = new HtmlGenericControl("a");
                    a.Attributes.Add("href", "user.aspx" );
                    a.InnerHtml = rid;
                    s0.Controls.Add(s1);
                    s1.Controls.Add(a);
                    HtmlGenericControl s2 = new HtmlGenericControl("span");
                    s0.Controls.Add(s2);
                    if (ha.type == "1")
                    {
                        //h5.InnerText = ha.send + " purchased your product.";
                        s2.InnerHtml= " purchased your product ";
                    }
                    else if (ha.type == "2")
                    {
                        //h5.InnerText = ha.send + " commissioned your product.";
                        HtmlGenericControl a2 = new HtmlGenericControl("a");
                        //need to integrate with kehui part
                        a2.Attributes.Add("href", "Inbox.aspx");
                        s2.Controls.Add(a2);
                        s2.InnerHtml= " sent you a message regarding on ";
                    }
                    else if (ha.type == "3")
                    {
                        //h5.InnerText = ha.send + " commented '" + ha.msg + "' at " + ha.filename;
                        s2.InnerHtml= " commented on your product ";
                    }
                    HtmlGenericControl s3 = new HtmlGenericControl("span");
                    HtmlGenericControl a1 = new HtmlGenericControl("a");
                    a1.Attributes.Add("href", "google.com");
                    a1.InnerHtml = ha.filename;
                    s0.Controls.Add(s3);
                    s3.Controls.Add(a1);

                    li.Controls.Add(h5);
                   
                }
            }


        }
        //protected void ho_Click(object sender, EventArgs e)
        //{
        //    Button d = (Button)sender;
        //    MsgBox(d.ID);
        //}
        public void delete(String id)
        {
            using (SqlConnection connection = new
  SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
  "NotificationConnectionString1"].ConnectionString))
            {

                connection.Open();
                String query;
                query = " DELETE from [dbo].[notification]  WHERE id =" + id;
                SqlCommand cc = new SqlCommand(query, connection);
                cc.ExecuteNonQuery();
                connection.Close();
            }
        }
        protected void updatestatus(String id)
        {
            
            
            

            //sql update UPDATE [dbo].[notification] set status = 'yes' WHERE id =12;
            using (SqlConnection connection = new
   SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
   "NotificationConnectionString1"].ConnectionString))
            {

                connection.Open();
                String query;
                query = " UPDATE [dbo].[notification] set status = 'yes' WHERE id =" + id;
                SqlCommand cc = new SqlCommand(query, connection);
                cc.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void MsgBox(String msg)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language='javascript'>alert('" + msg + "')</script>");
        }
        
        public string TimeAgo(DateTime dateTime)
        {
            string result = string.Empty;
            var timeSpan = DateTime.Now.Subtract(dateTime);

            if (timeSpan <= TimeSpan.FromSeconds(60))
            {
                result = string.Format("{0} seconds ago", timeSpan.Seconds);
            }
            else if (timeSpan <= TimeSpan.FromMinutes(60))
            {
                result = timeSpan.Minutes > 1 ?
                    String.Format("about {0} minutes ago", timeSpan.Minutes) :
                    "about a minute ago";
            }
            else if (timeSpan <= TimeSpan.FromHours(24))
            {
                result = timeSpan.Hours > 1 ?
                    String.Format("about {0} hours ago", timeSpan.Hours) :
                    "about an hour ago";
            }
            else if (timeSpan <= TimeSpan.FromDays(30))
            {
                result = timeSpan.Days > 1 ?
                    String.Format("about {0} days ago", timeSpan.Days) :
                    "yesterday";
            }
            else if (timeSpan <= TimeSpan.FromDays(365))
            {
                result = timeSpan.Days > 30 ?
                    String.Format("about {0} months ago", timeSpan.Days / 30) :
                    "about a month ago";
            }
            else
            {
                result = timeSpan.Days > 365 ?
                    String.Format("about {0} years ago", timeSpan.Days / 365) :
                    "about a year ago";
            }

            return result;
        }

        protected void DeleteB_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new
  SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
  "NotificationConnectionString1"].ConnectionString))
            {

                connection.Open();
                String query;
                query = " DELETE  from [dbo].[notification]";
                SqlCommand cc = new SqlCommand(query, connection);
                cc.ExecuteNonQuery();
                connection.Close();
            }
            Response.Redirect(Request.RawUrl);
        }

        protected void ALL_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new
   SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
   "NotificationConnectionString1"].ConnectionString))
            {

                connection.Open();
                String query;
                query = " UPDATE [dbo].[notification] set status = 'yes' ";
                SqlCommand cc = new SqlCommand(query, connection);
                cc.ExecuteNonQuery();
                connection.Close();
            }
            Response.Redirect(Request.RawUrl);
        }
    }
}

      
