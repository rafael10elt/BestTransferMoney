using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BestTransferMoney
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            using (var db = new BestTransferMoneyModelContainer())
            {
                var EmailResult =
                    (from em in db.Users
                     where em.Email == txtEmail.Text
                     select em.Email).SingleOrDefault();

                var PasswordResult =
                    (from en in db.Users
                     where en.Email == txtEmail.Text
                     select en.Password).SingleOrDefault();

                var VerifyAdmin =
                    (from v in db.Users
                     where v.Email == txtEmail.Text
                     select v.Admin).SingleOrDefault();

                var VerifyUserId = (from u in db.Users
                                    where u.Email == txtEmail.Text
                                    select u.UserId).SingleOrDefault();

                var VerifyFirstName = (from u in db.Users
                                    where u.Email == txtEmail.Text
                                    select u.FirstName).SingleOrDefault();

                if (EmailResult != txtEmail.Text)
                {
                    lblEmailValidation.Visible = true;
                }
                else if (PasswordResult != txtPassword.Text)
                {
                    lblPasswordValidation.Visible = true;
                }
                else
                {
                    Session["Email"] = txtEmail.Text;
                    Session["Admin"] = VerifyAdmin;
                    Session["UserId"] = VerifyUserId;
                    Session["FirstName"] = VerifyFirstName;
                    Response.Redirect("Default.aspx?user=" + txtEmail.Text);
                }
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtEmail.Text = "";
            txtPassword.Text = "";
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUpPage.aspx");
        }
    }
}