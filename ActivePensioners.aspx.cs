using PenPortfolio.Model;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace PenPortfolio
{
    public partial class ActivePensioners : System.Web.UI.Page
    {
        DataSet dtCountActivePensioner = new DataSet();
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
            GetMemberDetails(int.Parse(txtMemberID.Value));
        }
        protected void getContributionHistory()
        {
            try
            {
                LookUp g = new LookUp("cn", 1);
                string RegNo = g.getRegNo(int.Parse(txtFundID.Value));
                string SplittedRegNo = g.getRegNo(int.Parse(txtFundID.Value));
                DataSet dat = g.Get_Participarting_Employer(txtMemberID.Value, RegNo);
                try
                {
                    if (dat != null)
                    {
                        foreach (DataRow row in dat.Tables[0].Rows)
                        {
                            //dtCoverMultiple = lp.MedicalFreeLimits_Sel_ByRegNo_Premiums(CurrentFund,int.Parse(row["FundCategory"].ToString()),Convert.ToDateTime(row["EffectiveDate"].ToString()));

                            string CS = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                            string CSS = ConfigurationManager.ConnectionStrings["pr"].ConnectionString;

                            using (SqlConnection con = new SqlConnection(CSS))
                            {
                                SqlDataAdapter da = new SqlDataAdapter();
                                da.SelectCommand = new SqlCommand("Get_Active_Pensioners", con);
                                //da.SelectCommand = new SqlCommand("getlblExitedMemberss_Portal", con);
                                da.SelectCommand.CommandTimeout = 0;
                                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                                da.SelectCommand.Parameters.AddWithValue("@RegNo", RegNo);
                                //da.SelectCommand.Parameters.AddWithValue("@RegNo", SplittedRegNo);
                                da.SelectCommand.Parameters.AddWithValue("@BranchCode", row["ID"].ToString());
                                da.Fill(dtCountActivePensioner);

                            }
                        }
                    }
                }
                catch (Exception ex) {
                    //RedAlert(ex.Message);
                }
                
                

                if (dtCountActivePensioner != null)
                {
                    grdClientsView.DataSource = dtCountActivePensioner;
                    grdClientsView.DataBind();
                }
                else
                {
                    AmberAlert("No Active Pensioners");
                    grdClientsView.DataSource = null;
                    grdClientsView.DataBind();
                }

            }
            catch (Exception g)
            {
                //RedAlert(g.Message);
            }
        }
        //protected void RedAlert(string str)
        //{
        //    pnlDanger.Visible = true;
        //    lblDanger.Text = str;

        //    pnlSuccess.Visible = false;
        //    lblSuccess.Text = "";

        //    pnlWarning.Visible = false;
        //    lblWarning.Text = "";
        //}


        protected void GetMemberDetails(int MemberID)
        {
            
                LookUp g = new LookUp("cn", 1);
                string RegNo = g.getRegNo(int.Parse(txtFundID.Value));
                string SplittedRegNo = g.getRegNo(int.Parse(txtFundID.Value));
                DataSet dat = g.Get_Participarting_Employer(txtMemberID.Value, RegNo);
                

                if (dat != null)
                {
                    foreach (DataRow row in dat.Tables[0].Rows)
                    {
                        //dtCoverMultiple = lp.MedicalFreeLimits_Sel_ByRegNo_Premiums(CurrentFund,int.Parse(row["FundCategory"].ToString()),Convert.ToDateTime(row["EffectiveDate"].ToString()));
                       
                        string CSS = ConfigurationManager.ConnectionStrings["pr"].ConnectionString;
                        string CS = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

                        using (SqlConnection con = new SqlConnection(CSS))
                        {
                            SqlDataAdapter da = new SqlDataAdapter();
                            da.SelectCommand = new SqlCommand("Get_Active_Pensioners", con);
                            da.SelectCommand.CommandTimeout = 0;
                            da.SelectCommand.CommandType = CommandType.StoredProcedure;
                            da.SelectCommand.Parameters.AddWithValue("@RegNo", RegNo);
                            //da.SelectCommand.Parameters.AddWithValue("@RegNo", SplittedRegNo);
                            da.SelectCommand.Parameters.AddWithValue("@BranchCode", row["ID"].ToString());
                            da.Fill(dtCountActivePensioner);

                        }
                    }
                }

                if (dtCountActivePensioner != null)
                {
                    grdClientsView.DataSource = dtCountActivePensioner;
                    grdClientsView.DataBind();
                }
                else
                {
                    grdClientsView.DataSource = null;
                    grdClientsView.DataBind();
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