using PenPortfolio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace PenPortfolio
{
    public partial class PensionerDependants : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                txtFundID.Value = "0";
                if (Request.QueryString["RegNo"] != null)
                {
                    txtFundID.Value = Request.QueryString["RegNo"].ToString();
                }
                if (Request.QueryString["PensionNo"] != null)
                {
                    txtMemberID.Value = Request.QueryString["PensionNo"].ToString();
                    //GetMemberDetails(int.Parse(txtMemberID.Value));
                    getDependants(int.Parse(txtMemberID.Value));
                }

            }
        }
        protected void grdDependants_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdDependants.PageIndex = e.NewPageIndex;

            this.BindGrid();
        }
        private void BindGrid()
        {
            try
            {
                LookUp g = new LookUp("cn", 1);
                if (g.getDependants(int.Parse(txtMemberID.Value)) != null)
                {
                    grdDependants.DataSource = g.getDependants(int.Parse(txtMemberID.Value));
                    grdDependants.DataBind();
                }
                else
                {
                    grdDependants.DataSource = null;
                    grdDependants.DataBind();
                }
            }
            catch (Exception ex)
            {
                //RedAlert(ex.Message);
            }
        }
        protected void getDependants(int PensionsNo)
        {
            try
            {
                LookUp g = new LookUp("cn", 1);
                if (g.getDependants(PensionsNo) != null)
                {
                    grdDependants.DataSource = g.getDependants(PensionsNo);
                    grdDependants.DataBind();
                }
                else
                {
                    grdDependants.DataSource = null;
                    grdDependants.DataBind();
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