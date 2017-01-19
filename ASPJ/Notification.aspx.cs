using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ASPJ
{
    public partial class Notification : System.Web.UI.Page
    {
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
            notify ha = new notify();
            using (SqlConnection connection = new
   SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
   "NotificationConnectionString1"].ConnectionString))
            {

                connection.Open();
                String query;
                query = " SELECT sender,filename,type from [dbo].[user]where receiver =" + session.SName;
                SqlCommand cc = new SqlCommand(query, connection);
                //cc.Parameters.AddWithValue("@1", Username.Text);
                //cc.Parameters.AddWithValue("@2", Password.Text);
                SqlDataAdapter da = new SqlDataAdapter(cc);
                DataTable dt = new DataTable();
                dt.Clear();
                da.Fill(dt);
                //type = int.Parse(dt.Rows[0][0].ToString());
                //send = dt.Rows[0][1].ToString();
                //msg = dt.Rows[0][2].ToString();
                //st = dt.Rows[0][3].ToString();
                ha.send = dt.Rows[0][0].ToString();
                ha.filename = dt.Rows[0][1].ToString();
                ha.type = dt.Rows[0][2].ToString();
                connection.Close();
            }

            HtmlGenericControl li = new HtmlGenericControl("li");

            HtmlGenericControl anchor = new HtmlGenericControl("a");
            anchor.Attributes.Add("href", "#");
            if (ha.type.Equals("1"))
            {
                anchor.InnerText = ha.send + "like your page!";
            }

            li.Controls.Add(anchor);
            tabs.Controls.Add(li);
        }
        public void MsgBox(String msg)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language='javascript'>alert('" + msg + "')</script>");
        }
    }
}

      
