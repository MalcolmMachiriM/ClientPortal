using PenPortfolio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PenPortfolio
{
    public partial class PensionerProfileEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtMemberID.Value = "0";
                getPayRollBanks();
                if (Request.QueryString["SystemRef"] != null)
                {
                    txtMemberID.Value = Request.QueryString["SystemRef"].ToString();
                    
                }

                //if (Request.QueryString["RegNo"] != null)
                //{
                //    //txtMemberID.Value = Request.QueryString["RegNo"].ToString();
                //    //GetMemberDetails(int.Parse(txtMemberID.Value));
                //}
                
                GetMemberDetails(int.Parse(txtMemberID.Value));
            }
        }

        protected void GetMemberDetails(int MemberID)
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
                    txtAddress1.Text = rw["AddressLine1"].ToString();
                    txtAddress2.Text = rw["AddressLine2"].ToString();
                    txtAddress3.Text = rw["AddressLine3"].ToString();
                    txtMobile1.Text = rw["MobileNo"].ToString();
                    txtMobile2.Text = rw["TelephoneNo"].ToString();
                    txtEmail.Text = rw["Email"].ToString();
                    txtPensionBasis.Text = rw["PensionBasis"].ToString();
                    txtPensionType.Text = rw["PensionType"].ToString();
                    txtPaymentPeriod.Text = rw["PayPeriod"].ToString();
                    
                    txtAccountNo.Text = rw["BankAccountNo"].ToString();
                    txtMonthlySalary.Text = rw["MonthlySalary"].ToString();
                    txtDJP.Text = rw["DateJoinedPayroll"].ToString();
                    txtPSD.Text = rw["PensionStartDate"].ToString();
                    txtED.Text = rw["LastExistanceDate"].ToString();
                    drpBank.SelectedItem.Text = rw["BankName"].ToString();
                    drpBranch.SelectedItem.Text = rw["BankBranchName"].ToString();
                    txtStatus.Text = rw["Active"].ToString();


                }
                if (t.getPensionerDetails(MemberID) != null)
                {
                    DataRow rw = t.getPensionerDetails(MemberID).Tables[0].Rows[0];
                    txtLastSalary.Text = rw["NetSalary"].ToString();
                    txtLastPaymentDate.Text = rw["LastPayDate"].ToString();
                    txtPaySlipType.Text = rw["PayslipType"].ToString();
                }

            }
            catch (Exception t)
            {
            }

        }
        protected void getPayRollBanks()
        {
            try
            {
                LookUp f = new LookUp("cn", 1);
                if (f.getBanks() != null)
                {
                    ListItem li = new ListItem("Select a Bank", "0");
                    drpBank.DataSource = f.getBanks();
                    drpBank.DataValueField = "ID";
                    drpBank.DataTextField = "BankName";
                    drpBank.DataBind();
                    drpBank.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no Banks", "0");
                    drpBank.DataSource = null;
                    drpBank.DataBind();
                    drpBank.Items.Insert(0, li);
                }
                if (f.getBranches() != null)
                {
                    ListItem li = new ListItem("Select a Branch", "0");
                    drpBranch.DataSource = f.getBranches();
                    drpBranch.DataValueField = "ID";
                    drpBranch.DataTextField = "Name";
                    drpBranch.DataBind();
                    drpBranch.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no Branches", "0");
                    drpBranch.DataSource = null;
                    drpBranch.DataBind();
                    drpBranch.Items.Insert(0, li);
                }
                if (f.GetCities() != null)
                {
                    ListItem li = new ListItem("Select a City", "0");
                    drpCity.DataSource = f.GetCities();
                    drpCity.DataValueField = "ID";
                    drpCity.DataTextField = "Name";
                    drpCity.DataBind();
                    drpCity.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no Cities", "0");
                    drpCity.DataSource = null;
                    drpCity.DataBind();
                    drpCity.Items.Insert(0, li);
                }
            }

            catch (Exception ex)
            {
                //RedAlert(ex.Message);
            }
        }
    }
}