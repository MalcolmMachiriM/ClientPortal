using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PenPortfolio.Model;
namespace PenPortfolio
{
    public partial class PensionerHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                txtRecID.Value = "0";
                txtRoleType.Value = "0";
                txtRegNo.Value = "0";
                ClearAlert ();
                //if (Request.QueryString["RoleType"]!=null)
                //{
                //    txtRoleType.Value = Request.QueryString["RoleType"].ToString();
                //}
                if (Request.QueryString["RegNo"] != "")
                {
                    txtRegNo.Value = Request.QueryString["RegNo"].ToString();
                }
                if (Request.QueryString["SystemRef"] != "")
                {
                    txtRecID.Value = Request.QueryString["SystemRef"].ToString();
                    LoadPensionerDetails();
                }
               
                //if (txtRoleType.Value =="1")
                //{
                //    //Load Pensioner details
                //    LoadPensionerDetails();
                //}

                //if (txtRoleType.Value == "2")
                //{
                //    //Load Company details
                //}
            }
        }

        protected void LoadPensionerDetails()
        {
            try
            {
                PortalAccesssUsers pa = new PortalAccesssUsers("cn", 1);
                if (pa.PensionerLoginAccountDetails(int.Parse(txtRecID.Value), txtRegNo.Value) !=null)
                {
                    DataRow rw = pa.PensionerLoginAccountDetails(int.Parse(txtRecID.Value),txtRegNo.Value).Tables[0].Rows[0];

                    DataRow rwset = pa.GetArrears(int.Parse(txtRecID.Value), txtRegNo.Value).Tables[0].Rows[0];

                    lblPensionerName.Text = rw["LastName"].ToString() + ' ' + rw["Firstname"].ToString();
                    lblPensionType.Text = "Pension Type: "+rw["PensionType"].ToString();
                    lblNationalID.Text = "National ID No.: " + rw["NationalID"].ToString();
                    lblDOB.Text = "Date Of Birth: " +  rw["DOB"].ToString();
                    lblDJP.Text = "Date Joined Payroll: " + rw["DFP"].ToString();
                    lblPensionNo.Text = "Pension No: " + rw["PensionNo"].ToString();
                    lblPensionStartDate.Text = "Pension Start Date: " + rw["PSD"].ToString();
                    txtEmailAdd.Text = rw["Email"].ToString().ToLower();
                    txtContactNo.Text = rw["TelephoneNo"].ToString() + " " + rw["MobileNo"].ToString();
                    txtAddress1.Text = rw["Addressline1"].ToString();
                    txtAddress2.Text = rw["Addressline2"].ToString();
                    txtAddress3.Text = rw["Addressline3"].ToString();
                    lblSalary.Text = rwset["MonthlySalary"].ToString();
                    lblPayrollAccNo.Text = rwset["BankAccountNo"].ToString();
                    Label2.Text = rwset["BankAccountNo"].ToString();
                    Label5.Text = rwset["Arrears"].ToString();
                    lblLastPensionSalaryDate.Text = "Last Payment Date: " + rw["LastPaymentDate"].ToString() +" | Next Payroll Date: " + rw["NextRunDate"].ToString();
                    
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

        protected void btnNewLoan_Click(object sender, EventArgs e)
        {
            Response.Redirect("PensionerQueryLog?SystemRef=" + txtRecID.Value + "&RegNo=" + txtRegNo.Value + "");
        }
    }
}