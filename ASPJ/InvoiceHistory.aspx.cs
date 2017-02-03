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
    public partial class InvoiceHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void ret()
        {
            using (SqlConnection connection = new
  SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
  "NotificationConnectionString1"].ConnectionString))
            {

                connection.Open();
                //String query1 = " SELECT  from [dbo].[Invoices]where userid ='" + GetCounter.SName;
                //String query0 = " SELECT count(*) from [dbo].[Invoices]where receiver ='" + GetCounter.SName + "'";
                //String query2 = " SELECT count(*) from [dbo].[notification]where receiver ='" + session.SName + "' and status='no'";
                //SqlCommand cc = new SqlCommand(query0, connection);



                //MsgBox("You have no new notifications!");
                //header.InnerText = "You have " + newnotify + " unread notifications!";
                //SqlCommand cc1 = new SqlCommand(query1, connection);

                //SqlDataAdapter da = new SqlDataAdapter(cc1);
                DataTable dt = new DataTable();
                dt.Clear();
                //da.Fill(dt);
                connection.Close();
            }
        }
    }
}