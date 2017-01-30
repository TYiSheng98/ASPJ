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

                    MsgBox(parameter);
                    lmao(parameter);
                    getstuff();

                }

                
            }
            getstuff();

        }       

        //protected void TimerforN_Tick(object sender, EventArgs e)
        //{
        //    lol();
        //    loop.Text = "Page refreshed at: " + DateTime.Now.ToLongTimeString();
   

        //}
        public void getstuff()
        {
            tabs.Controls.Clear();
            ArrayList list = new ArrayList();
            
            using (SqlConnection connection = new
   SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
   "NotificationConnectionString1"].ConnectionString))
            {

                connection.Open();
                String query1 =" SELECT sender,filename,type,id,status from [dbo].[notification]where receiver ='" + session.SName + "'";
                String query0 = " SELECT count(*) from [dbo].[notification]where receiver ='" + session.SName + "'";
                SqlCommand cc = new SqlCommand(query0, connection);
                a= (int)(cc.ExecuteScalar());
                
                MsgBox(a.ToString());
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
                    list.Add(ha);
                    HtmlGenericControl li = new HtmlGenericControl("li");
                    li.Attributes.Add("id", ha.id.ToString());
                    li.Attributes.Add("onclick", "ha(this.id)");
                    if (ha.status == "no")
                    {
                        li.Style.Add("background-color", "lightblue");
                    }
                    else
                    {
                        li.Style.Add("background-color", "#F5F5DC");
                    }
                    tabs.Controls.Add(li);
                    HtmlGenericControl h5 = new HtmlGenericControl("h5");
                    h5.InnerText = ha.send + " purchased your product.";
                    li.Controls.Add(h5);
                    //Button butt = new Button();
                    //butt.ID = ha.id.ToString();
                    //butt.Text = "Delete this button";
                    //butt.Click += new EventHandler(this.ho_Click);
                    //li.Controls.Add(butt);
                }
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
    }
}

      
