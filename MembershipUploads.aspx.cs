using Microsoft.Practices.EnterpriseLibrary.Data;
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
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PenPortfolio
{
    public partial class MembershipUploads : System.Web.UI.Page
    {
        public static DataSet dsuld = new DataSet();
        public static DataSet MatchedAccounts;
        public static DataSet NewAccounts;
        public static DataSet UnmacthedTrades;
        static DataSet dsReady = new DataSet();
        static DataSet dsErrored = new DataSet();
        private cn db = new cn();
        public SqlConnection myConnection = new SqlConnection();
        public SqlDataAdapter adp;
        public SqlCommand cmd;
        double countSuccess = 0;
        double SumSuccess = 0;
        double SumFailed = 0;
        double countFailed = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                txtFundID.Value = "0";
                txtSystemRef.Value = "0";
                txtbatchID.Value = "0";
                
                if (Request.QueryString["FundID"] != null)
                {
                    txtFundID.Value = Request.QueryString["FundID"].ToString();
                }
                if (Request.QueryString["SystemRef"] != null)
                {
                    txtSystemRef.Value = Request.QueryString["SystemRef"].ToString();
                }
                getFundCompanies();
                ClearAlert();
            }
        }
        protected void getFundCompanies()
        {
            try
            {
                LookUp f = new LookUp("cn", 1);

                string RegNo = f.getRegNo(int.Parse(txtFundID.Value));
                if (f.Get_Participarting_Employer(txtSystemRef.Value,RegNo) != null)
                {
                    ListItem li = new ListItem("All Branches", "0");
                    cboCompany.DataSource = f.Get_Participarting_Employer(txtSystemRef.Value, RegNo);
                    cboCompany.DataValueField = "ID";
                    cboCompany.DataTextField = "Name";
                    cboCompany.DataBind();
                    cboCompany.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no Branches", "0");
                    cboCompany.DataSource = null;
                    cboCompany.DataBind();
                    cboCompany.Items.Insert(0, li);
                }
            }
            catch (Exception ex)
            {
                RedAlert(ex.Message);
            }
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                UploadFile();
            }
            catch (Exception ex)
            {
                RedAlert(ex.Message);
            }
        }

        protected void lstWrkSheets_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReadExcelFiletoDataset(txtFilePath.Text, lstWrkSheets.SelectedItem.Text, txtFileName.Text);
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
                    //lblComms.Text = "select a worksheet to continue";
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
                    dsuld = ds;
                    ProcessUploadData(dsuld, FileName, int.Parse(cboCompany.SelectedValue), cboCompany.SelectedItem.Text.ToString());
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
                lblDanger.Text= ex.ToString();
                return;
            }
        }
        protected void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessNewEntrantsRecords();

            }
            catch (Exception ex)
            {
                RedAlert(ex.Message);
            }
        }

        protected void ProcessUploadData(DataSet Ds, string FileUploadName, int CompanyID, string CompanyName)
        {
            try
            {
                long BatchUploadID = 0;
                List<double> CountSuccessArray = new List<double>();
                List<double> CountFailedArray = new List<double>();
                if ((dsReady != null))
                {
                    //We Create BatchUpload Record and Get Batch ID
                    Model.LookUp ebu = new Model.LookUp("cn", 1);
                    //Data.EmployeesUploadBatch ba = new Data.EmployeesUploadBatch();
                    ////ebu.EmployerID = CompanyID;
                    //ba.EmployerID = CompanyID;
                    //ba.BulkUploadFile = FileUploadName;
                    //ba.DateCreated = DateTime.Now;
                    //ba.DateUpload = DateTime.Now.Date;
                    //ba.UploadStatus = 1;
                    //db.EmployeesUploadBatches.Add(ba);
                    //db.SaveChanges();
                    //
                    string DatesCreated = DateTime.Now.ToString("yyyy-MM-dd");
                    myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                    cmd = new SqlCommand("insert into EmployeesUploadBatch(EmployerID,BulkUploadFile,DateCreated,DateUpload,UploadStatus) values('"+ CompanyID + "','"+ FileUploadName + "','"+ DatesCreated + "','" + DatesCreated + "','1')", myConnection);

                    if ((myConnection.State == ConnectionState.Open))
                        myConnection.Close();
                    myConnection.Open();
                    cmd.ExecuteNonQuery();
                    myConnection.Close();


                    DataSet y = ebu.GetUploadedEmployee(CompanyID);

                    foreach (DataRow rwset in y.Tables[0].Rows)
                    {
                        txtbatchID.Value = rwset["ID"].ToString();
                        //MemberRate = double.Parse(rwset["MemberContPerc"].ToString());

                    }

                 
                    DataSet x = null;
                    DataSet getFailed = null;
                    //EmployeeRecordsUploadDummy TI = new EmployeeRecordsUploadDummy("cn", 1);

                    //Model.Client c = new Model.Client("cn", 1);
                    LookUp f = new LookUp("cn", 1);
                    string RegNo = f.getRegNo(long.Parse(txtFundID.Value));
                    string Regname = f.getRegName(long.Parse(txtFundID.Value));
                    //string getusername = Session["username"].ToString();
                    int userid = int.Parse(txtSystemRef.Value);
                    foreach (DataRow rw in Ds.Tables[0].Rows)
                    {
                        //Model.ParticipatingEmployer pe = new Model.ParticipatingEmployer("cn", 1);

                        if (Int32.TryParse(rw[0].ToString(), out int vv))
                        {
                            if (rw[6].ToString().Trim() != "")
                            {
                                rw[6] = rw[6].ToString().Replace("-", "").Replace(" ", "");
                            }
                            if (rw[6].ToString() == "")
                            {
                                string dt = DateTime.Now.ToString("yyyy-MM-dd");
                                string Msg = $"National ID is missing for LastName {rw[4].ToString()} ,FirstName: {rw[5].ToString()} of Branch: {rw[0].ToString()}, Fund {Regname}";
                                myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                                cmd = new SqlCommand("insert into FailedMemberUploads(NationalID,RegNo,Description,BranchCode,DateCreated,CreatedBy) values('0','" + RegNo + "','" + Msg + "','" + rw[0].ToString() + "','" + dt + "','" + userid + "')", myConnection);
                                if ((myConnection.State == ConnectionState.Open))
                                    myConnection.Close();
                                myConnection.Open();
                                cmd.ExecuteNonQuery();
                                myConnection.Close();
                                double branchcode = double.Parse(rw[0].ToString());

                                for (int runs = 0; runs < 1; runs++)
                                {
                                    CountFailedArray.Add(branchcode);
                                }
                                continue;
                              
                            }
                            else if (rw[4].ToString() == "" || rw[5].ToString() == "")
                            {
                                string dt = DateTime.Now.ToString("yyyy-MM-dd");
                                string Msg = $"Specify both first name and surname for NationalID {rw[6].ToString()} of Branch: {rw[0].ToString()}, Fund {Regname}";
                                myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                                cmd = new SqlCommand("insert into FailedMemberUploads(NationalID,RegNo,Description,BranchCode,DateCreated,CreatedBy) values('" + rw[6].ToString() + "','" + RegNo + "','" + Msg + "','" + rw[0].ToString() + "','" + dt + "','" + userid + "')", myConnection);
                                if ((myConnection.State == ConnectionState.Open))
                                    myConnection.Close();
                                myConnection.Open();
                                cmd.ExecuteNonQuery();
                                myConnection.Close();
                                double branchcode = double.Parse(rw[0].ToString());

                                for (int runs = 0; runs < 1; runs++)
                                {
                                    CountFailedArray.Add(branchcode);
                                }
                                continue;
                            }
                            else if (Convert.ToDateTime(rw[7].ToString()).ToString() == "")
                            {
                                string dt = DateTime.Now.ToString("yyyy-MM-dd");
                                string Msg = $"Date of birth is missing for NationalID {rw[6].ToString()} of Branch: {rw[0].ToString()}, Fund {Regname}";
                                myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                                cmd = new SqlCommand("insert into FailedMemberUploads(NationalID,RegNo,Description,BranchCode,DateCreated,CreatedBy) values('" + rw[6].ToString() + "','" + RegNo + "','" + Msg + "','" + rw[0].ToString() + "','" + dt + "','" + userid + "')", myConnection);
                                if ((myConnection.State == ConnectionState.Open))
                                    myConnection.Close();
                                myConnection.Open();
                                cmd.ExecuteNonQuery();
                                myConnection.Close();
                                double branchcode = double.Parse(rw[0].ToString());

                                for (int runs = 0; runs < 1; runs++)
                                {
                                    CountFailedArray.Add(branchcode);
                                }
                                continue;
                            }
                            else if (Convert.ToDateTime(rw[9].ToString()).ToString() == "")
                            {
                                string dt = DateTime.Now.ToString("yyyy-MM-dd");
                                string Msg = $"Specify Date of joining fund for NationalID {rw[6].ToString()} of Branch: {rw[0].ToString()}, Fund {Regname}";
                                myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                                cmd = new SqlCommand("insert into FailedMemberUploads(NationalID,RegNo,Description,BranchCode,DateCreated,CreatedBy) values('" + rw[6].ToString() + "','" + RegNo + "','" + Msg + "','" + rw[0].ToString() + "','" + dt + "','" + userid + "')", myConnection);
                                if ((myConnection.State == ConnectionState.Open))
                                    myConnection.Close();
                                myConnection.Open();
                                cmd.ExecuteNonQuery();
                                myConnection.Close();
                                double branchcode = double.Parse(rw[0].ToString());

                                for (int runs = 0; runs < 1; runs++)
                                {
                                    CountFailedArray.Add(branchcode);
                                }
                                continue;
                            }
                            else if (rw[0].ToString() == "")
                            {
                                string dt = DateTime.Now.ToString("yyyy-MM-dd");
                                string Msg = $"Specify Branch code for NationalID {rw[6].ToString()}, Fund {Regname}";
                                myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                                cmd = new SqlCommand("insert into FailedMemberUploads(NationalID,RegNo,Description,BranchCode,DateCreated,CreatedBy) values('" + rw[6].ToString() + "','" + RegNo + "','" + Msg + "','" + rw[0].ToString() + "','" + dt + "','" + userid + "')", myConnection);
                                if ((myConnection.State == ConnectionState.Open))
                                    myConnection.Close();
                                myConnection.Open();
                                cmd.ExecuteNonQuery();
                                myConnection.Close();
                                double branchcode = double.Parse(rw[0].ToString());

                                for (int runs = 0; runs < 1; runs++)
                                {
                                    CountFailedArray.Add(branchcode);
                                }
                                continue;
                            }
                            else if (rw[8].ToString() == "")
                            {
                                string dt = DateTime.Now.ToString("yyyy-MM-dd");
                                string Msg = $"Gender is missing for NationalID {rw[6].ToString()} of Branch: {rw[0].ToString()}, Fund {Regname}";
                                myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                                cmd = new SqlCommand("insert into FailedMemberUploads(NationalID,RegNo,Description,BranchCode,DateCreated,CreatedBy) values('" + rw[6].ToString() + "','" + RegNo + "','" + Msg + "','" + rw[0].ToString() + "','" + dt + "','" + userid + "')", myConnection);
                                if ((myConnection.State == ConnectionState.Open))
                                    myConnection.Close();
                                myConnection.Open();
                                cmd.ExecuteNonQuery();
                                myConnection.Close();
                                double branchcode = double.Parse(rw[0].ToString());

                                for (int runs = 0; runs < 1; runs++)
                                {
                                    CountFailedArray.Add(branchcode);
                                }

                                continue;
                            }
                            else
                            {
                                if (f.ValidateMemberIDNumber(rw[6].ToString(), RegNo))
                                {
                                    string dt = DateTime.Now.ToString("yyyy-MM-dd");
                                    string Msg = $"Duplicate National Identity number: {rw[6].ToString()}. ID already exists for member: {rw[4].ToString()} {rw[5].ToString()} under Fund {Regname}";
                                    myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                                    cmd = new SqlCommand("insert into FailedMemberUploads(NationalID,RegNo,Description,BranchCode,DateCreated,CreatedBy) values('" + rw[6].ToString() + "','" + RegNo + "','" + Msg + "','" + rw[0].ToString() + "','" + dt + "','" + userid + "')", myConnection);
                                    if ((myConnection.State == ConnectionState.Open))
                                        myConnection.Close();
                                    myConnection.Open();
                                    cmd.ExecuteNonQuery();
                                    myConnection.Close();

                                    double branchcode = double.Parse(rw[0].ToString());

                                    for (int runs = 0; runs < 1; runs++)
                                    {
                                        CountFailedArray.Add(branchcode);
                                    }

                                    continue;
                                }
                                else
                                {
                                    //Insert into new table ClientUploads
                                    int AddNewClientRecord = 1;
                                    int AddNewMemberRecord = 1;
                                    //ClientsFileUpload my = new ClientsFileUpload();
                                    //my.BranchCode = rw[0].ToString();
                                    //my.EmployerName = rw[1].ToString();
                                    //my.membershipcategory = Convert.ToInt32(rw[2].ToString());
                                    //my.EmployeeNumber = rw[3].ToString();
                                    //my.Surname = rw[4].ToString();
                                    //my.Forenames = rw[5].ToString();
                                    //my.IDNumber = rw[6].ToString();
                                    //my.DateOfBirth = Convert.ToDateTime(rw[7].ToString());
                                    //my.Gender = rw[8].ToString();
                                    //if (my.Gender == "Male")
                                    //{
                                    //    my.Gender = "M";
                                    //}
                                    //else if (my.Gender == "Female")
                                    //{
                                    //    my.Gender = "F";
                                    //}
                                    //else
                                    //{
                                    //    my.Gender = rw[8].ToString();
                                    //}
                                    //string text = txtDateOfUpload.ToString();
                                    //string dateString = txtDateOfUpload.Text;

                                    //my.DateJoinedCompany = Convert.ToDateTime(rw[9].ToString());
                                    //my.PensionableserviceDate = Convert.ToDateTime(rw[10].ToString());
                                    //my.CompanyID = CompanyID;
                                    //my.DateOfUpload = Convert.ToDateTime(txtDateOfUpload.Text);
                                    //my.DateCreated = Convert.ToDateTime(txtDateOfUpload.Text);
                                    //my.UploadBatchID = Convert.ToInt32(txtbatchID.Value);
                                    //my.RegNo = RegNo;
                                    //my.CreatedBy = userid;
                                    //my.ProcessStatusID = false;
                                    //my.addnewclientrecord = AddNewClientRecord;
                                    //my.addnewmeberrecord = AddNewMemberRecord;
                                    //db.ClientsFileUploads.Add(my);
                                    //db.SaveChanges(); //save to database


                                    DateTime DJC = Convert.ToDateTime(rw[9].ToString());
                                    DateTime PSD = Convert.ToDateTime(rw[10].ToString());
                                    DateTime DOB = Convert.ToDateTime(rw[7].ToString());
                                    DateTime DC = Convert.ToDateTime(txtDateOfUpload.Text);
                                    string DJCs = DJC.ToString("yyyy-MM-dd");
                                    string DOBs = DOB.ToString("yyyy-MM-dd");
                                    string PSDs = PSD.ToString("yyyy-MM-dd");
                                    string DCs = DC.ToString("yyyy-MM-dd");
                                    if (rw[8].ToString() == "Male" || rw[8].ToString() == "MALE")
                                    {
                                        rw[8] = "M";
                                    }
                                    else if(rw[8].ToString() == "Female" || rw[8].ToString() == "FEMALE")
                                    {
                                        rw[8] = "F";
                                    }
                                    //string vt = "insert into ClientsFileUpload(BranchCode,EmployerName,membershipcategory,EmployeeNumber,Surname,Forenames,IDNumber,DateOfBirth,Gender,DateJoinedCompany,PensionableserviceDate,CompanyID,DateOfUpload,DateCreated,UploadBatchID,RegNo,CreatedBy,ProcessStatusID,addnewclientrecord,addnewmeberrecord) values('" + rw[0].ToString() + "','" + rw[1].ToString() + "','" + Convert.ToInt32(rw[2].ToString()) + "','" + rw[3].ToString() + "','" + rw[4].ToString() + "','" + rw[5].ToString() + "','" + rw[6].ToString() + "','" + Convert.ToDateTime(rw[7].ToString()) + "','" + rw[8].ToString() + "','" + Convert.ToDateTime(rw[9].ToString()) + "','" + Convert.ToDateTime(rw[10].ToString()) + "','" + CompanyID + "','" + Convert.ToDateTime(txtDateOfUpload.Text) + "','" + Convert.ToDateTime(txtDateOfUpload.Text) + "','" + Convert.ToInt32(txtbatchID.Value) + "','" + RegNo + "','" + int.Parse(txtSystemRef.Value) + "','" + false + "','" + AddNewClientRecord + "','" + AddNewMemberRecord + "')";
                                    myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                                    cmd = new SqlCommand("insert into ClientsFileUpload(BranchCode,EmployerName,membershipcategory,EmployeeNumber,Surname,Forenames,IDNumber,DateOfBirth,Gender,DateJoinedCompany,PensionableserviceDate,CompanyID,DateOfUpload,DateCreated,UploadBatchID,RegNo,CreatedBy,ProcessStatusID,addnewclientrecord,addnewmeberrecord) values('"+ rw[0].ToString() + "','"+ rw[1].ToString() + "','"+ Convert.ToInt32(rw[2].ToString())+"','"+ rw[3].ToString() + "','"+ rw[4].ToString() + "','"+ rw[5].ToString() + "','"+ rw[6].ToString() + "','"+ DOBs + "','"+ rw[8].ToString() + "','"+ DJCs + "','"+ PSDs + "','"+ CompanyID + "','"+ DCs + "','"+ DCs + "','"+ Convert.ToInt32(txtbatchID.Value) + "','"+ RegNo + "','"+int.Parse(txtSystemRef.Value)+"','"+ false + "','"+ AddNewClientRecord + "','"+ AddNewMemberRecord + "')", myConnection);
                                    if ((myConnection.State == ConnectionState.Open))
                                        myConnection.Close();
                                    myConnection.Open();
                                    cmd.ExecuteNonQuery();
                                    myConnection.Close();

                                    double branchcode = double.Parse(rw[0].ToString());

                                    for (int runs = 0; runs < 1; runs++)
                                    {
                                        CountSuccessArray.Add(branchcode);
                                    }
                                }
                            }

                        }
                        else
                        {
                            break;
                        }

                    }
                    double[] totalSucessarray = CountSuccessArray.ToArray();
                    //SumSuccess = totalSucessarray.Sum();
                    countSuccess = totalSucessarray.Count();

                    double[] totalFailedarray = CountFailedArray.ToArray();
                    //SumFailed = totalFailedarray.Sum();
                    countFailed = totalFailedarray.Count();

                    if (totalFailedarray.Count() > 0)
                    {
                        lblWarning.Text = "Please check reason below for failed upload reason. Click reset to upload again";
                        //AmberAlert("Please check reason below for failed upload reason. Click reset to upload again");
                    }


                    lblCurrentMembers.Text = "Success Members: " + countSuccess.ToString("##,###,###.##");
                    lblFailedUploads.Text = "Failed Members: " + countFailed.ToString("##,###,###.##");

                    BatchUploadID = long.Parse(txtbatchID.Value);
                    x = f.getclientuploaded(BatchUploadID, RegNo);
                    getFailed = f.GetFailedMemberUploads(RegNo);

                    if (x != null)
                    {
                        grdClientsView.DataSource = x;
                        grdClientsView.DataBind();

                        grdClientsView.Visible = true;
                    }
                    else
                    {
                        grdClientsView.DataSource = null;
                        grdClientsView.DataBind();
                        grdClientsView.Visible = false;

                        //AmberAlert("Please upload a document with data");
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


                    //dsReady.Tables.Clear();
                    //dsReady.Tables.Add(dsReadyTransactions);
                    //SuccessMsg("Employee Records Uploaded");

                }
                else
                {

                    //lblDanger.Text = "Problem fetching processing data";
                    RedAlert("Problem fetching processing data");
                }
            }
            catch (Exception ex)
            {
                //lblDanger.Text = ex.Message;
                RedAlert(ex.Message);
            }
        }
        protected void ProcessNewEntrantsRecords()
        {
            try
            {

                LookUp f = new LookUp("cn", 1);
                string RegNo = f.getRegNo(int.Parse(txtFundID.Value));
                //string getusername = Session["username"].ToString();
                int userid = 0;
                int ids = int.Parse(txtbatchID.Value);
                DataSet clientupload = f.GetUploads(false, ids, RegNo);
                long ClientID = int.Parse(txtSystemRef.Value);

                if (clientupload != null)
                {
                    foreach (DataRow item in clientupload.Tables[0].Rows)
                    {
                        DataSet dsElig = new DataSet();
                        if (f.getFundEligibilityRequirements(RegNo) != null)
                        {
                            int Title_Id = 0;
                            Guid guid = Guid.NewGuid();
                            dsElig = f.getFundEligibilityRequirements(RegNo);
                            DataRow rwE = dsElig.Tables[0].Rows[0];
                            string constr = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                            SqlConnection sqlCon = null;
                            using (sqlCon = new SqlConnection(constr))
                            {
                                sqlCon.Open();
                                SqlCommand sql_cmnd = new SqlCommand("MemberPortal_ins", sqlCon);
                                sql_cmnd.CommandType = CommandType.StoredProcedure;
                                if (item["BranchCode"].ToString() == "F")
                                {
                                    Title_Id = 3;

                                }
                                else
                                {

                                    Title_Id = 1;
                                }
                                sql_cmnd.Parameters.AddWithValue("@ClientID", SqlDbType.Int).Value = Convert.ToInt32(ClientID);
                                sql_cmnd.Parameters.AddWithValue("@CompanyNo", SqlDbType.Int).Value = item["BranchCode"].ToString();
                                sql_cmnd.Parameters.AddWithValue("@Company_ID", SqlDbType.Int).Value = item["CompanyID"].ToString();
                                sql_cmnd.Parameters.AddWithValue("@BranchId", SqlDbType.Int).Value = item["BranchCode"].ToString();
                                sql_cmnd.Parameters.AddWithValue("@FundCategory_ID", SqlDbType.Int).Value = item["membershipcategory"].ToString();
                                sql_cmnd.Parameters.AddWithValue("@MaritalStatus_ID", SqlDbType.Int).Value = 1;
                                sql_cmnd.Parameters.AddWithValue("@AuthorisedBy", SqlDbType.Int).Value = 1;
                                sql_cmnd.Parameters.AddWithValue("@ModifiedBy", SqlDbType.Int).Value = int.Parse(txtSystemRef.Value);
                                sql_cmnd.Parameters.AddWithValue("@UploadedBy", SqlDbType.Int).Value = int.Parse(txtSystemRef.Value);
                                sql_cmnd.Parameters.AddWithValue("@SplittedID", SqlDbType.Int).Value = 0;
                                sql_cmnd.Parameters.AddWithValue("@AvcsTATUS", SqlDbType.Bit).Value = false;
                                sql_cmnd.Parameters.AddWithValue("@AVCMonthly", SqlDbType.Decimal).Value = 0;
                                sql_cmnd.Parameters.AddWithValue("@SplittedCompanyNo", SqlDbType.Int).Value = 0;
                                sql_cmnd.Parameters.AddWithValue("@NormalRetAge", SqlDbType.Int).Value = int.Parse(rwE["NormalRetirementAge"].ToString());
                                sql_cmnd.Parameters.AddWithValue("@Title_Id", SqlDbType.Int).Value = Title_Id;
                                sql_cmnd.Parameters.AddWithValue("@MonthsWaiting", SqlDbType.Int).Value = int.Parse(rwE["WaitingPeriod"].ToString());
                                sql_cmnd.Parameters.AddWithValue("@MonthsSuspended", SqlDbType.Int).Value = 0;
                                sql_cmnd.Parameters.AddWithValue("@IntExitCode", SqlDbType.Int).Value = 1;
                                sql_cmnd.Parameters.AddWithValue("@ExitCode", SqlDbType.Int).Value = -1;
                                sql_cmnd.Parameters.AddWithValue("@AnnualSalary", SqlDbType.Decimal).Value = 0;
                                sql_cmnd.Parameters.AddWithValue("@StartupMember", SqlDbType.Decimal).Value = 0;
                                sql_cmnd.Parameters.AddWithValue("@StartupEmployer", SqlDbType.Decimal).Value = 0;
                                sql_cmnd.Parameters.AddWithValue("@TotalStartup", SqlDbType.Decimal).Value = 0;
                                sql_cmnd.Parameters.AddWithValue("@DateOfBirth", SqlDbType.DateTime).Value = Convert.ToDateTime(item["DateOfBirth"].ToString());
                                sql_cmnd.Parameters.AddWithValue("@DateJoinedCompany", SqlDbType.DateTime).Value = Convert.ToDateTime(item["DateJoinedCompany"].ToString());
                                sql_cmnd.Parameters.AddWithValue("@PensionableServiceDate", SqlDbType.DateTime).Value = Convert.ToDateTime(item["PensionableserviceDate"].ToString());
                                sql_cmnd.Parameters.AddWithValue("@TranferInDate", SqlDbType.DateTime).Value = Convert.ToDateTime(item["PensionableserviceDate"].ToString());
                                sql_cmnd.Parameters.AddWithValue("@NormalRetDate", SqlDbType.DateTime).Value = Convert.ToDateTime((DateTime.Parse(item["DateOfBirth"].ToString()).AddYears(int.Parse(rwE["NormalRetirementAge"].ToString())).ToString()));
                                sql_cmnd.Parameters.AddWithValue("@DateModified", SqlDbType.DateTime).Value = Convert.ToDateTime(item["DateOfUpload"].ToString());
                                sql_cmnd.Parameters.AddWithValue("@DateUploaded", SqlDbType.DateTime).Value = Convert.ToDateTime(item["DateOfUpload"].ToString());
                                sql_cmnd.Parameters.AddWithValue("@DOBConfirmed", SqlDbType.Bit).Value = true;
                                sql_cmnd.Parameters.AddWithValue("@StatusID", SqlDbType.Int).Value = 1;
                                sql_cmnd.Parameters.AddWithValue("@Authorised", SqlDbType.Bit).Value = true;
                                sql_cmnd.Parameters.AddWithValue("@Active", SqlDbType.Bit).Value = true;
                                sql_cmnd.Parameters.AddWithValue("@IsDeferred", SqlDbType.Bit).Value = false;
                                sql_cmnd.Parameters.AddWithValue("@msrepl_tran_version", SqlDbType.UniqueIdentifier).Value = guid;
                                sql_cmnd.Parameters.AddWithValue("@RegNo", SqlDbType.NVarChar).Value = RegNo;
                                sql_cmnd.Parameters.AddWithValue("@Gender_ID", SqlDbType.NVarChar).Value = item["Gender"].ToString();
                                sql_cmnd.Parameters.AddWithValue("@EmployeeReferenceNumber", SqlDbType.NVarChar).Value = item["EmployeeNumber"].ToString();
                                sql_cmnd.Parameters.AddWithValue("@LastName", SqlDbType.NVarChar).Value = item["Surname"].ToString();
                                sql_cmnd.Parameters.AddWithValue("@FirstName", SqlDbType.NVarChar).Value = item["Forenames"].ToString();
                                sql_cmnd.Parameters.AddWithValue("@IdentityNo", SqlDbType.NVarChar).Value = item["IDNumber"].ToString();
                                sql_cmnd.Parameters.AddWithValue("@FundID", SqlDbType.Int).Value = int.Parse(txtFundID.Value);
                                sql_cmnd.ExecuteNonQuery();
                                sqlCon.Close();
                            }

                            updateclientupload(Convert.ToInt32(item["UploadBatchID"].ToString()));

                        }
                        else
                        {
                            lblWarning.Text = "Please Enter Eligibility Rules First";
                            //msgbox("Please Enter Eligibility Rules First");
                            return;
                        }
                    }

                }

                SuccessAlert("Details Processed Successfully and awaiting approval");
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Details Processed Successfully');window.location ='./Employees.aspx?FundID=" + int.Parse(txtFundID.Value) + "';", true);
            }
            catch (Exception ex)
            {
                //lblDanger.Text = ex.Message;
                RedAlert(ex.Message);

            }
        }

        private void updateclientupload(int tid)
        {
            myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            cmd = new SqlCommand("update ClientsFileUpload set ProcessStatusID ='1'  where UploadBatchID ='" + tid + "' ", myConnection);

            if ((myConnection.State == ConnectionState.Open))
                myConnection.Close();
            myConnection.Open();
            cmd.ExecuteNonQuery();
            myConnection.Close();
        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdClientsView.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }
        private void BindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            LookUp f = new LookUp("cn", 1);
            string RegNO = f.getRegNo(int.Parse(txtFundID.Value));
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT [ID],[EmployerName],[Surname],[Forenames],[IDNumber],[Gender],[DateOfBirth] FROM ClientsFileUpload where ProcessStatusID=0 and RegNo ='" + RegNO + "' and UploadBatchID='" + int.Parse(txtbatchID.Value) + "'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            grdClientsView.DataSource = dt;
                            grdClientsView.DataBind();
                        }
                    }
                }
            }
        }
        protected void btnDiscard_Click(object sender, EventArgs e)
        {
            LookUp f = new LookUp("cn", 1);
            string RegNo = f.getRegNo(long.Parse(txtFundID.Value));
            DeleteMemberupload(RegNo);
            DeleteFailedMemberupload(RegNo);
            Response.Redirect(string.Format("MembershipUploads?FundID={0}", txtFundID.Value));
            grdClientsView.DataSource = null;
            grdClientsView.DataBind();

            grdUploadError.DataSource = null;
            grdUploadError.DataBind();
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
        private void DeleteFailedMemberupload(string tid)
        {
            myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            cmd = new SqlCommand("Delete from FailedMemberUploads where RegNo ='" + tid + "'", myConnection);

            if ((myConnection.State == ConnectionState.Open))
                myConnection.Close();
            myConnection.Open();
            cmd.ExecuteNonQuery();
            myConnection.Close();
        }

        private void DeleteMemberupload(string reg)
        {
            myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            cmd = new SqlCommand("Delete from ClientsFileUpload where RegNo='" + reg + "' and ProcessStatusID=0 and UploadBatchID ='" + int.Parse(txtbatchID.Value) + "'", myConnection);
            if ((myConnection.State == ConnectionState.Open))
                myConnection.Close();
            myConnection.Open();
            cmd.ExecuteNonQuery();
            myConnection.Close();
        }

        protected void grdMatchAccounts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

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
        protected void download()
        {
            byte[] bytes = null;
            string fileName = null;
            string contentType = null;
            string constr = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                
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
                    cmd.CommandText = "SELECT Name, Data,ContentType FROM EntrantUploadTemplate";
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

        public static String[] GetFilesFrom(String searchFolder, String[] filters, bool isRecursive)
        {
            List<String> filesFound = new List<String>();
            var searchOption = isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            foreach (var filter in filters)
            {
                filesFound.AddRange(Directory.GetFiles(searchFolder, String.Format("*.{0}", filter), searchOption));
            }
            return filesFound.ToArray();
        }
    }
}