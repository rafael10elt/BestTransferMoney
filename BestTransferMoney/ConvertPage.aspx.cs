using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BestTransferMoney
{
    public partial class ConvertPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            lblDate.Text = DateTime.Now.ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            BestTransferMoneyModelContainer db = new BestTransferMoneyModelContainer();
            var o = new Order();
            var user = Session["UserId"];
           // var email = Session["Email"];
            o.AmountTotal = txtTotal.Text;
            o.CurrencyFrom = ddlFrom.Text;
            o.CurrencyTo = ddlTo.Text;
            o.Amount = txtAmount.Text;
            o.Date = lblDate.Text;
            o.UserUserId = Convert.ToInt32(user);         
            
            db.Orders.Add(o);
            db.SaveChanges();

            txtAmount.Text = "";
            txtTotal.Text = "";
            ddlFrom.Text = "FROM";
            ddlTo.Text = "TO";
            lblCalculation.Visible = false;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtAmount.Text = "";
            txtTotal.Text = "";
            ddlFrom.Text = "FROM";
            ddlTo.Text = "TO";
            lblCalculation.Visible = false;
        }
        public void Calculation()
        {
            double result = 0;
            if (ddlFrom.Text == "CAD$" && ddlTo.Text == "US$")
            {
                result = Convert.ToDouble(txtAmount.Text) / 1.20 * 1.05;
                lblCalculation.Text = "CAD$ "+ txtAmount.Text + " / 1.20 + 5%(tax) = " + result;
                txtTotal.Text ="US$"+ result.ToString();

            }
            else if(ddlFrom.Text == "CAD$" && ddlTo.Text == "R$")
            {
                result = Convert.ToDouble(txtAmount.Text) * 2.70 *1.05;
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
                result = Convert.ToDouble(txtAmount.Text) / 2.70 *1.05;
                lblCalculation.Text = "R$ " + txtAmount.Text + " / 2.70 + 5%(tax) = " + result;
                txtTotal.Text = "CAD$" + result.ToString();
            }
            else if (ddlFrom.Text == "R$" && ddlTo.Text == "R$")
            {
                result = Convert.ToDouble(txtAmount.Text) * 1.05;
                lblCalculation.Text = "R$ " + txtAmount.Text + " + 5 % (tax) = "+ result;
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