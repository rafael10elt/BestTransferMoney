using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BestTransferMoney
{
    public partial class ManageOrdersPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGrid();
        }
        public void BindGrid()
        {
            using (BestTransferMoneyModelContainer db = new BestTransferMoneyModelContainer())
            {


                if (db.Orders.Count() > 0)
                {

                    gvOrders.DataSource = (from o in db.Orders
                                           select new
                                           {
                                               o.AmountTotal,
                                               o.Amount,
                                               o.CurrencyFrom,
                                               o.CurrencyTo,
                                               o.Date,
                                               o.OrderId,
                                               o.UserUserId
                                           }).ToList();
                    gvOrders.DataBind();
                }
                else
                {
                    gvOrders.DataSource = null;
                    gvOrders.DataBind();
                }
            }
        }
        public void BindSearch()
        {
            using (BestTransferMoneyModelContainer db = new BestTransferMoneyModelContainer())
            {
                if (db.Orders.Count() > 0)
                {
                    gvOrders.DataSource = (from o in db.Orders
                                           where o.Amount.Contains(txtSearch.Text) ||
                                           o.AmountTotal.Contains(txtSearch.Text) ||
                                           o.CurrencyFrom.Contains(txtSearch.Text) ||
                                           o.CurrencyTo.Contains(txtSearch.Text) ||
                                           o.Date.Contains(txtSearch.Text)
                                           select new
                                           {
                                               o.AmountTotal,
                                               o.Amount,
                                               o.CurrencyFrom,
                                               o.CurrencyTo,
                                               o.Date,
                                               o.OrderId,
                                               o.UserUserId
                                           }).ToList();
                    gvOrders.DataBind();

                }
            }

        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindSearch();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            BestTransferMoneyModelContainer db = new BestTransferMoneyModelContainer();
            int OrderId = Convert.ToInt32(txtOrderId.Text);
            Order ord = db.Orders.First(u => u.OrderId == OrderId);

            ord.AmountTotal = txtTotal.Text;
            ord.CurrencyFrom = ddlFrom.Text;
            ord.CurrencyTo = ddlTo.Text;
            ord.Amount = txtAmount.Text;
            ord.AmountTotal = txtTotal.Text;

            db.SaveChanges();
            BindGrid();

            txtAmount.Text = "";
            txtTotal.Text = "";
            txtTotal.Text = "";
            ddlFrom.Text = "FROM";
            ddlTo.Text = "TO";
            lblCalculation.Visible = false;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtAmount.Text = "";
            txtTotal.Text = "";
            txtTotal.Text = "";
            ddlFrom.Text = "FROM";
            ddlTo.Text = "TO";
            lblCalculation.Visible = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void gvOrders_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            using (BestTransferMoneyModelContainer db = new BestTransferMoneyModelContainer())
            {
                int orderid = Convert.ToInt32(gvOrders.DataKeys[e.RowIndex].Value);
                Order ord = db.Orders.First(x => x.OrderId == orderid);
                db.Orders.Remove(ord);
                db.SaveChanges();
            }
            BindGrid();
        }

        protected void gvOrders_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            using (BestTransferMoneyModelContainer db = new BestTransferMoneyModelContainer())
            {
                int OrderId = Convert.ToInt32(gvOrders.DataKeys[e.RowIndex].Value);
                Order ord = db.Orders.First(x => x.OrderId == OrderId);

                txtOrderId.Text = ord.OrderId.ToString();
                txtAmount.Text = ord.Amount;
                txtTotal.Text = ord.AmountTotal;
                txtTotal.Text = ord.AmountTotal;
                ddlFrom.Text = ord.CurrencyFrom;
                ddlTo.Text = ord.CurrencyTo;

            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            BindGrid();
        }
        public void Calculation()
        {
            double result = 0;
            if (ddlFrom.Text == "CAD$" && ddlTo.Text == "US$")
            {
                result = Convert.ToDouble(txtAmount.Text) / 1.20 * 1.05;
                lblCalculation.Text = "CAD$ " + txtAmount.Text + " / 1.20 + 5%(tax) = " + result;
                txtTotal.Text = "US$" + result.ToString();

            }
            else if (ddlFrom.Text == "CAD$" && ddlTo.Text == "R$")
            {
                result = Convert.ToDouble(txtAmount.Text) * 2.70 * 1.05;
                lblCalculation.Text = "CAD$ " + txtAmount.Text + " * 2.70 + 5%(tax) = " + result;
                txtTotal.Text = "R$" + result.ToString();
            }
            else if (ddlFrom.Text == "US$" && ddlTo.Text == "CAD$")
            {
                result = Convert.ToDouble(txtAmount.Text) * 1.20 * 1.05;
                lblCalculation.Text = "US$ " + txtAmount.Text + " * 1.20 + 5%(tax) = " + result;
                txtTotal.Text = "CAD$" + result.ToString();
            }
            else if (ddlFrom.Text == "US$" && ddlTo.Text == "R$")
            {
                result = Convert.ToDouble(txtAmount.Text) * 3.60 * 1.05;
                lblCalculation.Text = "US$ " + txtAmount.Text + " * 3.60 + 5%(tax) = " + result;
                txtTotal.Text = "R$" + result.ToString();

            }
            else if (ddlFrom.Text == "R$" && ddlTo.Text == "US$")
            {
                result = Convert.ToDouble(txtAmount.Text) / 3.60 * 1.05;
                lblCalculation.Text = "R$ " + txtAmount.Text + " / 3.60 + 5%(tax) = " + result;
                txtTotal.Text = "US$" + result.ToString();
            }
            else if (ddlFrom.Text == "R$" && ddlTo.Text == "CAD$")
            {
                result = Convert.ToDouble(txtAmount.Text) / 2.70 * 1.05;
                lblCalculation.Text = "R$ " + txtAmount.Text + " / 2.70 + 5%(tax) = " + result;
                txtTotal.Text = "CAD$" + result.ToString();
            }
            else if (ddlFrom.Text == "R$" && ddlTo.Text == "R$")
            {
                result = Convert.ToDouble(txtAmount.Text) * 1.05;
                lblCalculation.Text = "R$ " + txtAmount.Text + " + 5 % (tax) = " + result;
                txtTotal.Text = "R$" + result.ToString();
            }
            else if (ddlFrom.Text == "US$" && ddlTo.Text == "US$")
            {
                result = Convert.ToDouble(txtAmount.Text) * 1.05;
                lblCalculation.Text = "US$ " + txtAmount.Text + " + 5 % (tax) = " + result;
                txtTotal.Text = "US$" + result.ToString();
            }
            else if (ddlFrom.Text == "CAD$" && ddlTo.Text == "CAD$")
            {
                result = Convert.ToDouble(txtAmount.Text) * 1.05;
                lblCalculation.Text = "CAD$ " + txtAmount.Text + " + 5 % (tax) = " + result;
                txtTotal.Text = "CAD$" + result.ToString();
            }
            else
            {

            }
            lblCalculation.Visible = true;

        }
        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            Calculation();
        }
    }
}