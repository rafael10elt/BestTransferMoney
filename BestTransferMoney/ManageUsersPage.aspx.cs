using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BestTransferMoney
{
    public partial class ManageUsersPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGrid();
        }
        public void BindGrid()
        {
            using (BestTransferMoneyModelContainer db = new BestTransferMoneyModelContainer())
            {


                if (db.Users.Count() > 0)
                {

                    gvUsers.DataSource = (from u in db.Users
                                          select new
                                          {
                                              u.UserId,
                                              u.FirstName,
                                              u.LastName,
                                              u.Email,
                                              u.Password,
                                              u.Admin,
                                              u.PhoneNumber
                                          }).ToList();
                    gvUsers.DataBind();
                }
                else
                {
                    gvUsers.DataSource = null;
                    gvUsers.DataBind();
                }
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            BestTransferMoneyModelContainer db = new BestTransferMoneyModelContainer();
            int UserId = Convert.ToInt32(txtUserId.Text);
            User user = db.Users.First(u => u.UserId == UserId);

            user.Email = txtEmail.Text;
            user.FirstName = txtFirstName.Text;
            user.LastName = txtLastName.Text;
            user.Password = txtPassword.Text;
            user.PhoneNumber = txtPhoneNumber.Text;
            if (rdYes.Checked == true)
            {
                user.Admin = "Yes";
            }
            else
            {
                user.Admin = "No";
            }

            db.SaveChanges();
            BindGrid();

            txtConfirmPassword.Text = "";
            txtEmail.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPassword.Text = "";
            txtPhoneNumber.Text = "";
            txtSearch.Text = "";
            txtUserId.Text = "";
        }


        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtConfirmPassword.Text = "";
            txtEmail.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPassword.Text = "";
            txtPhoneNumber.Text = "";
            txtSearch.Text = "";
            txtUserId.Text = "";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindSearch();
        }
        public void BindSearch()
        {
            using (BestTransferMoneyModelContainer db = new BestTransferMoneyModelContainer())
            {
                if (db.Users.Count() > 0)
                {
                    gvUsers.DataSource = (from u in db.Users
                                          where u.FirstName.Contains(txtSearch.Text) ||
                                          u.Email.Contains(txtSearch.Text) ||
                                          u.LastName.Contains(txtSearch.Text) ||
                                          u.PhoneNumber.Contains(txtSearch.Text) ||
                                          u.Admin.Contains(txtSearch.Text)
                                          select new
                                          {
                                              u.UserId,
                                              u.FirstName,
                                              u.LastName,
                                              u.Email,
                                              u.Password,
                                              u.Admin,
                                              u.PhoneNumber
                                          }).ToList();
                    gvUsers.DataBind();

                }
            }

        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Admin")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvUsers.Rows[index];
                int UserId = Convert.ToInt32(gvUsers.DataKeys[index].Value);
                BestTransferMoneyModelContainer db = new BestTransferMoneyModelContainer();
                User user = db.Users.First(u => u.UserId == UserId);
                user.Admin = "Yes";

                db.SaveChanges();
            }
            else if (e.CommandName == "Undo")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvUsers.Rows[index];
                int UserId = Convert.ToInt32(gvUsers.DataKeys[index].Value);
                BestTransferMoneyModelContainer db = new BestTransferMoneyModelContainer();
                User user = db.Users.First(u => u.UserId == UserId);
                user.Admin = "No";

                db.SaveChanges();
            }
            else if (e.CommandName == "More")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvUsers.Rows[index];
                int UserId = Convert.ToInt32(gvUsers.DataKeys[index].Value);
                Response.Redirect("UserDetail.aspx?userId=" + UserId);
            }

            BindGrid();
        }

        protected void gvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            using (BestTransferMoneyModelContainer db = new BestTransferMoneyModelContainer())
            {
                int userid = Convert.ToInt32(gvUsers.DataKeys[e.RowIndex].Value);
                User user = db.Users.First(x => x.UserId == userid);
                db.Users.Remove(user);
                db.SaveChanges();
            }
            BindGrid();
        }

        protected void gvUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            using (BestTransferMoneyModelContainer db = new BestTransferMoneyModelContainer())
            {
                int UserId = Convert.ToInt32(gvUsers.DataKeys[e.RowIndex].Value);
                User user = db.Users.First(x => x.UserId == UserId);

                txtUserId.Text = user.UserId.ToString();
                txtEmail.Text = user.Email;
                txtFirstName.Text = user.FirstName;
                txtLastName.Text = user.LastName;
                txtPhoneNumber.Text = user.PhoneNumber;
                txtPassword.Text = user.Password;
                txtConfirmPassword.Text = user.Password;
                if (user.Admin == "Yes")
                {
                    rdYes.Checked = true;
                }
                else
                {
                    rdNo.Checked = true;
                }

            }
        }
    }
}