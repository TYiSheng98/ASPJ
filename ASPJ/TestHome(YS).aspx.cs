﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPJ
{
    public partial class TestHome_YS_ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            String ID = "";
            String password = "";
            //try
            //{
                using (SqlConnection connection = new
    SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[
    "NotificationConnectionString1"].ConnectionString))
                {

                    connection.Open();
                    String query;
                    query = " SELECT username,password from [dbo].[user]where username =@ID and password =@password";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@ID", Username.Text);
                    cmd.Parameters.AddWithValue("@password", Password.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    dt.Clear();
                    da.Fill(dt);
                    ID = dt.Rows[0][0].ToString();
                    password = dt.Rows[0][1].ToString();

                    //using (SqlDataReader reader = cmd.ExecuteReader())
                    //{

                    //        while (reader.Read())
                    //        {

                    //            ID = reader.GetString(1);
                    //            password = reader.GetString(2);
                    //             }

                    //}
                    if (Username.Text.Equals(ID) && Password.Text.Equals(password))
                    {
                        Session["ID"] = ID;
                        //GetCounter.SName = (String)Session["ID"];

                        Response.Redirect("home.aspx");

                    }
                    else
                        MsgBox("Login failed.Please try again!");
                }
            //}
            //catch (Exception ex)
            //{
            //    MsgBox("Login Failed!");
            //}
        }


        public void MsgBox(String msg)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language='javascript'>alert('" + msg + "')</script>");
        }
    }
}