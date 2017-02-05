using ASPJ.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPJ
{
    public partial class _Default : System.Web.UI.Page
    {
        String userid;        
        protected void Page_Load(object sender, EventArgs e)
        {
            bool val1 = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            if (val1 == true)
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                ApplicationUser user = manager.FindById(User.Identity.GetUserId());
                userid = user.Id;
                
                //int count = getnotifycounter(userid);
                //NO.Value = count.ToString();               
            }

        }

        public void MsgBox(String msg)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language='javascript'>alert('" + msg + "')</script>");
        }
   //     public static int getnotifycounter(String SID)
   //     {

   //         int newnotify;
   //         using (SqlConnection connection = new
   //SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
   //"NotificationConnectionString1"].ConnectionString))
   //         {
   //             connection.Open();
   //             String query2 = " SELECT count(*) from [dbo].[notification]where receiver ='" + SID + "' and status='no'";
   //             SqlCommand q = new SqlCommand(query2, connection);
   //             newnotify = (int)(q.ExecuteScalar());
   //             connection.Close();

   //         }
   //         return newnotify;
   //     }
       
        //protected void RF_Tick(object sender, EventArgs e)
        //{
        //    int count = getnotifycounter(name);
        //    NO.Value = count.ToString();
        //}
    }
}