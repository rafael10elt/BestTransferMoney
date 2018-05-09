using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BestTransferMoney
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {                      
            if (Session["Email"] != null)
            {
                lblUser.Text = "Welcome," + Session["FirstName"];
                btnLogout.Visible = true;
                LoadUserType();
            }
        }
        public void LoadUserType()
        {
            if (Session["Admin"].ToString() == "Yes")
            {
                linkConvertPage.Visible = true;
                linkManageOrdersPage.Visible = true;
                linkManageUsersPage.Visible = true;
                
            }
            else
            {
               
            }
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();           
            FormsAuthentication.SignOut();
            Response.Redirect("LoginPage.aspx");
        }
    }
}