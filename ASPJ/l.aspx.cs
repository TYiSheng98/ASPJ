using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ASPJ
{
    public partial class l : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void ho_Click(object sender, EventArgs e)
        {
            Button d = (Button)sender;
            MsgBox(d.ID);
        }
        public void MsgBox(String msg)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language='javascript'>alert('" + msg + "')</script>");
        }
        public void lalacall(object sender, EventArgs e)
        {
            
            // sender is the li dom element you'll need to cast it though.
            var p = (HtmlControl)sender;
            MsgBox(p.ID);
        }
        //protected void d(object sender, EventArgs e)
        //{
        //    var p = (HtmlControl)sender;
        //    MsgBox(p.ID);
        //}
    }
}