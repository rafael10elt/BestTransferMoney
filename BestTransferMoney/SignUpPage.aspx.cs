using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BestTransferMoney
{
    public partial class SignUpPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            BestTransferMoneyModelContainer db = new BestTransferMoneyModelContainer();
            var u = new User();
            u.Admin = "No";
            u.Email = txtEmail.Text;
            u.FirstName = txtFirstName.Text;
            u.LastName = txtLastName.Text;
            u.Password = txtPassword.Text;
            u.PhoneNumber = txtPhoneNumber.Text;

            db.Users.Add(u);
            db.SaveChanges();

            Response.Redirect("LoginPage.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtConfirmPassword.Text = "";
            txtEmail.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPassword.Text = "";
            txtPhoneNumber.Text = "";
        }
    }
}