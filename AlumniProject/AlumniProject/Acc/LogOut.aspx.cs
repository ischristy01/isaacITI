using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;

namespace AlumniProject.Acc
{
    public partial class LogOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
       
            Student student = (Student)Session["student"];
            lblLogout.Text = string.Format("You have successfully logged out, {0}", student.FirstName);
            Session["student"] = null;
            ///Session.Abandon();
        }
    }
}