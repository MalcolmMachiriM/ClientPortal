using PenPortfolio.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace PenPortfolio
{
    public partial class ExitedMembers : System.Web.UI.Page
    {
        DataSet dtExited = new DataSet();
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
                    //GetMemberDetails(int.Parse(txtMemberID.Value));
                    getContributionHistory();
                }

            }
        }

        protected void AmberAlert(string MsgFlg)
        {
            lblComms.Text = "Warning: " + MsgFlg;
            pnlComms.BackColor = System.Drawing.Color.Orange;
        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdClientsView.PageIndex = e.NewPageIndex;

            this.BindGrid();
        }
        private void BindGrid()
        {
            //GetMemberDetails(int.Parse(txtMemberID.Value));
            getContributionHistory();
        }
        protected void getContributionHistory()
        {
            try
            {
                LookUp g = new LookUp("cn", 1);
                string RegNo = g.getRegNo(int.Parse(txtFundID.Value));
                string SplittedRegNo = g.getRegNo(int.Parse(txtFundID.Value));
                DataSet dat = g.Get_Participarting_Employer(txtMemberID.Value, RegNo);

                if (dat != null)
                {
                    foreach (DataRow row in dat.Tables[0].Rows)
                    {
                        string CS = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                        string CSS = ConfigurationManager.ConnectionStrings["pr"].ConnectionString;
                        using (SqlConnection con = new SqlConnection(CS))
                        {
                            SqlDataAdapter da = new SqlDataAdapter();
                            //da.SelectCommand = new SqlCommand("getlblExitedMemberss", con);
                            da.SelectCommand = new SqlCommand("getlblExitedMemberss_Portal", con);
                            da.SelectCommand.CommandTimeout = 0;
                            da.SelectCommand.CommandType = CommandType.StoredProcedure;
                            //da.SelectCommand.Parameters.AddWithValue("@RegNo", RegNo);
                            da.SelectCommand.Parameters.AddWithValue("@RegNo", RegNo);
                            da.SelectCommand.Parameters.AddWithValue("@BranchCode", row["ID"]);
                            da.Fill(dtExited);

                        }
                    }
                }

                if (dtExited != null)
                {
                    grdClientsView.DataSource = dtExited;
                    grdClientsView.DataBind();
                }
                else
                {
                    AmberAlert("No Exited Members");
                    grdClientsView.DataSource = null;
                    grdClientsView.DataBind();
                }
                //if (g.getlblExitedMemberss(int.Parse(txtFundID.Value), int.Parse(txtMemberID.Value)) != null)
                //{
                //    grdClientsView.DataSource = g.getlblExitedMemberss(int.Parse(txtFundID.Value), int.Parse(txtMemberID.Value));
                //    grdClientsView.DataBind();
                //}
                //else
                //{
                //    grdClientsView.DataSource = null;
                //    grdClientsView.DataBind();
                //}
            }
            catch (Exception ex)
            {
                //RedAlert(ex.Message);
            }
        }


        //protected void GetMemberDetails(int MemberID)
        //{
        //    try
        //    {
        //        LookUp g = new LookUp("cn", 1);

        //        if (g.getlblExitedMemberss(int.Parse(txtFundID.Value), int.Parse(txtMemberID.Value)) != null)
        //        {
        //            grdClientsView.DataSource = g.getlblExitedMemberss(int.Parse(txtFundID.Value), int.Parse(txtMemberID.Value));
        //            grdClientsView.DataBind();
        //        }
        //        else
        //        {
        //            grdClientsView.DataSource = null;
        //            grdClientsView.DataBind();
        //        }

        //    }
        //    catch (Exception g)
        //    {
        //    }

        //}

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