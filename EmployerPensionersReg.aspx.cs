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
    public partial class EmployerPensionersReg : System.Web.UI.Page
    {
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
                    txtFirstnames.Text = rw["FirstName"].ToString();
                    txtSurname.Text = rw["LastName"].ToString();
                    txtNationalID.Text = rw["NationalID"].ToString();
                    txtDOB.Text = rw["DateOfBirth"].ToString();
                    //txtMobile1.Text = rw["MobileNo"].ToString();
                    //txtMobile2.Text = rw["TelephoneNo"].ToString();
                    //txtEmail.Text = rw["Email"].ToString();
                    txtPensionBasis.Text = rw["PensionBasis"].ToString();
                    txtPensionType.Text = rw["PensionType"].ToString();
                    txtPaymentPeriod.Text = rw["PayPeriod"].ToString();

                    //txtAccountNo.Text = rw["BankAccountNo"].ToString();
                    txtMonthlySalary.Text = rw["MonthlySalary"].ToString();
                    //txtDJP.Text = rw["DateJoinedPayroll"].ToString();
                    //txtPSD.Text = rw["PensionStartDate"].ToString();
                    txtED.Text = rw["LastExistanceDate"].ToString();
                    //drpBank.SelectedItem.Text = rw["BankName"].ToString();
                    //drpBranch.SelectedItem.Text = rw["BankBranchName"].ToString();
                    txtStatus.Text = rw["Active"].ToString();


                }
                if (t.getPensionerDetails(MemberID) != null)
                {
                    DataRow rw = t.getPensionerDetails(MemberID).Tables[0].Rows[0];
                    //txtLastSalary.Text = rw["NetSalary"].ToString();
                    txtLastPaymentDate.Text = rw["LastPayDate"].ToString();
                    //txtPaySlipType.Text = rw["PayslipType"].ToString();
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
            Response.Redirect(string.Format("PensionerDeclarationForm?FundID={0}&SystemRef={1}&MemberID={2}", txtFundID.Value, txtSystemRef.Value, txtMemberIDs.Value));
        }

        protected void btnLogQuery_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("EmployerQueryLog?FundID={0}&SystemRef={1}", txtFundID.Value,txtSystemRef.Value));
        }
    }
}