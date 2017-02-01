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
        protected void Page_Load(object sender, EventArgs e)
        {
            Inital.Text = "Page loaded at: " + DateTime.Now.ToLongTimeString();
            if (IsPostBack)
            {

                string clicked = Request["__EVENTTARGET"];//contrl
                if (clicked == "lala")
                {
                    string parameter = Request["__EVENTARGUMENT"]; // parameter

                    //MsgBox(parameter);
                    lmao(parameter);
                    getstuff();

                }
                else if (clicked == "haha")
                {
                    string parameter = Request["__EVENTARGUMENT"]; // parameter

                    MsgBox(parameter);

                 
                }



            }
            getstuff();

        }

        protected void TimerforN_Tick(object sender, EventArgs e)
        {
            getstuff();
            
            loop.Text = "Page refreshed at: " + DateTime.Now.ToLongTimeString();


        }
        public void getstuff()
        {
            tabs.Controls.Clear();
            ArrayList list = new ArrayList();
            
            using (SqlConnection connection = new
   SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
   "NotificationConnectionString1"].ConnectionString))
            {

                connection.Open();
                String query1 =" SELECT sender,filename,type,id,status,message,timepost,commentid from [dbo].[notification]where receiver ='" + session.SName + "' order by id desc";
                String query0 = " SELECT count(*) from [dbo].[notification]where receiver ='" + session.SName + "'";
                String query2 = " SELECT count(*) from [dbo].[notification]where receiver ='" + session.SName + "' and status='no'";
                SqlCommand cc = new SqlCommand(query0, connection);
                a= (int)(cc.ExecuteScalar());
                SqlCommand q = new SqlCommand(query2, connection);
                int newnotify = (int)(q.ExecuteScalar());
                counter.InnerHtml = newnotify.ToString();
                if (newnotify > 1)
                {
                    header.InnerText = "You have " + newnotify + " unread/new notifications!";
                }
                else if (newnotify == 1)
                {
                    header.InnerText = "You have " + newnotify + " unread/new notification!";
                }
                else
                {
                    header.InnerText = "You have no unread/new notifications!";
                    counter.InnerHtml = "";
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
                    ha.send = dt.Rows[i][0].ToString();
                    ha.filename = dt.Rows[i][1].ToString();
                    ha.type = dt.Rows[i][2].ToString();
                    ha.id = int.Parse(dt.Rows[i][3].ToString());
                    ha.status= dt.Rows[i][4].ToString();
                    ha.msg = dt.Rows[i][5].ToString();
                    ha.datet = dt.Rows[i][6].ToString();
                    ha.CID= dt.Rows[i][7].ToString();
                    if (ha.CID == "")
                        ha.CID = "0";
                    list.Add(ha);
                    HtmlGenericControl li = new HtmlGenericControl("li");
                    li.Attributes.Add("id", ha.id.ToString());
                    
                    if (ha.status == "no")
                    {
                        li.Style.Add("background-color", "lightblue");
                        
                    }
                    else
                    {
                        li.Style.Add("background-color", "#F5F5DC");
                    }
                    li.Attributes.Add("onclick", "ha(" + ha.id.ToString() + "," + ha.CID + ")");
                    tabs.Controls.Add(li);
                    HtmlGenericControl h6 = new HtmlGenericControl("h6");
                    DateTime datetime = DateTime.Parse(ha.datet);

                    h6.InnerHtml = TimeAgo(datetime);
                    li.Controls.Add(h6);

                    HtmlGenericControl h5 = new HtmlGenericControl("h5");
                    HtmlGenericControl s0 = new HtmlGenericControl("span");
                    h5.Controls.Add(s0);
                    HtmlGenericControl s1 = new HtmlGenericControl("span");
                    HtmlGenericControl a = new HtmlGenericControl("a");
                    a.Attributes.Add("href", "user.aspx" );
                    a.InnerHtml = ha.send;
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
                        s2.InnerHtml= " commissioned your product ";
                    }
                    else if (ha.type == "3")
                    {
                        //h5.InnerText = ha.send + " commented '" + ha.msg + "' at " + ha.filename;
                        s2.InnerHtml= " commented '" + ha.msg + "' on your product ";
                    }
                    HtmlGenericControl s3 = new HtmlGenericControl("span");
                    HtmlGenericControl a1 = new HtmlGenericControl("a");
                    a1.Attributes.Add("href", "google.com");
                    a1.InnerHtml = ha.filename;
                    s0.Controls.Add(s3);
                    s3.Controls.Add(a1);

                    li.Controls.Add(h5);
                    //HtmlGenericControl br = new HtmlGenericControl("br");
                    //li.Controls.Add(br);
                    //HtmlGenericControl butt = new HtmlGenericControl("input");
                    //butt.ID = ha.id.ToString();
                    //butt.Attributes.Add("type", "button");
                    //butt.InnerHtml = "Delete this notification";
                    ////butt.Click += new EventHandler(this.ho_Click);
                    //butt.Attributes.Add("onclick", "del(this.id)");
                    //li.Controls.Add(butt);
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
        protected void lmao(String id)
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
    }
}

      
