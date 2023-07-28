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
using PenPortfolio.Model;
namespace PenPortfolio
{
    public partial class EmployerQueryLog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Page.MaintainScrollPositionOnPostBack = true;
                if (!IsPostBack)
                {

                    ClearAlert();
                    txtRecID.Value = "0";
                    txtRoleType.Value = "0";
                    txtFund.Value = "0";
                    
                    GetQueryTypes();


                    if (Request.QueryString["SystemRef"] != "")
                    {
                        txtRecID.Value = Request.QueryString["SystemRef"].ToString();
                    }
                    if (Request.QueryString["FundID"] != "")
                    {
                        txtFund.Value = Request.QueryString["FundID"].ToString();
                    }


                    LoadPensionerDetails();
                    getCities();
                    getLoggedQueries();
                }
            }
            catch (Exception ex)
            {
                RedAlert(ex.Message);
            }
        }
        protected void LoadPensionerDetails()
        {
            try
            {
                PortalAccesssUsers pa = new PortalAccesssUsers("cn", 1);
                if (pa.PensionerLoginAccountDetails(int.Parse(txtRecID.Value), txtFund.Value) != null)
                {
                    DataRow rw = pa.PensionerLoginAccountDetails(int.Parse(txtRecID.Value), txtFund.Value).Tables[0].Rows[0];
                    //lblPensionerName.Text = rw["LastName"].ToString() + ' ' + rw["Firstname"].ToString();
                    lblLastPensionSalaryDate.Text = "Last Payment Date: " + rw["LastPaymentDate"].ToString() + " | Next Payroll Date: " + rw["NextRunDate"].ToString();
                }

            }
            catch (Exception ex)
            {
                RedAlert(ex.Message);
            }
        }
        protected void getLoggedQueries()
        {
            try
            {
                LookUp pa = new LookUp("cn", 1);
                string Type = "C";
                string RegNo = pa.getRegNo(int.Parse(txtFund.Value));
                if (pa.getQueries(int.Parse(txtRecID.Value), RegNo, Type) != null)
                {
                    DataRow rw = pa.getQueries(int.Parse(txtRecID.Value), RegNo, Type).Tables[0].Rows[0];
                    grdEmployees.DataSource = pa.getQueries(int.Parse(txtRecID.Value), RegNo, Type);
                    grdEmployees.DataBind();

                    //lblheader.Text = rw["Subject"].ToString();
                    //lblPayrollAccNo.Text = rw["DateCreated"].ToString();
                    //if (bool.Parse(rw["isSolved"].ToString()) == true)
                    //{
                    //    lblStatus.Text = "Actioned";
                    //    //lblStatus.col = Green;
                    //}
                    //else
                    //{
                    //    lblStatus.Text = "Pending Review";
                    //}
                    //lblLastPensionSalaryDate.Text = "Last Payment Date: " + rw["LastPaymentDate"].ToString() + " | Next Payroll Date: " + rw["NextRunDate"].ToString();
                }
                else
                {
                    grdEmployees.DataSource = null;
                    grdEmployees.DataBind();
                }
            }
            catch (Exception ex)
            {
                RedAlert(ex.Message);
            }
        }
        protected void GetQueryTypes()
        {
            try
            {
                PortalAccesssUsers pa = new PortalAccesssUsers("cn", 1);
                if (pa.getQueryTypes() != null)
                {
                    cboQueryType.DataSource = pa.getQueryTypes();
                    cboQueryType.DataValueField = "ID";
                    cboQueryType.DataTextField = "Description";
                    cboQueryType.DataBind();
                }
                else
                {
                    cboQueryType.DataSource = null;
                    cboQueryType.DataBind();
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
        protected void getCities()
        {
            try
            {
                LookUp f = new LookUp("cn", 1);

                if (f.GetCities() != null)
                {
                    ListItem li = new ListItem("Select a City", "0");
                    cboCity.DataSource = f.GetCities();
                    cboCity.DataValueField = "ID";
                    cboCity.DataTextField = "Name";
                    cboCity.DataBind();
                    cboCity.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no Cities", "0");
                    cboCity.DataSource = null;
                    cboCity.DataBind();
                    cboCity.Items.Insert(0, li);
                }
            }

            catch (Exception ex)
            {
                //RedAlert(ex.Message);
            }
        }
        public void msgbox(string strMessage)
        {
            string strScript = "<script language=JavaScript>";
            strScript += "window.alert(\"" + strMessage + "\");";
            strScript += "</script>";
            System.Web.UI.WebControls.Label lbl = new System.Web.UI.WebControls.Label();
            lbl.Text = strScript;
            Page.Controls.Add(lbl);
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            //if ((FileUpload1.HasFile))
            //{
            //}
            //else
            //{
            //    //AmberAlert("Please select a document to upload");
            //    msgbox("Please select a document to upload");
            //    return;
            //}
            LookUp pa = new LookUp("cn", 1);

            string RegNo = pa.getRegNo(int.Parse(txtFund.Value));
            if (txtQueryDetails.Text == "")
            {
                WarningAlert("Enter Query Description");
                return;
            }
            if (cboCity.SelectedItem.Text == "Select a City")
            {
                WarningAlert("Please Select City");
                return;
            }
            if (txtQuerySubject.Text == "")
            {
                WarningAlert("Please Query Subject");
                return;
            }
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string contentType = FileUpload1.PostedFile.ContentType;
            //long ApplicationID = int.Parse(txtMemberID.Value);
            //long DocTypeID = int.Parse(cboDocumentType.SelectedValue);
            using (Stream fs = FileUpload1.PostedFile.InputStream)
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    string constr = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        string query = "insert into [PortalLoggedQueries]([PensionNo], [Description], [City], [QueryType], [ContentType], [Data], [DateCreated], [isSolved], [Subject], [RegNo], [Type], [Comment], [ActionType], [DocumentName], [SyncID]) values (@PensionNo,@Description,@City,@QueryType,@ContentType,@Data,@DateCreated,@isSolved,@Subject,@RegNo,@Type,@Comment,@ActionType,@DocumentName,@SyncID)";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Connection = con;
                            cmd.Parameters.Add("@PensionNo", SqlDbType.Int).Value = int.Parse(txtRecID.Value);
                            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = txtQueryDetails.Text;
                            cmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = cboCity.SelectedItem.Text;
                            cmd.Parameters.Add("@QueryType", SqlDbType.NVarChar).Value = cboQueryType.SelectedItem.Text;
                            cmd.Parameters.Add("@ContentType", SqlDbType.NVarChar).Value = contentType;
                            cmd.Parameters.Add("@Data", SqlDbType.Binary).Value = bytes;
                            cmd.Parameters.Add("@DateCreated", SqlDbType.DateTime2).Value = DateTime.Today;
                            cmd.Parameters.Add("@isSolved", SqlDbType.Bit).Value = false;
                            cmd.Parameters.Add("@Subject", SqlDbType.NVarChar).Value = txtQuerySubject.Text;
                            cmd.Parameters.Add("@RegNo", SqlDbType.NVarChar).Value = RegNo;
                            cmd.Parameters.Add("@Type", SqlDbType.NVarChar).Value = "C";
                            cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = "";
                            cmd.Parameters.Add("@ActionType", SqlDbType.VarChar).Value = "";
                            cmd.Parameters.Add("@DocumentName", SqlDbType.VarChar).Value = filename;
                            cmd.Parameters.Add("@SyncID", SqlDbType.VarChar).Value = 1;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            SuccessAlert("Query Logged Successfully");
                            getLoggedQueries();

                        }
                    }
                }
            }

        }

        protected void grdEmployees_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "selectrecord")
            {
                int index = 0;
                string ssnSelect = "";
                GridViewRow row;
                GridView grid = sender as GridView;
                index = Convert.ToInt32(e.CommandArgument);
                //download(int.Parse(txtMemberIDs.Value), index);
                Response.Redirect(string.Format("ViewEmployerQueryReply.aspx?FundID={0}&SystemRef={1}&QueryID={2}", txtFund.Value, txtRecID.Value,index), false);
            }
        }
    }
}