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
    public partial class EmployerHome : System.Web.UI.Page
    {
        DataTable dtCountActive = new DataTable();
        DataTable dtCountDeferred = new DataTable();
        DataTable dtCountExited = new DataTable();
        DataTable dtCountActivePensioner = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                
                txtRecID.Value = "0";
                txtRoleType.Value = "";
                txtFund.Value = "0";
                ClearAlert();
                //if (Request.QueryString["RoleType"] != null)
                //{
                //    txtRoleType.Value = Request.QueryString["RoleType"].ToString();
                //}
                if (Request.QueryString["SystemRef"] != null)
                {
                    txtRecID.Value = Request.QueryString["SystemRef"].ToString();
                }
                if (Request.QueryString["FundID"] != null)
                {
                    txtFund.Value = Request.QueryString["FundID"].ToString();
                }
                am.Attributes["href"] = (string.Format("ActiveContributingMembers?FundID={0}&SystemRef={1}", txtFund.Value, txtRecID.Value));
                dm.Attributes["href"] = (string.Format("DeferredMembers?FundID={0}&SystemRef={1}", txtFund.Value, txtRecID.Value));
                em.Attributes["href"] = (string.Format("ExitedMembers?FundID={0}&SystemRef={1}", txtFund.Value, txtRecID.Value));
                ap.Attributes["href"] = (string.Format("ActivePensioners?FundID={0}&SystemRef={1}", txtFund.Value, txtRecID.Value));
                CompanyDetails();
                getStatistics();
                //if (txtRoleType.Value == "1")
                //{
                //    //Load Pensioner details

                //}

                //if (txtRoleType.Value == "2")
                //{

                //    //Load Company details
                //}
            }
        }
        protected void CompanyDetails()
        {
            try
            {
                LookUp f = new LookUp("cn", 1);
                PortalAccesssUsers pa = new PortalAccesssUsers("cn", 1);
                string RegNo = f.getRegNo(int.Parse(txtFund.Value));
                if (pa.getActiveFunds(RegNo,int.Parse(txtRecID.Value)) != null)
                {
                    DataRow rw = pa.getActiveFunds(RegNo, int.Parse(txtRecID.Value)).Tables[0].Rows[0];

                    txtFundName.Text = rw["RegName"].ToString();
                    txtCompanyName.Text = rw["Name"].ToString();
                    txtBusinessCategory.Text = rw["BusinessClassification"].ToString();
                    txtAddress1.Text = rw["Address"].ToString();
                    //txtAddress2.Text = rw["PhysicalAddress2"].ToString();
                    //txtAddress3.Text = rw["PhysicalAddress3"].ToString();

                    lblLastPensionSalaryDate.Text = $"Last Payment Date: {f.getLastPaymentDate(int.Parse(txtRecID.Value), RegNo)}";

                }
            }
            catch (Exception ex)
            {
                RedAlert(ex.Message);
            }
        }
        protected void getStatistics()
        {
            try
            {
                LookUp cd = new LookUp("cn", 1);
                string RegNo = cd.getRegNo(int.Parse(txtFund.Value));
                //string SplittedRegNo = cd.getRegNo(int.Parse(txtFund.Value));
                DataSet dat = cd.Get_Participarting_Employer(txtRecID.Value, RegNo);
                PortalAccesssUsers pa = new PortalAccesssUsers("cn", 1);
                
                if (dat !=null)
                {
                    //if (pa.GetFundName(RegNo))
                    //{
                    //    foreach (DataRow row in dat.Tables[0].Rows)
                    //    {
                    //        //dtCoverMultiple = lp.MedicalFreeLimits_Sel_ByRegNo_Premiums(CurrentFund,int.Parse(row["FundCategory"].ToString()),Convert.ToDateTime(row["EffectiveDate"].ToString()));
                    //        string CS = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                    //        string CSS = ConfigurationManager.ConnectionStrings["pr"].ConnectionString;
                    //        using (SqlConnection con = new SqlConnection(CS))
                    //        {
                    //            SqlDataAdapter da = new SqlDataAdapter();
                    //            //da.SelectCommand = new SqlCommand("CountActiveContributingMembers", con);
                    //            da.SelectCommand = new SqlCommand("CountActiveContributingMembers_Portal", con);
                    //            da.SelectCommand.CommandTimeout = 0;
                    //            da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    //            da.SelectCommand.Parameters.AddWithValue("@RegNo", RegNo);
                    //            //da.SelectCommand.Parameters.AddWithValue("@RegNo", SplittedRegNo);
                    //            da.SelectCommand.Parameters.AddWithValue("@BranchCode", row["ID"]);
                    //            da.Fill(dtCountActive);

                    //        }
                    //        using (SqlConnection con = new SqlConnection(CS))
                    //        {
                    //            SqlDataAdapter da = new SqlDataAdapter();
                    //            //da.SelectCommand = new SqlCommand("CountDeferredMembers", con);
                    //            da.SelectCommand = new SqlCommand("CountDeferredMembers_Portal", con);
                    //            da.SelectCommand.CommandTimeout = 0;
                    //            da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    //            da.SelectCommand.Parameters.AddWithValue("@RegNo", RegNo);
                    //            //da.SelectCommand.Parameters.AddWithValue("@RegNo", SplittedRegNo);
                    //            da.SelectCommand.Parameters.AddWithValue("@BranchCode", row["ID"].ToString());
                    //            da.Fill(dtCountDeferred);

                    //        }
                    //        using (SqlConnection con = new SqlConnection(CS))
                    //        {
                    //            SqlDataAdapter da = new SqlDataAdapter();
                    //            //da.SelectCommand = new SqlCommand("CountExitedMembers", con);
                    //            da.SelectCommand = new SqlCommand("CountExitedMembers_Portal", con);
                    //            da.SelectCommand.CommandTimeout = 0;
                    //            da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    //            da.SelectCommand.Parameters.AddWithValue("@RegNo", RegNo);
                    //            //da.SelectCommand.Parameters.AddWithValue("@RegNo", SplittedRegNo);
                    //            da.SelectCommand.Parameters.AddWithValue("@BranchCode", row["ID"].ToString());
                    //            da.Fill(dtCountExited);

                    //        }
                    //        using (SqlConnection con = new SqlConnection(CSS))
                    //        {
                    //            SqlDataAdapter da = new SqlDataAdapter();
                    //            da.SelectCommand = new SqlCommand("CountActivePensioners", con);
                    //            //da.SelectCommand = new SqlCommand("CountExitedMembers_Portal", con);
                    //            da.SelectCommand.CommandTimeout = 0;
                    //            da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    //            da.SelectCommand.Parameters.AddWithValue("@RegNo", RegNo);
                    //            //da.SelectCommand.Parameters.AddWithValue("@RegNo", SplittedRegNo);

                    //            da.SelectCommand.Parameters.AddWithValue("@BranchCode", row["ID"].ToString());
                    //            da.Fill(dtCountActivePensioner);

                    //        }
                    //    }

                    //}
                    //else
                    //{
                    //    foreach (DataRow row in dat.Tables[0].Rows)
                    //    {
                    //        //dtCoverMultiple = lp.MedicalFreeLimits_Sel_ByRegNo_Premiums(CurrentFund,int.Parse(row["FundCategory"].ToString()),Convert.ToDateTime(row["EffectiveDate"].ToString()));
                    //        string CS = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                    //        string CSS = ConfigurationManager.ConnectionStrings["pr"].ConnectionString;
                    //        using (SqlConnection con = new SqlConnection(CS))
                    //        {
                    //            SqlDataAdapter da = new SqlDataAdapter();
                    //            da.SelectCommand = new SqlCommand("CountActiveContributingMembers", con);
                    //            da.SelectCommand.CommandTimeout = 0;
                    //            da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    //            da.SelectCommand.Parameters.AddWithValue("@RegNo", RegNo);
                    //            //da.SelectCommand.Parameters.AddWithValue("@RegNo", SplittedRegNo);
                    //            da.SelectCommand.Parameters.AddWithValue("@BranchCode", row["ID"]);
                    //            da.Fill(dtCountActive);

                    //        }
                    //        using (SqlConnection con = new SqlConnection(CS))
                    //        {
                    //            SqlDataAdapter da = new SqlDataAdapter();
                    //            da.SelectCommand = new SqlCommand("CountDeferredMembers", con);
                    //            da.SelectCommand.CommandTimeout = 0;
                    //            da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    //            da.SelectCommand.Parameters.AddWithValue("@RegNo", RegNo);
                    //            //da.SelectCommand.Parameters.AddWithValue("@RegNo", SplittedRegNo);
                    //            da.SelectCommand.Parameters.AddWithValue("@BranchCode", row["ID"].ToString());
                    //            da.Fill(dtCountDeferred);

                    //        }
                    //        using (SqlConnection con = new SqlConnection(CS))
                    //        {
                    //            SqlDataAdapter da = new SqlDataAdapter();
                    //            da.SelectCommand = new SqlCommand("CountExitedMembers", con);
                    //            da.SelectCommand.CommandTimeout = 0;
                    //            da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    //            da.SelectCommand.Parameters.AddWithValue("@RegNo", RegNo);
                    //            //da.SelectCommand.Parameters.AddWithValue("@RegNo", SplittedRegNo);
                    //            da.SelectCommand.Parameters.AddWithValue("@BranchCode", row["ID"].ToString());
                    //            da.Fill(dtCountExited);

                    //        }
                    //        using (SqlConnection con = new SqlConnection(CSS))
                    //        {
                    //            SqlDataAdapter da = new SqlDataAdapter();
                    //            da.SelectCommand = new SqlCommand("CountActivePensioners", con);
                    //            da.SelectCommand.CommandTimeout = 0;
                    //            da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    //            da.SelectCommand.Parameters.AddWithValue("@RegNo", RegNo);
                    //            //da.SelectCommand.Parameters.AddWithValue("@RegNo", SplittedRegNo);

                    //            da.SelectCommand.Parameters.AddWithValue("@BranchCode", row["ID"].ToString());
                    //            da.Fill(dtCountActivePensioner);

                    //        }
                    //    }
                    //}
                    foreach (DataRow row in dat.Tables[0].Rows)
                    {
                        //dtCoverMultiple = lp.MedicalFreeLimits_Sel_ByRegNo_Premiums(CurrentFund,int.Parse(row["FundCategory"].ToString()),Convert.ToDateTime(row["EffectiveDate"].ToString()));
                        string CS = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                        string CSS = ConfigurationManager.ConnectionStrings["pr"].ConnectionString;
                        using (SqlConnection con = new SqlConnection(CS))
                        {
                            SqlDataAdapter da = new SqlDataAdapter();
                            da.SelectCommand = new SqlCommand("CountActiveContributingMembers", con);
                            //da.SelectCommand = new SqlCommand("CountActiveContributingMembers_Portal", con);
                            da.SelectCommand.CommandTimeout = 0;
                            da.SelectCommand.CommandType = CommandType.StoredProcedure;
                            da.SelectCommand.Parameters.AddWithValue("@RegNo", RegNo);
                            //da.SelectCommand.Parameters.AddWithValue("@RegNo", SplittedRegNo);
                            da.SelectCommand.Parameters.AddWithValue("@BranchCode", row["ID"]);
                            da.Fill(dtCountActive);

                        }
                        using (SqlConnection con = new SqlConnection(CS))
                        {
                            SqlDataAdapter da = new SqlDataAdapter();
                            da.SelectCommand = new SqlCommand("CountDeferredMembers", con);
                            //da.SelectCommand = new SqlCommand("CountDeferredMembers_Portal", con);
                            da.SelectCommand.CommandTimeout = 0;
                            da.SelectCommand.CommandType = CommandType.StoredProcedure;
                            da.SelectCommand.Parameters.AddWithValue("@RegNo", RegNo);
                            //da.SelectCommand.Parameters.AddWithValue("@RegNo", SplittedRegNo);
                            da.SelectCommand.Parameters.AddWithValue("@BranchCode", row["ID"].ToString());
                            da.Fill(dtCountDeferred);

                        }
                        using (SqlConnection con = new SqlConnection(CS))
                        {
                            SqlDataAdapter da = new SqlDataAdapter();
                            da.SelectCommand = new SqlCommand("CountExitedMembers", con);
                            //da.SelectCommand = new SqlCommand("CountExitedMembers_Portal", con);
                            da.SelectCommand.CommandTimeout = 0;
                            da.SelectCommand.CommandType = CommandType.StoredProcedure;
                            da.SelectCommand.Parameters.AddWithValue("@RegNo", RegNo);
                            //da.SelectCommand.Parameters.AddWithValue("@RegNo", SplittedRegNo);
                            da.SelectCommand.Parameters.AddWithValue("@BranchCode", row["ID"].ToString());
                            da.Fill(dtCountExited);

                        }
                        using (SqlConnection con = new SqlConnection(CSS))
                        {
                            SqlDataAdapter da = new SqlDataAdapter();
                            da.SelectCommand = new SqlCommand("CountActivePensioners", con);
                            //da.SelectCommand = new SqlCommand("CountExitedMembers_Portal", con);
                            da.SelectCommand.CommandTimeout = 0;
                            da.SelectCommand.CommandType = CommandType.StoredProcedure;
                            da.SelectCommand.Parameters.AddWithValue("@RegNo", RegNo);
                            //da.SelectCommand.Parameters.AddWithValue("@RegNo", SplittedRegNo);

                            da.SelectCommand.Parameters.AddWithValue("@BranchCode", row["ID"].ToString());
                            da.Fill(dtCountActivePensioner);

                        }
                    }

                }

                DataTable x = null;
                x = dtCountActive;
                if (x.Rows.Count > 0)
                {
                    //lblActiveMemberss.Text = x.Tables[0].Rows[0][0].ToString();
                    object sumObject;
                    sumObject = x.Compute("Sum(Active)", string.Empty);
                    lblActiveMemberss.Text = sumObject.ToString();
                }
                else
                {
                    lblActiveMemberss.Text = "0";
                }
                DataTable x1 = null;
                x1 = dtCountDeferred;
                if (x1.Rows.Count > 0)
                {
                    //lblDeferredMemberss.Text = x1.Tables[0].Rows[0][0].ToString();
                    object sumObject;
                    sumObject = x1.Compute("Sum(Active)", string.Empty);
                    lblDeferredMemberss.Text = sumObject.ToString();
                }
                else
                {
                    lblDeferredMemberss.Text = "0";
                }

                DataTable x2 = null;
                x2 = dtCountExited;

                if (x2.Rows.Count > 0)
                {
                    //lblExitedMemberss.Text = x2.Tables[0].Rows[0][0].ToString();
                    object sumObject;
                    sumObject = x2.Compute("Sum(Active)", string.Empty);
                    lblExitedMemberss.Text = sumObject.ToString();
                }
                else
                {
                    lblExitedMemberss.Text = "0";
                }
                DataTable x3 = null;
                x3 = dtCountActivePensioner;
                if (x3.Rows.Count > 0)
                {
                   // lblActivePensionerss.Text = x3.Tables[0].Rows[0][0].ToString();
                    object sumObject;
                    sumObject = x3.Compute("Sum(Active)", string.Empty);
                    lblActivePensionerss.Text = sumObject.ToString();
                }
                else
                {
                    lblActivePensionerss.Text = "0";
                }


            }
            catch (Exception ex)
            {
                RedAlert(ex.Message);
            }
        }
        protected void btnNewLoan_Click(object sender, EventArgs e)
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

        protected void btnLogQuery_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("EmployerQueryLog?FundID={0}&SystemRef={1}", txtFund.Value, txtRecID.Value));
        }
    }
}