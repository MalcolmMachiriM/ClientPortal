﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.AccessControl;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;
using PenPortfolio.Datasets;
using PenPortfolio.Model;


namespace PenPortfolio
{
    public partial class MemberHome : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet GetData = new DataSet();
        MembershipDS MemberCertificatesDS = new MembershipDS();
        string Address1 = "";
        string Address2 = "";
        string Address3 = "";
        string RegName = "";
        string RegNo = "";
        byte[] image = null;
        ReportDocument myReport;
        QueryStringModule qn = new QueryStringModule();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                txtFundID.Value = "0";
               
                //txtMemberID.Value = "0";
                txtSystemRef.Value = "0";
                ClearAlert();


                
                if (Request.QueryString["RegNo"] != null)
                {
                    txtFundID.Value = HttpUtility.UrlDecode(Request.QueryString["RegNo"].ToString());
                    //txtFundID.Value = qn.Decrypt(HttpUtility.UrlDecode(Request.QueryString["RegNo"]));

                }
                //if (txtFundID.Value.Contains("/"))
                //{
                //    txtFundID.Value = $"{txtFundID.Value}#";
                //}

                if (Request.QueryString["SystemRef"] != null)
                {
                    txtSystemRef.Value = Request.QueryString["SystemRef"].ToString();
                    //txtSystemRef.Value = qn.Decrypt(HttpUtility.UrlDecode(Request.QueryString["SystemRef"]));
                }

                //if (Request.QueryString["MemberID"] != null)
                //{
                //    //txtMemberID.Value = Request.QueryString["MemberID"].ToString();
                //}


                getMemberDetails();
            }
            else
            {
                ReportDocument doc = (ReportDocument)Session["EbcCertificate"];
                CrystalReportViewer1.ReportSource = doc;
            }
        }
        //protected void getSearchOptions()
        //{
        //    try
        //    {
        //        //LookUp pa = new LookUp("cn", 1);
        //        //DataSet x = pa.getActiveMembersByFilterSearch(RegNO, txtSSNSearch.Text, txtFnameSearch.Text, txtLnameSearch.Text, txtNationalID.Text);
        //        //if (x != null)
        //        //{
        //        //    grdClientsView.DataSource = x;

        //        //    grdClientsView.DataBind();
        //        //    grdClientsView.Visible = true;
        //        //}
        //        //else
        //        //{
        //        //    grdClientsView.DataSource = null;
        //        //    grdClientsView.DataBind();
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        RedAlert(ex.Message);
        //    }
        //}
        protected void getMemberDetails()
        {
            try
            {
                LookUp g = new LookUp("cn", 1);
                DataSet x = null;
                DataSet y = null;
                x = g.getPortalMemberDetails(int.Parse(txtSystemRef.Value), txtFundID.Value);
                y = g.getBankingDetails(int.Parse(txtSystemRef.Value));

                if (x != null)
                {
                    foreach (DataRow rw in x.Tables[0].Rows)
                    {

                        txtFirstnames.Text = rw["FirstName"].ToString();
                        txtSurname.Text = rw["LastName"].ToString();
                        txtNationalID.Text = rw["IdentityNo"].ToString();
                        txtEmployer.Text = rw["CompanyName"].ToString();
                        txtBranch.Text = rw["BranchName"].ToString();
                        if (rw["DateJoinedFund"] != null)
                        {

                            txtDJF.TextMode = TextBoxMode.SingleLine;
                            DateTime DJF = Convert.ToDateTime(rw["DateJoinedFund"].ToString());
                            txtDJF.Text = DJF.ToString("yyyy-MM-dd");

                        }
                        else
                        {
                            txtDJF.TextMode = TextBoxMode.Date;
                            txtDJF.Text = "";
                        }
                        if (rw["DateJoinedCompany"] != null)
                        {
                            txtDJC.TextMode = TextBoxMode.SingleLine;
                            DateTime DJC = Convert.ToDateTime(rw["DateJoinedCompany"].ToString());
                            txtDJC.Text = DJC.ToString("yyyy-MM-dd");

                        }
                        else
                        {
                            txtDJC.TextMode = TextBoxMode.Date;
                            txtDJC.Text = "";
                        }
                        if (rw["DateOfBirth"] != null)
                        {
                            txtDob.TextMode = TextBoxMode.SingleLine;
                            DateTime DOB = Convert.ToDateTime(rw["DateOfBirth"].ToString());
                            txtDob.Text = DOB.ToString("yyyy-MM-dd");

                        }
                        else
                        {
                            txtDob.TextMode = TextBoxMode.Date;
                            txtDob.Text = "";
                        }

                        txtMemberShipStatus.Text = rw["Description"].ToString();
                        txtID.Text = rw["ID"].ToString();
                        txtEcNo.Text = rw["EmployeeReferenceNumber"].ToString();
                        txtFund.Text = rw["RegName"].ToString();
                        txtSalary.Text = rw["LatestSalary"].ToString();
                        txtMembershipCategory.Text = rw["FundCategory"].ToString();


                    }

                }

                if (y != null)
                {
                    foreach (DataRow rw in y.Tables[0].Rows)
                    {
                        if (rw["BankName"].ToString() != "")
                        {
                            txtBank.Text = rw["BankName"].ToString();
                        }
                        if (rw["BranchName"].ToString() != "")
                        {
                            txtBankBranch.Text = rw["BranchName"].ToString();
                        }
                        if (rw["AccountName"].ToString() != "")
                        {
                            txtAccName.Text = rw["AccountName"].ToString();
                        }
                        if (rw["AccountNo"].ToString() != "")
                        {
                            txtAccNo.Text = rw["AccountNo"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                RedAlert(ex.Message);
            }
        }
        protected void getMemberContributionsHistory()
        {
            try
            {
                LookUp c = new LookUp("cn", 1);
                //string RegNo = c.getRegNo(int.Parse(txtFundID.Value));

                if (c.getMemberContributions(int.Parse(txtSystemRef.Value), RegNo) != null)
                {
                    grdContributions.DataSource = c.getMemberContributions(int.Parse(txtSystemRef.Value), RegNo);
                    grdContributions.DataBind();
                    //btnExport.Visible = true;


                }
                else
                {
                    grdContributions.DataSource = null;
                    grdContributions.DataBind();
                    WarningAlert("No Contributions For this User");
                }
            }
            catch (Exception ex)
            {
                RedAlert(ex.Message);
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

        protected void grdEmployees_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdEmployees_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            //Response.Redirect(string.Format("../ClaimLogging?FundID=" + txtFundID.Value + ""));
            //Response.Redirect(string.Format("ClaimLogging?FundID=" + txtFundID.Value + "&SystemRef=" + txtSystemRef.Value + "&MemberID={0}", txtMemberID.Value), false);
        }

        protected void btnCntHistory_Click(object sender, EventArgs e)
        {
            getMemberContributionsHistory();
        }

        protected void btnBenefitStm_Click(object sender, EventArgs e)
        {
            try
            {
                LookUp cd = new LookUp("cn", 1);
                string searchCriteria = "IdentityNo";
                //string branchId = "";
                string branchId = cd.getBranchId(int.Parse(txtSystemRef.Value.ToString()));
                string RegNo = txtFundID.Value;
                DataSet x = cd.getFundDetails(RegNo);
                //DataSet dtse = cd.getBranchId(int.Parse(txtSystemRef.Value.ToString()));
                //if (dtse != null)
                //{
                //    foreach (DataRow item in dtse.Tables[0].Rows)
                //    {
                //        branchId = item["BranchId"].ToString();
                //    }

                //}
                if (x != null && x.Tables.Count > 0 && x.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dt in x.Tables[0].Rows)
                    {
                        Address1 = dt["PostalAdd1"].ToString();
                        Address2 = dt["PostalAdd2"].ToString();
                        Address3 = dt["PostalAdd3"].ToString();
                        RegName = dt["RegName"].ToString();
                        RegNo = dt["RegNo"].ToString();
                        image = (byte[])dt["Logo"];

                    }

                }
                else
                {
                    WarningAlert("No Address Found");
                }
                string CS = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = new SqlCommand("Contributions_Sel_CertificateDataModLatestB_Portal", con);
                    da.SelectCommand.CommandTimeout = 0;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@RegNo", RegNo);
                    da.SelectCommand.Parameters.AddWithValue("@BranchId", branchId);
                    da.SelectCommand.Parameters.AddWithValue("@Criterion", searchCriteria);
                    da.SelectCommand.Parameters.AddWithValue("@SearchValue", txtNationalID.Text);
                    da.Fill(ds);
                }

                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = new SqlCommand("Contributions_Sel_CertificateDataModLatestB_Web_Portal", con);
                    da.SelectCommand.CommandTimeout = 0;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@RegNo", RegNo);
                    da.SelectCommand.Parameters.AddWithValue("@BranchId", branchId);
                    da.SelectCommand.Parameters.AddWithValue("@Criterion", searchCriteria);
                    da.SelectCommand.Parameters.AddWithValue("@SearchValue", txtNationalID.Text);
                    da.Fill(ds1);
                }

                int rowcount = 0;

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow rwset in ds.Tables[0].Rows)
                    {

                        GetData = cd.BenefitProjectionsNRA_Sel_By_MemberID(int.Parse(rwset["PensionNo"].ToString()), Convert.ToDateTime(rwset["CDate"].ToString()));
                        double ForecastPension = 0;
                        double AccumAtNRA = 0;
                        double IntRate = 0;
                        double salaryEsc = 0;
                        double NRR = 0;

                        if (GetData != null && GetData.Tables.Count > 0 && GetData.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow row2 in GetData.Tables[0].Rows)
                            {
                                if (row2["ForecastPension"].ToString() == "" || row2["ForecastPension"].ToString() == null)
                                {
                                    ForecastPension = 0;
                                }
                                else
                                {
                                    ForecastPension = Convert.ToDouble(row2["ForecastPension"].ToString());
                                }

                                if (row2["NRR"].ToString() == "" || row2["NRR"].ToString() == null)
                                {
                                    NRR = 0;
                                }
                                else
                                {
                                    NRR = Convert.ToDouble(row2["NRR"].ToString());
                                }

                                if (row2["AccumAtNRA"].ToString() == "" || row2["AccumAtNRA"].ToString() == null)
                                {
                                    AccumAtNRA = 0;
                                }
                                else
                                {
                                    AccumAtNRA = Convert.ToDouble(row2["AccumAtNRA"].ToString());
                                }
                                if (row2["InterestRate"].ToString() == "" || row2["InterestRate"].ToString() == null)
                                {
                                    IntRate = 0;
                                }
                                else
                                {
                                    IntRate = Convert.ToDouble(row2["InterestRate"].ToString());
                                }
                                if (row2["SalaryEscalation"].ToString() == "" || row2["SalaryEscalation"].ToString() == null)
                                {
                                    salaryEsc = 0;
                                }
                                else
                                {
                                    salaryEsc = Convert.ToDouble(row2["SalaryEscalation"].ToString());
                                }
                            }

                        }

                        DateTime date = DateTime.Parse(rwset["DateOfBirth"].ToString()).AddYears(int.Parse(rwset["NormalRetAge"].ToString()));
                        var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);  //Perioddate Column
                        var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

                        if (rwset["Gender_ID"].ToString().Trim() == "2")
                        {
                            rwset["Gender_ID"] = "Male";
                        }
                        else if (rwset["Gender_ID"].ToString().Trim() == "1")
                        {
                            rwset["Gender_ID"] = "Female";
                        }
                        string Currency = cd.getFundCurrency((txtFundID.Value));

                        if (Currency == "")
                        {
                            Currency = "ZWL";
                        }
                        DateTime ClosingDate = Convert.ToDateTime(rwset["ClosingBonusDate"].ToString());
                        int Year = ClosingDate.Year;
                        if (rwset["OpeningBonusDate"].ToString() == "")
                        {
                            rwset["OpeningBonusDate"] = new DateTime(Year, 1, 1);
                        }
                        //DateTime dty = Convert.ToDateTime(rwset["ClosingBonusDate"].ToString());
                        if (int.Parse(rwset["MemberClosingTransferIn"].ToString()) <= 0 && int.Parse(rwset["EmployerClosingTransferIn"].ToString()) <= 0 && (double.Parse(rwset["MemberCont"].ToString()) + double.Parse(rwset["EmployerCont"].ToString())) > 0)
                        {

                            string[] item = new[] { rwset["PensionNo"].ToString(), (rwset["LastName"].ToString()), rwset["FirstName"].ToString(), rwset["NationalID"].ToString(), rwset["Name"].ToString(), RegName, rwset["DateOfBirth"].ToString(), rwset["Gender_ID"].ToString(), rwset["NormalRetAge"].ToString(), lastDayOfMonth.ToString(), rwset["DateOfEntry"].ToString().ToUpper(), rwset["MemberOBalance"].ToString(), rwset["MemberCont"].ToString(), rwset["MemberCBalance"].ToString(), rwset["EmployerOBalance"].ToString(), rwset["EmployerCont"].ToString(), rwset["EmployerCBalance"].ToString(), rwset["ClosingBonusDate"].ToString(), rwset["OpeningBonusDate"].ToString(), Convert.ToDateTime(rwset["OpeningBonusDate"].ToString()).AddDays(1).ToString(), rwset["MemberClosingTransferIn"].ToString(), rwset["EmployerClosingTransferIn"].ToString(), rwset["AVCOBalance"].ToString(), rwset["AVCCont"].ToString(), rwset["AVCCBalance"].ToString() };
                            MemberCertificatesDS.Tables["Certificates"].Rows.Add(item);

                            MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["FundLogo"] = image;
                            MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["CoLogo"] = image;
                            MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["FundAddress"] = Address1 + " " + Address2 + " " + Address3;
                            MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["FundReg"] = RegNo;
                            MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["Expenses"] = -double.Parse(rwset["Expenses"].ToString());
                            MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["ForecastPension"] = ForecastPension;
                            MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["AccumAtNRA"] = AccumAtNRA;
                            MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["NRR"] = NRR;
                            MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["Return"] = IntRate;
                            MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["SalaryEsc"] = salaryEsc;
                            MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["Currency"] = Currency;

                            rowcount = rowcount + 1;
                        }
                        else if (int.Parse(rwset["MemberClosingTransferIn"].ToString()) <= 0 && int.Parse(rwset["EmployerClosingTransferIn"].ToString()) <= 0)
                        {
                            string[] item = new[] { rwset["PensionNo"].ToString(), (rwset["LastName"].ToString()), rwset["FirstName"].ToString(), rwset["NationalID"].ToString(), rwset["Name"].ToString(), RegName, rwset["DateOfBirth"].ToString(), rwset["Gender_ID"].ToString(), rwset["NormalRetAge"].ToString(), lastDayOfMonth.ToString(), rwset["DateOfEntry"].ToString().ToUpper(), rwset["MemberOBalance"].ToString(), rwset["MemberCont"].ToString(), rwset["MemberCBalance"].ToString(), rwset["EmployerOBalance"].ToString(), rwset["EmployerCont"].ToString(), rwset["EmployerCBalance"].ToString(), rwset["ClosingBonusDate"].ToString(), rwset["OpeningBonusDate"].ToString(), Convert.ToDateTime(rwset["OpeningBonusDate"].ToString()).AddDays(1).ToString(), rwset["MemberClosingTransferIn"].ToString(), rwset["EmployerClosingTransferIn"].ToString(), rwset["AVCOBalance"].ToString(), rwset["AVCCont"].ToString(), rwset["AVCCBalance"].ToString() };

                            MemberCertificatesDS.Tables[0].Rows.Add(item);
                            MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["FundLogo"] = image;
                            MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["CoLogo"] = image;
                            MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["FundAddress"] = Address1 + " " + Address2 + " " + Address3;
                            MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["FundReg"] = RegNo;
                            MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["Expenses"] = -double.Parse(rwset["Expenses"].ToString());
                            MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["ForecastPension"] = ForecastPension;
                            MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["AccumAtNRA"] = AccumAtNRA;
                            MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["NRR"] = NRR;
                            MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["Return"] = IntRate;
                            MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["SalaryEsc"] = salaryEsc;
                            MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["Currency"] = Currency;
                            rowcount = rowcount + 1;
                        }
                        else
                        {
                            if (Convert.ToDateTime(rwset["DateOfEntry"].ToString()) <= Convert.ToDateTime(rwset["OpeningBonusDate"].ToString()))
                            {

                                string[] item = new[] { rwset["PensionNo"].ToString(), (rwset["LastName"].ToString()), rwset["FirstName"].ToString(), rwset["NationalID"].ToString(), rwset["Name"].ToString(), RegName, rwset["DateOfBirth"].ToString(), rwset["Gender_ID"].ToString(), rwset["NormalRetAge"].ToString(), lastDayOfMonth.ToString(), rwset["DateOfEntry"].ToString().ToUpper(), rwset["MemberOBalance"].ToString(), rwset["MemberCont"].ToString(), rwset["MemberCBalance"].ToString(), rwset["EmployerOBalance"].ToString(), rwset["EmployerCont"].ToString(), rwset["EmployerCBalance"].ToString(), rwset["ClosingBonusDate"].ToString(), rwset["OpeningBonusDate"].ToString(), Convert.ToDateTime(rwset["OpeningBonusDate"].ToString()).AddDays(1).ToString(), rwset["MemberClosingTransferIn"].ToString(), rwset["EmployerClosingTransferIn"].ToString(), rwset["AVCOBalance"].ToString(), rwset["AVCCont"].ToString(), rwset["AVCCBalance"].ToString() };

                                MemberCertificatesDS.Tables[0].Rows.Add(item);
                                MemberCertificatesDS.Tables["Certificates"].Rows.Add(item);
                                MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["FundLogo"] = image;
                                MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["CoLogo"] = image;
                                MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["FundAddress"] = Address1 + " " + Address2 + " " + Address3;
                                MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["FundReg"] = RegNo;
                                MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["Expenses"] = -double.Parse(rwset["Expenses"].ToString());
                                MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["ForecastPension"] = ForecastPension;
                                MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["AccumAtNRA"] = AccumAtNRA;
                                MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["NRR"] = NRR;
                                MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["Return"] = IntRate;
                                MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["SalaryEsc"] = salaryEsc;
                                MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["Currency"] = Currency;
                                rowcount = rowcount + 1;
                            }

                        }
                    }
                }
                else
                {
                    if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                    {

                        foreach (DataRow rwset in ds1.Tables[0].Rows)
                        {

                            GetData = cd.BenefitProjectionsNRA_Sel_By_MemberID(int.Parse(rwset["PensionNo"].ToString()), Convert.ToDateTime(rwset["CDate"].ToString()));
                            double ForecastPension = 0;
                            double AccumAtNRA = 0;
                            double IntRate = 0;
                            double salaryEsc = 0;
                            double NRR = 0;

                            if (GetData != null && GetData.Tables.Count > 0 && GetData.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow row2 in GetData.Tables[0].Rows)
                                {
                                    if (row2["ForecastPension"].ToString() == "" || row2["ForecastPension"].ToString() == null)
                                    {
                                        ForecastPension = 0;
                                    }
                                    else
                                    {
                                        ForecastPension = Convert.ToDouble(row2["ForecastPension"].ToString());
                                    }

                                    if (row2["NRR"].ToString() == "" || row2["NRR"].ToString() == null)
                                    {
                                        NRR = 0;
                                    }
                                    else
                                    {
                                        NRR = Convert.ToDouble(row2["NRR"].ToString());
                                    }

                                    if (row2["AccumAtNRA"].ToString() == "" || row2["AccumAtNRA"].ToString() == null)
                                    {
                                        AccumAtNRA = 0;
                                    }
                                    else
                                    {
                                        AccumAtNRA = Convert.ToDouble(row2["AccumAtNRA"].ToString());
                                    }
                                    if (row2["InterestRate"].ToString() == "" || row2["InterestRate"].ToString() == null)
                                    {
                                        IntRate = 0;
                                    }
                                    else
                                    {
                                        IntRate = Convert.ToDouble(row2["InterestRate"].ToString());
                                    }
                                    if (row2["SalaryEscalation"].ToString() == "" || row2["SalaryEscalation"].ToString() == null)
                                    {
                                        salaryEsc = 0;
                                    }
                                    else
                                    {
                                        salaryEsc = Convert.ToDouble(row2["SalaryEscalation"].ToString());
                                    }
                                }

                            }

                            DateTime date = DateTime.Parse(rwset["DateOfBirth"].ToString()).AddYears(int.Parse(rwset["NormalRetAge"].ToString()));
                            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);  //Perioddate Column
                            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);


                            if (rwset["Gender_ID"].ToString().Trim() == "2")
                            {
                                rwset["Gender_ID"] = "Male";
                            }
                            else if (rwset["Gender_ID"].ToString().Trim() == "1")
                            {
                                rwset["Gender_ID"] = "Female";
                            }
                            string Currency = cd.getFundCurrency(RegNo);

                            if (Currency == "")
                            {
                                Currency = "ZWL";
                            }
                            DateTime ClosingDate = Convert.ToDateTime(rwset["ClosingBonusDate"].ToString());
                            int Year = ClosingDate.Year;
                            if (rwset["OpeningBonusDate"].ToString() == "")
                            {
                                rwset["OpeningBonusDate"] = new DateTime(Year, 1, 1);
                            }

                            if (int.Parse(rwset["MemberClosingTransferIn"].ToString()) <= 0 && int.Parse(rwset["EmployerClosingTransferIn"].ToString()) <= 0 && (double.Parse(rwset["MemberCont"].ToString()) + double.Parse(rwset["EmployerCont"].ToString())) > 0)
                            {


                                string[] item = new[] { rwset["PensionNo"].ToString(), (rwset["LastName"].ToString()), rwset["FirstName"].ToString(), rwset["NationalID"].ToString(), rwset["Name"].ToString(), RegName, rwset["DateOfBirth"].ToString(), rwset["Gender_ID"].ToString(), rwset["NormalRetAge"].ToString(), lastDayOfMonth.ToString(), rwset["DateOfEntry"].ToString().ToUpper(), rwset["MemberOBalance"].ToString(), rwset["MemberCont"].ToString(), rwset["MemberCBalance"].ToString(), rwset["EmployerOBalance"].ToString(), rwset["EmployerCont"].ToString(), rwset["EmployerCBalance"].ToString(), rwset["ClosingBonusDate"].ToString(), rwset["OpeningBonusDate"].ToString(), Convert.ToDateTime(rwset["OpeningBonusDate"].ToString()).AddDays(1).ToString(), rwset["MemberClosingTransferIn"].ToString(), rwset["EmployerClosingTransferIn"].ToString(), rwset["AVCOBalance"].ToString(), rwset["AVCCont"].ToString(), rwset["AVCCBalance"].ToString() };
                                MemberCertificatesDS.Tables["Certificates"].Rows.Add(item);

                                MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["FundLogo"] = image;
                                MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["CoLogo"] = image;
                                MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["FundAddress"] = Address1 + " " + Address2 + " " + Address3;
                                MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["FundReg"] = RegNo;
                                MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["Expenses"] = -double.Parse(rwset["Expenses"].ToString());
                                MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["ForecastPension"] = ForecastPension;
                                MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["AccumAtNRA"] = AccumAtNRA;
                                MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["NRR"] = NRR;
                                MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["Return"] = IntRate;
                                MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["SalaryEsc"] = salaryEsc;
                                MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["Currency"] = Currency;

                                rowcount = rowcount + 1;
                            }
                            else if (int.Parse(rwset["MemberClosingTransferIn"].ToString()) <= 0 && int.Parse(rwset["EmployerClosingTransferIn"].ToString()) <= 0)
                            {
                                string[] item = new[] { rwset["PensionNo"].ToString(), (rwset["LastName"].ToString()), rwset["FirstName"].ToString(), rwset["NationalID"].ToString(), rwset["Name"].ToString(), RegName, rwset["DateOfBirth"].ToString(), rwset["Gender_ID"].ToString(), rwset["NormalRetAge"].ToString(), lastDayOfMonth.ToString(), rwset["DateOfEntry"].ToString().ToUpper(), rwset["MemberOBalance"].ToString(), rwset["MemberCont"].ToString(), rwset["MemberCBalance"].ToString(), rwset["EmployerOBalance"].ToString(), rwset["EmployerCont"].ToString(), rwset["EmployerCBalance"].ToString(), rwset["ClosingBonusDate"].ToString(), rwset["OpeningBonusDate"].ToString(), Convert.ToDateTime(rwset["OpeningBonusDate"].ToString()).AddDays(1).ToString(), rwset["MemberClosingTransferIn"].ToString(), rwset["EmployerClosingTransferIn"].ToString(), rwset["AVCOBalance"].ToString(), rwset["AVCCont"].ToString(), rwset["AVCCBalance"].ToString() };

                                MemberCertificatesDS.Tables[0].Rows.Add(item);
                                MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["FundLogo"] = image;
                                MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["CoLogo"] = image;
                                MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["FundAddress"] = Address1 + " " + Address2 + " " + Address3;
                                MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["FundReg"] = RegNo;
                                MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["Expenses"] = -double.Parse(rwset["Expenses"].ToString());
                                MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["ForecastPension"] = ForecastPension;
                                MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["AccumAtNRA"] = AccumAtNRA;
                                MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["NRR"] = NRR;
                                MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["Return"] = IntRate;
                                MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["SalaryEsc"] = salaryEsc;
                                MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["Currency"] = Currency;
                                rowcount = rowcount + 1;
                            }
                            else
                            {
                                if (Convert.ToDateTime(rwset["DateOfEntry"].ToString()) <= Convert.ToDateTime(rwset["OpeningBonusDate"].ToString()))
                                {

                                    string[] item = new[] { rwset["PensionNo"].ToString(), (rwset["LastName"].ToString()), rwset["FirstName"].ToString(), rwset["NationalID"].ToString(), rwset["Name"].ToString(), RegName, rwset["DateOfBirth"].ToString(), rwset["Gender_ID"].ToString(), rwset["NormalRetAge"].ToString(), lastDayOfMonth.ToString(), rwset["DateOfEntry"].ToString().ToUpper(), rwset["MemberOBalance"].ToString(), rwset["MemberCont"].ToString(), rwset["MemberCBalance"].ToString(), rwset["EmployerOBalance"].ToString(), rwset["EmployerCont"].ToString(), rwset["EmployerCBalance"].ToString(), rwset["ClosingBonusDate"].ToString(), rwset["OpeningBonusDate"].ToString(), Convert.ToDateTime(rwset["OpeningBonusDate"].ToString()).AddDays(1).ToString(), rwset["MemberClosingTransferIn"].ToString(), rwset["EmployerClosingTransferIn"].ToString(), rwset["AVCOBalance"].ToString(), rwset["AVCCont"].ToString(), rwset["AVCCBalance"].ToString() };

                                    MemberCertificatesDS.Tables[0].Rows.Add(item);
                                    MemberCertificatesDS.Tables["Certificates"].Rows.Add(item);
                                    MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["FundLogo"] = image;
                                    MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["CoLogo"] = image;
                                    MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["FundAddress"] = Address1 + " " + Address2 + " " + Address3;
                                    MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["FundReg"] = RegNo;
                                    MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["Expenses"] = -double.Parse(rwset["Expenses"].ToString());
                                    MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["ForecastPension"] = ForecastPension;
                                    MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["AccumAtNRA"] = AccumAtNRA;
                                    MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["NRR"] = NRR;
                                    MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["Return"] = IntRate;
                                    MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["SalaryEsc"] = salaryEsc;
                                    MemberCertificatesDS.Tables["Certificates"].Rows[rowcount]["Currency"] = Currency;
                                    rowcount = rowcount + 1;
                                }

                            }
                        }

                    }
                    else
                    {
                        WarningAlert("No Benefits To Project");
                    }
                }
                myReport = new ReportDocument();
                //if (RegNo.Contains("#"))
                //{
                //    //myReport.Load(Server.MapPath(@"../Reports/MembershipCertificatesWithTransferInNoProjectionsFundB.rpt"));

                //}
                //else
                //{
                //    //myReport.Load(Server.MapPath(@"../Reports/MembershipCertificatesWithTransferInNoProjectionsFundB.rpt"));
                //    myReport.Load(Server.MapPath("Reports/MembershipCertificatesWithTransferInDBNoProjectionsFundA.rpt"));
                //}
                myReport.Load(Server.MapPath("Reports/MembershipCertificatesWithTransferInDBNoProjectionsFundB.rpt"));
                myReport.SetDataSource(MemberCertificatesDS);
                CrystalReportViewer1.ReportSource = myReport;
                CrystalReportViewer1.RefreshReport();
                CrystalReportViewer1.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;
                Session["EbcCertificate"] = myReport;

            }
            catch (Exception exx)
            {

                WarningAlert(exx.Message);
            }
            

        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            //Response.Redirect(string.Format("MemberContributionsReport?FundID=" + txtFundID.Value + "&MemberID=" + txtMemberID.Value + ""));
        }

        protected void grdContributions_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdContributions.PageIndex = e.NewPageIndex;

            this.BindGrid();
        }

        private void BindGrid()
        {
            try
            {
                LookUp c = new LookUp("cn", 1);
                string RegNo = c.getRegNo(int.Parse(txtFundID.Value));

                if (c.getMemberContributions(int.Parse(txtSystemRef.Value), txtFundID.Value) != null)
                {
                    grdContributions.DataSource = c.getMemberContributions(int.Parse(txtSystemRef.Value), RegNo);
                    grdContributions.DataBind();
                    btnExport.Visible = true;


                }
                else
                {
                    grdContributions.DataSource = null;
                    grdContributions.DataBind();
                }
            }
            catch (Exception ex)
            {
                RedAlert(ex.Message);
            }
        }
    }
}