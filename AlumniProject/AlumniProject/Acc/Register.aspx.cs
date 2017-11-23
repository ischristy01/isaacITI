using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;

namespace AlumniProject.Acc
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                DepartmentList departments = new DepartmentList();
                departments = departments.GetAll();
                ddlDepartments.DataSource = departments.List;
                ddlDepartments.DataBind();
            }
         
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {try
            {
                Student student = new Student();
                string Email = txtEmail.Text;
                string FirstName = txtFirstName.Text;
                string LastName = txtLastName.Text;
                Guid DepartmentId = Guid.Parse(ddlDepartments.SelectedValue);
                student.Register(Email, FirstName, LastName, DepartmentId);
            }
           catch(Exception ex)
            {
                lblStatus.Text = ex.Message;
            }
          
        }
    }
}