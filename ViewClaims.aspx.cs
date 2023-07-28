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
    public partial class ViewClaims : System.Web.UI.Page
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
                getEmployerClaims();
              
            }
        }
        protected void grdClientsView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "selectrecord")
            //{
            //    int index = 0;
            //    string ssnSelect = "";
            //    GridViewRow row;
            //    GridViewRow row2;
            //    GridView grid = sender as GridView;
            //    index = Convert.ToInt32(e.CommandArgument);
            //    row = grid.Rows[index];
            //    row2 = grid.Rows[index];
            //    ssnSelect = grdClientsView.DataKeys[row.RowIndex].ToString();
            //    Session["pid"] = grdClientsView.DataKeys[row.RowIndex].Value;
            //    string strscript = null;
            //    strscript = "<script langauage=JavaScript>";
            //    strscript += "window.open('frmViewBenefitQuotation.aspx?FundID=" + txtFundID.Value + "&MemberID=" + Session["pid"] + "&ExitCode=" + txtExitCode.Value + "');";
            //    strscript += "</script>";
            //    ClientScript.RegisterStartupScript(this.GetType(), "newwin", strscript);
            //    //Delete(index);
            //}

            //if (e.CommandName == "selectrecord")
            //{
            //    int index = 0;
            //    string ssnSelect = "";
            //    GridViewRow row;
            //    GridView grid = sender as GridView;
            //    index = Convert.ToInt32(e.CommandArgument);
            //    row = grid.Rows[index];
            //    ssnSelect = grdClientsView.DataKeys[row.RowIndex].ToString();
            //    Session["pid"] = grdClientsView.DataKeys[row.RowIndex].Value;
            //    //download(int.Parse(txtMemberIDs.Value), index);
            //    Response.Redirect(string.Format("ViewEmployerQueryReply.aspx?FundID={0}&SystemRef={1}&QueryID={2}", txtFund.Value, txtRecID.Value, index), false);
            //}
        }
        protected void getEmployerClaims()
        {
            try
            {
                LookUp g = new LookUp("cn", 1);

                if (g.getCompanyIDClaim(int.Parse(txtFundID.Value), int.Parse(txtParticipatingEmployerID.Value)) != null)
                {
                    grdClientsView.DataSource = g.getCompanyIDClaim(int.Parse(txtFundID.Value), int.Parse(txtParticipatingEmployerID.Value));
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