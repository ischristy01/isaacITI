using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;

namespace AlumniProject.Acc
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["student"] == null)
            {
                Response.Redirect("Login.aspx");
            }



        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (Session["student"] != null)
            {
                Student student = (Student)Session["student"];
                if (txtNewPassword.Text == txtConfirm.Text)
                {
                    student.Password = txtNewPassword.Text;
                    student.Save();
                }
            }
        }
    }
}