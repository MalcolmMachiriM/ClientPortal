using PenPortfolio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace PenPortfolio
{
    public partial class PensionerPayrollSummary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                txtFundID.Value = "0";
                if (Request.QueryString["RegNo"] != "")
                {
                    txtFundID.Value = Request.QueryString["RegNo"].ToString();
                }
                if (Request.QueryString["SystemRef"] != "")
                {
                    txtMemberID.Value = Request.QueryString["SystemRef"].ToString();
                    GetMemberDetails(int.Parse(txtMemberID.Value));
                }

            }
        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdClientsView.PageIndex = e.NewPageIndex;
           
            this.BindGrid();
        }
        private void BindGrid()
        {
            GetMemberDetails(int.Parse(txtMemberID.Value));
        }
        protected void getPAysliphistory(int PensionsNo)
        {
            try
            {
                LookUp g = new LookUp("cn", 1);
                if (g.getPensionerHistory(txtFundID.Value, PensionsNo) != null)
                {
                    grdClientsView.DataSource = g.getPensionerHistory(txtFundID.Value, PensionsNo);
                    grdClientsView.DataBind();
                }
                else
                {
                    grdClientsView.DataSource = null;
                    grdClientsView.DataBind();
                }
            }
            catch (Exception ex)
            {
                //RedAlert(ex.Message);
            }
        }

     
        protected void GetMemberDetails(int MemberID)
        {
            try
            {
                LookUp g = new LookUp("cn", 1);
                if (g.Retrieve(MemberID) != false)
                {
                    //txtPensionNumber.Text = g.PensionNo.ToString();
                    txtFirstName.Text = g.FirstName;
                    txtLastName.Text = g.LastName;
                    //txtNationalID.Text = g.NationalID;
                    //txtStatus.Text = g.Active.ToString();
                    getPAysliphistory(MemberID);

                }

            }
            catch (Exception g)
            {
            }

        }

        /*NAvigation lInks*/
        //protected void lnkBankingandAddressDetails_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("PensionersBankingDetailsAndContactDetails.aspx?FundID=" + txtFundID.Value + "&MemberID=" + txtMemberID.Value + "");
        //}

        //protected void lnkPersonalandPaymentDetails_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("PensionersPersonalAndPayment.aspx?FundID=" + txtFundID.Value + "&MemberID=" + txtMemberID.Value + "");
        //}

        //protected void lnkFormerMemberDetails_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("PensionersFormerMemberDetails.aspx?FundID=" + txtFundID.Value + "&MemberID=" + txtMemberID.Value + "");
        //}

        //protected void lnkPensionersPayslipHistory_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("PensionersPayslipHistory.aspx?FundID=" + txtFundID.Value + "&MemberID=" + txtMemberID.Value + "");
        //}

        //protected void btnDashboard_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect(string.Format("../Home/Home?FundID={0}", txtFundID.Value));
        //}

        /*NAvigation lInks*/
    }
}