using PenPortfolio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace PenPortfolio
{
    public partial class ViewMemberContributions : System.Web.UI.Page
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
                    //GetMemberDetails(int.Parse(txtMemberID.Value));
                    getContributionHistory();
                }

            }
        }
        protected void grdContributions_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdContributions.PageIndex = e.NewPageIndex;

            this.BindGrid();
        }
        private void BindGrid()
        {
            GetMemberDetails(int.Parse(txtMemberID.Value));
        }
        protected void getContributionHistory()
        {
            try
            {
                LookUp c = new LookUp("cn", 1);
                //string RegNo = c.getRegNo(int.Parse(txtFundID.Value));

                if (c.getMemberContributions(int.Parse(txtMemberID.Value), txtFundID.Value) != null)
                {
                    grdContributions.DataSource = c.getMemberContributions(int.Parse(txtMemberID.Value), txtFundID.Value);
                    grdContributions.DataBind();
                    //btnExport.Visible = true;


                }
                else
                {
                    grdContributions.DataSource = null;
                    grdContributions.DataBind();
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
                LookUp c = new LookUp("cn", 1);
                //string RegNo = c.getRegNo(int.Parse(txtFundID.Value));

                if (c.getMemberContributions(int.Parse(txtMemberID.Value), txtFundID.Value) != null)
                {
                    grdContributions.DataSource = c.getMemberContributions(int.Parse(txtMemberID.Value), txtFundID.Value);
                    grdContributions.DataBind();
                    //btnExport.Visible = true;


                }
                else
                {
                    grdContributions.DataSource = null;
                    grdContributions.DataBind();
                }
            }
            catch (Exception ex)
            {
                //RedAlert(ex.Message);
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