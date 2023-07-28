using OfficeOpenXml;
using PenPortfolio.Data;
using PenPortfolio.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PenPortfolio
{
    public partial class ContributionsUploads : System.Web.UI.Page
    {
        private cn db = new cn();
        public static DataSet dsuld = new DataSet();
        public SqlConnection myConnection = new SqlConnection();
        public SqlDataAdapter adp;
        public SqlCommand cmd;
        static DataSet dsReady = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack )
            {
                txtFundID.Value = "0";
                txtSystemRef.Value = "0";
                txtDB.Value = "0";
                if (Request.QueryString["FundID"] != null)
                {
                    txtFundID.Value = Request.QueryString["FundID"].ToString();
                }
                if (Request.QueryString["SystemRef"] != null)
                {
                    txtSystemRef.Value = Request.QueryString["SystemRef"].ToString();
                }
                getFundCompanies();
                
                //if (Request.QueryString["MemberID"] != null)
                //{
                //    txtMemberID.Value = Request.QueryString["MemberID"].ToString();
                //}
                ClearAlert();
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

        protected void lstWrkSheets_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReadExcelFiletoDataset(txtFilePath.Text, lstWrkSheets.SelectedItem.Text, txtFileName.Text);
        }

        protected void ReadExcelFiletoDataset(string FilePath, string wrkSheet, string FileName)
        {
            try
            {
                dsuld.Clear();

                OleDbCommand cmd = new OleDbCommand();
                OleDbDataAdapter oleda = new OleDbDataAdapter();
                DataSet ds = new DataSet();

                string con = "";
                if ((Path.GetExtension(FilePath) == ".xls"))
                {
                    con = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + FilePath + "';Extended Properties='Excel 8.0;HDR=YES;'";
                }
                else if ((Path.GetExtension(FilePath) == ".xlsx"))
                {
                    con = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FilePath + ";Extended Properties='Excel 12.0;HDR=YES;'";
                }

                OleDbConnection olecon = default(OleDbConnection);
                OleDbCommand olecomm = default(OleDbCommand);

                OleDbDataAdapter oleadpt = default(OleDbDataAdapter);

                olecon = new OleDbConnection();
                olecon.ConnectionString = con;
                olecomm = new OleDbCommand();
                olecomm.CommandText = "Select * from [" + wrkSheet + "$" + "]";
                olecomm.Connection = olecon;

                oleadpt = new OleDbDataAdapter(olecomm);
                ds = new DataSet();
                olecon.Open();
                oleadpt.Fill(ds, wrkSheet + "$");


                if ((ds != null) && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DateTime UploadDate = DateTime.Parse(DateTime.Today.ToShortDateString());
                    if (DateTime.TryParse(txtPaymentDate.Text, out DateTime dt))
                    {
                        UploadDate = DateTime.Parse(txtPaymentDate.Text);
                    }
                    else
                    {
                        UploadDate = DateTime.Parse(DateTime.Today.ToShortDateString());
                    }

                    dsuld = ds;

                    ProcessUploadData(dsuld, FileName, cboPeriod.SelectedItem.Text + "/" + cboMonths.SelectedValue, int.Parse(cboCompany.SelectedValue), cboCompany.SelectedItem.Text, UploadDate);
                    olecon.Close();

                }
                else
                {
                    dsuld.Clear();
                }
                olecon.Close();


            }
            catch (Exception ex)
            {
                RedAlert(ex.Message);
                return;
            }
        }

        protected void ProcessUploadData(DataSet Ds, string FileUploadName, string UploadPeriod, int CompanyID, string CompanyName, DateTime UploadDate)
        {
            try
            {

                long BatchUploadID = 0;
                LookUp tt = new LookUp("cn", 1);
                string CS = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

                if (CS.Contains("PensionsManComarton"))
                {
                    txtDB.Value = "C";
                }
                else
                {
                    txtDB.Value = "E";
                }
                if ((dsReady != null))
                {
                    DataSet x = null;
                    DataSet getFailed = null;
                    string TransBatchNo = DateTime.Today.Day.ToString() + DateTime.Today.Year.ToString();
                    var max = 0;
                    try
                    {
                        max = db.ContributionsFileUploads.ToList().Max(a => a.ID);

                    }
                    catch (Exception)
                    {

                        max = 0;
                    }
                    max = max + 1;
                    string UploadRefence = max + "W"; // Generate Contributions Reference Number
                    //Fund f = new Fund("cn", 1);
                    //Model.Client kk = new Model.Client("cn", 1);
                    //PensionsAdministration.Model.Contributions cc = new PensionsAdministration.Model.Contributions("cn", 1);
                    //Model.Member mm = new Model.Member("cn", 1);
                    //Model.Companies tt = new Model.Companies("cn", 1);
                    string RegNo = tt.getRegNo(long.Parse(txtFundID.Value));
                    DeleteFailedcontributionupload(RegNo);
                    List<double> SalaryBillArray = new List<double>();
                    List<double> MemberContributionsArray = new List<double>();
                    List<double> EmployerContributionsArray = new List<double>();
                    List<double> ExpextedMemberContributionsArray = new List<double>();
                    List<double> ExpextedEmployerContributionsArray = new List<double>();
                    List<double> TransferInMemberContributionsArray = new List<double>();
                    List<double> TransferInEmployerContributionsArray = new List<double>();
                    List<double> OtheMemberContributionsArray = new List<double>();
                    List<double> OtheEmployerContributionsArray = new List<double>();
                    List<double> FaildContributionsArray = new List<double>();
                    double sumcontribution = 0;
                    double ExpectedEmployerY = 0;
                    double ExpectedTransferInMember = 0;
                    double ExpectedTransferInEmployer = 0;
                    double ExpectedOtheMember = 0;
                    double ExpectedOtheEmployer = 0;
                    double countsalary = 0;
                    double sumsalary = 0;
                    double ExpectedMemberX = 0;
                    double sumemployercontribution = 0;
                    double EmployerRate = 0;
                    double MemberRate = 0;
                    double countFailed = 0;
                    double costrate = 0;
                    double MemberPort = 0;
                    double EmployerPort = 0;
                    double GrossEmployer = 0;
                    double Expenses = 0;
                    double ContSalary = 0;
                    double ExpM = 0;
                    double ExpE = 0;
                    double MemberContRate = 0;
                    double CompanyContRate = 0;
                    DateTime date = Convert.ToDateTime(txtPaymentDate.Text.ToString());
                    var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);  //Perioddate Column
                    var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                    foreach (DataRow rw in Ds.Tables[0].Rows)
                    {

                        if (int.TryParse(rw[0].ToString(), out int vv))
                        {
                            string MemberID = "0";

                            string ID = rw["ID Number"].ToString();
                            if (rw["ID Number"].ToString().Trim() != "")
                            {
                                rw["ID Number"] = rw["ID Number"].ToString().Replace("-", "").Replace(" ", "");
                            }
                            ID = rw["ID Number"].ToString();
                            if (rw[0].ToString() != "")
                            {
                                rw[0] = rw[0].ToString().Trim();
                            }
                            if (rw[1].ToString() != "")
                            {
                                rw[1] = rw[1].ToString().Trim();
                            }
                            if (rw[3].ToString() != "")
                            {
                                rw[3] = rw[3].ToString().Trim();
                                MemberID = rw[3].ToString();
                            }
                            if (rw[4].ToString() != "")
                            {
                                rw[4] = rw[4].ToString().Trim();
                            }
                            if (rw[5].ToString() != "")
                            {
                                rw[5] = rw[5].ToString().Trim();
                            }
                            if (rw[8].ToString() != "")
                            {
                                rw[8] = rw[8].ToString().Trim();
                            }
                            if (rw[7].ToString() != "")
                            {
                                rw[7] = rw[7].ToString().Trim();
                            }
                            if (rw[9].ToString() != "")
                            {
                                rw[9] = rw[9].ToString().Trim();
                            }
                            if (rw[10].ToString() != "")
                            {
                                rw[10] = rw[10].ToString().Trim();
                            }
                            if (rw[11].ToString() != "")
                            {
                                rw[11] = rw[11].ToString().Trim();
                            }
                            if (rw[12].ToString() != "")
                            {
                                rw[12] = rw[12].ToString().Trim();
                            }
                            if (rw[13].ToString() != "")
                            {
                                rw[13] = rw[13].ToString().Trim();
                            }
                            if (rw[14].ToString() != "")
                            {
                                rw[14] = rw[14].ToString().Trim();
                            }
                            int compid = int.Parse(cboCompany.SelectedValue);
                            string MemberPeriod = cboPeriod.SelectedItem.Text + "/" + cboMonths.SelectedValue;
                            if (tt.CheckContributionsExists(MemberPeriod, rw["ID Number"].ToString(), RegNo) != null)
                            {
                                string Msg = $"Contributions for this member: {rw[3].ToString()}, for the period {UploadPeriod} have already been uploaded";
                                string dt = DateTime.Now.ToString("yyyy-MM-dd");
                                //msgbox("Contributions for  Member:" + " " + rw["ID Number"].ToString() + " " + " for this period have already been uploaded.");
                                //AmberAlert($"Contributions for this member: {rw[3].ToString()}, for the period {UploadPeriod} have already been uploaded");

                                myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                                cmd = new SqlCommand("insert into FailedContributionUploads(NationalID,RegNo,Description,BranchCode,DateCreated,CreatedBy) values('" + rw["ID Number"].ToString() + "','" + RegNo + "','" + Msg + "','" + rw[0].ToString() + "','" + dt + "','" + int.Parse(txtSystemRef.Value) + "')", myConnection);
                                if ((myConnection.State == ConnectionState.Open))
                                    myConnection.Close();
                                myConnection.Open();
                                cmd.ExecuteNonQuery();
                                myConnection.Close();

                                double branchcode = double.Parse(rw[8].ToString());

                                for (int runs = 0; runs < 1; runs++)
                                {
                                    FaildContributionsArray.Add(branchcode);
                                }

                                continue;
                            }
                            else
                            {
                                string Branchid = tt.GetBranchID(int.Parse(rw[0].ToString()));
                                if (cbobranch.SelectedValue != Branchid)
                                {
                                    string Msg = $"Member does not belong to the selected cost centre";
                                    string dt = DateTime.Now.ToString("yyyy-MM-dd");
                                    myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                                    cmd = new SqlCommand("insert into FailedContributionUploads(NationalID,RegNo,Description,BranchCode,DateCreated,CreatedBy) values('" + rw["ID Number"].ToString() + "','" + RegNo + "','" + Msg + "','" + rw[0].ToString() + "','" + dt + "','" + int.Parse(txtSystemRef.Value) + "')", myConnection);
                                    if ((myConnection.State == ConnectionState.Open))
                                        myConnection.Close();
                                    myConnection.Open();
                                    cmd.ExecuteNonQuery();
                                    myConnection.Close();
                                    double branchcode = double.Parse(rw[8].ToString());

                                    for (int runs = 0; runs < 1; runs++)
                                    {
                                        FaildContributionsArray.Add(branchcode);
                                    }
                                    continue;
                                }
                                else
                                {
                                    //validateMemberExistence
                                    if (tt.ValidateIdentityNumberMember(MemberID, RegNo) != null)
                                    {

                                        string sname = rw[4].ToString();
                                        string uperiod = UploadPeriod;
                                        if (sname.Length > 1 && uperiod.Length > 1)
                                        {
                                            Data.ContributionsFileUpload cfu = new Data.ContributionsFileUpload();
                                            //string getusername = Session["username"].ToString();
                                            int userid = 0;

                                            //var users = db.Users.ToList().Where(a => a.Email == getusername).ToArray();//select userid of current session
                                            //foreach (var id in users)
                                            //{
                                            //    userid = id.UserID;
                                            //}
                                            //cfu.ID = 0;
                                            userid = int.Parse(txtSystemRef.Value);
                                            txtBatchID.Value = BatchUploadID.ToString();
                                            //Save to ContributionsFileUpload Table
                                            cfu.EmployerCode = rw[0].ToString();
                                            cfu.EmployerName = rw[1].ToString();
                                            cfu.SystemRefNo = rw[3].ToString();
                                            cfu.Surname = rw[4].ToString();
                                            cfu.Forenames = rw[5].ToString();
                                            cfu.IDNumber = rw["ID Number"].ToString();
                                            cfu.MemberSalary = decimal.Parse(rw[7].ToString());
                                            cfu.MemberContributions = decimal.Parse(rw[8].ToString());
                                            cfu.EmployerContributions = decimal.Parse(rw[9].ToString());
                                            cfu.MemberTransferIn = decimal.Parse(rw[10].ToString());
                                            cfu.EmployerTransferIn = decimal.Parse(rw[11].ToString());
                                            cfu.MemberOther = decimal.Parse(rw[12].ToString());
                                            cfu.EmployerOther = decimal.Parse(rw[13].ToString());
                                            cfu.VoluntaryContributions = decimal.Parse(rw[14].ToString());
                                            cfu.CompanyID = CompanyID;
                                            cfu.MemberPort = cfu.MemberContributions;
                                            cfu.EmployerPort = cfu.EmployerContributions;
                                            cfu.CreatedBy = userid;
                                            cfu.Period = UploadPeriod;
                                            cfu.DateOfUpload = Convert.ToDateTime(txtPaymentDate.Text);
                                            cfu.DateCreated = Convert.ToDateTime(txtPaymentDate.Text);
                                            cfu.UploadBatchID = Convert.ToInt32(BatchUploadID);
                                            cfu.RegNo = RegNo;
                                            cfu.BatchNo = UploadRefence;
                                            cfu.Isprocessed = false;
                                            cfu.ProcessStatusID = 0;
                                            db.ContributionsFileUploads.Add(cfu);
                                            db.SaveChanges();

                                            txtBatchNo.Value = UploadRefence.ToString();
                                            string CategoryID = tt.getFundCategory(int.Parse(rw[3].ToString()));
                                            DataSet y = tt.getInterestRates(CategoryID, RegNo, lastDayOfMonth,txtDB.Value);
                                            DataSet z = tt.getExpenses(CategoryID, RegNo, lastDayOfMonth, txtDB.Value);

                                            if (y != null)
                                            {
                                                foreach (DataRow rwset in y.Tables[0].Rows)
                                                {
                                                    EmployerRate = double.Parse(rwset["CompanyContPerc"].ToString());
                                                    MemberRate = double.Parse(rwset["MemberContPerc"].ToString());

                                                }
                                            }
                                            if (z != null)
                                            {
                                                foreach (DataRow rwset in z.Tables[0].Rows)
                                                {
                                                    costrate = double.Parse(rwset["CostPercentage"].ToString());

                                                }

                                            }
                                            //Sum Salary from excel
                                            double membersalary = double.Parse(rw[7].ToString());

                                            for (int runs = 0; runs < 1; runs++)
                                            {
                                                SalaryBillArray.Add(membersalary);
                                            }

                                            //sum Member contribution from excel
                                            double membercont = double.Parse(rw[8].ToString());

                                            for (int runs = 0; runs < 1; runs++)
                                            {
                                                MemberContributionsArray.Add(membercont);
                                            }

                                            //sum Employer contribution from excel
                                            double Empcont = double.Parse(rw[9].ToString());

                                            for (int runs = 0; runs < 1; runs++)
                                            {
                                                EmployerContributionsArray.Add(Empcont);
                                            }

                                            double TMemberCont = double.Parse(rw[10].ToString());

                                            for (int runs = 0; runs < 1; runs++)
                                            {
                                                TransferInMemberContributionsArray.Add(TMemberCont);
                                            }
                                            double TEmployerCont = double.Parse(rw[11].ToString());

                                            for (int runs = 0; runs < 1; runs++)
                                            {
                                                TransferInEmployerContributionsArray.Add(TEmployerCont);
                                            }


                                            double OMemberCont = double.Parse(rw[12].ToString());

                                            for (int runs = 0; runs < 1; runs++)
                                            {
                                                OtheMemberContributionsArray.Add(OMemberCont);
                                            }


                                            double OEmployerCont = double.Parse(rw[13].ToString());

                                            for (int runs = 0; runs < 1; runs++)
                                            {
                                                OtheEmployerContributionsArray.Add(OEmployerCont);
                                            }


                                            MemberPort = (double.Parse(rw[8].ToString()));

                                            GrossEmployer = (double.Parse(rw[9].ToString()));

                                            MemberContRate = MemberRate;

                                            CompanyContRate = EmployerRate + costrate;

                                            if (CompanyContRate > 0)
                                            {
                                                EmployerPort = ((EmployerRate / CompanyContRate) * GrossEmployer);
                                            }

                                            if (EmployerPort < 0)
                                            {
                                                EmployerPort = 0;
                                            }

                                            Expenses = (GrossEmployer - EmployerPort);

                                            ContSalary = (double.Parse(rw[7].ToString()));

                                            ExpM = (MemberRate * ContSalary / 100);
                                            ExpE = (CompanyContRate * ContSalary / 100);

                                            for (int runs = 0; runs < 1; runs++)
                                            {
                                                ExpextedMemberContributionsArray.Add(ExpM);
                                            }

                                            for (int runs = 0; runs < 1; runs++)
                                            {
                                                ExpextedEmployerContributionsArray.Add(ExpE);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        string dt = DateTime.Now.ToString("yyyy-MM-dd");
                                        string Msg = $"Member with ID number : {rw["ID Number"].ToString()} ,System Ref: {rw[3].ToString()} , Surname: {rw[4].ToString()} and Branch Code {rw[0].ToString()} is not found. Contributions for: {UploadPeriod} will not be uploaded";
                                        myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                                        cmd = new SqlCommand("insert into FailedContributionUploads(NationalID,RegNo,Description,BranchCode,DateCreated,CreatedBy) values('" + rw["ID Number"].ToString() + "','" + RegNo + "','" + Msg + "','" + rw[0].ToString() + "','" + dt + "','" + int.Parse(txtSystemRef.Value) + "')", myConnection);
                                        if ((myConnection.State == ConnectionState.Open))
                                            myConnection.Close();
                                        myConnection.Open();
                                        cmd.ExecuteNonQuery();
                                        myConnection.Close();
                                        double branchcode = double.Parse(rw[8].ToString());

                                        for (int runs = 0; runs < 1; runs++)
                                        {
                                            FaildContributionsArray.Add(branchcode);
                                        }
                                        continue;
                                    }
                                }
                            }

                        }
                        else
                        {
                            break;
                        }

                    }
                    double[] sumsalaries = SalaryBillArray.ToArray();
                    sumsalary = sumsalaries.Sum();
                    countsalary = sumsalaries.Count();

                    double[] sumFailedCont = FaildContributionsArray.ToArray();
                    //sumsalary = sumsalaries.Sum();
                    countFailed = sumFailedCont.Count();

                    double[] sumcontributions = MemberContributionsArray.ToArray();
                    sumcontribution = sumcontributions.Sum();

                    double[] sumemployercontributions = EmployerContributionsArray.ToArray();
                    sumemployercontribution = sumemployercontributions.Sum();

                    double[] ExpectedMemberXs = ExpextedMemberContributionsArray.ToArray();
                    ExpectedMemberX = ExpectedMemberXs.Sum();

                    double[] ExpectedEmployerYs = ExpextedEmployerContributionsArray.ToArray();
                    ExpectedEmployerY = ExpectedEmployerYs.Sum();

                    double[] ExpectedTransferInMembers = TransferInMemberContributionsArray.ToArray();
                    ExpectedTransferInMember = ExpectedTransferInMembers.Sum();

                    double[] ExpectedTransferInEmployers = TransferInEmployerContributionsArray.ToArray();
                    ExpectedTransferInEmployer = ExpectedTransferInEmployers.Sum();

                    double[] ExpectedOtheMembers = OtheMemberContributionsArray.ToArray();
                    ExpectedOtheMember = ExpectedOtheMembers.Sum();

                    double[] ExpectedOtheEmployers = OtheEmployerContributionsArray.ToArray();
                    ExpectedOtheEmployer = ExpectedOtheEmployers.Sum();

                    txtRecordsCount.Text = countsalary.ToString("##,###,###.##");
                    txtExpectedEmployer.Text = ExpectedEmployerY.ToString("##,###,###.##");
                    txtEmployerActual.Text = sumemployercontribution.ToString("##,###,###.##");
                    txtMemberActual.Text = sumcontribution.ToString("##,###,###.##");
                    txtExpectedMember.Text = ExpectedMemberX.ToString("##,###,###.##");
                    txtTransferInMember.Text = ExpectedTransferInMember.ToString("##,###,###.##");
                    txtTransferInEmployer.Text = ExpectedTransferInEmployer.ToString("##,###,###.##");
                    txtOtherMember.Text = ExpectedOtheMember.ToString("##,###,###.##");
                    txtOtherEmployer.Text = ExpectedOtheEmployer.ToString("##,###,###.##");
                    txtSalaryBill.Text = sumsalary.ToString("##,###,###.##");

                    double Actamt = Convert.ToDouble(sumcontribution);
                    double Examt = Convert.ToDouble(ExpectedMemberX);
                    double ActEmpamt = Convert.ToDouble(sumemployercontribution);
                    double ExEmpamt = Convert.ToDouble(ExpectedEmployerY);


                    //if (Actamt  != Examt)
                    //{
                    //    lblBalancing.Text = "NOT BALANCING: ";
                    //    lblBalancing.ForeColor = System.Drawing.Color.Red;
                    //    btnProcess.Text = "Send Upload Approval Request";


                    //}
                    if (((Actamt - Examt) > 0.1) || (((Actamt - Examt) < -0.1)))
                    {

                        //lblBalancing.Text = "Not Balancing Employee Portion diff: " + (Actamt - Examt).ToString("##,###,###.##");
                        lblBalancing.Text = "NOT BALANCING";
                        lblBalancing.ForeColor = System.Drawing.Color.Red;
                        //qq.Visible = true;
                        //zz.Visible = true;
                        //pl.Visible = true;
                        //btnOk.Visible = true;
                        //btnProcess.Visible = false;
                        //btnProcess.Text = "Send Upload Approval Request";

                    }
                    else if (((ActEmpamt - ExEmpamt) > 0.1) || (((ActEmpamt - ExEmpamt) < -0.1)))
                    {
                        //lblBalancing.Text = "Upload Not balanced Employer Portion difference: " + (ActEmpamt - ExEmpamt).ToString("##,###,###.##");
                        lblBalancing.Text = "NOT BALANCING";
                        lblBalancing.ForeColor = System.Drawing.Color.Red;
                        //qq.Visible = true;
                        //zz.Visible = true;
                        //pl.Visible = true;
                        //btnOk.Visible = true;
                        //btnProcess.Visible = false;
                        //btnProcess.Text = "Send Upload Approval Request";

                    }
                    else
                    {
                        lblBalancing.Text = "BALANCED";
                        lblBalancing.ForeColor = System.Drawing.Color.Green;
                        //btnProcess.Text = "Process Upload";
                        //qq.Visible = false;
                        //zz.Visible = false;
                        //pl.Visible = false;
                        //btnOk.Visible = false;
                        //btnProcess.Visible = true;
                    }
                    //Virtual DataSet 

                    // Get Upload Results

                    dsReady.Tables.Clear();

                    x = tt.getcontributionuploaded(UploadRefence, RegNo);
                    getFailed = tt.GetFailedContributions(RegNo);
                    if (x != null)
                    {
                        grdMatchAccounts.DataSource = x;
                        grdMatchAccounts.DataBind();

                        grdMatchAccounts.Visible = true;
                    }
                    else
                    {
                        grdMatchAccounts.DataSource = null;
                        grdMatchAccounts.DataBind();
                        grdMatchAccounts.Visible = false;
                    }
                    if (getFailed != null)
                    {
                        grdUploadError.DataSource = getFailed;
                        grdUploadError.DataBind();

                        grdUploadError.Visible = true;
                    }
                    else
                    {
                        grdUploadError.DataSource = null;
                        grdUploadError.DataBind();
                        grdUploadError.Visible = false;
                    }
                    //if (getFailed != null)
                    //{
                    //    grdUploadError.DataSource = getFailed;
                    //    grdUploadError.DataBind();

                    //    grdUploadError.Visible = true;
                    //}
                    //else
                    //{
                    //    grdUploadError.DataSource = null;
                    //    grdUploadError.DataBind();
                    //    grdUploadError.Visible = false;
                    //}

                    dsuld.Clear();
                }
                else
                {
                    RedAlert("Problem fetching processing data");
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
                //return lineNumber;
            }
        }

        protected void getFundCompanies()
        {
            try
            {
                //Fund f = new Fund("cn", 1);
                LookUp f = new LookUp("cn", 1);
                DataSet fsd = f.getCostCenter(txtSystemRef.Value);
                if (fsd != null)
                {
                    ListItem li = new ListItem("Select Cost Centre", "0");
                    cboCompany.DataSource = f.getCostCenter(txtSystemRef.Value);
                    cboCompany.DataValueField = "ID";
                    cboCompany.DataTextField = "Name";
                    cboCompany.DataBind();
                    cboCompany.Items.Insert(0, li);
                    //foreach (DataRow item in fsd.Tables[0].Rows)
                    //{
                    //    cboCompany.SelectedItem.Value = item["Name"].ToString();
                    //}
                }
                else
                {
                    ListItem li = new ListItem("There are no Cost Centres", "0");
                    cboCompany.DataSource = null;
                    cboCompany.DataBind();
                    cboCompany.Items.Insert(0, li);
                }
                if (f.Get_Participarting_Employer( txtSystemRef.Value,txtFundID.Value) != null)
                {
                    ListItem li = new ListItem("Select All", "0");
                    cbobranch.DataSource = f.Get_Participarting_Employer( txtSystemRef.Value,txtFundID.Value);
                    cbobranch.DataValueField = "ID";
                    cbobranch.DataTextField = "Name";
                    cbobranch.DataBind();
                    cbobranch.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no Branch Codes", "0");
                    cbobranch.DataSource = null;
                    cbobranch.DataBind();
                    cbobranch.Items.Insert(0, li);
                }

            
                if (f.getFundUploadPeriods(int.Parse(txtFundID.Value)) != null)
                {
                    ListItem li = new ListItem("Select an upload year", "0");
                    cboPeriod.DataSource = f.getFundUploadPeriods(int.Parse(txtFundID.Value));
                    cboPeriod.DataValueField = "ID";
                    cboPeriod.DataTextField = "Year";
                    cboPeriod.DataBind();
                    cboPeriod.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no defined upload years", "0");
                    cboPeriod.DataSource = null;
                    cboPeriod.DataBind();
                    cboPeriod.Items.Insert(0, li);
                }
                //Load Months
                if (f.getCalendarMonths() != null)
                {
                    ListItem li = new ListItem("Select an upload month", "0");
                    cboMonths.DataSource = f.getCalendarMonths();
                    cboMonths.DataValueField = "ID";
                    cboMonths.DataTextField = "MonthName";
                    cboMonths.DataBind();
                    cboMonths.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no defined upload motnh", "0");
                    cboMonths.DataSource = null;
                    cboMonths.DataBind();
                    cboMonths.Items.Insert(0, li);
                }
            }
            catch (Exception ex)
            {
                RedAlert(ex.Message);
            }
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (cboCompany.SelectedItem.Text == "Select Cost Centre")
            {
                WarningAlert("Please Select a Cost Centre");
            }
            else if (txtPaymentDate.Text == "")
            {
                WarningAlert("Please Select Upload Date");
            }
            else if (cboPeriod.SelectedItem.Text == "Select an upload year")
            {
                WarningAlert("Please Select Upload Period");
            }
            else if (cboMonths.SelectedItem.Text == "Select an upload month")
            {
                WarningAlert("Please Select Upload month");
            }
            else
            {
                UploadFile();
            }
        }

        protected void UploadFile()
        {
            try
            {
                dsuld.Clear();
                pnlComms.BackColor = System.Drawing.Color.Transparent;
                lblComms.Text = "";
                if ((flContributionsUpload.HasFile))
                {
                }
                else
                {
                    lblComms.Text = "Please select a file for upload";
                    pnlComms.BackColor = System.Drawing.Color.Red;
                    return;
                }

                //Upload and save the file
                string csvPath = Server.MapPath("~/FileUploads/") + Path.GetFileName(flContributionsUpload.PostedFile.FileName);
                string finename = Path.GetFileName(flContributionsUpload.PostedFile.FileName);
                txtFileName.Text = finename;
                flContributionsUpload.SaveAs(csvPath);

                string filePath = "FileUploads/" + finename;
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                //Dim stream As FileStream = File.Open(csvPath, FileMode.Open, FileAccess.Read)
                txtFilePath.Text = csvPath;
                ExcelPackage pckage = new ExcelPackage(new FileInfo(csvPath));
                //ExcelWorksheet wksheets = default(ExcelWorksheet);
                List<string> wkBks = new List<string>();
                foreach (ExcelWorksheet wksheets in pckage.Workbook.Worksheets)
                {
                    wkBks.Add(wksheets.Name);
                }
                lstWrkSheets.DataSource = wkBks;
                lstWrkSheets.DataBind();
                if ((lstWrkSheets.Items.Count > 0))
                {
                    //lblComms.Text = "File Uploaded, select a worksheet to continue";
                    //pnlComms.BackColor = System.Drawing.Color.Green;
                }
                else
                {
                    RedAlert("There was a problem reading the worksheets of the file");
                }


                if (lstWrkSheets.Items.Count >= 1)
                {
                    lstWrkSheets.Visible = true;
                    lblWrkSheetPrompt.Visible = true;
                }
                else
                {
                    lblWrkSheetPrompt.Visible = false;
                    lstWrkSheets.Visible = false;
                }
                return;

            }
            catch (Exception ex)
            {
                lblComms.Text = ex.Message;
                pnlComms.BackColor = System.Drawing.Color.Red;
            }
        }
        protected void UploadContributions()
        {
            try
            {

                if (btnProcess.Text.Contains("Send Upload Approval Request"))
                {
                    WarningAlert("Error sending request for apprval");
                }
                else
                {
                    //if (int.Parse(txtBatchID.Value) >= 1)
                    //{
                    LookUp tt = new LookUp("cn", 1);
                    string CS = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                    if (CS.Contains("PensionsManComarton"))
                    {
                        txtDB.Value = "C";
                    }
                    else
                    {
                        txtDB.Value = "E";
                    }
                    string RegNo = tt.getRegNo(long.Parse(txtFundID.Value));
                    DateTime DateofUpload = DateTime.Today;
                    if (DateTime.TryParse(txtPaymentDate.Text, out DateTime dt))
                    {
                        DateofUpload = DateTime.Parse(txtPaymentDate.Text).Date;
                    }
                   
                    DataSet x = tt.getBatchUploadDetails(txtBatchNo.Value.ToString(), RegNo);

                    //Contribution c = new Contribution();
                    if (x != null)
                    {
                        double LoadedMemberPort = 0;
                        double LoadedEmployerPort = 0;
                        double Stabilization = 0;
                        double AVC = 0;
                        string reference = "";
                        int Userid = 1;
                        double MemberPort = 0;
                        double EmployerPort = 0;
                        double Expenses = 0;
                        double ExpectedMember = 0;
                        double ExpectedEmployer = 0;
                        double MemberContributions = 0;
                        double VoluntaryContributions = 0;
                        int Memberid = 0;
                        double EmployerRate = 0;
                        double MemberRate = 0;
                        double costrate = 0;

                        double EmployerContributions = 0;
                        double MemberSalary = 0;
                        string EmployerCode = "0";
                        DateTime perioddate = DateTime.Now;
                        DateTime paymentdate = DateTime.Now;
                        DateTime date = Convert.ToDateTime(txtPaymentDate.Text.ToString());
                        var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);  //Perioddate Column
                        var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                        foreach (DataRow rw in x.Tables[0].Rows)
                        {

                            //get member fundcategory
                            string CategoryID = tt.getFundCategory(int.Parse(rw["SystemRefNo"].ToString()));

                            //get category name
                            //string CategoryName = m.getFundCategorynAME(int.Parse(CategoryID),RegNo);

                            //select RATES from table
                            DataSet y = tt.getInterestRates(CategoryID, RegNo, lastDayOfMonth, txtDB.Value);
                            DataSet z = tt.getExpenses(CategoryID, RegNo, lastDayOfMonth, txtDB.Value);

                            if (y != null)
                            {
                                foreach (DataRow rwset in y.Tables[0].Rows)
                                {
                                    EmployerRate = double.Parse(rwset["CompanyContPerc"].ToString()) / 100;
                                    MemberRate = double.Parse(rwset["MemberContPerc"].ToString()) / 100;
                                }
                            }

                            if (z != null)
                            {
                                foreach (DataRow rwset in z.Tables[0].Rows)
                                {
                                    costrate = double.Parse(rwset["CostPercentage"].ToString()) / 100;

                                }
                            }


                            if (rw["MemberContributions"].ToString() != "")
                            {
                                MemberPort = double.Parse(rw["MemberContributions"].ToString());

                            }
                            if (rw["EmployerContributions"].ToString() != "")
                            {
                                EmployerPort = double.Parse(rw["EmployerContributions"].ToString());

                            }
                            if (rw["Expenses"].ToString() != "")
                            {
                                Expenses = double.Parse(rw["Expenses"].ToString());

                            }
                            if (rw["ExpectedMember"].ToString() != "")
                            {
                                ExpectedMember = double.Parse(rw["ExpectedMember"].ToString());

                            }
                            if (rw["ExpectedEmployer"].ToString() != "")
                            {
                                ExpectedEmployer = double.Parse(rw["ExpectedEmployer"].ToString());

                            }
                            if (rw["VoluntaryContributions"].ToString() != "")
                            {
                                VoluntaryContributions = double.Parse(rw["VoluntaryContributions"].ToString());

                            }
                            //if (rw["EmployerContributions"].ToString() != "")
                            //{
                            //    EmployerContributions = double.Parse(rw["EmployerContributions"].ToString());

                            //}
                            if (rw["EmployerCode"].ToString() != "")
                            {
                                EmployerCode = rw["EmployerCode"].ToString();

                            }
                            if (rw["MemberSalary"].ToString() != "")
                            {
                                MemberSalary = double.Parse(rw["MemberSalary"].ToString());

                            }
                            //if (rw["MemberContributions"].ToString() != "")
                            //{
                            //    MemberContributions = double.Parse(rw["MemberContributions"].ToString());

                            //}
                            Guid guid = Guid.NewGuid();
                            Math.Round(EmployerContributions, 2);
                            Data.Contribution my = new Data.Contribution();
                            my.MemberID = int.Parse(rw["SystemRefNo"].ToString());
                            Memberid = Convert.ToInt32(my.MemberID);
                            my.NationalID = rw["IDNumber"].ToString().Replace("-", "");
                            my.Period = cboPeriod.SelectedItem.Text + "/" + cboMonths.SelectedValue;
                            my.RegNo = RegNo;
                            my.TransID = guid;
                            //yContribution = Math.Round((Convert.ToDouble(rate) * EmployerContributions), 2);
                            my.Salary = Math.Round(MemberSalary, 2);
                            my.XContribution = Math.Round(MemberPort, 2);
                            //MemberPort = Convert.ToDouble(my.XContribution);
                            my.ZContribution = Math.Round(VoluntaryContributions, 2);
                            my.GrossYContribution = Math.Round(EmployerPort, 2);
                            //EmployerPort = my.GrossYContribution;
                            Expenses = Math.Round(my.Salary * costrate, 2);
                            my.Expenses = Math.Round(my.Salary * costrate, 2);
                            my.YContribution = Math.Round(Convert.ToDouble(my.GrossYContribution) - Convert.ToDouble(my.Expenses), 2);
                            my.ExpectedX = Math.Round(my.Salary * MemberRate, 2);
                            my.ExpectedY = Math.Round(EmployerContributions, 2);
                            my.UserID = int.Parse(rw["CreatedBy"].ToString());
                            my.isStartup = false;
                            my.IsHistory = false;
                            my.BonusTypeID = 0;
                            my.BranchCode = rw["EmployerCode"].ToString();
                            my.Platform = "Portal";
                            my.CompanyID = int.Parse(rw["CompanyID"].ToString());
                            my.BatchNo = rw["BatchNo"].ToString();
                            my.PeriodDate = firstDayOfMonth;
                            my.PaymentDate = lastDayOfMonth;
                            perioddate = Convert.ToDateTime(my.PeriodDate);
                            paymentdate = Convert.ToDateTime(my.PaymentDate);
                            my.LatestUpdateDate = lastDayOfMonth;
                            my.BackPay = 0;
                            my.DateCaptured = Convert.ToDateTime(rw["DateCreated"]);
                            my.DateSplitted = Convert.ToDateTime(txtPaymentDate.Text);
                            my.Total = Math.Round(Convert.ToDouble(my.ExpectedY), 2);
                            int uploadID = int.Parse(rw["UploadBatchID"].ToString());
                            reference = rw["BatchNo"].ToString();
                            Userid = Convert.ToInt32(txtSystemRef.Value);
                            //db.Contributions.Add(my);
                            //db.SaveChanges();
                            string constr = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                            SqlConnection sqlCon = null;
                            using (sqlCon = new SqlConnection(constr))
                            {
                                sqlCon.Open();
                                SqlCommand sql_cmnd = new SqlCommand("ContributionsPortal_ins", sqlCon);
                                sql_cmnd.CommandType = CommandType.StoredProcedure;
                                sql_cmnd.Parameters.AddWithValue("@MemberID", SqlDbType.Int).Value = my.MemberID;
                                sql_cmnd.Parameters.AddWithValue("@NationalID", SqlDbType.Int).Value = my.NationalID;
                                sql_cmnd.Parameters.AddWithValue("@Period", SqlDbType.Int).Value = my.Period;
                                sql_cmnd.Parameters.AddWithValue("@RegNo", SqlDbType.Int).Value = my.RegNo;
                                sql_cmnd.Parameters.AddWithValue("@TransID", SqlDbType.Int).Value = my.TransID;
                                sql_cmnd.Parameters.AddWithValue("@Salary", SqlDbType.Int).Value = my.Salary;
                                sql_cmnd.Parameters.AddWithValue("@XContribution", SqlDbType.Int).Value = my.XContribution;
                                sql_cmnd.Parameters.AddWithValue("@ZContribution", SqlDbType.Int).Value = my.ZContribution;
                                sql_cmnd.Parameters.AddWithValue("@GrossYContribution", SqlDbType.Int).Value = my.GrossYContribution;
                                sql_cmnd.Parameters.AddWithValue("@Expenses", SqlDbType.Int).Value = my.Expenses;
                                sql_cmnd.Parameters.AddWithValue("@YContribution", SqlDbType.Bit).Value = my.YContribution;
                                sql_cmnd.Parameters.AddWithValue("@ExpectedX", SqlDbType.Decimal).Value = my.ExpectedX;
                                sql_cmnd.Parameters.AddWithValue("@ExpectedY", SqlDbType.Int).Value = my.ExpectedY;
                                sql_cmnd.Parameters.AddWithValue("@UserID", SqlDbType.Int).Value = my.UserID;
                                sql_cmnd.Parameters.AddWithValue("@isStartup", SqlDbType.Int).Value = my.isStartup;
                                sql_cmnd.Parameters.AddWithValue("@IsHistory", SqlDbType.Int).Value = my.IsHistory;
                                sql_cmnd.Parameters.AddWithValue("@BonusTypeID", SqlDbType.Int).Value = my.BonusTypeID;
                                sql_cmnd.Parameters.AddWithValue("@BranchCode", SqlDbType.Int).Value = my.BranchCode;
                                sql_cmnd.Parameters.AddWithValue("@Platform", SqlDbType.Int).Value = my.Platform;
                                sql_cmnd.Parameters.AddWithValue("@CompanyID", SqlDbType.Decimal).Value = my.CompanyID;
                                sql_cmnd.Parameters.AddWithValue("@BatchNo", SqlDbType.Decimal).Value = my.BatchNo;
                                sql_cmnd.Parameters.AddWithValue("@PeriodDate", SqlDbType.Decimal).Value = my.PeriodDate;
                                sql_cmnd.Parameters.AddWithValue("@PaymentDate", SqlDbType.Decimal).Value = my.PaymentDate;
                                sql_cmnd.Parameters.AddWithValue("@LatestUpdateDate", SqlDbType.DateTime).Value = my.LatestUpdateDate;
                                sql_cmnd.Parameters.AddWithValue("@BackPay", SqlDbType.DateTime).Value = my.BackPay;
                                sql_cmnd.Parameters.AddWithValue("@DateCaptured", SqlDbType.DateTime).Value = my.DateCaptured;
                                sql_cmnd.Parameters.AddWithValue("@DateSplitted", SqlDbType.DateTime).Value = my.DateSplitted;
                                sql_cmnd.Parameters.AddWithValue("@Total", SqlDbType.DateTime).Value = my.Total;
                                sql_cmnd.ExecuteNonQuery();
                                sqlCon.Close();
                            }
                            updatecontributionupload(uploadID);
                            //To be posted to accounts
                            //LoadedMemberPort = LoadedMemberPort + MemberPort;
                            //LoadedEmployerPort = LoadedEmployerPort + EmployerPort;
                            //Stabilization = Stabilization + Expenses;
                            //AVC = AVC + VoluntaryContributions;
                        }

                        //Post Contributions to Accounts
                        //string Period = cboPeriod.SelectedItem.Text + "/" + cboMonths.SelectedValue;
                        //string ActualRef = cboPeriod.SelectedItem.Text + "/" + cboMonths.SelectedValue + " Actual";
                        //double TotalUploadValue = LoadedMemberPort + LoadedEmployerPort + Stabilization + AVC;

                        //DateTime postDate = DateTime.Today;
                        //string entryPostDate = "";
                        //if (DateTime.TryParse(txtPaymentDate.Text, out DateTime pstdt))
                        //{

                        //    entryPostDate = (new DateTime(DateTime.Parse(txtPaymentDate.Text).Year, DateTime.Parse(txtPaymentDate.Text).Month, 1)).ToString();
                        //}
                        //else
                        //{
                        //    entryPostDate = (new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1)).ToString();
                        //}
                        //DateTime pstDate = DateTime.Parse(entryPostDate).AddMonths(1).AddDays(-1);

                        //DateTime entryDate = pstDate; //DateTime.Parse(DateTime.Today.Month + "/" + DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month) + "/" + DateTime.Today.Month);
                        //tt.PostTransactions(RegNo, entryDate, int.Parse(cboCompany.SelectedValue), Convert.ToDouble(LoadedMemberPort), Convert.ToDouble(LoadedEmployerPort), Convert.ToDouble(AVC), Convert.ToDouble(Stabilization), DateofUpload, cboCompany.SelectedItem.Text, DateofUpload, ActualRef, false, Memberid.ToString(), cbobranch.SelectedItem.Text, reference, Userid);
                        //tt.UploadUnreceiptedAmount(RegNo, int.Parse(cboCompany.SelectedValue), Period, perioddate, paymentdate, Convert.ToDouble(TotalUploadValue), cboCompany.SelectedItem.Text);


                        //delete failed contributions in temp table
                        //DeleteFailedontributionupload(RegNo);

                        SuccessAlert("Contributions Processed Successfully and awaiting approval");
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Contributions uploaded Successfully')", true);
                        Clear();
                        //DeleteFailedontributionupload(RegNo);
                      
                        lblBalancing.Text = "Balancing Status: -";

                        lstWrkSheets.Items.Clear();
                        grdMatchAccounts.DataSource = null;
                        grdMatchAccounts.DataBind();

                    }
                    else
                    {
                        //RedAlert("Selected batch has not contributions pending upload");
                        WarningAlert("Selected batch has not contributions pending upload");
                    }
                }

            }
            catch (Exception ex)
            {
                RedAlert(ex.Message);
                //var st = new System.Diagnostics.StackTrace(ex, true);
                //// Get the top stack frame
                //var frame = st.GetFrame(0);
                //// Get the line number from the stack frame
                //var line = frame.GetFileLineNumber();
                //var lineNumber = 0;
                //const string lineSearch = ":line ";
                //var index = ex.StackTrace.LastIndexOf(lineSearch);
                //if (index != -1)
                //{
                //    var lineNumberText = ex.StackTrace.Substring(index + lineSearch.Length);
                //    if (int.TryParse(lineNumberText, out lineNumber))
                //    {
                //    }
                //}
                ////return lineNumber;
                //msgbox(lineNumber.ToString() + ex);
            }
        }
        public void Clear()
        {
            txtPaymentDate.Text = "";
            cboCompany.SelectedItem.Text = "";
            cbobranch.SelectedItem.Value = "0";
            cboPeriod.SelectedItem.Text = "";
            lstWrkSheets.SelectedItem.Text = "";
            cboMonths.SelectedItem.Text = "";
            txtRecordsCount.Text = "0";
            txtSalaryBill.Text = "";
            txtMemberActual.Text = "";
            txtEmployerActual.Text = "";
            txtExpectedMember.Text = "";
            txtExpectedEmployer.Text = "";
            txtTransferInMember.Text = "";
            txtTransferInEmployer.Text = "";
            txtOtherMember.Text = "";
            txtOtherEmployer.Text = "";



        }
        //private void DeleteFailedontributionupload(string tid)
        //{
        //    myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        //    cmd = new SqlCommand("Delete from FailedContributionUploads where RegNo ='" + tid + "'", myConnection);

        //    if ((myConnection.State == ConnectionState.Open))
        //        myConnection.Close();
        //    myConnection.Open();
        //    cmd.ExecuteNonQuery();
        //    myConnection.Close();
        //}
        private void updatecontributionupload(int tid)
        {
            myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            cmd = new SqlCommand("update ContributionsFileUpload set Isprocessed ='1'  where UploadBatchID ='" + tid + "' ", myConnection);

            if ((myConnection.State == ConnectionState.Open))
                myConnection.Close();
            myConnection.Open();
            cmd.ExecuteNonQuery();
            myConnection.Close();
        }
        protected void grdMatchAccounts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdMatchAccounts.PageIndex = e.NewPageIndex;
           
            this.BindGrid();
        }

        private void BindGrid()
        {
            
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            UploadContributions();
        }

        protected void btnDiscard_Click(object sender, EventArgs e)
        {
            LookUp f = new LookUp("cn", 1);
            string RegNo = f.getRegNo(long.Parse(txtFundID.Value));
            Deletecontributionupload(RegNo);
            DeleteFailedcontributionupload(RegNo);
            Response.Redirect(string.Format("ContributionsUploads?FundID={0}&SystemRef={1}", txtFundID.Value,txtSystemRef.Value));
            grdMatchAccounts.DataSource = null;
            grdMatchAccounts.DataBind();
            grdMatchAccounts.Visible = false;
        }

        private void Deletecontributionupload(string reg)
        {
            myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            cmd = new SqlCommand("Delete from ContributionsFileUpload where RegNo='" + reg + "' and Isprocessed=0 and batchNo ='" + txtBatchNo.Value.ToString() + "'", myConnection);
            if ((myConnection.State == ConnectionState.Open))
                myConnection.Close();
            myConnection.Open();
            cmd.ExecuteNonQuery();
            myConnection.Close();
        }
        private void DeleteFailedcontributionupload(string reg)
        {
            myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            cmd = new SqlCommand("Delete from FailedContributionUploads where RegNo='" + reg + "'", myConnection);
            if ((myConnection.State == ConnectionState.Open))
                myConnection.Close();
            myConnection.Open();
            cmd.ExecuteNonQuery();
            myConnection.Close();
        }

        protected void grdUploadError_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            byte[] bytes = null;
            string fileName = null;
            string contentType = null;
            string constr = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT Name, Data,ContentType FROM ContributionsUploadTemplate";
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        if ((sdr.HasRows))
                        {
                            bytes = (byte[])sdr["Data"];
                            contentType = sdr["ContentType"].ToString();
                            fileName = sdr["Name"].ToString();
                        }
                        else
                        {
                            bytes = null;
                            contentType = null;
                            fileName = string.Empty;
                        }

                    }
                    con.Close();
                }
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = contentType;
                Response.AddHeader("content-disposition", "attachment;filename=\"" + fileName + "");
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }
        }
    }
}