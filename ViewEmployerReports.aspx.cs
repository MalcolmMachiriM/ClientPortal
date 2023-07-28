using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PenPortfolio
{
    public partial class ViewEmployerReports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                txtFundID.Value = "0";
                if (Request.QueryString["FundID"] != "")
                {
                    txtFundID.Value = Request.QueryString["FundID"].ToString();
                }
                if (Request.QueryString["SystemRef"] != "")
                {
                    txtMemberID.Value = Request.QueryString["SystemRef"].ToString();
                }

            }
        }

        protected void lblContributionSummary_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("ContributionSummaryReport?FundID={0}&SystemRef={1}", txtFundID.Value, txtMemberID.Value));
        }

        protected void lblBranchSummary_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("BranchSummary?FundID={0}&SystemRef={1}", txtFundID.Value, txtMemberID.Value));
        }
    }
}