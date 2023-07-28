using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PenPortfolio.Model;

namespace PenPortfolio
{
    public partial class EmployerRegister : System.Web.UI.Page
    {
        public SqlConnection myConnection = new SqlConnection();
        public SqlDataAdapter adp;
        public SqlCommand cmd;
        DataSet dtCountActive = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                txtID.Value = "0";
                txtFundID.Value = "0";
                txtParticipatingEmployerID.Value = "0";


                if (Request.QueryString["FundID"] != null)
                {
                    txtFundID.Value = Request.QueryString["FundID"].ToString();
                }
                if (Request.QueryString["SystemRef"] != null)
                {
                    txtParticipatingEmployerID.Value = Request.QueryString["SystemRef"].ToString();
                }

                GetAllClients();
            }
        }

        protected void grdClients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "selectrecord")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                Response.Redirect(string.Format("EmployerEmployeesReg?FundID=" + txtFundID.Value + "&SystemRef=" + txtParticipatingEmployerID.Value + "&MemberID={0}", index), false);

            }

        }
        protected void GetAllClients()
        {
            try
            {

                LookUp g = new LookUp("cn", 1);
                string RegNo = g.getRegNo(int.Parse(txtFundID.Value));
                DataSet dat = g.Get_Participarting_Employer(txtParticipatingEmployerID.Value, RegNo);
                //DataSet x = g.getFundMembersByFundID(RegNo, int.Parse(txtParticipatingEmployerID.Value));
                if (dat != null)
                {
                    foreach (DataRow row in dat.Tables[0].Rows)
                    {
                        //dtCoverMultiple = lp.MedicalFreeLimits_Sel_ByRegNo_Premiums(CurrentFund,int.Parse(row["FundCategory"].ToString()),Convert.ToDateTime(row["EffectiveDate"].ToString()));
                        string CS = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                        using (SqlConnection con = new SqlConnection(CS))
                        {
                            SqlDataAdapter da = new SqlDataAdapter();
                            da.SelectCommand = new SqlCommand("Get_Employees_Register", con);
                            da.SelectCommand.CommandTimeout = 0;
                            da.SelectCommand.CommandType = CommandType.StoredProcedure;
                            da.SelectCommand.Parameters.AddWithValue("@RegNo", RegNo);
                            da.SelectCommand.Parameters.AddWithValue("@BranchCode", row["ID"].ToString());
                            da.Fill(dtCountActive);

                        }
                    }

                    if (dtCountActive != null)
                    {
                        grdClientsView.DataSource = dtCountActive;
                        grdClientsView.DataBind();

                    }
                    else
                    {
                        grdClientsView.DataSource = null;
                        grdClientsView.DataBind();
                    }
                }


            }
            catch (Exception ex)
            {
                RedAlert(ex.Message);
            }
        }

        protected void btnDashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("../Funds/FundHome?FundID=" + txtFundID.Value + ""));
        }

        protected void btnMembershipDash_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("../Clients/Employees?FundID=" + txtFundID.Value + ""));
        }

        protected void RedAlert(string MsgFlg)
        {
            //lblComms.Text = "An Error occured: " + MsgFlg;
            //pnlComms.BackColor = System.Drawing.Color.Red;
        }

        protected void AmberAlert(string MsgFlg)
        {
            //lblComms.Text = "Warning: " + MsgFlg;
            //pnlComms.BackColor = System.Drawing.Color.Orange;
        }

        protected void SuccessAlert(string MsgFlg)
        {
            //lblComms.Text = "Success: " + MsgFlg;
            //pnlComms.BackColor = System.Drawing.Color.Green;
        }

        protected void btnCreateNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmClients");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LookUp c = new LookUp("cn", 1);
                string RegNo = c.getRegNo(int.Parse(txtFundID.Value));
                DataSet x = c.getActiveMembersByFilterSearch(int.Parse(txtParticipatingEmployerID.Value), txtSSNSearch.Text, txtFnameSearch.Text, txtLnameSearch.Text, txtNationalID.Text);
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
                }

            }
            catch (Exception ex)
            {
                RedAlert(ex.Message);
            }
        }

        protected void lnkActiveEmployee_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("../Clients/frmClientsView?FundID={0}&ViewType=1", txtFundID.Value));
        }

        protected void LinlAwaitingApproval_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("../Clients/frmClientsView?FundID={0}&ViewType=0", txtFundID.Value));
        }

        protected void LinkDeferred_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("../Clients/frmdefferedclients?FundID={0}&ViewType=1", txtFundID.Value));
        }

        protected void LinkExited_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("../Clients/frmexited?FundID={0}&ViewType=1", txtFundID.Value));
        }

        protected void btnDashboard_Click1(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("../Funds/FundHome?FundID=" + txtFundID.Value + ""));
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("../Clients/BulkEmployeesUpload?FundID={0}&ViewType=0", txtFundID.Value));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void grdClientsView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdClientsView.PageIndex = e.NewPageIndex;

            this.BindGrid();
        }

        private void BindGrid()
        {
            try
            {

                LookUp g = new LookUp("cn", 1);
                string RegNo = g.getRegNo(int.Parse(txtFundID.Value));
                DataSet dat = g.Get_Participarting_Employer(txtParticipatingEmployerID.Value, RegNo);
                //DataSet x = g.getFundMembersByFundID(RegNo, int.Parse(txtParticipatingEmployerID.Value));
                if (dat != null)
                {
                    foreach (DataRow row in dat.Tables[0].Rows)
                    {
                        //dtCoverMultiple = lp.MedicalFreeLimits_Sel_ByRegNo_Premiums(CurrentFund,int.Parse(row["FundCategory"].ToString()),Convert.ToDateTime(row["EffectiveDate"].ToString()));
                        string CS = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                        using (SqlConnection con = new SqlConnection(CS))
                        {
                            SqlDataAdapter da = new SqlDataAdapter();
                            da.SelectCommand = new SqlCommand("Get_Employees_Register", con);
                            da.SelectCommand.CommandTimeout = 0;
                            da.SelectCommand.CommandType = CommandType.StoredProcedure;
                            da.SelectCommand.Parameters.AddWithValue("@RegNo", RegNo);
                            da.SelectCommand.Parameters.AddWithValue("@BranchCode", row["ID"].ToString());
                            da.Fill(dtCountActive);

                        }
                    }
                }
                if (dtCountActive != null)
                {
                    grdClientsView.DataSource = dtCountActive;
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
                RedAlert(ex.Message);
            }
        }
    }
}