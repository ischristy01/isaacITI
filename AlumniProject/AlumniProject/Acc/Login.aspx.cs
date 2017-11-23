using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;

namespace AlumniProject.Acc
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student = student.Login(txtEmail.Text, txtPassword.Text);

            if(student.Version == 0)
            {
                Session.Add("student", student);
                Response.Redirect("ChangePassword.aspx");
            }
            else if(student!=null)
            {
                Session.Add("student", student);
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                lblStatus.Text = "Invalid Email or Password";
            }
        }
    }
}