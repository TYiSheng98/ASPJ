
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ASPJ
{
    public class GetCounter
    {
        

        //put in every page Hfield then run the javascript in every page! 
        public static int getnotifycounter(String SName)
        {
            
            int newnotify;
            using (SqlConnection connection = new
   SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
   "NotificationConnectionString1"].ConnectionString))
            {
                connection.Open();
                String query2 = " SELECT count(*) from [dbo].[notification]where receiver ='" + SName + "' and status='no'";
                SqlCommand q = new SqlCommand(query2, connection);
                newnotify = (int)(q.ExecuteScalar());
                connection.Close();

            }
            return newnotify;
        }
        
    }
}