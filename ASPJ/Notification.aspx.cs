using System;
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
        notify ha = new notify();
        protected void Page_Load(object sender, EventArgs e)
        {
            Inital.Text = "Page loaded at: " + DateTime.Now.ToLongTimeString();
            lol();
            
        }
        

        protected void TimerforN_Tick(object sender, EventArgs e)
        {
            lol();
            loop.Text = "Page refreshed at: " + DateTime.Now.ToLongTimeString();
   

        }
        public void lol()
        {
            
            using (SqlConnection connection = new
   SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
   "NotificationConnectionString1"].ConnectionString))
            {

                connection.Open();
                String query;
                query = " SELECT sender,filename,type,id from [dbo].[notification]where receiver ='" + session.SName+"'";
                SqlCommand cc = new SqlCommand(query, connection);
                //cc.Parameters.AddWithValue("@1", Username.Text);
                //cc.Parameters.AddWithValue("@2", Password.Text);
                SqlDataAdapter da = new SqlDataAdapter(cc);
                DataTable dt = new DataTable();
                dt.Clear();
                da.Fill(dt);
                connection.Close();
                ha.send = dt.Rows[0][0].ToString();
                ha.filename = dt.Rows[0][1].ToString();
                ha.type = dt.Rows[0][2].ToString();
                ha.id = int.Parse(dt.Rows[0][3].ToString());
                
            }

            HtmlGenericControl li = new HtmlGenericControl("li");
            li.Attributes.Add("id","yaa");
            li.Attributes.Add("class", "ya");
            Button butt = new Button();
            butt.Attributes.Add("id", ha.id.ToString());
            butt.BackColor = Color.FromArgb(66, 134, 244);
            butt.Text= Server.HtmlEncode(ha.send + " like your page!");
            butt.Click += new EventHandler(this.ho_Click);


            li.Controls.Add(butt);
            tabs.Controls.Add(li);
        }
        protected void ho_Click(object sender, EventArgs e)
        {
            
            //cannot get button id
            Button clickedButton = (Button)sender;
            //clickedButton.Text = "...button clicked...";
            
            clickedButton.BackColor = Color.Beige;
            //sql update UPDATE [dbo].[notification] set status = 'yes' WHERE id =12;
            using (SqlConnection connection = new
   SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
   "NotificationConnectionString1"].ConnectionString))
            {

                connection.Open();
                String query;
                query = " UPDATE [dbo].[notification] set status = 'yes' WHERE id =" +  xxxx;
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

      
