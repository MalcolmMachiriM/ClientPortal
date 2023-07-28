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
    public partial class FundSelect : System.Web.UI.Page
    {
        DataSet dtEmployerFunds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAllFunds();
            }
        }
        protected void getAllFunds(int Page = 0)
        {
            try
            {
                LookUp lookUp = new LookUp("cn", 1);
                if (lookUp.getActiveFunds() != null)
                {
                    grdFunds.DataSource = lookUp.getActiveFunds();
                    if (Page > 0)
                    {
                        grdFunds.PageIndex = Page;
                    }
                    grdFunds.DataBind();
                }
                else
                {
                    grdFunds.DataSource = null;
                    grdFunds.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblWarningComms.Text = ex.Message;
            }
        }
        protected void filterSearchFund(string fundName)
        {
            try
            {
                LookUp lu = new LookUp("cn", 1);
                DataSet x = lu.getActiveFunds(fundName);
                if (x != null)
                {
                    grdFunds.DataSource = x;
                    grdFunds.DataBind();
                }
                else
                {
                    AmberAlert("There are no fund names found by the search phrase");
                    grdFunds.DataSource = null;
                    grdFunds.DataBind();
                }
            }
            catch (Exception ex)
            {
                RedAlert(ex.Message);
            }
        }

        protected void RedAlert(string Err)
        {
            lblErrorComms.Text = "An exception occured: " + Err;
            pnlErrorComms.Visible = true;
            //Disable Others
            pnlWarningComms.Visible = false;
            pnlSuccessComms.Visible = false;
            lblWarningComms.Text = "";
            lblSuccessComms.Text = "";
        }

        protected void SuccessMsg(string Msg)
        {
            lblSuccessComms.Text = Msg;
            pnlSuccessComms.Visible = true;

            //Disable Others
            pnlWarningComms.Visible = false;
            pnlErrorComms.Visible = false;
            lblWarningComms.Text = "";
            lblErrorComms.Text = "";
        }


        protected void AmberAlert(string Err)
        {
            lblWarningComms.Text = "Warning: " + Err;
            pnlWarningComms.Visible = true;

            //Disable Others
            pnlSuccessComms.Visible = false;
            pnlErrorComms.Visible = false;
            lblSuccessComms.Text = "";
            lblErrorComms.Text = "";
        }


        protected void LoadAllFunds()
        {
            try
            {
                LookUp lp = new LookUp("cn", 1);
                DataSet dat = lp.GetPortalUsers(Session["Empcode"].ToString());

                if (dat !=null)
                {
                    foreach (DataRow row in dat.Tables[0].Rows)
                    {
                        //dtCoverMultiple = lp.MedicalFreeLimits_Sel_ByRegNo_Premiums(CurrentFund,int.Parse(row["FundCategory"].ToString()),Convert.ToDateTime(row["EffectiveDate"].ToString()));
                        string CS = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                        using (SqlConnection con = new SqlConnection(CS))
                        {
                            SqlDataAdapter da = new SqlDataAdapter();
                            da.SelectCommand = new SqlCommand("Get_Employer_Funds", con);
                            da.SelectCommand.CommandTimeout = 0;
                            da.SelectCommand.CommandType = CommandType.StoredProcedure;
                            da.SelectCommand.Parameters.AddWithValue("@RegNo", row["RegNo"].ToString());
                            da.Fill(dtEmployerFunds);

                        }
                    }

                }

                if (dtEmployerFunds != null)
                {
                    ListItem li = new ListItem("Select a fund", "0");
                    cboFundSelect.DataSource = dtEmployerFunds;
                    cboFundSelect.DataValueField = "Key";
                    cboFundSelect.DataTextField = "Fund";
                    cboFundSelect.DataBind();
                    cboFundSelect.Items.Insert(0, li);

                    grdFunds.DataSource = dtEmployerFunds;
                    grdFunds.DataBind();
                }
                else
                {
                    ListItem li = new ListItem("There are no active funds", "0");
                    cboFundSelect.DataSource = null;

                    cboFundSelect.DataBind();
                    cboFundSelect.Items.Insert(0, li);

                    grdFunds.DataSource = null;
                    grdFunds.DataBind();

                }

            }
            catch (Exception ex)
            {
                lblWarningComms.Text = ex.Message;
            }
        }

        protected void grdClients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            LookUp lp = new LookUp("cn", 1);
            DataSet dat = lp.GetPortalUsers(Session["Empcode"].ToString());
            if (e.CommandName == "selectrecord")
            {
               
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                Session["FundID"] = index;
                LookUp f = new LookUp("cn", 1);
                string RegNo = f.getRegNo(int.Parse(Session["FundID"].ToString()));
                Session["FundType"] = f.getFundDetails(RegNo).Tables[0].Rows[0]["FundTypeDescription"].ToString();
                if (dat != null)
                {
                    foreach (DataRow row in dat.Tables[0].Rows)
                    {
                        Session["SystemRef"] = f.getSystemRef(RegNo, Session["LoginCode"].ToString());
                    }

                }
                //Response.Redirect("../Funds/FundHome?FundID=" + index + "");
                PortalAccesssUsers pa = new PortalAccesssUsers("cn", 1);
                getLoginCode(int.Parse(Session["SystemRef"].ToString()));
                if (pa.ValidateUser(txtUsername.Value))
                {
                    //Session["SystemRef"] = pa.SystemRef;
                    Session["SystemRef"] = f.getSystemRef(RegNo, pa.Code);
                    Session["RoleType"] = pa.RoleType;
                    //Session["RegNo"] = pa.RegNo;                    
                    Session["RegNo"] = RegNo;
                    Session["LoginCode"] = pa.Code;
                    string systemRef = f.getSystemRef(RegNo, pa.Code);
                    string encodedReg = HttpUtility.UrlEncode(RegNo);

                    if (pa.RoleType == "1")
                    {
                        Response.Redirect("PensionerHome?SystemRef=" + pa.SystemRef + "&RegNo=" + index + "");
                    }

                    if (pa.RoleType == "2")
                    {
                        Session["Empcode"] = txtUsername.Value;
                        Response.Redirect("EmployerHome?FundID=" + index + "&SystemRef=" + Session["SystemRef"].ToString() + "");
                    }
                    if (pa.RoleType == "3")
                    {
                        Session["Empcode"] = txtUsername.Value;
                        Response.Redirect("MemberHome?SystemRef=" + systemRef + "&RegNo=" + encodedReg + "");

                    }
                }
                else
                {
                    RedAlert(pa.MsgFlg);
                }
                ////Response.Redirect("EmployerHome?FundID=" + index + "&SystemRef=" + Session["SystemRef"].ToString() + "");
                //Delete(index);
            }
            if (e.CommandName == "editClient")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                Response.Redirect(string.Format("frmEditIndividualApproval?EmployeeID={0}", index));
            }
            if (e.CommandName == "viewClient")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                Response.Redirect(string.Format("../PortalRequests/frmParticipatingEmployerView?ID={0}", index), false);
            }
        }

        private string getLoginCode(int v)
        {
            try
            {
                PortalAccesssUsers pa = new PortalAccesssUsers("cn", 1);
                DataSet c =pa.getLoginCode(v);
                if (c != null)
                {
                    foreach (DataRow dr in c.Tables[0].Rows) 
                    {
                        txtUsername.Value = dr["LoginCode"].ToString();
                    }
                }
                return txtUsername.Value;
            }
            catch (Exception c)
            {

                RedAlert(c.Message);
                return null;
            }
            
        }

        protected void gridPageChange(object sender, GridViewPageEventArgs e)
        {
            //getAllFunds(e.NewPageIndex);
            grdFunds.PageIndex = e.NewPageIndex;

            this.BindGrid();
        }
        protected void BindGrid()
        {
            try
            {
                LookUp lp = new LookUp("cn", 1);
                DataSet dat = lp.GetPortalUsers(Session["Empcode"].ToString());

                if (dat != null)
                {
                    foreach (DataRow row in dat.Tables[0].Rows)
                    {
                        //dtCoverMultiple = lp.MedicalFreeLimits_Sel_ByRegNo_Premiums(CurrentFund,int.Parse(row["FundCategory"].ToString()),Convert.ToDateTime(row["EffectiveDate"].ToString()));
                        string CS = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                        using (SqlConnection con = new SqlConnection(CS))
                        {
                            SqlDataAdapter da = new SqlDataAdapter();
                            da.SelectCommand = new SqlCommand("Get_Employer_Funds", con);
                            da.SelectCommand.CommandTimeout = 0;
                            da.SelectCommand.CommandType = CommandType.StoredProcedure;
                            da.SelectCommand.Parameters.AddWithValue("@RegNo", row["RegNo"].ToString());
                            da.Fill(dtEmployerFunds);

                        }
                    }

                }

                if (dtEmployerFunds != null)
                {
                    ListItem li = new ListItem("Select a fund", "0");
                    cboFundSelect.DataSource = dtEmployerFunds;
                    cboFundSelect.DataValueField = "Key";
                    cboFundSelect.DataTextField = "Fund";
                    cboFundSelect.DataBind();
                    cboFundSelect.Items.Insert(0, li);

                    grdFunds.DataSource = dtEmployerFunds;
                    grdFunds.DataBind();
                }
                else
                {
                    ListItem li = new ListItem("There are no active funds", "0");
                    cboFundSelect.DataSource = null;

                    cboFundSelect.DataBind();
                    cboFundSelect.Items.Insert(0, li);

                    grdFunds.DataSource = null;
                    grdFunds.DataBind();

                }

            }
            catch (Exception ex)
            {

            }
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            Session["FundID"] = cboFundSelect.SelectedValue.ToString();
            Response.Redirect("../Funds/FundHome?FundID=" + int.Parse(cboFundSelect.SelectedValue) + "");
        }

        protected void btnCreateNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Funds/FundHome?FundID=0");
        }

        protected void btnSeach_Click(object sender, EventArgs e)
        {
            filterSearchFund(txtSearchFilter.Text);
        }
    }
}