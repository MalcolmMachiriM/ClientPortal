using CrystalDecisions.ReportAppServer.DataDefModel;
using PenPortfolio.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PenPortfolio
{
    public partial class MemberContributions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            QueryStringModule qn = new QueryStringModule();
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {

                ClearAlert();   
                txtFundID.Value = "0";
                if (Request.QueryString["RegNo"] != "")
                {
                    //txtFundID.Value = HttpUtility.UrlDecode(Request.QueryString["RegNo"].ToString());
                    txtFundID.Value = qn.Decrypt(HttpUtility.UrlDecode(Request.QueryString["RegNo"]));
                }
                else
                {
                    WarningAlert("No RegNo for user");
                }
                if (Request.QueryString["SystemRef"] != "")
                {
                    ////txtMemberID.Value = HttpUtility.UrlDecode(Request.QueryString["SystemRef"].ToString());
                    txtMemberID.Value = qn.Decrypt(HttpUtility.UrlDecode(Request.QueryString["SystemRef"]));
                    //GetMemberDetails(int.Parse(txtMemberID.Value));
                    getContributionHistory();
                }

                else
                {
                    WarningAlert("No Systemref for user");
                }
            }

        }
        #region alerts
        protected void ClearAlert()
        {
            pnlDanger.Visible = false;
            lblDanger.Text = "";

            pnlSuccess.Visible = false;
            lblSuccess.Text = "";

            pnlWarning.Visible = false;
            lblWarning.Text = "";
        }
        protected void RedAlert(string str)
        {
            pnlDanger.Visible = true;
            lblDanger.Text = str;

            pnlSuccess.Visible = false;
            lblSuccess.Text = "";

            pnlWarning.Visible = false;
            lblWarning.Text = "";
        }
        public void SuccessAlert(string str)
        {
            pnlSuccess.Visible = true;
            lblSuccess.Text = str;

            pnlWarning.Visible = false;
            lblWarning.Text = "";

            pnlDanger.Visible = false;
            lblDanger.Text = "";
        }
        public void WarningAlert(string str)
        {
            pnlSuccess.Visible = false;
            lblSuccess.Text = "";

            pnlWarning.Visible = true;
            lblWarning.Text = str;

            pnlDanger.Visible = false;
            lblDanger.Text = "";
        }
        #endregion

        protected void getContributionHistory()
        {
            try
            {
                LookUp c = new LookUp("cn", 1);
                //string RegNo = c.getRegNo(int.Parse(txtFundID.Value));
                System.Data.DataSet datdsaSet = c.getMemberContributions(int.Parse(txtMemberID.Value), txtFundID.Value);

                if (datdsaSet != null && datdsaSet.Tables[0] != null && datdsaSet.Tables[0].Rows !=null)
                {
                    grdContributions.DataSource = c.getMemberContributions(int.Parse(txtMemberID.Value), txtFundID.Value);
                    grdContributions.DataBind();

                }
                else
                {
                    grdContributions.DataSource = null;
                    grdContributions.DataBind();
                    WarningAlert("No Contributions Found");
                }
            }
            catch (Exception ex)
            {
                RedAlert(ex.Message);
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
    }
}