using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using PenPortfolio.Data;
using PenPortfolio.Datasets;
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
    public partial class MemberClaimLogging : System.Web.UI.Page
    {
        private cn db = new cn();
        ReportDocument myReport;
        ParameterFields myParameterFields = new ParameterFields();
        ParameterField myParameterField = new ParameterField();
        ParameterDiscreteValue myDiscreteValue = new ParameterDiscreteValue();
        string ExitType = "";
        string ExitCode = "";
        public SqlConnection myConnection = new SqlConnection();
        public SqlDataAdapter adp;
        public SqlCommand cmd;
        DataSet InitialMemberDetails = new DataSet();
        DataSet MemberDetails = new DataSet();
        DataSet EligibilityRequirements = new DataSet();
        MembershipDS MemberCertificatesDS = new MembershipDS();
        DataSet InterimRates = new DataSet();
        DataSet LastBonus = new DataSet();
        DataSet ContributionsWithoutInt = new DataSet();
        DataSet ContributionsAfterDeclaration = new DataSet();
        DataSet dtInterests = new DataSet();
        DataSet LastBonusWithInterest = new DataSet();
        DataSet LatestSalary = new DataSet();
        DataSet CommutationFactorAndMinCom = new DataSet();
        DataSet illHealthParameters = new DataSet();
        DataSet CummSalary = new DataSet();
        DataSet TaxTable = new DataSet();
        double Age = 0;
        int ExitMemberCategory = 0;
        double NormalRetAge = 0;
        DateTime NormalRetDate;
        double CoverMultiple = 0;
        double PensionableService = 0;
        DateTime LastBonusDate;
        DateTime CalculationDate;
        DateTime PensionCommenceDate;
        DateTime ExitDate;
        int MemberRef = 0;
        double PotentialPS = 0;
        double ConversionFactor = 0;
        double PensionArrearsPeriod = 0;
        double RateValue = 0;
        double MemberPortAtReview = 0;
        double EmployerPortAtReview = 0;
        double AccumReserveAtLastReview = 0;
        double MemberContWithoutInt = 0;
        double EmployerContWithoutInt = 0;
        double MemberContWithInt = 0;
        double EmployerContWithInt = 0;
        double AccumReserveToExit = 0;
        double AccumReserveToExitMemberOnly = 0;
        double AccumReserveToExitEmployerOnly = 0;
        double MemberPortAtExit = 0;
        double EmployerPortAtExit = 0;
        double AccumReserveAtExit = 0;
        double LastestSalary = 0;
        double illHealthPerc = 0;
        double MinAnnualPension = 0;
        double CapitalValue = 0;
        double FullAnnualPenBeforeComutation = 0;
        double AnnualPenAfterCommutation = 0;
        double MonthlyPension = 0;
        double BalAccumCredit = 0;
        double TaxFreeCommutation = 0;
        double EnhancedResidualConsid = 0;
        double EnhancedResidualAnnualPen = 0;
        double AnnualSalary = 0;
        double GLAEntiltlement = 0;
        double LumpsumPayable = 0;
        double NetLumpsumPayableWithInt = 0;
        double NBeneficiary_LumpsumWithInt = 0;
        double BenefitAmount = 0;
        double MinPensionAllowable = 0;
        double EmployerBenefit = 0;
        double MemberBenefit = 0;
        double AdditionalAward = 0;
        double MemberPortionWithLatePaymentInt = 0;
        double EmployerPortionWithLatePaymentInt = 0;
        double AccumCreditWithIntAtPaymentdateWithInt = 0;
        double PensionArrears = 0;
        double TaxfreeCommutationWithint = 0;
        double AccumulationWithInt = 0;
        double ReassuredCover = 0;
        double NetLumpsumPayable = 0;
        double NetLumpsumPayablewithint = 0;
        double NBeneficiary_BalTaxableAmount = 0;
        double BenefitTransferedIn = 0;
        double LateRetirementConversionfactor = 0;
        double AnnualisedLastSalary = 0;
        double ProjectedPension = 0;
        double ReductionRercentage = 0;
        string BenefitDescription = "";
        double MemberBenefitTax = 0;
        double AdditionalAwardTax = 0;
        QueryStringModule qn = new QueryStringModule();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                ClearAlert();

                txtFundID.Value = "0";
                txtMemberID.Value = "0";
                txtSystemRef.Value = "0";
                txtCalType.Value = "N";
                txtExitCode.Value = "0";
                LookUp lookUp = new LookUp("cn", 1);
                if (Request.QueryString["RegNo"] != null)
                {
                    txtFundID.Value = qn.Decrypt(HttpUtility.UrlDecode(Request.QueryString["RegNo"]));
                    //txtFundID.Value = Request.QueryString["RegNo"].ToString();
                    string FundID = lookUp.getFundID(txtFundID.Value);
                    txtFundID.Value = FundID;
                }
                if (Request.QueryString["SystemRef"] != null)
                {
                    txtSystemRef.Value = qn.Decrypt(HttpUtility.UrlDecode(Request.QueryString["SystemRef"]));
                    //txtSystemRef.Value = Request.QueryString["SystemRef"].ToString();
                }
                txtMemberID.Value = txtSystemRef.Value;
                //if (Request.QueryString["MemberID"] != null)
                //{
                //    txtMemberID.Value = Request.QueryString["MemberID"].ToString();
                //}
                getEmployees();
                getSearchOptions();
                getMemberClaim();
            }
        }
        protected void getSearchOptions()
        {
            try
            {
                PortalAccesssUsers pa = new PortalAccesssUsers("cn", 1);
                if (pa.getSearchOptions() != null)
                {
                    cboSearchOptions.DataSource = pa.getSearchOptions();
                    cboSearchOptions.DataValueField = "ID";
                    cboSearchOptions.DataTextField = "Description";
                    cboSearchOptions.DataBind();
                }
                else
                {
                    cboSearchOptions.DataSource = null;
                    cboSearchOptions.DataBind();
                }

                LookUp lookUp = new LookUp("cn", 1);

                if (lookUp.getClaimTypes() != null)
                {
                    ListItem li = new ListItem("Select a claim type", "77");
                    cboClaimType.DataSource = lookUp.getClaimTypes();
                    cboClaimType.DataTextField = "Description";
                    cboClaimType.DataValueField = "ID";
                    cboClaimType.DataBind();
                    cboClaimType.Items.Insert(0, li);

                }
                else
                {
                    ListItem li = new ListItem("There are no claim types defined", "77");
                    cboClaimType.DataSource = null;
                    cboClaimType.DataBind();
                    cboClaimType.Items.Insert(0, li);
                }
                if (lookUp.getBanks() != null)
                {
                    ListItem li = new ListItem("Select a Bank", "0");
                    drpBank.DataSource = lookUp.getBanks();
                    drpBank.DataTextField = "BankName";
                    drpBank.DataValueField = "ID";
                    drpBank.DataBind();
                    drpBank.Items.Insert(0, li);

                }
                else
                {
                    ListItem li = new ListItem("There are no Banks defined", "0");
                    drpBank.DataSource = null;
                    drpBank.DataBind();
                    drpBank.Items.Insert(0, li);
                }
                if (lookUp.getBranches() != null)
                {
                    ListItem li = new ListItem("Select a Branch", "0");
                    drpBranch.DataSource = lookUp.getBranches();
                    drpBranch.DataTextField = "Name";
                    drpBranch.DataValueField = "ID";
                    drpBranch.DataBind();
                    drpBranch.Items.Insert(0, li);

                }
                else
                {
                    ListItem li = new ListItem("There are no Branchs defined", "0");
                    drpBranch.DataSource = null;
                    drpBranch.DataBind();
                    drpBranch.Items.Insert(0, li);
                }
            }
            catch (Exception ex)
            {
                RedAlert(ex.Message);
            }
        }
        protected void getEmployees()
        {
            try
            {
                LookUp g = new LookUp("cn", 1);
                DataSet x = null;
                x = g.getFundMemberDetails(int.Parse(txtMemberID.Value), int.Parse(txtFundID.Value));

                if (x != null)
                {
                    foreach (DataRow rw in x.Tables[0].Rows)
                    {
                        txtFirstnames.Text = rw["FirstName"].ToString();
                        txtSurname.Text = rw["LastName"].ToString();
                        txtNationalID.Text = rw["IdentityNo"].ToString();
                        txtGender.Text = rw["Gender_ID"].ToString();

                        if (txtGender.Text == "2")
                        {
                            txtGender.Text = "Male";
                            rw["Gender_ID"] = "M";
                        }
                        else
                        {
                            txtGender.Text = "Female";
                            rw["Gender_ID"] = "F";
                        }
                        //txtEmployer.Text = rw["CompanyName"].ToString();
                        //txtBranch.Text = rw["BranchName"].ToString();
                        //txtDepartment.Text = rw[""].ToString();
                        //txtMembershipCategory.Text = rw["FundCategory"].ToString();

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

                        //txtMemberShipStatus.Text = rw[""].ToString();
                        //txtLastContDate.Text = rw[""].ToString();

                    }

                }

            }
            catch (Exception ex)
            {
                RedAlert(ex.Message);
            }
        }
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

        protected void btnSaveClaim_Click(object sender, EventArgs e)
        {

            LookUp lp = new LookUp("cn", 1);
            string RegNo = lp.getRegNo(int.Parse(txtFundID.Value));

            if (lp.CheckAlreadyPosted(txtNationalID.Text, int.Parse(txtMemberID.Value)))
            {
                WarningAlert("Claim Already Exists");
                return;

            }

            if (cboClaimType.SelectedValue == "77")
            {
                WarningAlert("Select a claim type");
                return;
            }
            if (txtExitDate.Text == "")
            {
                WarningAlert("Please Select Exit Date");
                return;
            }
            if (txtCalDate.Text == "")
            {
                WarningAlert("Please Select Calculation Date");
                return;
            }



            if (lp.ValidateClaim(txtNationalID.Text, RegNo, int.Parse(txtMemberID.Value)))
            {
                WarningAlert("Member has a pending claim. Please view the quoatation below");
                return;
            }
            else
            {
                if (cboClaimType.SelectedValue == "0")
                {
                    ExitType = "Withdrawal";
                    ExitCode = "0";
                    txtExitCode.Value = "0";
                }
                if (cboClaimType.SelectedValue == "1")
                {
                    ExitType = "Early Retirement";
                    ExitCode = "1";
                    txtExitCode.Value = "1";
                }
                if (cboClaimType.SelectedValue == "2")
                {
                    ExitType = "Normal Retirement";
                    ExitCode = "2";
                    txtExitCode.Value = "2";
                }
                if (cboClaimType.SelectedValue == "3")
                {
                    ExitType = "Late Retirement";
                    ExitCode = "3";
                    txtExitCode.Value = "3";
                }
                if (cboClaimType.SelectedValue == "4")
                {
                    ExitType = "Death";
                    ExitCode = "4";
                    txtExitCode.Value = "4";
                }
                if (cboClaimType.SelectedValue == "5")
                {
                    ExitType = "Ill Health Retirement";
                    ExitCode = "5";
                    txtExitCode.Value = "5";
                }
                if (cboClaimType.SelectedValue == "6")
                {
                    ExitType = "Retrenchment/Reorganization";
                    ExitCode = "6";
                    txtExitCode.Value = "6";
                }
                double PeriodAfterDOEx = 0;
                if (lp.GetMemberDetails(int.Parse(txtMemberID.Value), int.Parse(txtFundID.Value)) != null)
                {
                    InitialMemberDetails = lp.GetMemberDetails(int.Parse(txtMemberID.Value), int.Parse(txtFundID.Value));
                    MemberDetails = lp.GetMemberDetails(int.Parse(txtMemberID.Value), int.Parse(txtFundID.Value));
                    DataRow rwMdts = MemberDetails.Tables[0].Rows[0];
                    DateTime DateOfExit = DateTime.Parse(txtCalDate.Text);
                    if (DateTime.TryParse(rwMdts["DateOfExit"].ToString(), out DateTime dt))
                    {
                        DateOfExit = DateTime.Parse(rwMdts["DateOfExit"].ToString());

                    }
                    //string s = DateOfExit.ToString("dd/lp/yyyy");
                    DateTime mdob = DateTime.Parse(rwMdts["DateOfBirth"].ToString());

                    //DateTime sysdateofexit = DateTime.Parse(s);

                    //rwMdts["DateofExit"] = s;
                    //DateTime dtt = DateTime.Parse(s);
                    PeriodAfterDOEx = (DateOfExit - mdob).TotalDays / 365.5;
                    ExitMemberCategory = int.Parse(rwMdts["FundCategory_ID"].ToString());
                }

                //Get Eligibility Requirements

                string MemberCategory = MemberDetails.Tables[0].Rows[0]["FundCategory_ID"].ToString();
                if (lp.GetMemberEligibilityRequirements(DateTime.Parse(txtExitDate.Text), int.Parse(txtFundID.Value), MemberCategory) != null)
                {
                    EligibilityRequirements = lp.GetMemberEligibilityRequirements(DateTime.Parse(txtExitDate.Text), int.Parse(txtFundID.Value), MemberCategory);

                }

                //Get Medical Free Limits 
                DataSet MedicalFreeLimits = new DataSet();
                if (lp.getMedicalFreeLimits(DateTime.Parse(txtExitDate.Text), int.Parse(txtFundID.Value), MemberCategory, EligibilityRequirements) != null)
                {
                    MedicalFreeLimits = lp.getMedicalFreeLimits(DateTime.Parse(txtExitDate.Text), int.Parse(txtFundID.Value), MemberCategory, EligibilityRequirements);

                }

                int NormalRet = 0;
                if (EligibilityRequirements != null && EligibilityRequirements.Tables.Count > 0 && EligibilityRequirements.Tables[0].Rows.Count > 0)
                {
                    NormalRet = int.Parse(EligibilityRequirements.Tables[0].Rows[0]["NormalRetirementAge"].ToString());
                }

                //END GET PRE-EXIT DETAILS

                //Get Member Age at retirement
                if (InitialMemberDetails.Tables[0].Rows.Count > 0)
                {
                    DataRow rwMd = InitialMemberDetails.Tables[0].Rows[0];
                    MemberDetails.Tables[0].Columns.Add("ReceivedBy");
                    MemberDetails.Tables[0].Columns.Add("DateReceived");
                    MemberDetails.Tables[0].Columns.Add("DateReported");
                    MemberDetails.Tables.Clear();
                    foreach (DataRow row in InitialMemberDetails.Tables[0].Rows)
                    {

                        string ValidatedNewColumns = "";
                        string[] item = {
        row["IdentityNo"].ToString(),
        row["LastName"].ToString(),
        row["LastName"].ToString(),
        row["Firstname"].ToString(),
        row["DateOfBirth"].ToString(),
        row["Gender_Id"].ToString(),
        row["DateJoinedFund"].ToString(),
        DateTime.Today.ToShortDateString(),
        txtExitDate.Text,
       DateTime.Parse( txtExitDate.Text).AddMonths(1).AddDays (1-DateTime.Parse(txtExitDate.Text).Day).ToString() ,//row["PensionCommenceDate"].ToString(),
        "0",
       DateTime.Parse(row["DateOfBirth"].ToString()).AddYears(NormalRet).ToString(),
        "0",
        row["ExitCode"].ToString()

    };
                        MemberCertificatesDS.Tables["MemberDetails"].Rows.Add(item);

                        MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["SystemRef"] = row["ID"].ToString();
                        MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["CompanyCode"] = row["CompanyNo"].ToString();
                        MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["CompanyName"] = row["Name"].ToString();
                        MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["ActualExitDate"] = txtExitDate.Text;

                    }

                    double RetAge = Math.Round((DateTime.Parse(txtCalDate.Text) - DateTime.Parse(rwMd["DateOfBirth"].ToString())).TotalDays / 365.5, 2);
                    Age = RetAge;

                    //Validate if Member has exited before
                    DataSet ExitedMember = new DataSet();
                    if (lp.GetExitedMemberDetails(int.Parse(txtFundID.Value), int.Parse(txtMemberID.Value)) != null)
                    {
                        ExitedMember = lp.GetExitedMemberDetails(int.Parse(txtFundID.Value), int.Parse(txtMemberID.Value));
                        foreach (DataRow rwEx in ExitedMember.Tables[0].Rows)
                        {
                            MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["ReceivedBy"] = rwEx["ReceivedBy"];
                            MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["DateReceived"] = rwEx["DateReceived"];
                            MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["DateReported"] = rwEx["DateReported"];
                        }

                        //Validate if Exited Member has been filled with details 

                    }

                    int NormalRetirement = int.Parse(EligibilityRequirements.Tables[0].Rows[0]["NormalRetirementAge"].ToString());
                    int EarlyRetirement = int.Parse(EligibilityRequirements.Tables[0].Rows[0]["EarlyRetirementAge"].ToString());
                    int LateRetirement = int.Parse(EligibilityRequirements.Tables[0].Rows[0]["MaxRetirementAge"].ToString());
                    int Ages = Convert.ToInt32(RetAge);
                    //Validate Exit Details By Fund Type and Age

                    //Early retiremnt
                    if (ExitType == "Early Retirement")
                    {
                        if ((Ages >= int.Parse(EligibilityRequirements.Tables[0].Rows[0]["EarlyRetirementAge"].ToString()) && Ages < int.Parse(EligibilityRequirements.Tables[0].Rows[0]["NormalRetirementAge"].ToString())))
                        {
                            InitializeValuesForNewCalculation(ExitType, MemberCertificatesDS, EligibilityRequirements);
                            ViewReport();
                        }
                        else
                        {

                            WarningAlert("This member does not qualify for " + ExitType + " because on exit (" + rwMd["DateOfExit"] + ") his/her age is  (" + Ages + ") and  Early Retirement age is '" + EarlyRetirement + "'");
                            //lblUserPrompt.Text = ;
                            //lblUserPrompt.ForeColor = System.Drawing.Color.Orange;
                            ////Ask User for if they want to see a quoatation
                            ////////btnYes.Visible = false;
                            ////////btnNo.Visible = false;
                            //pnlUserComms.Visible = false;
                            return;
                        }
                    }
                    else if (ExitType == "Ill Health Retirement")
                    {
                        if (Ages < int.Parse(EligibilityRequirements.Tables[0].Rows[0]["NormalRetirementAge"].ToString()))
                        {
                            InitializeValuesForNewCalculation(ExitType, MemberCertificatesDS, EligibilityRequirements);
                            ViewReport();
                        }
                        else
                        {
                            WarningAlert("This member does not qualify for " + ExitType + " because on exit (" + rwMd["DateOfExit"] + ") his/her age is (" + Ages + ")");
                            //lblUserPrompt.Text = ;
                            //lblUserPrompt.ForeColor = System.Drawing.Color.Orange;
                            ////Ask User for if they want to see a quoatation
                            ////////btnYes.Visible = false;
                            ////////btnNo.Visible = false;
                            //pnlUserComms.Visible = false;
                            return;
                        }
                    }
                    else if (ExitType == "Normal Retirement")
                    {
                        if (Ages == int.Parse(EligibilityRequirements.Tables[0].Rows[0]["NormalRetirementAge"].ToString()))
                        {
                            InitializeValuesForNewCalculation(ExitType, MemberCertificatesDS, EligibilityRequirements);
                            ViewReport();
                        }
                        else
                        {
                            WarningAlert("This member does not qualify for " + ExitType + " because on exit (" + rwMd["DateOfExit"] + ") his/her age is (" + Ages + ") and than Normal Retirement age is '" + NormalRetirement + "'");
                            //lblUserPrompt.Text = ;
                            //lblUserPrompt.ForeColor = System.Drawing.Color.Orange;
                            ////Ask User for if they want to see a quoatation
                            ////////btnYes.Visible = false;
                            ////////btnNo.Visible = false;
                            //pnlUserComms.Visible = false;
                            return;
                        }
                    }
                    else if (ExitType == "Late Retirement")
                    {
                        if (Ages > int.Parse(EligibilityRequirements.Tables[0].Rows[0]["NormalRetirementAge"].ToString()))
                        {
                            InitializeValuesForNewCalculation(ExitType, MemberCertificatesDS, EligibilityRequirements);
                            ViewReport();
                        }
                        else
                        {
                            WarningAlert("This member does not qualify for " + ExitType + " because on exit (" + rwMd["DateOfExit"] + ") his/her age is  (" + Ages + ") and late Retirement age is '" + LateRetirement + "'");

                            //lblUserPrompt.Text = ;
                            //lblUserPrompt.ForeColor = System.Drawing.Color.Orange;
                            ////Ask User for if they want to see a quoatation
                            ////////btnYes.Visible = false;
                            ////////btnNo.Visible = false;
                            //pnlUserComms.Visible = false;
                            return;
                        }
                    }
                    else
                    {
                        InitializeValuesForNewCalculation(ExitType, MemberCertificatesDS, EligibilityRequirements);
                        ViewReport();
                    }
                }
                else

                {
                    RedAlert("Invalid Member Details Selected");
                    return;
                }
            }

        }
        protected void ViewReport()
        {
            LookUp f = new LookUp("cn", 1);
            try
            {
                string RegNo = f.getRegNo(long.Parse(txtFundID.Value));

                myReport = new ReportDocument();

                if (ExitType == "Withdrawal")
                {
                    if (txtCalType.Value == "N")
                    {
                        myReport.Load(Server.MapPath(@"../Reports/WithDrawalBenefitCalQuotationReport.rpt"));
                    }
                    else if (txtCalType.Value == "A")
                    {
                        myReport.Load(Server.MapPath(@"../Reports/WithDrawalBenefitCalQuotationAReport.rpt"));
                    }
                    else
                    {
                        myReport.Load(Server.MapPath(@"../Reports/WithDrawalBenefitCalQuotationBReport.rpt"));
                    }
                }
                else if (ExitType == "Death")
                {
                    if (txtCalType.Value == "N")
                    {
                        myReport.Load(Server.MapPath(@"../Reports/DeathInServiceCalcQuotationReport.rpt"));
                    }
                    else if (txtCalType.Value == "A")
                    {
                        myReport.Load(Server.MapPath(@"../Reports/DeathInServiceCalcQuotationAReport.rpt"));
                    }
                    else
                    {
                        myReport.Load(Server.MapPath(@"../Reports/DeathInServiceCalcQuotationBReport.rpt"));
                    }
                }
                else if (ExitType == "Ill Health Retirement")
                {
                    if (txtCalType.Value == "N")
                    {
                        myReport.Load(Server.MapPath(@"../Reports/IllHealthBenefitsCalQuotationReport.rpt"));
                    }
                    else if (txtCalType.Value == "A")
                    {
                        myReport.Load(Server.MapPath(@"../Reports/IllHealthBenefitsCalQuotationAReport.rpt"));
                    }
                    else
                    {
                        myReport.Load(Server.MapPath(@"../Reports/IllHealthBenefitsCalQuotationBReport.rpt"));
                    }

                }
                else if (ExitType == "Early Retirement" || ExitType == "Normal Retirement" || ExitType == "Late Retirement" || ExitType == "Retrenchment/Reorganization")
                {
                    if (txtCalType.Value == "N")
                    {
                        myReport.Load(Server.MapPath(@"../Reports/RetirementBenefitsCalcQuotationReport.rpt"));
                    }
                    else if (txtCalType.Value == "A")
                    {
                        myReport.Load(Server.MapPath(@"../Reports/RetirementBenefitsCalcQuotationAReport.rpt"));
                    }
                    else
                    {
                        myReport.Load(Server.MapPath(@"../Reports/RetirementBenefitsCalcQuotationBReport.rpt"));
                    }
                }
                else
                {
                    myReport.Load(Server.MapPath(@"../Reports/WithDrawalBenefitCalQuotationReport.rpt"));
                }

                string servername = ConfigurationManager.AppSettings["servername"].ToString();
                string ReportPass = ConfigurationManager.AppSettings["ReportPass"].ToString();
                string DBName = ConfigurationManager.AppSettings["DBName"].ToString();
                string DbUser = ConfigurationManager.AppSettings["DbUser"].ToString();

                //myReport = new ReportDocument();
                //myReport.Load(Server.MapPath(@"~/Reports/TrialBalance.rpt"));
                //myReport.SetDatabaseLogon(DbUser, ReportPass, servername, DBName);

                //string servername = "DATASERVER"; //System.Configuration.ConfigurationManager.AppSettings("Hostname");
                //string ReportPass = "cive15Um";//System.Configuration.ConfigurationManager.AppSettings("RepPassword");
                //string DBName = "PensionsManComarton";//System.Configuration.ConfigurationManager.AppSettings("DBName");
                //string user1 = "sa";
                myReport.SetDatabaseLogon(DbUser, ReportPass, servername, DBName);

                CrystalDecisions.Shared.ParameterFields myParameterFields = new CrystalDecisions.Shared.ParameterFields();
                CrystalDecisions.Shared.ParameterField myParameterField = new CrystalDecisions.Shared.ParameterField();
                CrystalDecisions.Shared.ParameterDiscreteValue myDiscreteValue = new CrystalDecisions.Shared.ParameterDiscreteValue();
                myParameterField.ParameterFieldName = "RegNo";
                myDiscreteValue.Value = RegNo;
                myParameterField.CurrentValues.Add(myDiscreteValue);
                myParameterFields.Add(myParameterField);

                CrystalDecisions.Shared.ParameterField myParameterField1 = new CrystalDecisions.Shared.ParameterField();
                CrystalDecisions.Shared.ParameterDiscreteValue myDiscreteValue1 = new CrystalDecisions.Shared.ParameterDiscreteValue();
                myParameterField1.ParameterFieldName = "MemberID";
                myDiscreteValue1.Value = int.Parse(txtMemberID.Value);
                myParameterField1.CurrentValues.Add(myDiscreteValue1);
                myParameterFields.Add(myParameterField1);

                CrystalDecisions.Shared.ParameterField myParameterField2 = new CrystalDecisions.Shared.ParameterField();
                CrystalDecisions.Shared.ParameterDiscreteValue myDiscreteValue2 = new CrystalDecisions.Shared.ParameterDiscreteValue();
                myParameterField2.ParameterFieldName = "MemberIDNumber";
                myDiscreteValue2.Value = txtNationalID.Text;
                myParameterField2.CurrentValues.Add(myDiscreteValue2);
                myParameterFields.Add(myParameterField2);


                CrvTrialBalance.ReportSource = myReport;
                CrvTrialBalance.ParameterFieldInfo = myParameterFields;
                CrvTrialBalance.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;

                Session["Claims"] = myReport;
            }
            catch (Exception ex)
            {
                //msgbox(ex.Message);
                return;
            }

        }
        protected void InitializeValuesForNewCalculation(string ExitType, DataSet MemberDs, DataSet EligibilityDs)
        {
            try
            {
                //double Age = 0;
                foreach (DataRow rw in MemberDs.Tables["MemberDetails"].Rows)
                {
                    foreach (DataRow rwE in EligibilityDs.Tables[0].Rows)
                    {

                        if (rwE["GLACoverMultiple"].ToString() == "")
                        {
                            rwE["GLACoverMultiple"] = 0;
                        }
                        NormalRetAge = double.Parse(rwE["NormalRetirementAge"].ToString());
                        NormalRetDate = DateTime.Parse(rw["DOB"].ToString()).AddYears(int.Parse(rwE["NormalRetirementAge"].ToString()));
                        CoverMultiple = double.Parse(rwE["GLACoverMultiple"].ToString());
                        PensionableService = (DateTime.Parse(txtCalDate.Text) - DateTime.Parse(rw["DateJoinedFund"].ToString())).TotalDays / 365.5;
                    }
                }
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["TotalPS"] = PensionableService;

                //Age = (DateTime.Parse(txtExitDate.Text) - DateTime.Parse(MemberDs.Tables["MemberDetails"].Rows[0]["DOB"].ToString())).TotalDays / 365.5;

                FillBenefitParameters(ExitType, MemberDs); //Gets last bonus Date

                foreach (DataRow row in MemberDs.Tables["MemberDetails"].Rows)
                {
                    MemberRef = int.Parse(row["SystemRef"].ToString());
                    ExitDate = DateTime.Parse(txtExitDate.Text);
                    CalculationDate = DateTime.Now;
                    //CalculationDate = DateTime.Parse(row["CalculationDate"].ToString());
                    PensionCommenceDate = DateTime.Parse(txtCalDate.Text).AddMonths(1).AddDays(1 - DateTime.Parse(txtCalDate.Text).Day);//row["PensionCommenceDate"].ToString()
                    PensionArrearsPeriod = (CalculationDate - DateTime.Parse(txtCalDate.Text)).TotalDays;

                    LookUp lp = new LookUp("cn", 1);
                    int dr = 0;
                    DataSet r1 = new DataSet();
                    r1 = lp.getePeriodDateDiff(DateTime.Parse(txtCalDate.Text), CalculationDate);
                    if (r1 != null)
                    {
                        foreach (DataRow rwInt in r1.Tables[0].Rows)
                        {
                            dr = int.Parse(rwInt["result"].ToString());
                        }
                    }

                    PensionArrearsPeriod = dr;
                    PotentialPS = NormalRetAge - Age;
                    //LookUp lp = new LookUp("cn", 1);
                    ConversionFactor = lp.FillCommutation(DateTime.Parse((row["DOB"].ToString())), DateTime.Parse(txtCalDate.Text), row["Gender"].ToString(), int.Parse(txtFundID.Value), Age, ExitType);
                }
                //if (ExitType == "Death")
                //{
                //    Deathcalculation(MemberDs.Tables["MemberDetails"].Rows[0]["NationalID"].ToString(), LastBonusDate, ExitType, MemberDs.Tables["MemberDetails"].Rows[0]["DateOfExit"].ToString(), DateTime.Parse(MemberDs.Tables["MemberDetails"].Rows[0]["CalculationDate"].ToString()), int.Parse(MemberDs.Tables["MemberDetails"].Rows[0]["SystemRef"].ToString()));
                //}
                //else if (ExitType == "Withdrawal")
                //{
                //    withdrawalcalculation(MemberDs.Tables["MemberDetails"].Rows[0]["NationalID"].ToString(), LastBonusDate, ExitType, MemberDs.Tables["MemberDetails"].Rows[0]["DateOfExit"].ToString(), DateTime.Parse(MemberDs.Tables["MemberDetails"].Rows[0]["CalculationDate"].ToString()), int.Parse(MemberDs.Tables["MemberDetails"].Rows[0]["SystemRef"].ToString()));
                //}
                //else
                //{
                //    Retirementcalculation(MemberDs.Tables["MemberDetails"].Rows[0]["NationalID"].ToString(), LastBonusDate, ExitType, MemberDs.Tables["MemberDetails"].Rows[0]["DateOfExit"].ToString(), DateTime.Parse(MemberDs.Tables["MemberDetails"].Rows[0]["CalculationDate"].ToString()), int.Parse(MemberDs.Tables["MemberDetails"].Rows[0]["SystemRef"].ToString()));
                //}
                if (ExitType == "Death")
                {
                    Deathcalculation(MemberDs.Tables["MemberDetails"].Rows[0]["NationalID"].ToString(), LastBonusDate, ExitType, txtCalDate.Text, DateTime.Parse(MemberDs.Tables["MemberDetails"].Rows[0]["CalculationDate"].ToString()), int.Parse(MemberDs.Tables["MemberDetails"].Rows[0]["SystemRef"].ToString()));
                }
                else if (ExitType == "Withdrawal")
                {
                    withdrawalcalculation(MemberDs.Tables["MemberDetails"].Rows[0]["NationalID"].ToString(), LastBonusDate, ExitType, txtCalDate.Text, DateTime.Parse(MemberDs.Tables["MemberDetails"].Rows[0]["CalculationDate"].ToString()), int.Parse(MemberDs.Tables["MemberDetails"].Rows[0]["SystemRef"].ToString()));
                }
                else
                {
                    Retirementcalculation(MemberDs.Tables["MemberDetails"].Rows[0]["NationalID"].ToString(), LastBonusDate, ExitType, txtCalDate.Text, DateTime.Parse(MemberDs.Tables["MemberDetails"].Rows[0]["CalculationDate"].ToString()), int.Parse(MemberDs.Tables["MemberDetails"].Rows[0]["SystemRef"].ToString()));
                }



            }
            catch (Exception ex)
            {
                RedAlert(ex.Message);
            }
        }
        //protected void InitializeValuesForNewCalculation(string ExitType, DataSet MemberDs, DataSet EligibilityDs)
        //{
        //    try
        //    {
        //        double Age = 0;
        //        foreach (DataRow rw in MemberDs.Tables["MemberDetails"].Rows)
        //        {
        //            foreach (DataRow rwE in EligibilityDs.Tables[0].Rows)
        //            {

        //                if (rwE["GLACoverMultiple"].ToString() == "")
        //                {
        //                    rwE["GLACoverMultiple"] = 0;
        //                }
        //                NormalRetAge = double.Parse(rwE["NormalRetirementAge"].ToString());
        //                NormalRetDate = DateTime.Parse(rw["DOB"].ToString()).AddYears(int.Parse(rwE["NormalRetirementAge"].ToString()));
        //                CoverMultiple = double.Parse(rwE["GLACoverMultiple"].ToString());
        //                PensionableService = (DateTime.Parse(txtExitDate.Text) - DateTime.Parse(rw["DateJoinedFund"].ToString())).TotalDays / 365.5;
        //            }
        //        }
        //        MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["TotalPS"] = PensionableService;

        //        Age = (DateTime.Parse(txtExitDate.Text) - DateTime.Parse(MemberDs.Tables["MemberDetails"].Rows[0]["DOB"].ToString())).TotalDays / 365.5;

        //        FillBenefitParameters(ExitType, MemberDs); //Gets last bonus Date

        //        foreach (DataRow row in MemberDs.Tables["MemberDetails"].Rows)
        //        {
        //            MemberRef = int.Parse(row["SystemRef"].ToString());
        //            ExitDate = DateTime.Parse(txtExitDate.Text);
        //            CalculationDate = DateTime.Parse(row["CalculationDate"].ToString());
        //            PensionCommenceDate = DateTime.Parse(txtExitDate.Text).AddMonths(1).AddDays(1 - DateTime.Parse(txtExitDate.Text).Day);//row["PensionCommenceDate"].ToString()
        //            PensionArrearsPeriod = (CalculationDate - DateTime.Parse(txtExitDate.Text)).TotalDays;

        //            if (PensionArrearsPeriod < 0)
        //            {
        //                PensionArrearsPeriod = 0;
        //            }
        //            PotentialPS = NormalRetAge - Age;
        //            LookUp lp = new LookUp("cn", 1);
        //            ConversionFactor = lp.FillCommutation(DateTime.Parse((row["DOB"].ToString())), DateTime.Parse(txtExitDate.Text), row["Gender"].ToString(), int.Parse(txtFundID.Value), Age, ExitType);
        //        }
        //        if (ExitType == "Death")
        //        {
        //            Deathcalculation(MemberDs.Tables["MemberDetails"].Rows[0]["NationalID"].ToString(), LastBonusDate, ExitType, MemberDs.Tables["MemberDetails"].Rows[0]["DateOfExit"].ToString(), DateTime.Parse(MemberDs.Tables["MemberDetails"].Rows[0]["CalculationDate"].ToString()), int.Parse(MemberDs.Tables["MemberDetails"].Rows[0]["SystemRef"].ToString()));
        //        }
        //        else if (ExitType == "Withdrawal")
        //        {
        //            withdrawalcalculation(MemberDs.Tables["MemberDetails"].Rows[0]["NationalID"].ToString(), LastBonusDate, ExitType, MemberDs.Tables["MemberDetails"].Rows[0]["DateOfExit"].ToString(), DateTime.Parse(MemberDs.Tables["MemberDetails"].Rows[0]["CalculationDate"].ToString()), int.Parse(MemberDs.Tables["MemberDetails"].Rows[0]["SystemRef"].ToString()));
        //        }
        //        else
        //        {
        //            Retirementcalculation(MemberDs.Tables["MemberDetails"].Rows[0]["NationalID"].ToString(), LastBonusDate, ExitType, MemberDs.Tables["MemberDetails"].Rows[0]["DateOfExit"].ToString(), DateTime.Parse(MemberDs.Tables["MemberDetails"].Rows[0]["CalculationDate"].ToString()), int.Parse(MemberDs.Tables["MemberDetails"].Rows[0]["SystemRef"].ToString()));
        //        }



        //    }
        //    catch (Exception ex)
        //    {
        //        RedAlert(ex.Message);
        //    }
        //}
        protected void UpdateMemberDetailsTable(string ExitType)
        {
            LookUp lp = new LookUp("cn", 1);
            try
            {
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["BonusDate"] = LastBonusDate;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["MemberCont"] = MemberContWithoutInt;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["EmployerCont"] = EmployerContWithoutInt;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["MemberContInt"] = MemberContWithInt;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["EmployerContInt"] = EmployerContWithInt;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["Memberportlastreview"] = MemberPortAtReview;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["EmployerPortLastReview"] = EmployerPortAtReview;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["MemberPortExit"] = MemberPortAtExit;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["EmployerPortExit"] = EmployerPortAtExit;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["MemberPortionAtPayment"] = MemberPortionWithLatePaymentInt;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["EmployerPortionAtPayment"] = EmployerPortionWithLatePaymentInt;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["Salary"] = AnnualSalary;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["BenefitAmount"] = BenefitAmount;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["AdditionalAward"] = AdditionalAward;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["BenefitDescription"] = BenefitDescription;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["MemberAge"] = Age;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["ThirdCommutation"] = TaxFreeCommutation;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["ThirdComutationWithInterest"] = TaxfreeCommutationWithint;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["AccumulationWithInterest"] = AccumulationWithInt;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["ResidualConsid"] = BalAccumCredit;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["ConversionFactor"] = ConversionFactor;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["AnnualPension"] = AnnualPenAfterCommutation;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["MonthlyPension"] = Math.Round(AnnualPenAfterCommutation / 12, 2);
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["Exittype"] = ExitType;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["MinAnnualPension"] = MinPensionAllowable;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["CapitalValue"] = CapitalValue;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["EnhResCons"] = EnhancedResidualConsid;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["EnhResAnnualP"] = EnhancedResidualAnnualPen;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["EnhmontlyP"] = Math.Round(EnhancedResidualAnnualPen / 12, 2);
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["CoverMultiple"] = CoverMultiple;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["GLAEntitlement"] = GLAEntiltlement;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["ReassuredCover"] = ReassuredCover;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["LumpsumPayable"] = LumpsumPayable;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["NetLumpsumPayable"] = NetLumpsumPayable;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["NetLumpsumPayableWithInterest"] = NetLumpsumPayablewithint;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["MemberBenefitTax"] = MemberBenefitTax;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["AddAwardTax"] = AdditionalAwardTax;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["PensionCommenceDate"] = PensionCommenceDate;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["PeriodAfterExit"] = PensionArrearsPeriod;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["NomBenTaxableAmount"] = NBeneficiary_BalTaxableAmount;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["BenefitTransferedIn"] = BenefitTransferedIn;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["NormalRetAge"] = NormalRetAge;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["ReductionPercentage"] = ReductionRercentage;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["PotentialPensionableService"] = PotentialPS;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["LateRetConversionFactor"] = LateRetirementConversionfactor;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["ProjectedPension"] = ProjectedPension;
                MemberCertificatesDS.Tables["MemberDetails"].Rows[0]["AnnualisedLatestSalary"] = AnnualisedLastSalary;
                //Fund F = new Fund("cn", int.Parse(Session["userid"].ToString()));
                string RegNo = lp.getRegNo(int.Parse(txtFundID.Value));
                string FundName = "";
                string FundTaxNo = "";
                string FundPostalAddress = "";
                //string getusername = Session["username"].ToString();
                //int userid = 1;

                ////var users = db.Users.ToList().Where(a => a.Email == getusername).ToArray();//select userid of current session
                ////foreach (var id in users)
                ////{
                ////    userid = id.UserID;
                ////}
                //DataSet GetAminUsers = lp.GetAdminUsers(getusername);

                //if (GetAminUsers != null)
                //{
                //    foreach (DataRow dt in GetAminUsers.Tables[0].Rows)
                //    {
                //        userid = Convert.ToInt32(dt["UserID"].ToString());
                //    }
                //}
                //string RegName = F.getRegName(int.Parse(txtFundID.Value));
                DataSet fd = lp.getFundDetails(RegNo);

                if (MemberCertificatesDS.Tables["MemberDetails"].Rows.Count > 0)
                {

                    //We have a fund exit record and a quote
                    foreach (DataRow row in MemberCertificatesDS.Tables["MemberDetails"].Rows)
                    {

                        DateTime convDate = DateTime.Parse(row["DOB"].ToString());
                        //lblUserPrompt.Text = "This is our supposed converted date_" + convDate.ToString("lp/dd/yyyy");
                        //pnlUserComms.Visible = false;


                        double PensionableService = (DateTime.Parse(row["DateOfExit"].ToString()) - DateTime.Parse(row["DateJoinedFund"].ToString())).TotalDays / 365.5;


                        if (ExitType != "Withdrawal")
                        {
                            //Exit
                            if (lp.ValidateDouble(row["CapitalValue"].ToString()) >= (lp.ValidateDouble(row["MemberPortExit"].ToString()) + lp.ValidateDouble(row["EmployerPortExit"].ToString())))
                            {
                                //FullAnnualPenBeforeComutation = lp.ValidateDouble(row["MinAnnualPension"].ToString());
                            }
                            else
                            {
                                //FullAnnualPenBeforeComutation = (lp.ValidateDouble(row["MemberPortExit"].ToString()) + lp.ValidateDouble(row["EmployerPortExit"].ToString())) / lp.ValidateDouble(row["ConversionFactor"].ToString());
                            }
                            row["AnnualPension"] = row["MinAnnualPension"];
                            //string b = row["MinAnnualPension"].ToString();
                            //Exit                            
                        }
                        else
                        {
                            row["AnnualPension"] = "0";
                            row["MonthlyPension"] = "0";
                        }

                        foreach (DataRow rw in fd.Tables[0].Rows)
                        {
                            FundName = rw["RegName"].ToString();
                            FundTaxNo = rw["TaxNo"].ToString();
                            FundPostalAddress = rw["PostalAdd1"].ToString();
                        }
                        DateTime ActualExitDate = Convert.ToDateTime(txtExitDate.Text);
                        DateTime SystemExitDate = Convert.ToDateTime(txtCalDate.Text);
                        DateTime CalculationDate = DateTime.Now;
                        string ActualExitDates = ActualExitDate.ToString("yyyy-MM-dd");
                        string SystemExitDates = SystemExitDate.ToString("yyyy-MM-dd");
                        string CalculationDates = CalculationDate.ToString("yyyy-MM-dd");

                        if (txtCalType.Value == "N")
                        {
                            FundExit fe = new FundExit();
                            fe.RegNo = RegNo;
                            Guid guid = Guid.NewGuid();
                            fe.MemberID = int.Parse(row["SystemRef"].ToString());
                            fe.ExitDate = Convert.ToDateTime(SystemExitDates);
                            fe.CalculationDate = Convert.ToDateTime(CalculationDates);
                            fe.ExitCode = int.Parse(ExitCode);
                            ExitCode = fe.ExitCode.ToString();
                            fe.AgeOnExit = double.Parse(row["MemberAge"].ToString());
                            fe.PensionableService = double.Parse(PensionableService.ToString());
                            fe.AnualSalary = AnnualSalary;
                            fe.ReservationDate = DateTime.Parse(row["BonusDate"].ToString());
                            fe.AccruedReserve = double.Parse(row["MemberPortLastReview"].ToString()) + double.Parse(row["EmployerPortLastReview"].ToString());
                            fe.XContribution = double.Parse(row["MemberContInt"].ToString());
                            fe.YContribution = double.Parse(row["EmployerContInt"].ToString());
                            fe.AccruedReserveAtExit = (double.Parse(row["MemberPortExit"].ToString()) + double.Parse(row["EmployerPortExit"].ToString()));
                            fe.ConversionFactor = double.Parse(row["ConversionFactor"].ToString());
                            fe.PostReserveService = 0;
                            fe.PensionBeforeCommutation = double.Parse(FullAnnualPenBeforeComutation.ToString());
                            fe.Commutation = double.Parse(row["ThirdCommutation"].ToString());
                            fe.ResidualPension = double.Parse(row["AnnualPension"].ToString());
                            fe.EmployerAmountTo = double.Parse(row["AdditionalAward"].ToString());
                            fe.ResidualConsideration = double.Parse(row["ResidualConsid"].ToString());
                            fe.UserID = Convert.ToInt32(txtSystemRef.Value);
                            fe.Paye = 0;
                            fe.TotalBenefit = decimal.Parse(row["BenefitAmount"].ToString());
                            fe.LifeAssurance = 0;
                            fe.ReassuredCover = 0;
                            fe.Checked = false;
                            fe.PaymentType = "AR";
                            fe.Authorised = false;
                            fe.AuthorisedBy = null;
                            fe.PensionType = "N";
                            fe.ClaimStatusID = 2;
                            fe.msrepl_tran_version = guid;
                            db.FundExits.Add(fe);
                            db.SaveChanges();

                            FundExitsQuotation fn = new FundExitsQuotation();
                            fn.RegNo = RegNo;
                            fn.SystemRef = int.Parse(row["SystemRef"].ToString());
                            fn.NationalID = row["NationalID"].ToString();
                            fn.Surname = $"{row["Surname"].ToString()} {row["Firstname"].ToString()}";
                            fn.SecondSurname = row["SecondSurname"].ToString();
                            fn.Firstname = row["Firstname"].ToString();
                            fn.Gender = row["Gender"].ToString();
                            fn.FundName = FundName.ToString();
                            fn.FundPostalAdd = FundPostalAddress;
                            fn.FundTaxNum = FundTaxNo;
                            fn.DateOfExit = Convert.ToDateTime(SystemExitDates);
                            fn.CalculationDate = Convert.ToDateTime(CalculationDates);
                            fn.DateJoinedFund = DateTime.Parse(row["DateJoinedFund"].ToString());
                            fn.DOB = DateTime.Parse(row["DOB"].ToString());
                            fn.ExitCode = int.Parse(row["ExitCode"].ToString());
                            fn.MemberAge = double.Parse(row["MemberAge"].ToString());
                            fn.TotalPS = double.Parse(row["TotalPS"].ToString());
                            fn.Salary = double.Parse(row["Salary"].ToString());
                            fn.MemberCont = double.Parse(row["MemberCont"].ToString());
                            fn.MemberContInt = double.Parse(row["MemberContInt"].ToString());
                            fn.EmployerCont = double.Parse(row["EmployerCont"].ToString());
                            fn.EmployerContInt = double.Parse(row["EmployerContInt"].ToString());
                            fn.MemberPortLastReview = double.Parse(row["MemberPortLastReview"].ToString());
                            fn.MemberPortExit = double.Parse(row["MemberPortExit"].ToString());
                            fn.EmployerPortExit = double.Parse(row["EmployerPortExit"].ToString());
                            fn.MemberPortionAtPayment = double.Parse(row["MemberPortionAtPayment"].ToString());
                            fn.EmployerPortionAtPayment = double.Parse(row["EmployerPortionAtPayment"].ToString());
                            fn.EmployerPortLastReview = double.Parse(row["EmployerPortLastReview"].ToString());
                            fn.NormalRet = DateTime.Parse((row["NormalRet"].ToString()));
                            fn.BonusDate = (DateTime.Parse(row["BonusDate"].ToString()));
                            fn.FundName = FundName;
                            fn.FundTaxNum = FundTaxNo;
                            fn.FundPostalAdd = FundPostalAddress;
                            fn.BenefitAmount = double.Parse(row["BenefitAmount"].ToString());
                            fn.BenefitDescription = (row["BenefitDescription"].ToString());
                            fn.ThirdCommutation = double.Parse(row["ThirdCommutation"].ToString());
                            fn.ThirdComutationWithInterest = double.Parse(row["ThirdComutationWithInterest"].ToString());
                            fn.AccumulationWithInterest = double.Parse(row["AccumulationWithInterest"].ToString());
                            fn.ResidualConsid = double.Parse(row["ResidualConsid"].ToString());
                            fn.ConversionFactor = double.Parse(row["ConversionFactor"].ToString());
                            fn.AnnualPension = double.Parse(row["AnnualPension"].ToString());
                            fn.MonthlyPension = double.Parse(row["MonthlyPension"].ToString());
                            fn.ExitType = (row["ExitType"].ToString());
                            fn.MinAnnualPension = double.Parse(row["MinAnnualPension"].ToString());
                            fn.CapitalValue = double.Parse(row["CapitalValue"].ToString());
                            fn.EnhResCons = double.Parse(row["EnhResCons"].ToString());
                            fn.EnhResAnnualP = double.Parse(row["EnhResAnnualP"].ToString());
                            fn.EnhMontlyP = double.Parse(row["EnhMontlyP"].ToString());
                            fn.CoverMultiple = double.Parse(row["CoverMultiple"].ToString());
                            fn.GLAEntitlement = double.Parse(row["GLAEntitlement"].ToString());
                            fn.ReassuredCover = double.Parse(row["ReassuredCover"].ToString());
                            fn.LumpsumPayable = double.Parse(row["LumpsumPayable"].ToString());
                            fn.NetLumpsumPayable = double.Parse(row["NetLumpsumPayable"].ToString());
                            fn.MemberBenefitTax = double.Parse(row["MemberBenefitTax"].ToString());
                            fn.AddAwardTax = double.Parse(row["AddAwardTax"].ToString());
                            fn.NetLumpsumPayableWithInterest = double.Parse(row["NetLumpsumPayableWithInterest"].ToString());
                            fn.PensionCommenceDate = DateTime.Parse(row["PensionCommenceDate"].ToString());
                            fn.PeriodAfterExit = Convert.ToInt32(PensionArrearsPeriod);


                            if (row["PensionArrears"].ToString() == "")
                            {
                                row["PensionArrears"] = 0;
                            }
                            if (row["AdvancePayment"].ToString() == "")
                            {
                                row["AdvancePayment"] = 0;
                            }
                            if (row["SpouseMonthlyPension"].ToString() == "")
                            {
                                row["SpouseMonthlyPension"] = 0;
                            }
                            if (row["CompanyCode"].ToString() == "")
                            {
                                row["CompanyCode"] = 0;
                            }
                            fn.PensionArrears = double.Parse(row["PensionArrears"].ToString());
                            fn.AdvancePayment = double.Parse(row["AdvancePayment"].ToString());
                            fn.SpouseMonthlyPension = double.Parse(row["SpouseMonthlyPension"].ToString());
                            fn.ChildMonthlyPension = 0;
                            fn.CompanyCode = int.Parse(row["CompanyCode"].ToString());

                            fn.ChildMonthlyPension = 0;
                            fn.CompanyCode = int.Parse(row["CompanyCode"].ToString());
                            fn.CompanyName = (row["CompanyName"].ToString());
                            fn.BenefitTransferedIn = double.Parse(row["BenefitTransferedIn"].ToString());
                            fn.ActualExitDate = DateTime.Parse(ActualExitDates);
                            fn.DateOfDeath = fn.ActualExitDate;
                            fn.UserID = Convert.ToInt32(txtSystemRef.Value);
                            fn.Authorised = false;
                            fn.AuthorisedBy = null;
                            fn.DateAuthorised = DateTime.Today.Date;
                            fn.Paye = 0;
                            fn.CheckedBy = 1;
                            fn.ClaimStatusID = 2;
                            fn.Checked = false;
                            fn.PaymentType = "AR";
                            fn.PaymentType = "N";
                            fn.DateChecked = DateTime.Today.Date;
                            fn.DateCreated = DateTime.Today.Date;
                            if (DateTime.TryParse(row["DateReceived"].ToString(), out DateTime result))
                            {

                            }
                            else
                            {
                                row["DateReceived"] = DateTime.Today;
                            }
                            fn.DateReceived = DateTime.Parse(row["DateReceived"].ToString());
                            if (long.TryParse(row["ReceivedBy"].ToString(), out long rb))
                            {

                            }
                            else
                            {
                                row["Receivedby"] = 1;
                            }

                            fn.ReceivedBy = int.Parse(row["ReceivedBy"].ToString());
                            fn.Remarks = (row["Remarks"].ToString());

                            db.FundExitsQuotations.Add(fn);
                            db.SaveChanges();

                            SuccessAlert("Claim Successfully Logged, Claim No." + fe.ID.ToString() + "Awaiting Checking");
                            txtClaimNo.Text = fe.ID.ToString();
                            getMemberClaim();

                            string constr = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                            if (ExitCode == "4")
                            {
                                LookUp mm = new LookUp("cn", 1);
                                if (mm.CheckBeneficiaryRecordExists(MemberRef))
                                {
                                    myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                                    cmd = new SqlCommand("Delete from MemberBeneficiaries where MemberID='" + MemberRef + "'", myConnection);
                                    if ((myConnection.State == ConnectionState.Open))
                                        myConnection.Close();
                                    myConnection.Open();
                                    cmd.ExecuteNonQuery();
                                    myConnection.Close();


                                    SqlConnection sqlCon = null;
                                    using (sqlCon = new SqlConnection(constr))
                                    {
                                        sqlCon.Open();
                                        SqlCommand sql_cmnd = new SqlCommand("Beneficiary_Ins", sqlCon);
                                        sql_cmnd.CommandType = CommandType.StoredProcedure;
                                        sql_cmnd.Parameters.AddWithValue("@MemberID", SqlDbType.Int).Value = MemberRef;
                                        sql_cmnd.Parameters.AddWithValue("@FirstName", SqlDbType.NVarChar).Value = txtSpouseFirstname.Text;
                                        sql_cmnd.Parameters.AddWithValue("@SurName", SqlDbType.NVarChar).Value = txtSpouseSurname.Text;
                                        sql_cmnd.Parameters.AddWithValue("@Bank", SqlDbType.NVarChar).Value = drpBank.SelectedItem.Text;
                                        sql_cmnd.Parameters.AddWithValue("@Branch", SqlDbType.NVarChar).Value = drpBranch.SelectedItem.Text;
                                        sql_cmnd.Parameters.AddWithValue("@AccountName", SqlDbType.NVarChar).Value = txtAccName.Text;
                                        sql_cmnd.Parameters.AddWithValue("@AccountNo", SqlDbType.Int).Value = txtAccNo.Text;
                                        sql_cmnd.Parameters.AddWithValue("@NationalID", SqlDbType.NVarChar).Value = txtSpouseID.Text;
                                        sql_cmnd.Parameters.AddWithValue("@RelationshipID", SqlDbType.Int).Value = 0;
                                        sql_cmnd.Parameters.AddWithValue("@EntitlementPortion", SqlDbType.Decimal).Value = txtSpouseShare.Text;
                                        sql_cmnd.Parameters.AddWithValue("@GenderID", SqlDbType.Int).Value = 1;
                                        sql_cmnd.Parameters.AddWithValue("@DateCreated", SqlDbType.DateTime).Value = DateTime.Now;
                                        sql_cmnd.Parameters.AddWithValue("@CreatedBy", SqlDbType.Int).Value = 1;
                                        sql_cmnd.Parameters.AddWithValue("@DOB", SqlDbType.Date).Value = txtSpouseDOB.Text;
                                        sql_cmnd.ExecuteNonQuery();
                                        sqlCon.Close();
                                    }
                                }
                                else
                                {
                                    SqlConnection sqlCon = null;
                                    using (sqlCon = new SqlConnection(constr))
                                    {
                                        sqlCon.Open();
                                        SqlCommand sql_cmnd = new SqlCommand("Beneficiary_Ins", sqlCon);
                                        sql_cmnd.CommandType = CommandType.StoredProcedure;
                                        sql_cmnd.Parameters.AddWithValue("@MemberID", SqlDbType.Int).Value = MemberRef;
                                        sql_cmnd.Parameters.AddWithValue("@FirstName", SqlDbType.NVarChar).Value = txtSpouseFirstname.Text;
                                        sql_cmnd.Parameters.AddWithValue("@SurName", SqlDbType.NVarChar).Value = txtSpouseSurname.Text;
                                        sql_cmnd.Parameters.AddWithValue("@Bank", SqlDbType.NVarChar).Value = drpBank.SelectedItem.Text;
                                        sql_cmnd.Parameters.AddWithValue("@Branch", SqlDbType.NVarChar).Value = drpBranch.SelectedItem.Text;
                                        sql_cmnd.Parameters.AddWithValue("@AccountName", SqlDbType.NVarChar).Value = txtAccName.Text;
                                        sql_cmnd.Parameters.AddWithValue("@AccountNo", SqlDbType.NVarChar).Value = txtAccNo.Text;
                                        sql_cmnd.Parameters.AddWithValue("@NationalID", SqlDbType.NVarChar).Value = txtSpouseID.Text;
                                        sql_cmnd.Parameters.AddWithValue("@RelationshipID", SqlDbType.Int).Value = 0;
                                        sql_cmnd.Parameters.AddWithValue("@EntitlementPortion", SqlDbType.Decimal).Value = txtSpouseShare.Text;
                                        sql_cmnd.Parameters.AddWithValue("@GenderID", SqlDbType.Int).Value = 0;
                                        sql_cmnd.Parameters.AddWithValue("@DateCreated", SqlDbType.DateTime).Value = DateTime.Now;
                                        sql_cmnd.Parameters.AddWithValue("@CreatedBy", SqlDbType.Int).Value = 1;
                                        sql_cmnd.Parameters.AddWithValue("@DOB", SqlDbType.Date).Value = txtSpouseDOB.Text;
                                        sql_cmnd.ExecuteNonQuery();
                                        sqlCon.Close();
                                    }
                                }
                            }

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                RedAlert(ex.Message);
                var st = new System.Diagnostics.StackTrace(ex, true);
                // Get the top stack frame
                var frame = st.GetFrame(0);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();
                var lineNumber = 0;
                const string lineSearch = ":line ";
                var index = ex.StackTrace.LastIndexOf(lineSearch);
                if (index != -1)
                {
                    var lineNumberText = ex.StackTrace.Substring(index + lineSearch.Length);
                    if (int.TryParse(lineNumberText, out lineNumber))
                    {
                    }
                }
            }
        }
        protected void Retirementcalculation(string nationalid, DateTime Lastbonusdate, string Exitype, string ExitDate, DateTime Calculationdate, int refnumber, double CommutationFactor = 0)
        {
            try
            {

                DataSet generalds = new DataSet();
                DataSet DS = new DataSet();
                LookUp lp = new LookUp("cn", 1);
                // Fill Working Data Sets
                DataSet x = new DataSet();
                x = lp.MemberStartupValues(int.Parse(txtFundID.Value), refnumber, Lastbonusdate, txtCalType.Value);
                if (x != null)
                {
                    LastBonus = x;
                }
                else
                {
                    LastBonus = null;
                }
                DataSet x1 = new DataSet();

                ContributionsWithoutInt = null;
                x1 = lp.MemberContributionsAfterReview(int.Parse(txtFundID.Value), refnumber, Lastbonusdate, DateTime.Parse(ExitDate.ToString()), txtCalType.Value);
                if (x1 != null)
                {
                    ContributionsWithoutInt = x1;

                }
                else
                {
                    ContributionsWithoutInt = null;

                }
                //get ContributiosWithoutInt
                DataSet x9 = new DataSet();
                x9 = lp.MemberContributionsAfterReview(int.Parse(txtFundID.Value), refnumber, Lastbonusdate, DateTime.Parse(ExitDate.ToString()), txtCalType.Value);
                if (x9 != null)
                {
                    ContributionsAfterDeclaration = x9;
                }
                else
                {
                    ContributionsAfterDeclaration = null;
                }
                DataSet x2 = null;
                x2 = lp.InterestBasis(int.Parse(txtFundID.Value), DateTime.Parse(ExitDate.ToString()));
                if (x2 != null)
                {
                    dtInterests = x2;

                }
                else
                {
                    dtInterests = null;
                }

                if (x2 != null)
                {
                    foreach (DataRow rwInt in x2.Tables[0].Rows)
                    {
                        if (rwInt["AnnualyOrPart"].ToString() == "A")
                        {
                            if (rwInt["SCInd"].ToString() == "C")
                            {
                                RateValue = Math.Pow(1 + double.Parse(rwInt["MonthlyIntRate"].ToString()) / 100, 0.083333); //1/12 = 0.083333
                            }
                            else
                            {

                                RateValue = (1 + double.Parse(rwInt["MonthlyIntRate"].ToString()) / 1200);
                            }
                        }
                        else
                        {
                            RateValue = (1 + double.Parse(rwInt["MonthlyIntRate"].ToString()) / 100);
                        }
                        if (ContributionsAfterDeclaration != null)
                        {
                            foreach (DataRow rwCntAD in ContributionsAfterDeclaration.Tables[0].Rows)
                            {
                                if (DateTime.Parse(rwCntAD["PaymentDate"].ToString()) < DateTime.Parse(rwInt["EffectiveDate"].ToString()))
                                {
                                    rwCntAD["XContribution"] = double.Parse(rwCntAD["XContribution"].ToString()) * RateValue;
                                    rwCntAD["YContribution"] = double.Parse(rwCntAD["YContribution"].ToString()) * RateValue;
                                    rwCntAD["ZContribution"] = double.Parse(rwCntAD["ZContribution"].ToString()) * RateValue;
                                    rwCntAD["TransferInMember"] = double.Parse(rwCntAD["TransferInMember"].ToString()) * RateValue;
                                    rwCntAD["TransferInEmployer"] = double.Parse(rwCntAD["TransferInEmployer"].ToString()) * RateValue;
                                    rwCntAD["OtherMember"] = double.Parse(rwCntAD["OtherMember"].ToString()) * RateValue;
                                    rwCntAD["OtherEmployer"] = double.Parse(rwCntAD["OtherEmployer"].ToString()) * RateValue;
                                }
                            }
                        }

                    }
                }


                DataSet x3 = new DataSet();
                x3 = lp.MemberLastSalary(int.Parse(txtFundID.Value), refnumber, DateTime.Parse(ExitDate.ToString()), txtCalType.Value);
                if (x3 != null)
                {
                    LatestSalary = x3;
                }
                else
                {
                    LatestSalary = null;
                }
                DataSet x4 = new DataSet();
                x4 = lp.MemberLastBonusWithInterest(int.Parse(txtFundID.Value), refnumber, Lastbonusdate, DateTime.Parse(ExitDate.ToString()), txtCalType.Value);
                if (x4 != null)
                {
                    LastBonusWithInterest = x4;
                }
                else
                {
                    LastBonusWithInterest = null;
                }
                if (x2 != null)
                {
                    foreach (DataRow rwInt in x2.Tables[0].Rows)
                    {
                        if (rwInt["AnnualyorPart"].ToString() == "A")
                        {
                            if (rwInt["SCInd"].ToString() == "C")
                            {
                                RateValue = Math.Pow(1 + double.Parse(rwInt["MonthlyIntRate"].ToString()) / 100, 0.083333); //1/12 = 0.083333
                            }
                            else
                            {

                                RateValue = (1 + double.Parse(rwInt["MonthlyIntRate"].ToString()) / 1200);
                            }
                        }
                        else
                        {
                            RateValue = (1 + double.Parse(rwInt["MonthlyIntRate"].ToString()) / 100);
                        }

                        if (LastBonusWithInterest != null)
                        {
                            foreach (DataRow rwCntAD in LastBonusWithInterest.Tables[0].Rows)
                            {
                                if (DateTime.Parse(rwCntAD["PaymentDate"].ToString()) < DateTime.Parse(rwInt["EffectiveDate"].ToString()))
                                {
                                    rwCntAD["XContribution"] = double.Parse(rwCntAD["XContribution"].ToString()) * RateValue;
                                    rwCntAD["YContribution"] = double.Parse(rwCntAD["YContribution"].ToString()) * RateValue;
                                    rwCntAD["ZContribution"] = double.Parse(rwCntAD["ZContribution"].ToString()) * RateValue;
                                    rwCntAD["TransferInMember"] = double.Parse(rwCntAD["TransferInMember"].ToString()) * RateValue;
                                    rwCntAD["TransferInEmployer"] = double.Parse(rwCntAD["TransferInEmployer"].ToString()) * RateValue;
                                    rwCntAD["OtherMember"] = double.Parse(rwCntAD["OtherMember"].ToString()) * RateValue;
                                    rwCntAD["OtherEmployer"] = double.Parse(rwCntAD["OtherEmployer"].ToString()) * RateValue;
                                }
                            }
                        }
                    }

                }
                DataSet x5 = new DataSet();
                x5 = lp.StatutoryRequirements(int.Parse(txtFundID.Value), LastBonusDate);
                if (x5 != null)
                {
                    CommutationFactorAndMinCom = x5;
                }
                else
                {
                    CommutationFactorAndMinCom = null;
                }
                DataSet x5A = new DataSet();
                x5A = lp.RetirementillHealthParameters(int.Parse(txtFundID.Value), ExitMemberCategory, DateTime.Parse(ExitDate.ToString()));
                if (x5A != null)
                {
                    illHealthParameters = x5A;
                }
                else
                {
                    illHealthParameters = null;
                }

                //Begin Calculations
                //Get Accumulated Credit as at the Last Bonus Date
                if (LastBonus != null)
                {
                    foreach (DataRow rwLstB in LastBonus.Tables[0].Rows)
                    {
                        AccumReserveAtLastReview = Math.Round(AccumReserveAtLastReview + double.Parse(rwLstB["XContribution"].ToString()) + double.Parse(rwLstB["YContribution"].ToString()) + double.Parse(rwLstB["ZContribution"].ToString()) + double.Parse(rwLstB["TransferInMember"].ToString()) + double.Parse(rwLstB["TransferInEmployer"].ToString()) + double.Parse(rwLstB["OtherMember"].ToString()) + double.Parse(rwLstB["OtherEmployer"].ToString()), 2);
                        MemberPortAtReview = Math.Round(MemberPortAtReview + double.Parse(rwLstB["XContribution"].ToString()) + double.Parse(rwLstB["ZContribution"].ToString()) + double.Parse(rwLstB["TransferInMember"].ToString()) + double.Parse(rwLstB["OtherMember"].ToString()), 2);
                        EmployerPortAtReview = Math.Round(EmployerPortAtReview + double.Parse(rwLstB["YContribution"].ToString()) + double.Parse(rwLstB["TransferInEmployer"].ToString()) + double.Parse(rwLstB["OtherEmployer"].ToString()), 2);
                    }

                }

                //Get Contributions without interest since last bonus date
                if (ContributionsWithoutInt != null)
                {
                    foreach (DataRow rwLstB in ContributionsWithoutInt.Tables[0].Rows)
                    {
                        MemberContWithoutInt = Math.Round(MemberContWithoutInt + double.Parse(rwLstB["XContribution"].ToString()) + double.Parse(rwLstB["ZContribution"].ToString()) + double.Parse(rwLstB["TransferInMember"].ToString()) + double.Parse(rwLstB["OtherMember"].ToString()), 2);
                        EmployerContWithoutInt = Math.Round(EmployerContWithoutInt + double.Parse(rwLstB["YContribution"].ToString()) + double.Parse(rwLstB["TransferInEmployer"].ToString()) + double.Parse(rwLstB["OtherEmployer"].ToString()), 2);
                    }
                }

                //Get employer and member contributions after bonus date including interest 
                if (ContributionsAfterDeclaration != null)
                {

                    foreach (DataRow rwLstB in ContributionsAfterDeclaration.Tables[0].Rows)
                    {
                        MemberContWithInt = Math.Round(MemberContWithInt + double.Parse(rwLstB["XContribution"].ToString()) + double.Parse(rwLstB["ZContribution"].ToString()) + double.Parse(rwLstB["TransferInMember"].ToString()) + double.Parse(rwLstB["OtherMember"].ToString()), 2);
                        EmployerContWithInt = Math.Round(EmployerContWithInt + double.Parse(rwLstB["YContribution"].ToString()) + double.Parse(rwLstB["TransferInEmployer"].ToString()) + double.Parse(rwLstB["OtherEmployer"].ToString()), 2);
                    }
                }

                //get accumulated credit at bonus date updated with interest
                if (LastBonusWithInterest != null)
                {
                    foreach (DataRow rwLstB in LastBonusWithInterest.Tables[0].Rows)
                    {
                        AccumReserveToExit = Math.Round(AccumReserveToExit + double.Parse(rwLstB["XContribution"].ToString()) + double.Parse(rwLstB["YContribution"].ToString()) + double.Parse(rwLstB["ZContribution"].ToString()) + double.Parse(rwLstB["TransferInMember"].ToString()) + double.Parse(rwLstB["TransferInEmployer"].ToString()) + double.Parse(rwLstB["OtherMember"].ToString()) + double.Parse(rwLstB["OtherEmployer"].ToString()), 2);
                        AccumReserveToExitMemberOnly = Math.Round(AccumReserveToExitMemberOnly + double.Parse(rwLstB["XContribution"].ToString()) + double.Parse(rwLstB["ZContribution"].ToString()) + double.Parse(rwLstB["TransferInMember"].ToString()) + double.Parse(rwLstB["OtherMember"].ToString()), 2);
                        AccumReserveToExitEmployerOnly = Math.Round(AccumReserveToExitEmployerOnly + double.Parse(rwLstB["YContribution"].ToString()) + double.Parse(rwLstB["TransferInEmployer"].ToString()) + double.Parse(rwLstB["OtherEmployer"].ToString()), 2);
                    }
                }
                if (AccumReserveToExitMemberOnly == 0)
                {
                    AccumReserveToExitMemberOnly = MemberPortAtReview;
                }
                if (AccumReserveToExitEmployerOnly == 0)
                {
                    AccumReserveToExitEmployerOnly = EmployerPortAtReview;
                }
                MemberPortAtExit = (MemberContWithInt + AccumReserveToExitMemberOnly);
                EmployerPortAtExit = EmployerContWithInt + AccumReserveToExitEmployerOnly;

                AccumReserveAtExit = Math.Round(MemberPortAtExit + EmployerPortAtExit, 2);

                MemberPortionWithLatePaymentInt = MemberPortAtExit;
                EmployerPortionWithLatePaymentInt = EmployerPortAtExit;

                AccumCreditWithIntAtPaymentdateWithInt = MemberPortionWithLatePaymentInt + EmployerPortionWithLatePaymentInt;

                //Get Minimum Additional Award to calculate Amount of Benefit
                if (CommutationFactorAndMinCom != null)
                {
                    foreach (DataRow row in CommutationFactorAndMinCom.Tables[0].Rows)
                    {
                        BenefitAmount = double.Parse(row["MinimumAdditionalAward"].ToString());
                        MinPensionAllowable = double.Parse(row["MinAnnualPension"].ToString());
                    }
                }
                if (EmployerPortAtExit > BenefitAmount)
                {
                    BenefitAmount = MemberPortAtExit;
                    AdditionalAward = EmployerPortAtExit;
                    EmployerBenefit = 0;
                    MemberBenefit = MemberPortAtExit;
                    BenefitDescription = "REFUND OF MEMBER CONTRIBUTIONS";
                }
                else
                {
                    AdditionalAward = 0;
                    EmployerBenefit = EmployerPortAtExit;
                    MemberBenefit = MemberPortAtExit;
                    BenefitAmount = MemberPortAtExit + EmployerPortAtExit;
                    BenefitDescription = "REFUND OF MEMBER CONTRIBUTIONS PLUS ADDITIONAL AWARD";
                }
                //Get latest Monthly Salary
                if (LatestSalary != null)
                {
                    foreach (DataRow row in LatestSalary.Tables[0].Rows)
                    {
                        LastestSalary = double.Parse(row["Salary"].ToString());
                    }

                }
                AnnualSalary = LastestSalary * 12;
                if (illHealthParameters != null)
                {
                    foreach (DataRow row in illHealthParameters.Tables[0].Rows)
                    {
                        illHealthPerc = double.Parse(row["IHSalaryPerc"].ToString());
                    }

                }

                MinAnnualPension = Math.Round(AnnualSalary * (illHealthPerc / 100), 2);
                CapitalValue = Math.Round(MinAnnualPension * ConversionFactor, 2);

                if (ExitType != "Withdrawal")
                {
                    //Getting Full Annual Pension before Commutation 
                    if (CapitalValue >= AccumReserveAtExit)
                    {
                        FullAnnualPenBeforeComutation = MinAnnualPension;
                    }
                    else
                    {
                        if (ConversionFactor == 0)
                        {
                            FullAnnualPenBeforeComutation = AccumReserveAtExit;
                        }
                        else
                        {
                            FullAnnualPenBeforeComutation = AccumReserveAtExit / ConversionFactor;
                        }

                    }

                    foreach (DataRow row in CommutationFactorAndMinCom.Tables[0].Rows)
                    {
                        CommutationFactor = double.Parse(row["MinCommutation"].ToString()) / 100;
                    }
                    //Get Bal;ance Accumulated Credit/Residual Consideration and Taxfree Commutation
                    TaxFreeCommutation = Math.Round(CommutationFactor * AccumReserveAtExit, 2);
                    BalAccumCredit = Math.Round(AccumReserveAtExit - (CommutationFactor * AccumReserveAtExit), 2);

                    if (MinAnnualPension != 0)
                    {
                        EnhancedResidualConsid = Math.Round(MinAnnualPension * ConversionFactor - TaxFreeCommutation, 2);
                        if (ConversionFactor == 0)
                        {
                            AnnualPenAfterCommutation = Math.Round(BalAccumCredit, 2);
                            EnhancedResidualAnnualPen = Math.Round(EnhancedResidualConsid, 2);
                        }
                        else
                        {
                            AnnualPenAfterCommutation = Math.Round(BalAccumCredit / ConversionFactor, 2);
                            EnhancedResidualAnnualPen = Math.Round(EnhancedResidualConsid / ConversionFactor, 2);
                        }

                    }

                    //get Annual Pension after commutation


                    //get Monthly Pension 
                    MonthlyPension = Math.Round(AnnualPenAfterCommutation / 12, 2);

                    DateTime interestDate = DateTime.Today;
                    if (interestDate.Day >= 15)
                    {
                        interestDate = interestDate.AddDays(16);
                    }

                    if ((MinPensionAllowable < MonthlyPension) || (MinPensionAllowable < Math.Round((EnhancedResidualAnnualPen / 12), 2)))
                    {

                        interestDate = Calculationdate;
                        if (interestDate.Day >= 15)
                        {
                            interestDate = interestDate.AddDays(16);
                        }

                        DataSet x6a = new DataSet();
                        x6a = lp.InterestBasis(int.Parse(txtFundID.Value), interestDate);
                        if (x6a != null)
                        {
                            InterimRates = x6a;
                        }
                        else
                        {
                            InterimRates = null;
                        }
                        TaxfreeCommutationWithint = TaxFreeCommutation;
                        if (InterimRates != null)
                        {
                            foreach (DataRow row in InterimRates.Tables[0].Rows)
                            {
                                if (DateTime.Parse(row["EffectiveDate"].ToString()) >= DateTime.Parse(ExitDate.ToString()))
                                {
                                    RateValue = 0;
                                    if (row["AnnualyOrPart"].ToString() == "A")
                                    {
                                        if (row["SCind"].ToString() == "C")
                                        {
                                            double expVal = Math.Round(double.Parse((1 / 12).ToString()), 6);
                                            RateValue = Math.Pow((1 + double.Parse(row["MonthlyIntRate"].ToString()) / 100), 0.083333);
                                        }
                                        else
                                        {
                                            RateValue = (1 + double.Parse(row["MonthlyIntRate"].ToString()) / 1200);
                                        }
                                    }
                                    else
                                    {
                                        RateValue = (1 + double.Parse(row["MonthlyIntRate"].ToString()) / 100);
                                    }

                                    TaxfreeCommutationWithint = TaxfreeCommutationWithint * RateValue;
                                }
                            }
                        }


                        if (ExitType == "Ill Health Retirement")
                        {
                            if (MonthlyPension > (EnhancedResidualAnnualPen / 12))
                            {
                                EnhancedResidualAnnualPen = MonthlyPension * 12;
                            }
                            PensionArrears = Math.Round((EnhancedResidualAnnualPen / 12) * PensionArrearsPeriod, 2);

                        }
                        else
                        {
                            PensionArrears = Math.Round((AnnualPenAfterCommutation / 12) * PensionArrearsPeriod, 2);
                        }
                    }
                    else
                    {
                        interestDate = Calculationdate;
                        if (interestDate.Day >= 15)
                        {
                            interestDate = interestDate.AddDays(16);
                        }

                        DataSet x6a = new DataSet();
                        x6a = lp.InterestBasis(int.Parse(txtFundID.Value), interestDate);
                        if (x6a != null)
                        {
                            InterimRates = x6a;
                        }
                        else
                        {
                            InterimRates = null;
                        }
                        AccumulationWithInt = Math.Round(AccumReserveAtExit - TaxFreeCommutation, 2);
                        TaxfreeCommutationWithint = TaxFreeCommutation;
                        if (InterimRates != null)
                        {
                            foreach (DataRow row in InterimRates.Tables[0].Rows)
                            {
                                if (DateTime.Parse(row["EffectiveDate"].ToString()) >= interestDate)
                                {
                                    RateValue = 0;
                                    if (row["AnnualyOrPart"].ToString() == "A")
                                    {
                                        if (row["SCind"].ToString() == "C")
                                        {
                                            double expVal = Math.Round(double.Parse((1 / 12).ToString()), 6);
                                            RateValue = Math.Pow((1 + double.Parse(row["MonthlyIntRate"].ToString()) / 100), 0.083333);
                                        }
                                        else
                                        {
                                            RateValue = (1 + double.Parse(row["MonthlyIntRate"].ToString()) / 1200);
                                        }
                                    }
                                    else
                                    {
                                        RateValue = (1 + double.Parse(row["MonthlyIntRate"].ToString()) / 100);
                                    }
                                    AccumulationWithInt = AccumulationWithInt * RateValue;
                                    TaxfreeCommutationWithint = TaxfreeCommutationWithint * RateValue;
                                }
                            }
                        }
                    }
                    DataSet x8 = new DataSet();
                    x8 = lp.TaxTables(AnnualSalary, MemberBenefit, Convert.ToDateTime(ExitDate));
                    if (x8 != null)
                    {
                        TaxTable = x8;
                    }
                    else
                    {
                        TaxTable = null;
                    }

                    if (TaxTable != null)
                    {
                        foreach (DataRow row in TaxTable.Tables[0].Rows)
                        {
                            MemberBenefitTax = Math.Round(double.Parse(row["BandRate"].ToString()) / 100, 2) * MemberBenefit;
                            AdditionalAwardTax = Math.Round(double.Parse(row["BandRate"].ToString()) / 100, 2) * EmployerBenefit;
                        }

                    }
                }
                //insert in temp table
                //DateTime pensiondate = DateTime.Now;



                //Model.Fund f = new Model.Fund("cn", 1);
                string RegNo = lp.getRegNo(int.Parse(txtFundID.Value));
                //Model.Member lp = new Model.Member("cn", 1);

                if (lp.CheckRecordExists(txtNationalID.Text, RegNo, int.Parse(txtMemberID.Value)))
                {
                    //update table
                    myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                    cmd = new SqlCommand("Delete from FundExitsTemp where IDNumber='" + txtNationalID.Text + "' and RegNo='" + RegNo + "' and MemberID ='" + int.Parse(txtMemberID.Value) + "' ", myConnection);
                    if ((myConnection.State == ConnectionState.Open))
                        myConnection.Close();
                    myConnection.Open();
                    cmd.ExecuteNonQuery();
                    myConnection.Close();

                    FundExitsTemp pp = new FundExitsTemp();
                    pp.RegNo = RegNo;
                    pp.MemberID = int.Parse(txtMemberID.Value);
                    pp.FirstName = txtFirstnames.Text + " " + txtSurname.Text;
                    pp.LastName = txtSurname.Text;
                    pp.IDNumber = txtNationalID.Text;
                    pp.Gender = txtGender.Text;
                    DateTime DOB = Convert.ToDateTime(txtDob.Text);
                    DateTime DJF = Convert.ToDateTime(txtDJF.Text);
                    DateTime CalculationDate = Convert.ToDateTime(txtCalDate.Text);
                    DateTime ExitDates = Convert.ToDateTime(txtExitDate.Text);
                    DateTime BonusDate = Convert.ToDateTime(Lastbonusdate);
                    string DOBs = DOB.ToString("yyyy-MM-dd");
                    string DJFs = DJF.ToString("yyyy-MM-dd");
                    string CalculationDates = CalculationDate.ToString("yyyy-MM-dd");
                    string ExitDatess = ExitDates.ToString("yyyy-MM-dd");
                    string BonusDates = BonusDate.ToString("yyyy-MM-dd");

                    pp.DOB = Convert.ToDateTime(DOBs);
                    pp.DJF = Convert.ToDateTime(DJFs);
                    pp.CalculationDate = Convert.ToDateTime(CalculationDates);
                    pp.ExitDate = Convert.ToDateTime(ExitDatess);
                    DateTime pensiondate = Convert.ToDateTime(ExitDatess).AddMonths(1);
                    var PensionCommencementDate = new DateTime(pensiondate.Year, pensiondate.Month, 1);
                    pp.AnualSalary = AnnualSalary;
                    pp.BonusDate = Convert.ToDateTime(BonusDates);
                    pp.PensionCommencementDate = PensionCommencementDate;
                    pp.PeriodAfterExit = Convert.ToInt32(PensionArrearsPeriod);
                    pp.TotalPensionableService = Convert.ToDecimal(PensionableService);
                    pp.MemberPortAtBonusDate = Convert.ToDecimal(MemberPortAtReview);
                    pp.EmployerPortAtBonusDate = Convert.ToDecimal(EmployerPortAtReview);
                    pp.MemberContSinceLastReviewWithoutInt = Convert.ToDecimal(MemberContWithoutInt);
                    pp.EmployerContSinceLastReviewWithoutInt = Convert.ToDecimal(EmployerContWithoutInt);
                    pp.MemberContSinceLastReviewWithInt = Convert.ToDecimal(MemberContWithInt);
                    pp.EmployerContSinceLastReviewWithInt = Convert.ToDecimal(EmployerContWithInt);
                    pp.MemberPortAtExitDate = Convert.ToDecimal(MemberPortAtExit);
                    pp.EmployerPortAtExitDate = Convert.ToDecimal(EmployerPortAtExit);
                    pp.AccumAtReview = pp.MemberPortAtBonusDate + pp.EmployerPortAtBonusDate;
                    pp.AccumAtExit = pp.MemberPortAtExitDate + pp.EmployerPortAtExitDate;
                    pp.AccumAtPayment = pp.AccumAtExit;
                    pp.ExitCode = int.Parse(ExitCode);
                    pp.Third_Commutation = Convert.ToDecimal(TaxFreeCommutation);
                    pp.ThirdComutationWithIntrest = pp.Third_Commutation;
                    pp.MemberAge = Convert.ToInt32(Age);
                    pp.ResidualConsideration = Convert.ToDecimal(BalAccumCredit);
                    pp.ConversionFactor = Convert.ToDecimal(ConversionFactor);
                    pp.AnnualPension = Convert.ToDecimal(AnnualPenAfterCommutation);
                    pp.MonthlyPension = Convert.ToDecimal(AnnualPenAfterCommutation);
                    pp.MiAnnualPension = Convert.ToDecimal(MinPensionAllowable);
                    pp.CapitalValue = Convert.ToDecimal(CapitalValue);
                    pp.EnhMonthlyP = Convert.ToDecimal(EnhancedResidualAnnualPen / 12);
                    pp.EnhResAnnualP = Convert.ToDecimal(EnhancedResidualAnnualPen);
                    pp.Exit_Type = ExitType;
                    pp.Platform = "Portal";
                    db.FundExitsTemps.Add(pp);
                    db.SaveChanges();

                }
                else
                {
                    //insert

                    FundExitsTemp pp = new FundExitsTemp();
                    pp.RegNo = RegNo;
                    pp.MemberID = int.Parse(txtMemberID.Value);
                    pp.FirstName = txtFirstnames.Text + " " + txtSurname.Text;
                    pp.LastName = txtSurname.Text;
                    pp.IDNumber = txtNationalID.Text;
                    pp.Gender = txtGender.Text;
                    DateTime DOB = Convert.ToDateTime(txtDob.Text);
                    DateTime DJF = Convert.ToDateTime(txtDJF.Text);
                    DateTime CalculationDate = Convert.ToDateTime(txtCalDate.Text);
                    DateTime ExitDates = Convert.ToDateTime(txtExitDate.Text);
                    DateTime BonusDate = Convert.ToDateTime(Lastbonusdate);
                    string DOBs = DOB.ToString("yyyy-MM-dd");
                    string DJFs = DJF.ToString("yyyy-MM-dd");
                    string CalculationDates = CalculationDate.ToString("yyyy-MM-dd");
                    string ExitDatess = ExitDates.ToString("yyyy-MM-dd");
                    string BonusDates = BonusDate.ToString("yyyy-MM-dd");
                    //pp.Gender = txtGender.Text;
                    pp.DOB = Convert.ToDateTime(DOBs);
                    pp.DJF = Convert.ToDateTime(DJFs);
                    DateTime pensiondate = Convert.ToDateTime(ExitDatess).AddMonths(1);
                    var PensionCommencementDate = new DateTime(pensiondate.Year, pensiondate.Month, 1);
                    pp.PensionCommencementDate = PensionCommencementDate;
                    pp.CalculationDate = Convert.ToDateTime(CalculationDates);
                    pp.ExitDate = Convert.ToDateTime(ExitDatess);
                    pp.AnualSalary = AnnualSalary;
                    pp.BonusDate = Convert.ToDateTime(BonusDates);
                    pp.TotalPensionableService = Convert.ToDecimal(PensionableService);
                    pp.MemberPortAtBonusDate = Convert.ToDecimal(MemberPortAtReview);
                    pp.EmployerPortAtBonusDate = Convert.ToDecimal(EmployerPortAtReview);
                    pp.MemberContSinceLastReviewWithoutInt = Convert.ToDecimal(MemberContWithoutInt);
                    pp.EmployerContSinceLastReviewWithoutInt = Convert.ToDecimal(EmployerContWithoutInt);
                    pp.MemberContSinceLastReviewWithInt = Convert.ToDecimal(MemberContWithInt);
                    pp.EmployerContSinceLastReviewWithInt = Convert.ToDecimal(EmployerContWithInt);
                    pp.MemberPortAtExitDate = Convert.ToDecimal(MemberPortAtExit);
                    pp.EmployerPortAtExitDate = Convert.ToDecimal(EmployerPortAtExit);
                    pp.AccumAtReview = pp.MemberPortAtBonusDate + pp.EmployerPortAtBonusDate;
                    pp.AccumAtExit = pp.MemberPortAtExitDate + pp.EmployerPortAtExitDate;
                    pp.AccumAtPayment = pp.AccumAtExit;
                    pp.ExitCode = int.Parse(ExitCode);
                    pp.PeriodAfterExit = Convert.ToInt32(PensionArrearsPeriod);
                    pp.Third_Commutation = Convert.ToDecimal(TaxFreeCommutation);
                    pp.ThirdComutationWithIntrest = pp.Third_Commutation;
                    pp.MemberAge = Convert.ToInt32(Age);
                    pp.ResidualConsideration = Convert.ToDecimal(BalAccumCredit);
                    pp.ConversionFactor = Convert.ToDecimal(ConversionFactor);
                    pp.AnnualPension = Convert.ToDecimal(AnnualPenAfterCommutation);
                    pp.MonthlyPension = Convert.ToDecimal(AnnualPenAfterCommutation / 12);
                    pp.MiAnnualPension = Convert.ToDecimal(MinPensionAllowable);
                    pp.CapitalValue = Convert.ToDecimal(CapitalValue);
                    pp.EnhMonthlyP = Convert.ToDecimal(EnhancedResidualAnnualPen / 12);
                    pp.EnhResAnnualP = Convert.ToDecimal(EnhancedResidualAnnualPen);
                    pp.Exit_Type = Exitype;
                    pp.Platform = "Portal";
                    db.FundExitsTemps.Add(pp);
                    db.SaveChanges();


                }

                UpdateMemberDetailsTable(ExitType);
            }

            catch (Exception ex)
            {
                RedAlert(ex.Message);
            }

        }
        protected void withdrawalcalculation(string nationalid, DateTime Lastbonusdate, string Exitype, string ExitDate, DateTime Calculationdate, int refnumber, double CommutationFactor = 0)
        {
            try
            {
                //string CalType = "N";
                DataSet generalds = new DataSet();
                DataSet DS = new DataSet();
                LookUp lp = new LookUp("cn", 1);
                // Fill Working Data Sets
                DataSet x = new DataSet();
                x = lp.MemberStartupValues(int.Parse(txtFundID.Value), refnumber, Lastbonusdate, txtCalType.Value);
                if (x != null)
                {
                    LastBonus = x;
                }
                else
                {
                    LastBonus = null;
                }
                DataSet x1 = new DataSet();
                DataSet x9 = new DataSet();

                //get ContributiosWithoutInt
                x1 = lp.MemberContributionsAfterReview(int.Parse(txtFundID.Value), refnumber, Lastbonusdate, DateTime.Parse(ExitDate.ToString()), txtCalType.Value);
                if (x1 != null)
                {
                    ContributionsWithoutInt = x1;
                }
                else
                {
                    ContributionsWithoutInt = null;
                }

                //get ContributiosWithoutInt
                x9 = lp.MemberContributionsAfterReview(int.Parse(txtFundID.Value), refnumber, Lastbonusdate, DateTime.Parse(ExitDate.ToString()), txtCalType.Value);
                if (x9 != null)
                {
                    ContributionsAfterDeclaration = x9;
                }
                else
                {
                    ContributionsAfterDeclaration = null;
                }
                DataSet x2 = null;
                x2 = lp.InterestBasis(int.Parse(txtFundID.Value), DateTime.Parse(ExitDate.ToString()));
                if (x2 != null)
                {
                    dtInterests = x2;

                }
                else
                {
                    dtInterests = null;
                }

                if (x2 != null)
                {
                    foreach (DataRow rwInt in x2.Tables[0].Rows)
                    {
                        if (rwInt["AnnualyorPart"].ToString() == "A")
                        {
                            if (rwInt["SCInd"].ToString() == "C")
                            {
                                RateValue = Math.Pow(1 + double.Parse(rwInt["MonthlyIntRate"].ToString()) / 100, 0.083333); //1/12 = 0.083333
                            }
                            else
                            {

                                RateValue = (1 + double.Parse(rwInt["MonthlyIntRate"].ToString()) / 1200);
                            }
                        }
                        else
                        {
                            RateValue = (1 + double.Parse(rwInt["MonthlyIntRate"].ToString()) / 100);
                        }

                        if (ContributionsAfterDeclaration != null)
                        {
                            foreach (DataRow rwCntAD in ContributionsAfterDeclaration.Tables[0].Rows)
                            {
                                if (DateTime.Parse(rwCntAD["PaymentDate"].ToString()) < DateTime.Parse(rwInt["EffectiveDate"].ToString()))
                                {
                                    rwCntAD["XContribution"] = double.Parse(rwCntAD["XContribution"].ToString()) * RateValue;
                                    rwCntAD["YContribution"] = double.Parse(rwCntAD["YContribution"].ToString()) * RateValue;
                                    rwCntAD["ZContribution"] = double.Parse(rwCntAD["ZContribution"].ToString()) * RateValue;
                                    rwCntAD["TransferInMember"] = double.Parse(rwCntAD["TransferInMember"].ToString()) * RateValue;
                                    rwCntAD["TransferInEmployer"] = double.Parse(rwCntAD["TransferInEmployer"].ToString()) * RateValue;
                                    rwCntAD["OtherMember"] = double.Parse(rwCntAD["OtherMember"].ToString()) * RateValue;
                                    rwCntAD["OtherEmployer"] = double.Parse(rwCntAD["OtherEmployer"].ToString()) * RateValue;

                                }
                            }
                        }
                    }
                }


                DataSet x3 = new DataSet();
                x3 = lp.MemberLastSalary(int.Parse(txtFundID.Value), refnumber, DateTime.Parse(ExitDate.ToString()), txtCalType.Value);
                if (x3 != null)
                {
                    LatestSalary = x3;
                }
                else
                {
                    LatestSalary = null;
                }
                DataSet x4 = new DataSet();
                x4 = lp.MemberLastBonusWithInterest(int.Parse(txtFundID.Value), refnumber, Lastbonusdate, DateTime.Parse(ExitDate.ToString()), txtCalType.Value);
                if (x4 != null)
                {
                    LastBonusWithInterest = x4;
                }
                else
                {
                    LastBonusWithInterest = null;
                }
                if (x2 != null)
                {
                    foreach (DataRow rwInt in x2.Tables[0].Rows)
                    {
                        if (rwInt["AnnualyorPart"].ToString() == "A")
                        {
                            if (rwInt["SCInd"].ToString() == "C")
                            {
                                RateValue = Math.Pow(1 + double.Parse(rwInt["MonthlyIntRate"].ToString()) / 100, 0.083333); //1/12 = 0.083333
                            }
                            else
                            {

                                RateValue = (1 + double.Parse(rwInt["MonthlyIntRate"].ToString()) / 1200);
                            }
                        }
                        else
                        {
                            RateValue = (1 + double.Parse(rwInt["MonthlyIntRate"].ToString()) / 100);
                        }

                        if (LastBonusWithInterest != null)
                        {
                            foreach (DataRow rwCntAD in LastBonusWithInterest.Tables[0].Rows)
                            {
                                if (DateTime.Parse(rwCntAD["PaymentDate"].ToString()) < DateTime.Parse(rwInt["EffectiveDate"].ToString()))
                                {
                                    rwCntAD["XContribution"] = double.Parse(rwCntAD["XContribution"].ToString()) * RateValue;
                                    rwCntAD["YContribution"] = double.Parse(rwCntAD["YContribution"].ToString()) * RateValue;
                                    rwCntAD["ZContribution"] = double.Parse(rwCntAD["ZContribution"].ToString()) * RateValue;
                                    rwCntAD["TransferInMember"] = double.Parse(rwCntAD["TransferInMember"].ToString()) * RateValue;
                                    rwCntAD["TransferInEmployer"] = double.Parse(rwCntAD["TransferInEmployer"].ToString()) * RateValue;
                                    rwCntAD["OtherMember"] = double.Parse(rwCntAD["OtherMember"].ToString()) * RateValue;
                                    rwCntAD["OtherEmployer"] = double.Parse(rwCntAD["OtherEmployer"].ToString()) * RateValue;
                                }
                            }
                        }
                    }
                }

                DataSet x5 = new DataSet();
                x5 = lp.StatutoryRequirements(int.Parse(txtFundID.Value), LastBonusDate);
                if (x5 != null)
                {
                    CommutationFactorAndMinCom = x5;
                }
                else
                {
                    CommutationFactorAndMinCom = null;
                }

                //Get Last bonus date amount(Accumulated Credit)
                if (LastBonus != null)
                {
                    foreach (DataRow rwLstB in LastBonus.Tables[0].Rows)
                    {
                        AccumReserveAtLastReview = Math.Round(AccumReserveAtLastReview + double.Parse(rwLstB["XContribution"].ToString()) + double.Parse(rwLstB["YContribution"].ToString()) + double.Parse(rwLstB["ZContribution"].ToString()) + double.Parse(rwLstB["TransferInMember"].ToString()) + double.Parse(rwLstB["TransferInEmployer"].ToString()) + double.Parse(rwLstB["OtherMember"].ToString()) + double.Parse(rwLstB["OtherEmployer"].ToString()), 2);
                        MemberPortAtReview = Math.Round(MemberPortAtReview + double.Parse(rwLstB["XContribution"].ToString()) + double.Parse(rwLstB["ZContribution"].ToString()) + double.Parse(rwLstB["TransferInMember"].ToString()) + double.Parse(rwLstB["OtherMember"].ToString()), 2);
                        EmployerPortAtReview = Math.Round(EmployerPortAtReview + double.Parse(rwLstB["YContribution"].ToString()) + double.Parse(rwLstB["TransferInEmployer"].ToString()) + double.Parse(rwLstB["OtherEmployer"].ToString()), 2);
                    }

                }

                //Get Contributions without interest since last bonus date
                if (ContributionsWithoutInt != null)
                {
                    foreach (DataRow rwLstB in ContributionsWithoutInt.Tables[0].Rows)
                    {
                        MemberContWithoutInt = Math.Round(MemberContWithoutInt + double.Parse(rwLstB["XContribution"].ToString()) + double.Parse(rwLstB["ZContribution"].ToString()) + double.Parse(rwLstB["TransferInMember"].ToString()) + double.Parse(rwLstB["OtherMember"].ToString()), 2);
                        EmployerContWithoutInt = Math.Round(EmployerContWithoutInt + double.Parse(rwLstB["YContribution"].ToString()) + double.Parse(rwLstB["TransferInEmployer"].ToString()) + double.Parse(rwLstB["OtherEmployer"].ToString()), 2);
                    }
                }


                //Get employer and member contributions after bonus date including interest 
                if (ContributionsAfterDeclaration != null)
                {
                    foreach (DataRow rwLstB in ContributionsAfterDeclaration.Tables[0].Rows)
                    {
                        MemberContWithInt = Math.Round(MemberContWithInt + double.Parse(rwLstB["XContribution"].ToString()) + double.Parse(rwLstB["ZContribution"].ToString()) + double.Parse(rwLstB["TransferInMember"].ToString()) + double.Parse(rwLstB["OtherMember"].ToString()), 2);
                        EmployerContWithInt = Math.Round(EmployerContWithInt + double.Parse(rwLstB["YContribution"].ToString()) + double.Parse(rwLstB["TransferInEmployer"].ToString()) + double.Parse(rwLstB["OtherEmployer"].ToString()), 2);
                    }
                }

                //get accumulated credit at bonus date updated with interest
                if (LastBonusWithInterest != null)
                {
                    foreach (DataRow rwLstB in LastBonusWithInterest.Tables[0].Rows)
                    {
                        AccumReserveToExit = Math.Round(AccumReserveToExit + double.Parse(rwLstB["XContribution"].ToString()) + double.Parse(rwLstB["YContribution"].ToString()) + double.Parse(rwLstB["ZContribution"].ToString()) + double.Parse(rwLstB["TransferInMember"].ToString()) + double.Parse(rwLstB["TransferInEmployer"].ToString()) + double.Parse(rwLstB["OtherMember"].ToString()) + double.Parse(rwLstB["OtherEmployer"].ToString()), 2);
                        AccumReserveToExitMemberOnly = Math.Round(AccumReserveToExitMemberOnly + double.Parse(rwLstB["XContribution"].ToString()) + double.Parse(rwLstB["ZContribution"].ToString()) + double.Parse(rwLstB["TransferInMember"].ToString()) + double.Parse(rwLstB["OtherMember"].ToString()), 2);
                        AccumReserveToExitEmployerOnly = Math.Round(AccumReserveToExitEmployerOnly + double.Parse(rwLstB["YContribution"].ToString()) + double.Parse(rwLstB["TransferInEmployer"].ToString()) + double.Parse(rwLstB["OtherEmployer"].ToString()), 2);
                    }
                }
                if (AccumReserveToExitMemberOnly == 0)
                {
                    AccumReserveToExitMemberOnly = MemberPortAtReview;
                }
                if (AccumReserveToExitEmployerOnly == 0)
                {
                    AccumReserveToExitEmployerOnly = EmployerPortAtReview;
                }
                MemberPortAtExit = Math.Round(MemberContWithInt + AccumReserveToExitMemberOnly, 2);
                EmployerPortAtExit = Math.Round(EmployerContWithInt + AccumReserveToExitEmployerOnly, 2);

                AccumReserveAtExit = Math.Round(MemberPortAtExit + EmployerPortAtExit, 2);


                DateTime interestDate = DateTime.Today;
                if (interestDate.Day >= 15)
                {
                    interestDate = interestDate.AddDays(16);
                }

                DataSet x6 = new DataSet();
                x6 = lp.InterestBasis(int.Parse(txtFundID.Value), interestDate);
                if (x6 != null)
                {
                    InterimRates = x6;
                }
                else
                {
                    InterimRates = null;
                }

                MemberPortionWithLatePaymentInt = MemberPortAtExit;
                EmployerPortionWithLatePaymentInt = EmployerPortAtExit;

                if (InterimRates != null)
                {
                    foreach (DataRow row in InterimRates.Tables[0].Rows)
                    {
                        if (DateTime.Parse(row["EffectiveDate"].ToString()) >= Convert.ToDateTime(ExitDate))
                        {
                            RateValue = 0;
                            if (row["AnnualyorPart"].ToString() == "A")
                            {
                                if (row["SCind"].ToString() == "C")
                                {
                                    RateValue = Math.Pow(1 + double.Parse(row["MonthlyIntRate"].ToString()) / 100, 0.083333); //1/12 = 0.083333
                                }
                                else
                                {
                                    RateValue = (1 + double.Parse(row["MonthlyIntRate"].ToString()) / 1200);
                                }
                            }
                            else
                            {
                                RateValue = (1 + double.Parse(row["MonthlyIntRate"].ToString()) / 100);
                            }

                            MemberPortionWithLatePaymentInt = Math.Round(MemberPortionWithLatePaymentInt * RateValue, 2);
                            EmployerPortionWithLatePaymentInt = Math.Round(EmployerPortionWithLatePaymentInt * RateValue, 2);
                        }
                    }
                }

                AccumCreditWithIntAtPaymentdateWithInt = MemberPortionWithLatePaymentInt + EmployerPortionWithLatePaymentInt;
                //Get Minimum Additional Award to calculate Amount of Benefit
                if (CommutationFactorAndMinCom != null)
                {
                    foreach (DataRow row in CommutationFactorAndMinCom.Tables[0].Rows)
                    {
                        BenefitAmount = double.Parse(row["MinimumAdditionalAward"].ToString());
                        MinPensionAllowable = double.Parse(row["MinAnnualPension"].ToString());
                    }
                }

                if (EmployerPortionWithLatePaymentInt > BenefitAmount)
                {
                    BenefitAmount = MemberPortionWithLatePaymentInt;
                    AdditionalAward = EmployerPortionWithLatePaymentInt;
                    EmployerBenefit = 0;
                    MemberBenefit = MemberPortionWithLatePaymentInt;
                    BenefitDescription = "REFUND OF MEMBER CONTRIBUTIONS";
                }
                else
                {
                    AdditionalAward = 0;
                    EmployerBenefit = EmployerPortionWithLatePaymentInt;
                    MemberBenefit = MemberPortionWithLatePaymentInt;
                    BenefitAmount = MemberPortionWithLatePaymentInt + EmployerPortionWithLatePaymentInt;
                    BenefitDescription = "REFUND OF MEMBER CONTRIBUTIONS PLUS ADDITIONAL AWARD";
                }
                //Get latest Monthly Salary
                if (LatestSalary != null)
                {
                    foreach (DataRow row in LatestSalary.Tables[0].Rows)
                    {
                        LastestSalary = double.Parse(row["Salary"].ToString());
                    }

                }

                AnnualSalary = LastestSalary * 12;
                DataSet x5A = new DataSet();
                x5A = lp.RetirementillHealthParameters(int.Parse(txtFundID.Value), ExitMemberCategory, Convert.ToDateTime(ExitDate));
                if (x5A != null)
                {
                    illHealthParameters = x5A;
                }
                else
                {
                    illHealthParameters = null;
                }
                if (illHealthParameters != null)
                {
                    foreach (DataRow row in illHealthParameters.Tables[0].Rows)
                    {
                        illHealthPerc = double.Parse(row["IHSalaryPerc"].ToString());
                    }

                }

                DataSet x7 = new DataSet();
                x7 = lp.MemberContributionsCummulativeSalary(refnumber, Convert.ToDateTime(ExitDate));
                if (x7 != null)
                {
                    CummSalary = x7;
                }
                else
                {
                    CummSalary = null;

                }

                double CummulativeSalary = 0;
                if (CummSalary != null)
                {
                    foreach (DataRow row in CummSalary.Tables[0].Rows)
                    {
                        if (double.TryParse(row["CummulativeSalary"].ToString(), out double cx))
                        {
                            CummulativeSalary = double.Parse(row["CummulativeSalary"].ToString());
                        }
                        else
                        {
                            row["CummulativeSalary"] = 0;
                        }
                    }
                }


                MinAnnualPension = Math.Round(AnnualSalary * (illHealthPerc / 100), 2);
                CapitalValue = Math.Round(MinAnnualPension * ConversionFactor, 2);
                //Getting Full Annual Pension before Commutation 
                if (CapitalValue >= AccumReserveAtExit)
                {
                    FullAnnualPenBeforeComutation = MinAnnualPension;
                }
                else
                {
                    if (ConversionFactor == 0)
                    {
                        FullAnnualPenBeforeComutation = AccumReserveAtExit;
                    }
                    else
                    {
                        FullAnnualPenBeforeComutation = AccumReserveAtExit / ConversionFactor;
                    }

                }

                if (CommutationFactorAndMinCom != null)
                {
                    foreach (DataRow row in CommutationFactorAndMinCom.Tables[0].Rows)
                    {
                        CommutationFactor = double.Parse(row["MinCommutation"].ToString()) / 100;
                    }
                }

                //Get Bal;ance Accumulated Credit/Residual Consideration and Taxfree Commutation
                TaxFreeCommutation = Math.Round(CommutationFactor * AccumReserveAtExit, 2);
                BalAccumCredit = Math.Round(AccumReserveAtExit - (CommutationFactor * AccumReserveAtExit), 2);

                if (MinAnnualPension != 0)
                {
                    EnhancedResidualConsid = Math.Round(MinAnnualPension * ConversionFactor - TaxFreeCommutation, 2);
                    if (ConversionFactor == 0)
                    {
                        AnnualPenAfterCommutation = Math.Round(BalAccumCredit, 2);
                        EnhancedResidualAnnualPen = Math.Round(EnhancedResidualConsid, 2);
                    }
                    else
                    {
                        AnnualPenAfterCommutation = Math.Round(BalAccumCredit / ConversionFactor, 2);
                        EnhancedResidualAnnualPen = Math.Round(EnhancedResidualConsid / ConversionFactor, 2);
                    }

                }

                //get Annual Pension after commutation


                //get Monthly Pension 
                MonthlyPension = Math.Round(AnnualPenAfterCommutation / 12, 2);

                //DateTime interestDate = DateTime.Today;
                if (interestDate.Day >= 15)
                {
                    interestDate = interestDate.AddDays(16);
                }

                if ((MinPensionAllowable < MonthlyPension) || (MinPensionAllowable < Math.Round((EnhancedResidualAnnualPen / 12), 2)))
                {

                    interestDate = Calculationdate;
                    if (interestDate.Day >= 15)
                    {
                        interestDate = interestDate.AddDays(16);
                    }

                    DataSet x6a = new DataSet();
                    x6a = lp.InterestBasis(int.Parse(txtFundID.Value), interestDate);
                    if (x6a != null)
                    {
                        InterimRates = x6a;
                    }
                    else
                    {
                        InterimRates = null;
                    }
                    TaxfreeCommutationWithint = TaxFreeCommutation;
                    if (InterimRates != null)
                    {
                        foreach (DataRow row in InterimRates.Tables[0].Rows)
                        {
                            if (DateTime.Parse(row["EffectiveDate"].ToString()) >= Convert.ToDateTime(ExitDate))
                            {
                                RateValue = 0;
                                if (row["AnnualyOrPart"].ToString() == "A")
                                {
                                    if (row["SCind"].ToString() == "C")
                                    {
                                        double expVal = Math.Round(double.Parse((1 / 12).ToString()), 6);
                                        RateValue = Math.Pow((1 + double.Parse(row["MonthlyIntRate"].ToString()) / 100), 0.083333);
                                    }
                                    else
                                    {
                                        RateValue = (1 + double.Parse(row["MonthlyIntRate"].ToString()) / 1200);
                                    }
                                }
                                else
                                {
                                    RateValue = (1 + double.Parse(row["MonthlyIntRate"].ToString()) / 100);
                                }

                                TaxfreeCommutationWithint = TaxfreeCommutationWithint * RateValue;
                            }
                        }
                    }


                    if (ExitType == "Ill Health Retirement")
                    {
                        if (MonthlyPension > (EnhancedResidualAnnualPen / 12))
                        {
                            EnhancedResidualAnnualPen = MonthlyPension * 12;
                        }
                        PensionArrears = Math.Round((EnhancedResidualAnnualPen / 12) * PensionArrearsPeriod, 2);

                    }
                    else
                    {
                        PensionArrears = Math.Round((AnnualPenAfterCommutation / 12) * PensionArrearsPeriod, 2);
                    }
                }
                else
                {
                    interestDate = Calculationdate;
                    if (interestDate.Day >= 15)
                    {
                        interestDate = interestDate.AddDays(16);
                    }

                    DataSet x6a = new DataSet();
                    x6a = lp.InterestBasis(int.Parse(txtFundID.Value), interestDate);
                    if (x6a != null)
                    {
                        InterimRates = x6a;
                    }
                    else
                    {
                        InterimRates = null;
                    }
                    AccumulationWithInt = Math.Round(AccumReserveAtExit - TaxFreeCommutation, 2);
                    TaxfreeCommutationWithint = TaxFreeCommutation;
                    if (InterimRates != null)
                    {
                        foreach (DataRow row in InterimRates.Tables[0].Rows)
                        {
                            if (DateTime.Parse(row["EffectiveDate"].ToString()) >= interestDate)
                            {
                                RateValue = 0;
                                if (row["AnnualyOrPart"].ToString() == "A")
                                {
                                    if (row["SCind"].ToString() == "C")
                                    {
                                        double expVal = Math.Round(double.Parse((1 / 12).ToString()), 6);
                                        RateValue = Math.Pow((1 + double.Parse(row["MonthlyIntRate"].ToString()) / 100), 0.083333);
                                    }
                                    else
                                    {
                                        RateValue = (1 + double.Parse(row["MonthlyIntRate"].ToString()) / 1200);
                                    }
                                }
                                else
                                {
                                    RateValue = (1 + double.Parse(row["MonthlyIntRate"].ToString()) / 100);
                                }
                                AccumulationWithInt = AccumulationWithInt * RateValue;
                                TaxfreeCommutationWithint = TaxfreeCommutationWithint * RateValue;
                            }
                        }
                    }

                    DataSet x8 = new DataSet();
                    x8 = lp.TaxTables(AnnualSalary, MemberBenefit, Convert.ToDateTime(ExitDate));
                    if (x8 != null)
                    {
                        TaxTable = x8;
                    }
                    else
                    {
                        TaxTable = null;
                    }

                    if (TaxTable != null)
                    {
                        foreach (DataRow row in TaxTable.Tables[0].Rows)
                        {
                            MemberBenefitTax = Math.Round(double.Parse(row["BandRate"].ToString()) / 100, 2) * MemberBenefit;
                            AdditionalAwardTax = Math.Round(double.Parse(row["BandRate"].ToString()) / 100, 2) * EmployerBenefit;
                        }

                    }
                }
                //Model.Fund f = new Model.Fund("cn", 1);
                string RegNo = lp.getRegNo(int.Parse(txtFundID.Value));

                if (txtCalType.Value == "N")
                {
                    //insert in temp table
                    if (lp.CheckRecordExists(txtNationalID.Text, RegNo, int.Parse(txtMemberID.Value)))
                    {
                        //update table
                        myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                        cmd = new SqlCommand("Delete from FundExitsTemp where IDNumber='" + txtNationalID.Text + "' and RegNo='" + RegNo + "' and MemberID ='" + int.Parse(txtMemberID.Value) + "' ", myConnection);
                        if ((myConnection.State == ConnectionState.Open))
                            myConnection.Close();
                        myConnection.Open();
                        cmd.ExecuteNonQuery();
                        myConnection.Close();

                        FundExitsTemp pp = new FundExitsTemp();
                        pp.RegNo = RegNo;
                        pp.MemberID = int.Parse(txtMemberID.Value);
                        pp.FirstName = txtFirstnames.Text + " " + txtSurname.Text;
                        pp.LastName = txtSurname.Text;
                        pp.IDNumber = txtNationalID.Text;
                        pp.Gender = txtGender.Text;
                        DateTime DOB = Convert.ToDateTime(txtDob.Text);
                        DateTime DJF = Convert.ToDateTime(txtDJF.Text);
                        DateTime CalculationDate = Convert.ToDateTime(txtCalDate.Text);
                        DateTime ExitDates = Convert.ToDateTime(txtExitDate.Text);
                        DateTime BonusDate = Convert.ToDateTime(Lastbonusdate);
                        string DOBs = DOB.ToString("yyyy-MM-dd");
                        string DJFs = DJF.ToString("yyyy-MM-dd");
                        string CalculationDates = CalculationDate.ToString("yyyy-MM-dd");
                        string ExitDatess = ExitDates.ToString("yyyy-MM-dd");
                        string BonusDates = BonusDate.ToString("yyyy-MM-dd");
                        pp.DOB = Convert.ToDateTime(DOBs);
                        pp.DJF = Convert.ToDateTime(DJFs);
                        pp.CalculationDate = Convert.ToDateTime(CalculationDates);
                        pp.ExitDate = Convert.ToDateTime(ExitDatess);
                        pp.AnualSalary = AnnualSalary;
                        pp.BonusDate = Convert.ToDateTime(BonusDates);
                        pp.Exit_Type = "Withdrawal";
                        pp.TotalPensionableService = Convert.ToDecimal(PensionableService);
                        pp.MemberPortAtBonusDate = Convert.ToDecimal(MemberPortAtReview);
                        pp.EmployerPortAtBonusDate = Convert.ToDecimal(EmployerPortAtReview);
                        pp.MemberContSinceLastReviewWithoutInt = Convert.ToDecimal(MemberContWithoutInt);
                        pp.EmployerContSinceLastReviewWithoutInt = Convert.ToDecimal(EmployerContWithoutInt);
                        pp.MemberContSinceLastReviewWithInt = Convert.ToDecimal(MemberContWithInt);
                        pp.EmployerContSinceLastReviewWithInt = Convert.ToDecimal(EmployerContWithInt);
                        pp.MemberPortAtExitDate = Convert.ToDecimal(MemberPortAtExit);
                        pp.EmployerPortAtExitDate = Convert.ToDecimal(EmployerPortAtExit);
                        pp.AccumAtReview = pp.MemberPortAtBonusDate + pp.EmployerPortAtBonusDate;
                        pp.AccumAtExit = pp.MemberPortAtExitDate + pp.EmployerPortAtExitDate;
                        pp.AccumAtPayment = pp.AccumAtExit;
                        pp.ExitCode = int.Parse(ExitCode);
                        pp.Platform = "Portal";
                        db.FundExitsTemps.Add(pp);
                        db.SaveChanges();
                    }
                    else
                    {
                        //insert
                        FundExitsTemp pp = new FundExitsTemp();
                        pp.RegNo = RegNo;
                        pp.MemberID = int.Parse(txtMemberID.Value);
                        pp.FirstName = txtFirstnames.Text + " " + txtSurname.Text;
                        pp.LastName = txtSurname.Text;
                        pp.IDNumber = txtNationalID.Text;
                        DateTime DOB = Convert.ToDateTime(txtDob.Text);
                        DateTime DJF = Convert.ToDateTime(txtDJF.Text);
                        DateTime CalculationDate = Convert.ToDateTime(txtCalDate.Text);
                        DateTime ExitDates = Convert.ToDateTime(txtExitDate.Text);
                        DateTime BonusDate = Convert.ToDateTime(Lastbonusdate);
                        string DOBs = DOB.ToString("yyyy-MM-dd");
                        string DJFs = DJF.ToString("yyyy-MM-dd");
                        string CalculationDates = CalculationDate.ToString("yyyy-MM-dd");
                        string ExitDatess = ExitDates.ToString("yyyy-MM-dd");
                        string BonusDates = BonusDate.ToString("yyyy-MM-dd");
                        pp.DOB = Convert.ToDateTime(DOBs);
                        pp.DJF = Convert.ToDateTime(DJFs);
                        pp.CalculationDate = Convert.ToDateTime(CalculationDates);
                        pp.ExitDate = Convert.ToDateTime(ExitDatess);
                        pp.AnualSalary = AnnualSalary;
                        pp.Exit_Type = "Withdrawal";
                        pp.BonusDate = Convert.ToDateTime(BonusDates);
                        pp.TotalPensionableService = Convert.ToDecimal(PensionableService);
                        pp.MemberPortAtBonusDate = Convert.ToDecimal(MemberPortAtReview);
                        pp.EmployerPortAtBonusDate = Convert.ToDecimal(EmployerPortAtReview);
                        pp.MemberContSinceLastReviewWithoutInt = Convert.ToDecimal(MemberContWithoutInt);
                        pp.EmployerContSinceLastReviewWithoutInt = Convert.ToDecimal(EmployerContWithoutInt);
                        pp.MemberContSinceLastReviewWithInt = Convert.ToDecimal(MemberContWithInt);
                        pp.EmployerContSinceLastReviewWithInt = Convert.ToDecimal(EmployerContWithInt);
                        pp.MemberPortAtExitDate = Convert.ToDecimal(MemberPortAtExit);
                        pp.EmployerPortAtExitDate = Convert.ToDecimal(EmployerPortAtExit);
                        pp.AccumAtReview = pp.MemberPortAtBonusDate + pp.EmployerPortAtBonusDate;
                        pp.AccumAtExit = pp.MemberPortAtExitDate + pp.EmployerPortAtExitDate;
                        pp.AccumAtPayment = pp.AccumAtExit;
                        pp.ExitCode = int.Parse(ExitCode);
                        pp.Platform = "Portal";
                        db.FundExitsTemps.Add(pp);
                        db.SaveChanges();
                    }
                }

                UpdateMemberDetailsTable(ExitType);
            }
            catch (Exception ex)
            {
                RedAlert(ex.Message);
                //RedAlert(ex.Message);
                var st = new System.Diagnostics.StackTrace(ex, true);
                // Get the top stack frame
                var frame = st.GetFrame(0);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();
                var lineNumber = 0;
                const string lineSearch = ":line ";
                var index = ex.StackTrace.LastIndexOf(lineSearch);
                if (index != -1)
                {
                    var lineNumberText = ex.StackTrace.Substring(index + lineSearch.Length);
                    if (int.TryParse(lineNumberText, out lineNumber))
                    {
                    }
                }
            }
        }

        protected void getMemberClaim()
        {
            try
            {
                LookUp g = new LookUp("cn", 1);

                if (g.getEmployeeClaim(int.Parse(txtFundID.Value), int.Parse(txtMemberID.Value)) != null)
                {
                    grdClientsView.DataSource = g.getEmployeeClaim(int.Parse(txtFundID.Value), int.Parse(txtMemberID.Value));
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
        protected void Deathcalculation(string nationalid, DateTime Lastbonusdate, string Exitype, string ExitDate, DateTime CalculationDate, int refnumber, double CommutationFactor = 0)
        {
            try
            {
                //string CalType = "N";
                double AdvancePayment = 0;
                DataSet generalds = new DataSet();
                DataSet DS = new DataSet();
                LookUp lp = new LookUp("cn", 1);
                // Fill Working Data Sets
                DataSet x = new DataSet();
                DataSet y = new DataSet();
                //x = lp.Contributions_Sel_StartupValueMember_ForExits(int.Parse(txtFundID.Value), refnumber, Lastbonusdate,txtCalType.Value);
                x = lp.MemberStartupValues(int.Parse(txtFundID.Value), refnumber, Lastbonusdate, txtCalType.Value);
                if (x != null)
                {
                    LastBonus = x;
                }
                else
                {
                    LastBonus = null;
                }

                DataSet x4 = new DataSet();
                x4 = lp.MemberLastBonusWithInterest(int.Parse(txtFundID.Value), refnumber, Lastbonusdate, DateTime.Parse(ExitDate.ToString()), txtCalType.Value);
                if (x4 != null)
                {
                    LastBonusWithInterest = x4;
                }
                else
                {
                    LastBonusWithInterest = null;
                }


                DataSet x5 = null;
                x5 = lp.InterestBasis(int.Parse(txtFundID.Value), DateTime.Parse(ExitDate.ToString()));
                if (x5 != null)
                {
                    dtInterests = x5;

                }
                else
                {
                    dtInterests = null;
                }
                DateTime MaximumBonusDate = Lastbonusdate;
                DateTime interestDate = DateTime.Today;
                if (interestDate.Day >= 15)
                {
                    interestDate = interestDate.AddDays(16);
                }

                //if (MaximumBonusDate < CalculationDate)
                //{
                //    x5 = lp.InterestBasisAfterBonusDate(int.Parse(txtFundID.Value), MaximumBonusDate, interestDate);
                //    if (x5 != null)
                //    {
                //        dtInterests = x5;

                //    }
                //    else
                //    {
                //        dtInterests = null;
                //    }
                //}


                DataSet x1 = new DataSet();
                DataSet x9 = new DataSet();

                x1 = lp.MemberContributionsAfterReview(int.Parse(txtFundID.Value), refnumber, Lastbonusdate, DateTime.Parse(ExitDate.ToString()), txtCalType.Value);
                if (x1 != null)
                {
                    ContributionsWithoutInt = x1;

                }
                else
                {
                    ContributionsWithoutInt = null;

                }
                x9 = lp.MemberContributionsAfterReview(int.Parse(txtFundID.Value), refnumber, Lastbonusdate, DateTime.Parse(ExitDate.ToString()), txtCalType.Value);
                //get ContributiosWithoutInt
                //x9 = lp.Contributions_Sel_MemberAfterReview_forExits(int.Parse(txtFundID.Value), refnumber, Lastbonusdate, DateTime.Parse(ExitDate.ToString()));
                if (x9 != null)
                {
                    ContributionsAfterDeclaration = x9;
                }
                else
                {
                    ContributionsAfterDeclaration = null;
                }

                DateTime EndDate = Convert.ToDateTime(ExitDate);
                DateTime StartDate = Lastbonusdate;
                double dr = 0;
                DataSet r1 = new DataSet();
                r1 = lp.geteDateDiff(StartDate, EndDate);
                if (r1 != null)
                {
                    foreach (DataRow rwInt in r1.Tables[0].Rows)
                    {
                        dr = double.Parse(rwInt["result"].ToString());
                    }
                }
                if (x5 != null)
                {
                    foreach (DataRow rwInt in x5.Tables[0].Rows)
                    {
                        if (rwInt["AnnualyOrPart"].ToString() == "A")
                        {
                            if (rwInt["SCInd"].ToString() == "C")
                            {
                                RateValue = Math.Pow(1 + double.Parse(rwInt["MonthlyIntRate"].ToString()) / 100, 0.083333); //1/12 = 0.083333
                            }
                            else
                            {

                                RateValue = (1 + double.Parse(rwInt["MonthlyIntRate"].ToString()) / 1200);
                            }
                        }
                        else
                        {
                            RateValue = (1 + double.Parse(rwInt["MonthlyIntRate"].ToString()) / 100);
                        }
                        if (ContributionsAfterDeclaration != null)
                        {
                            foreach (DataRow rwCntAD in ContributionsAfterDeclaration.Tables[0].Rows)
                            {
                                if (DateTime.Parse(rwCntAD["PaymentDate"].ToString()) < DateTime.Parse(rwInt["EffectiveDate"].ToString()))
                                {
                                    rwCntAD["XContribution"] = double.Parse(rwCntAD["XContribution"].ToString()) * RateValue;
                                    rwCntAD["YContribution"] = double.Parse(rwCntAD["YContribution"].ToString()) * RateValue;
                                    rwCntAD["ZContribution"] = double.Parse(rwCntAD["ZContribution"].ToString()) * RateValue;
                                    rwCntAD["TransferInMember"] = double.Parse(rwCntAD["TransferInMember"].ToString()) * RateValue;
                                    rwCntAD["TransferInEmployer"] = double.Parse(rwCntAD["TransferInEmployer"].ToString()) * RateValue;
                                    rwCntAD["OtherMember"] = double.Parse(rwCntAD["OtherMember"].ToString()) * RateValue;
                                    rwCntAD["OtherEmployer"] = double.Parse(rwCntAD["OtherEmployer"].ToString()) * RateValue;
                                }
                            }
                        }

                    }

                }
                if (x5 != null)
                {
                    foreach (DataRow rwInt in x5.Tables[0].Rows)
                    {
                        if (rwInt["AnnualyorPart"].ToString() == "A")
                        {
                            if (rwInt["SCInd"].ToString() == "C")
                            {
                                RateValue = Math.Pow(1 + double.Parse(rwInt["MonthlyIntRate"].ToString()) / 100, 0.083333); //1/12 = 0.083333
                            }
                            else
                            {

                                RateValue = (1 + double.Parse(rwInt["MonthlyIntRate"].ToString()) / 1200);
                            }
                        }
                        else
                        {
                            RateValue = (1 + double.Parse(rwInt["MonthlyIntRate"].ToString()) / 100);
                        }

                        if (LastBonusWithInterest != null)
                        {
                            foreach (DataRow rwCntAD in LastBonusWithInterest.Tables[0].Rows)
                            {
                                if (DateTime.Parse(rwCntAD["PaymentDate"].ToString()) < DateTime.Parse(rwInt["EffectiveDate"].ToString()))
                                {
                                    rwCntAD["XContribution"] = double.Parse(rwCntAD["XContribution"].ToString()) * RateValue;
                                    rwCntAD["YContribution"] = double.Parse(rwCntAD["YContribution"].ToString()) * RateValue;
                                    rwCntAD["ZContribution"] = double.Parse(rwCntAD["ZContribution"].ToString()) * RateValue;
                                    rwCntAD["TransferInMember"] = double.Parse(rwCntAD["TransferInMember"].ToString()) * RateValue;
                                    rwCntAD["TransferInEmployer"] = double.Parse(rwCntAD["TransferInEmployer"].ToString()) * RateValue;
                                    rwCntAD["OtherMember"] = double.Parse(rwCntAD["OtherMember"].ToString()) * RateValue;
                                    rwCntAD["OtherEmployer"] = double.Parse(rwCntAD["OtherEmployer"].ToString()) * RateValue;
                                }
                            }
                        }
                    }

                }
                DataSet x3 = new DataSet();
                x3 = lp.MemberLastSalary(int.Parse(txtFundID.Value), refnumber, DateTime.Parse(ExitDate.ToString()), txtCalType.Value);
                if (x3 != null)
                {
                    LatestSalary = x3;
                }
                else
                {
                    LatestSalary = null;
                }


                DataSet x5B = new DataSet();
                x5B = lp.DeathStatutaryRequirements_Sel_Active(int.Parse(txtFundID.Value), Lastbonusdate);
                if (x5 != null)
                {
                    CommutationFactorAndMinCom = x5B;
                }
                else
                {
                    CommutationFactorAndMinCom = null;
                }

                DataSet x5A = new DataSet();
                x5A = lp.RetirementillHealthParameters(int.Parse(txtFundID.Value), ExitMemberCategory, Convert.ToDateTime(ExitDate));
                if (x5A != null)
                {
                    illHealthParameters = x5A;
                }
                else
                {
                    illHealthParameters = null;
                }

                //Begin Calculations
                //Get Accumulated Credit as at the Last Bonus Date
                if (LastBonus != null)
                {
                    foreach (DataRow rwLstB in LastBonus.Tables[0].Rows)
                    {
                        AccumReserveAtLastReview = Math.Round(AccumReserveAtLastReview + double.Parse(rwLstB["XContribution"].ToString()) + double.Parse(rwLstB["YContribution"].ToString()) + double.Parse(rwLstB["ZContribution"].ToString()) + double.Parse(rwLstB["TransferInMember"].ToString()) + double.Parse(rwLstB["TransferInEmployer"].ToString()) + double.Parse(rwLstB["OtherMember"].ToString()) + double.Parse(rwLstB["OtherEmployer"].ToString()), 2);
                        MemberPortAtReview = Math.Round(MemberPortAtReview + double.Parse(rwLstB["XContribution"].ToString()) + double.Parse(rwLstB["ZContribution"].ToString()) + double.Parse(rwLstB["TransferInMember"].ToString()) + double.Parse(rwLstB["OtherMember"].ToString()), 2);
                        EmployerPortAtReview = Math.Round(EmployerPortAtReview + double.Parse(rwLstB["YContribution"].ToString()) + double.Parse(rwLstB["TransferInEmployer"].ToString()) + double.Parse(rwLstB["OtherEmployer"].ToString()), 2);
                    }

                }

                //Get Contributions without interest since last bonus date
                if (ContributionsWithoutInt != null)
                {
                    foreach (DataRow rwLstB in ContributionsWithoutInt.Tables[0].Rows)
                    {
                        MemberContWithoutInt = Math.Round(MemberContWithoutInt + double.Parse(rwLstB["XContribution"].ToString()) + double.Parse(rwLstB["ZContribution"].ToString()) + double.Parse(rwLstB["TransferInMember"].ToString()) + double.Parse(rwLstB["OtherMember"].ToString()), 2);
                        EmployerContWithoutInt = Math.Round(EmployerContWithoutInt + double.Parse(rwLstB["YContribution"].ToString()) + double.Parse(rwLstB["TransferInEmployer"].ToString()) + double.Parse(rwLstB["OtherEmployer"].ToString()), 2);
                    }
                }


                //Get employer and member contributions after bonus date including interest 
                if (ContributionsAfterDeclaration != null)
                {

                    foreach (DataRow rwLstB in ContributionsAfterDeclaration.Tables[0].Rows)
                    {
                        MemberContWithInt = Math.Round(MemberContWithInt + double.Parse(rwLstB["XContribution"].ToString()) + double.Parse(rwLstB["ZContribution"].ToString()) + double.Parse(rwLstB["TransferInMember"].ToString()) + double.Parse(rwLstB["OtherMember"].ToString()), 2);
                        EmployerContWithInt = Math.Round(EmployerContWithInt + double.Parse(rwLstB["YContribution"].ToString()) + double.Parse(rwLstB["TransferInEmployer"].ToString()) + double.Parse(rwLstB["OtherEmployer"].ToString()), 2);
                    }
                }

                //get accumulated credit at bonus date updated with interest
                if (LastBonusWithInterest != null)
                {
                    foreach (DataRow rwLstB in LastBonusWithInterest.Tables[0].Rows)
                    {
                        AccumReserveToExit = Math.Round(AccumReserveToExit + double.Parse(rwLstB["XContribution"].ToString()) + double.Parse(rwLstB["YContribution"].ToString()) + double.Parse(rwLstB["ZContribution"].ToString()) + double.Parse(rwLstB["TransferInMember"].ToString()) + double.Parse(rwLstB["TransferInEmployer"].ToString()) + double.Parse(rwLstB["OtherMember"].ToString()) + double.Parse(rwLstB["OtherEmployer"].ToString()), 2);
                        AccumReserveToExitMemberOnly = Math.Round(AccumReserveToExitMemberOnly + double.Parse(rwLstB["XContribution"].ToString()) + double.Parse(rwLstB["ZContribution"].ToString()) + double.Parse(rwLstB["TransferInMember"].ToString()) + double.Parse(rwLstB["OtherMember"].ToString()), 2);
                        AccumReserveToExitEmployerOnly = Math.Round(AccumReserveToExitEmployerOnly + double.Parse(rwLstB["YContribution"].ToString()) + double.Parse(rwLstB["TransferInEmployer"].ToString()) + double.Parse(rwLstB["OtherEmployer"].ToString()), 2);
                    }
                }
                if (AccumReserveToExitMemberOnly == 0)
                {
                    AccumReserveToExitMemberOnly = MemberPortAtReview;
                }
                if (AccumReserveToExitEmployerOnly == 0)
                {
                    AccumReserveToExitEmployerOnly = EmployerPortAtReview;
                }

                MemberPortAtExit = (MemberContWithInt + AccumReserveToExitMemberOnly);
                EmployerPortAtExit = EmployerContWithInt + AccumReserveToExitEmployerOnly;

                AccumReserveAtExit = Math.Round(MemberPortAtExit + EmployerPortAtExit, 2);

                //Get Minimum Additional Award to calculate Amount of Benefit
                if (CommutationFactorAndMinCom != null)
                {
                    foreach (DataRow row in CommutationFactorAndMinCom.Tables[0].Rows)
                    {
                        BenefitAmount = double.Parse(row["MinimumAdditionalAward"].ToString());
                        MinPensionAllowable = double.Parse(row["MinAnnualPension"].ToString());
                    }
                }

                if (ExitType != "Withdrawal")
                {
                    if (EmployerPortAtExit > BenefitAmount)
                    {
                        BenefitAmount = MemberPortAtExit;
                        AdditionalAward = EmployerPortAtExit;
                        EmployerBenefit = 0;
                        MemberBenefit = MemberPortAtExit;
                        BenefitDescription = "REFUND OF MEMBER CONTRIBUTIONS";

                    }
                    else
                    {
                        AdditionalAward = 0;
                        EmployerBenefit = EmployerPortAtExit;
                        MemberBenefit = MemberPortAtExit;
                        BenefitAmount = MemberPortAtExit + EmployerPortAtExit;
                        BenefitDescription = "REFUND OF MEMBER CONTRIBUTIONS PLUS ADDITIONAL AWARD";
                    }
                }

                //Get latest Monthly Salary
                if (LatestSalary != null)
                {
                    foreach (DataRow row in LatestSalary.Tables[0].Rows)
                    {
                        LastestSalary = double.Parse(row["Salary"].ToString());
                    }

                }

                AnnualSalary = LastestSalary * 12;

                if (illHealthParameters != null)
                {
                    foreach (DataRow row in illHealthParameters.Tables[0].Rows)
                    {
                        illHealthPerc = double.Parse(row["IHSalaryPerc"].ToString());
                    }

                }
                if (ConversionFactor <= 0)
                {
                    ConversionFactor = 1;
                }
                if (CoverMultiple <= 0)
                {
                    CoverMultiple = 1;
                }

                if (ExitType != "Withdrawal")
                {
                    MinAnnualPension = Math.Round(AnnualSalary * (illHealthPerc / 100), 2);

                    CapitalValue = Math.Round(MinAnnualPension * ConversionFactor, 2);

                    //Getting Full Annual Pension before Commutation 

                    if (CapitalValue >= AccumReserveAtExit)
                    {
                        FullAnnualPenBeforeComutation = MinAnnualPension;
                    }
                    else
                    {
                        FullAnnualPenBeforeComutation = AccumReserveAtExit / ConversionFactor;
                    }

                    if (CommutationFactorAndMinCom != null)
                    {
                        foreach (DataRow row in CommutationFactorAndMinCom.Tables[0].Rows)
                        {
                            CommutationFactor = double.Parse(row["MinCommutation"].ToString()) / 100;
                        }
                    }

                    //Get Bal;ance Accumulated Credit/Residual Consideration and Taxfree Commutation

                    TaxFreeCommutation = Math.Round(CommutationFactor * AccumReserveAtExit, 2);
                    BalAccumCredit = Math.Round(AccumReserveAtExit - (CommutationFactor * AccumReserveAtExit), 2);
                    EnhancedResidualConsid = Math.Round(MinAnnualPension * ConversionFactor - TaxFreeCommutation, 2);

                    EnhancedResidualAnnualPen = Math.Round(EnhancedResidualConsid / ConversionFactor, 2);
                    //get Annual Pension after commutation
                    AnnualPenAfterCommutation = Math.Round(BalAccumCredit / ConversionFactor, 2);

                    //get Monthly Pension 
                    MonthlyPension = Math.Round(AnnualPenAfterCommutation / 12, 2);
                    //put case statements
                    string BenefitFormula = "AnnualSalary * CoverMultiple";
                    double LumpsumMultiple = 1;
                    DataSet GetFormula = new DataSet();
                    GetFormula = lp.GetBenefitFormula(int.Parse(txtFundID.Value));

                    if (GetFormula != null)
                    {
                        foreach (DataRow row in GetFormula.Tables[0].Rows)
                        {
                            BenefitFormula = row["BenefitFormular"].ToString();
                            LumpsumMultiple = double.Parse(row["LumpsumMultiple"].ToString());

                        }
                    }

                    if (BenefitFormula == "AnnualSalary * CoverMultiple + AccumReserveAtExit")
                    {
                        ReassuredCover = Math.Round(CoverMultiple * AnnualSalary, 2);
                    }
                    else
                    {
                        ReassuredCover = Math.Round(CoverMultiple * AnnualSalary - AccumReserveAtExit, 2);
                    }
                    if (ReassuredCover < 0)
                    {
                        ReassuredCover = 0;
                    }

                    if (ReassuredCover == 0 && LumpsumMultiple != 0)
                    {
                        LumpsumPayable = TaxFreeCommutation;
                        BenefitAmount = AccumReserveAtExit;

                        NetLumpsumPayable = Math.Round(LumpsumPayable - AdvancePayment, 2);
                        NetLumpsumPayableWithInt = NetLumpsumPayable;

                        StartDate = Convert.ToDateTime(ExitDate);
                        EndDate = CalculationDate;


                        if (x5 != null)
                        {
                            foreach (DataRow rwInt in x5.Tables[0].Rows)
                            {

                                if (Convert.ToDateTime(rwInt["Effectivedate"].ToString()) < StartDate)
                                {

                                }
                                else
                                {
                                    double finalresult = 0;
                                    double deathrate = 0;
                                    EndDate = Convert.ToDateTime(rwInt["Effectivedate"].ToString());
                                    DataSet getDate = new DataSet();
                                    getDate = lp.getRetDateDiff(StartDate, EndDate);
                                    if (getDate != null)
                                    {
                                        foreach (DataRow rows in getDate.Tables[0].Rows)
                                        {
                                            finalresult = int.Parse(rows["result"].ToString());
                                        }
                                    }

                                    deathrate = (1 + double.Parse(rwInt["MonthlyIntRate"].ToString()) / 100);

                                    if (rwInt["SCInd"].ToString().ToUpper() == "C")
                                    {
                                        NetLumpsumPayableWithInt = Math.Pow(NetLumpsumPayableWithInt * deathrate, finalresult);
                                        NBeneficiary_BalTaxableAmount = Math.Pow(NBeneficiary_BalTaxableAmount * deathrate, finalresult);
                                        StartDate = EndDate;


                                    }
                                    else
                                    {

                                        NetLumpsumPayableWithInt = Math.Pow(NetLumpsumPayableWithInt * deathrate, finalresult);
                                        NBeneficiary_BalTaxableAmount = Math.Pow(NBeneficiary_BalTaxableAmount * deathrate, finalresult);
                                        StartDate = EndDate;
                                    }

                                }
                            }

                        }

                        NBeneficiary_LumpsumWithInt = NetLumpsumPayableWithInt;

                    }
                    else
                    {
                        if (BenefitFormula == "AnnualSalary * CoverMultiple + AccumReserveAtExit")
                        {
                            BenefitAmount = AnnualSalary * CoverMultiple + AccumReserveAtExit;
                            GLAEntiltlement = AnnualSalary * CoverMultiple;
                            LumpsumPayable = LumpsumMultiple * AnnualSalary;
                            NetLumpsumPayable = Math.Round(LumpsumPayable - AdvancePayment, 2);
                            NetLumpsumPayableWithInt = NetLumpsumPayable;
                        }
                        else
                        {
                            if (AnnualSalary * CoverMultiple >= AccumReserveAtExit)
                            {
                                BenefitAmount = AnnualSalary * CoverMultiple;
                                GLAEntiltlement = AnnualSalary * CoverMultiple;
                                if (CoverMultiple == 0)
                                {
                                    LumpsumPayable = (LumpsumMultiple) * BenefitAmount;
                                }
                                else
                                {
                                    LumpsumPayable = (LumpsumMultiple / CoverMultiple) * BenefitAmount;
                                }

                                NetLumpsumPayable = Math.Round(LumpsumPayable - AdvancePayment, 2);
                                NetLumpsumPayableWithInt = NetLumpsumPayable;
                            }
                            else
                            {
                                BenefitAmount = AccumReserveAtExit;
                                LumpsumPayable = TaxFreeCommutation;
                                NetLumpsumPayable = Math.Round(LumpsumPayable - AdvancePayment, 2);
                                NetLumpsumPayableWithInt = NetLumpsumPayable;
                                StartDate = Convert.ToDateTime(ExitDate);
                                EndDate = interestDate;

                                // to put intrest here
                            }
                        }

                    }
                    NBeneficiary_BalTaxableAmount = BenefitAmount - LumpsumPayable;

                    if (ReassuredCover == 0 && LumpsumMultiple != 0)
                    {

                    }
                    else
                    {
                        BalAccumCredit = BenefitAmount - LumpsumPayable;
                    }
                    //to put if statement
                    BalAccumCredit = BalAccumCredit + BenefitTransferedIn;
                    MinAnnualPension = MinPensionAllowable;
                }


                DataSet x7 = new DataSet();
                x7 = lp.MemberContributionsCummulativeSalary(refnumber, Convert.ToDateTime(ExitDate));
                if (x7 != null)
                {
                    CummSalary = x7;
                }
                else
                {
                    CummSalary = null;

                }
                double CummulativeSalary = 0;
                if (CummSalary != null)
                {
                    foreach (DataRow row in CummSalary.Tables[0].Rows)
                    {
                        if (double.TryParse(row["CummulativeSalary"].ToString(), out double cx))
                        {
                            //CummulativeSalary = double.Parse(row["CummulativeSalary"].ToString());
                        }
                        else
                        {
                            row["CummulativeSalary"] = 0;
                        }
                        CummulativeSalary = double.Parse(row["CummulativeSalary"].ToString());

                    }
                }
                if (ExitType != "Withdrawal")
                {
                    DataSet x8 = new DataSet();
                    x8 = lp.TaxTables(AnnualSalary, MemberBenefit, Convert.ToDateTime(ExitDate));
                    if (x8 != null)
                    {
                        TaxTable = x8;
                    }
                    else
                    {
                        TaxTable = null;
                    }

                    if (TaxTable != null)
                    {
                        foreach (DataRow row in TaxTable.Tables[0].Rows)
                        {
                            MemberBenefitTax = Math.Round(double.Parse(row["BandRate"].ToString()) / 100, 2) * MemberBenefit;
                            AdditionalAwardTax = Math.Round(double.Parse(row["BandRate"].ToString()) / 100, 2) * EmployerBenefit;
                        }

                    }
                }

                //insert in temp table
                //Model.Fund f = new Model.Fund("cn", 1);
                string RegNo = lp.getRegNo(int.Parse(txtFundID.Value));

                //Model.Member mm = new Model.Member("cn", 1);

                if (lp.CheckRecordExists(txtNationalID.Text, RegNo, int.Parse(txtMemberID.Value)))
                {
                    //update table
                    myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                    cmd = new SqlCommand("Delete from FundExitsTemp where IDNumber='" + txtNationalID.Text + "' and RegNo='" + RegNo + "' and MemberID ='" + int.Parse(txtMemberID.Value) + "' ", myConnection);
                    if ((myConnection.State == ConnectionState.Open))
                        myConnection.Close();
                    myConnection.Open();
                    cmd.ExecuteNonQuery();
                    myConnection.Close();

                    FundExitsTemp pp = new FundExitsTemp();
                    pp.RegNo = RegNo;
                    pp.MemberID = int.Parse(txtMemberID.Value);
                    pp.FirstName = txtFirstnames.Text;
                    pp.LastName = txtSurname.Text;
                    pp.IDNumber = txtNationalID.Text;
                    pp.Gender = txtGender.Text;
                    DateTime DOB = Convert.ToDateTime(txtDob.Text);
                    DateTime DJF = Convert.ToDateTime(txtDJF.Text);
                    DateTime CalculationDates = Convert.ToDateTime(txtCalDate.Text);
                    DateTime ExitDates = Convert.ToDateTime(txtExitDate.Text);
                    DateTime BonusDate = Convert.ToDateTime(Lastbonusdate);
                    string DOBs = DOB.ToString("yyyy-MM-dd");
                    string DJFs = DJF.ToString("yyyy-MM-dd");
                    string CalculationDatess = CalculationDates.ToString("yyyy-MM-dd");
                    string ExitDatess = ExitDates.ToString("yyyy-MM-dd");
                    string BonusDates = BonusDate.ToString("yyyy-MM-dd");
                    pp.Gender = txtGender.Text;
                    pp.DOB = Convert.ToDateTime(DOBs);
                    pp.DJF = Convert.ToDateTime(DJFs);
                    pp.CalculationDate = Convert.ToDateTime(CalculationDatess);
                    pp.ExitDate = Convert.ToDateTime(ExitDatess);
                    pp.AnualSalary = AnnualSalary;
                    pp.BonusDate = Convert.ToDateTime(BonusDates);
                    pp.TotalPensionableService = Convert.ToDecimal(PensionableService);
                    pp.MemberPortAtBonusDate = Convert.ToDecimal(MemberPortAtReview);
                    pp.EmployerPortAtBonusDate = Convert.ToDecimal(EmployerPortAtReview);
                    pp.MemberContSinceLastReviewWithoutInt = Convert.ToDecimal(MemberContWithoutInt);
                    pp.EmployerContSinceLastReviewWithoutInt = Convert.ToDecimal(EmployerContWithoutInt);
                    pp.MemberContSinceLastReviewWithInt = Convert.ToDecimal(MemberContWithInt);
                    pp.EmployerContSinceLastReviewWithInt = Convert.ToDecimal(EmployerContWithInt);
                    pp.MemberPortAtExitDate = Convert.ToDecimal(MemberPortAtExit);
                    pp.EmployerPortAtExitDate = Convert.ToDecimal(EmployerPortAtExit);
                    pp.AccumAtReview = pp.MemberPortAtBonusDate + pp.EmployerPortAtBonusDate;
                    pp.AccumAtExit = pp.MemberPortAtExitDate + pp.EmployerPortAtExitDate;
                    pp.AccumAtPayment = pp.AccumAtExit;
                    pp.ExitCode = int.Parse(ExitCode);
                    pp.DeathDate = Convert.ToDateTime(ExitDates);
                    pp.Third_Commutation = Convert.ToDecimal(TaxFreeCommutation);
                    pp.GLA_Entilement = Convert.ToDecimal(GLAEntiltlement);
                    pp.Benefit_Transfered_In = Convert.ToDecimal(BenefitTransferedIn);
                    pp.Reassured_Cover = Convert.ToDecimal(ReassuredCover);
                    pp.Lumpsum_payable = Convert.ToDecimal(LumpsumPayable);
                    //pp.AdvancePayment = Convert.ToDecimal(AdvancePayment);
                    pp.NetLumpsumPayable = Convert.ToDecimal(NetLumpsumPayable);
                    //pp.SpouseMonthlyPension =  ;
                    //pp.ChildMonthlyPension =;
                    pp.PensionArrears = Convert.ToDecimal(PensionArrears);
                    pp.LumpsumPayableWithIntrest = Convert.ToDecimal(NetLumpsumPayableWithInt);
                    pp.Exit_Type = Exitype;
                    db.FundExitsTemps.Add(pp);
                    db.SaveChanges();
                }
                else
                {
                    //insert
                    FundExitsTemp pp = new FundExitsTemp();
                    pp.RegNo = RegNo;
                    pp.MemberID = int.Parse(txtMemberID.Value);
                    pp.FirstName = txtFirstnames.Text;
                    pp.LastName = txtSurname.Text;
                    pp.IDNumber = txtNationalID.Text;
                    string dt = txtDob.Text;
                    pp.Gender = txtGender.Text;
                    DateTime DOB = Convert.ToDateTime(txtDob.Text);
                    DateTime DJF = Convert.ToDateTime(txtDJF.Text);
                    DateTime CalculationDates = Convert.ToDateTime(txtCalDate.Text);
                    DateTime ExitDates = Convert.ToDateTime(txtExitDate.Text);
                    DateTime BonusDate = Convert.ToDateTime(Lastbonusdate);
                    string DOBs = DOB.ToString("yyyy-MM-dd");
                    string DJFs = DJF.ToString("yyyy-MM-dd");
                    string CalculationDatess = CalculationDates.ToString("yyyy-MM-dd");
                    string ExitDatess = ExitDates.ToString("yyyy-MM-dd");
                    string BonusDates = BonusDate.ToString("yyyy-MM-dd");
                    pp.Gender = txtGender.Text;
                    pp.DOB = Convert.ToDateTime(DOBs);
                    pp.DJF = Convert.ToDateTime(DJFs);
                    pp.CalculationDate = Convert.ToDateTime(CalculationDatess);
                    pp.ExitDate = Convert.ToDateTime(ExitDatess);
                    pp.AnualSalary = AnnualSalary;
                    pp.BonusDate = Convert.ToDateTime(BonusDates);
                    pp.TotalPensionableService = Convert.ToDecimal(PensionableService);
                    pp.MemberPortAtBonusDate = Convert.ToDecimal(MemberPortAtReview);
                    pp.EmployerPortAtBonusDate = Convert.ToDecimal(EmployerPortAtReview);
                    pp.MemberContSinceLastReviewWithoutInt = Convert.ToDecimal(MemberContWithoutInt);
                    pp.EmployerContSinceLastReviewWithoutInt = Convert.ToDecimal(EmployerContWithoutInt);
                    pp.MemberContSinceLastReviewWithInt = Convert.ToDecimal(MemberContWithInt);
                    pp.EmployerContSinceLastReviewWithInt = Convert.ToDecimal(EmployerContWithInt);
                    pp.MemberPortAtExitDate = Convert.ToDecimal(MemberPortAtExit);
                    pp.EmployerPortAtExitDate = Convert.ToDecimal(EmployerPortAtExit);
                    pp.AccumAtReview = pp.MemberPortAtBonusDate + pp.EmployerPortAtBonusDate;
                    pp.AccumAtExit = pp.MemberPortAtExitDate + pp.EmployerPortAtExitDate;
                    pp.AccumAtPayment = pp.AccumAtExit;
                    pp.ExitCode = int.Parse(ExitCode);
                    pp.DeathDate = Convert.ToDateTime(ExitDates);
                    pp.Third_Commutation = Convert.ToDecimal(TaxFreeCommutation);
                    pp.GLA_Entilement = Convert.ToDecimal(GLAEntiltlement);
                    pp.Benefit_Transfered_In = Convert.ToDecimal(BenefitTransferedIn);
                    pp.Reassured_Cover = Convert.ToDecimal(ReassuredCover);
                    pp.Lumpsum_payable = Convert.ToDecimal(LumpsumPayable);
                    //pp.AdvancePayment = Convert.ToDecimal(AdvancePayment);
                    pp.NetLumpsumPayable = Convert.ToDecimal(NetLumpsumPayable);
                    //pp.SpouseMonthlyPension =  ;
                    //pp.ChildMonthlyPension =;
                    pp.PensionArrears = Convert.ToDecimal(PensionArrears);
                    pp.LumpsumPayableWithIntrest = Convert.ToDecimal(NetLumpsumPayableWithInt);
                    pp.Exit_Type = Exitype;
                    db.FundExitsTemps.Add(pp);
                    db.SaveChanges();

                }

                UpdateMemberDetailsTable(ExitType);
            }
            catch (Exception ex)
            {
                RedAlert(ex.Message);
            }
        }
        protected void FillBenefitParameters(string ExitType, DataSet MemberDs)
        {
            try
            {
                LookUp lp = new LookUp("cn", 1);
                DataSet bp;
                DataRow rw = MemberDs.Tables["MemberDetails"].Rows[0];
                if (rw.Table.Rows.Count > 0)
                {

                    string ff = (rw["DateOfExit"].ToString());
                    if (DateTime.TryParse(rw["DateOfExit"].ToString(), out DateTime dt))
                    {
                        bp = lp.BenefitParameters(ExitType, int.Parse(txtFundID.Value), DateTime.Parse(rw["DateOfExit"].ToString()));
                    }
                    else
                    {
                        bp = lp.BenefitParameters(ExitType, int.Parse(txtFundID.Value), DateTime.Parse(txtExitDate.Text));
                    }
                    if (bp != null)
                    {
                        LastBonusDate = DateTime.Parse(bp.Tables[0].Rows[0]["EffectiveDate"].ToString());
                    }
                    //else
                    //{
                    //    LastBonusDate = Convert.ToDateTime(ff);
                    //}


                }

            }
            catch (Exception ex)
            {
                RedAlert(ex.Message);
            }
        }
        protected void grdEmployees_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grdEmployees_PageIndexChanged(object sender, EventArgs e)
        {

        }

        //protected void btnSaveClaim_Click(object sender, EventArgs e)
        //{

        //}

        protected void btnDiscardClaim_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void grdClientsView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "selectrecord")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                string strscript = null;
                strscript = "<script langauage=JavaScript>";
                strscript += "window.open('frmViewBenefitQuotation.aspx?FundID=" + txtFundID.Value + "&MemberID=" + txtMemberID.Value + "&ExitCode=" + txtExitCode.Value + "');";
                strscript += "</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "newwin", strscript);
                //Delete(index);
            }
            if (e.CommandName == "deleterecord")
            {
                LookUp f = new LookUp("cn", 1);
                string RegNO = f.getRegNo(int.Parse(txtFundID.Value));
                int MemberID = int.Parse(txtMemberID.Value);

                myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                cmd = new SqlCommand("Delete from FundExits where MemberID ='" + MemberID + "'and RegNo='" + RegNO + "'", myConnection);
                if ((myConnection.State == ConnectionState.Open))
                    myConnection.Close();
                myConnection.Open();
                cmd.ExecuteNonQuery();
                myConnection.Close();


                myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                cmd = new SqlCommand("Delete from FundExitsQuotations where SystemRef ='" + MemberID + "'and RegNo='" + RegNO + "'", myConnection);
                if ((myConnection.State == ConnectionState.Open))
                    myConnection.Close();
                myConnection.Open();
                cmd.ExecuteNonQuery();
                myConnection.Close();


                myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                cmd = new SqlCommand("Delete from FundExitsTemp where MemberID ='" + MemberID + "'and RegNo='" + RegNO + "'", myConnection);
                if ((myConnection.State == ConnectionState.Open))
                    myConnection.Close();
                myConnection.Open();
                cmd.ExecuteNonQuery();
                myConnection.Close();

                myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                cmd = new SqlCommand("Update Member set ExitCode=-1 where ID ='" + MemberID + "'and RegNo='" + RegNO + "'", myConnection);
                if ((myConnection.State == ConnectionState.Open))
                    myConnection.Close();
                myConnection.Open();
                cmd.ExecuteNonQuery();
                myConnection.Close();

                SuccessAlert("Claims Canceled Successfully");

            }
        }

        protected void cboClaimType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboClaimType.SelectedValue == "4")
            {
                sh.Visible = true;
                sh1.Visible = true;
                sh2.Visible = true;
                sh3.Visible = true;
                sh4.Visible = true;
            }
            else
            {
                sh.Visible = false;
                sh1.Visible = false;
                sh2.Visible = false;
                sh3.Visible = false;
                sh4.Visible = false;
            }
        }
    }
}