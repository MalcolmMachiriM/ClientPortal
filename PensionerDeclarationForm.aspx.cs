using PenPortfolio.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PenPortfolio
{
    public partial class PensionerDeclarationForm : System.Web.UI.Page
    {
        public SqlConnection myConnection = new SqlConnection();
        public SqlDataAdapter adp;
        public SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                txtFundID.Value = "0";
                txtMemberIDs.Value = "0";
                txtSystemRef.Value = "0";
                ClearAlert();
                //getSearchOptions();
                if (Request.QueryString["FundID"] != null)
                {
                    txtFundID.Value = Request.QueryString["FundID"].ToString();
                }
                if (Request.QueryString["SystemRef"] != null)
                {
                    txtSystemRef.Value = Request.QueryString["SystemRef"].ToString();
                }
                if (Request.QueryString["MemberID"] != null)
                {
                    txtMemberIDs.Value = Request.QueryString["MemberID"].ToString();
                }

                getEmployees(int.Parse(txtMemberIDs.Value));
                getSearchOptions();
                getSavedDocuments();
            }
        }
        protected void getSearchOptions()
        {
            try
            {
                LookUp lookUp = new LookUp("cn", 1);
                if (lookUp.getDocumentTypes() != null)
                {
                    ListItem li = new ListItem("Select a document name", "0");
                    cboDocument.DataSource = lookUp.getDocumentTypes();
                    cboDocument.DataValueField = "ID";
                    cboDocument.DataTextField = "IdentityDocument";
                    cboDocument.DataBind();
                    cboDocument.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no document names available", "0");
                    cboDocument.DataSource = null;

                    cboDocument.DataBind();
                    cboDocument.Items.Insert(0, li);
                }


            }
            catch (Exception ex)
            {
                RedAlert(ex.Message);
            }
        }
        protected void getEmployees(int MemberID)
        {
            try
            {
                Model.LookUp t = new Model.LookUp("cn", 1);

                if (t.getPensionerbASICdETAILS(MemberID) != null)
                {
                    DataRow rw = t.getPensionerbASICdETAILS(MemberID).Tables[0].Rows[0];
                    txtPensioner.Text = $"{rw["FirstName"].ToString()} {rw["LastName"].ToString()}";
                    txtID.Text = MemberID.ToString();
                    txtPensionBasis.Text = rw["PensionBasis"].ToString();
                    DateTime currentDate = DateTime.Now.AddYears(1);
                    string dt = currentDate.Year.ToString();

                    txtYear.Text = dt;

                    //txtSurname.Text = rw["LastName"].ToString();
                    //txtNationalID.Text = rw["NationalID"].ToString();
                    //txtDOB.Text = rw["DateOfBirth"].ToString();
                    //txtMobile1.Text = rw["MobileNo"].ToString();
                    //txtMobile2.Text = rw["TelephoneNo"].ToString();
                    //txtEmail.Text = rw["Email"].ToString();
                    txtPensionBasis.Text = rw["PensionBasis"].ToString();
                    //txtPensionType.Text = rw["PensionType"].ToString();
                    //txtPaymentPeriod.Text = rw["PayPeriod"].ToString();

                    //txtAccountNo.Text = rw["BankAccountNo"].ToString();
                    //txtMonthlySalary.Text = rw["MonthlySalary"].ToString();
                    //txtDJP.Text = rw["DateJoinedPayroll"].ToString();
                    //txtPSD.Text = rw["PensionStartDate"].ToString();
                    //txtED.Text = rw["LastExistanceDate"].ToString();
                    //drpBank.SelectedItem.Text = rw["BankName"].ToString();
                    //drpBranch.SelectedItem.Text = rw["BankBranchName"].ToString();
                    //txtStatus.Text = rw["Active"].ToString();


                }
                if (t.getPensionerDetails(MemberID) != null)
                {
                    DataRow rw = t.getPensionerDetails(MemberID).Tables[0].Rows[0];
                    //txtLastSalary.Text = rw["NetSalary"].ToString();
                    //txtLastPaymentDate.Text = rw["LastPayDate"].ToString();
                    //txtPaySlipType.Text = rw["PayslipType"].ToString();
                }
            }
            catch (Exception ex)
            {
                RedAlert(ex.Message);
            }
        }
        protected void getSavedDocuments()
        {
            try
            {
                LookUp c = new LookUp("cn", 1);
                string RegNo = c.getRegNo(int.Parse(txtFundID.Value));

                if (c.getMemberDocuments(int.Parse(txtMemberIDs.Value), int.Parse(txtSystemRef.Value)) != null)
                {
                    grdDocuments.DataSource = c.getMemberDocuments(int.Parse(txtMemberIDs.Value), int.Parse(txtSystemRef.Value));
                    grdDocuments.DataBind();
                    //btnExport.Visible = true;


                }
                else
                {
                    grdDocuments.DataSource = null;
                    grdDocuments.DataBind();
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

        protected void grdEmployees_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdEmployees_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void btnDeclare_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("PensionerDeclarationForm?FundID={0}&SystemRef={1}", txtFundID.Value, txtSystemRef.Value));
        }

        protected void btnLogQuery_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("EmployerQueryLog?FundID={0}&SystemRef={1}", txtFundID.Value, txtSystemRef.Value));
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            Model.LookUp t = new Model.LookUp("cn", 1);
            String RegNo = t.getRegNo(int.Parse(txtFundID.Value));
            if ((FileUpload1.HasFile))
            {
               
            }
            else
            {
                //AmberAlert("Please select a document to upload");
                WarningAlert("Please select a document to upload");
                return;
            }

            if ((int.TryParse(cboDocument.SelectedValue, out int xi) == false) || int.Parse(cboDocument.SelectedValue) <= 0)
            {
                //RedAlert("Please select a document type");
                WarningAlert("Please select a document type");
                return;
            }
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string contentType = FileUpload1.PostedFile.ContentType;
            long PensionNo = int.Parse(txtMemberIDs.Value);
            long DocTypeID = int.Parse(cboDocument.SelectedValue);
            using (Stream fs = FileUpload1.PostedFile.InputStream)
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    string constr = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(constr))
                    {

                        string query = "insert into [Portal_Documents] values (@Name, @ContentType, @Data,@PensionNo,@YearOfDeclaration,@DocTypeID,@DateCreated,@CreatedBy,@RegNo)";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Connection = con;
                            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = filename;
                            cmd.Parameters.Add("@ContentType", SqlDbType.VarChar).Value = contentType;
                            cmd.Parameters.Add("@Data", SqlDbType.Binary).Value = bytes;
                            cmd.Parameters.Add("@PensionNo", SqlDbType.NVarChar).Value = PensionNo;
                            cmd.Parameters.Add("@YearOfDeclaration", SqlDbType.NVarChar).Value = txtYear.Text;
                            cmd.Parameters.Add("@DocTypeID", SqlDbType.Int).Value = DocTypeID;
                            cmd.Parameters.Add("@DateCreated", SqlDbType.DateTime).Value = DateTime.Today;
                            cmd.Parameters.Add("@CreatedBy ", SqlDbType.Int).Value = txtSystemRef.Value;
                            cmd.Parameters.Add("@RegNo ", SqlDbType.NVarChar).Value = RegNo;
                            //cmd.Parameters.Add("@logo ", SqlDbType.Image).Value = bytes;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();

                        }
                    }
                }
            }

            //BindGrid();
            getSavedDocuments();
            SuccessAlert("Declaration Documents Uploaded Successfully");
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Clients Documents uploaded Successfully');window.location ='./MemberDocuments.aspx?FundID=" + txtFundID.Value + "&MemberID=" + txtMemberID.Value + "';", true);
        }

        protected void grdDocuments_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grdDocuments_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "selectrecord")
            {
                int index = 0;
                string ssnSelect = "";
                GridViewRow row;
                GridView grid = sender as GridView;
                index = Convert.ToInt32(e.CommandArgument);
                download(int.Parse(txtMemberIDs.Value), index);

            }
            if (e.CommandName == "deleterecord")
            {
                //Fund f = new Fund("cn", 1);
                int index = 0;
                string ssnSelect = "";
                GridViewRow row;
                GridView grid = sender as GridView;
                index = Convert.ToInt32(e.CommandArgument);

                myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                cmd = new SqlCommand("Delete from Portal_Documents where ID ='" + index + "'", myConnection);
                if ((myConnection.State == ConnectionState.Open))
                    myConnection.Close();
                myConnection.Open();
                cmd.ExecuteNonQuery();
                myConnection.Close();
                SuccessAlert("Document deleted Successfully");
            }
        }

        protected void download(int id, int AppID)
        {
            byte[] bytes = null;
            string fileName = null;
            string contentType = null;
            string constr = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT Name, Data,ContentType FROM Portal_Documents WHERE PensionNo=@PensionNo and ID=@AppID";
                    cmd.Parameters.AddWithValue("@PensionNo", id);
                    cmd.Parameters.AddWithValue("@AppID", AppID);
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