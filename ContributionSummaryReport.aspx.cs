using CrystalDecisions.CrystalReports.Engine;
using PenPortfolio.Datasets;
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
    public partial class ContributionSummaryReport : System.Web.UI.Page
    {


        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet UtilisedReceiptsDT = new DataSet();
        MembershipDS MemberCertificatesDS = new MembershipDS();
        string Address1 = "";
        string Address2 = "";
        string Address3 = "";
        string RegName = "";
        string Period = "";
        DateTime PeriodDate = DateTime.Now;
        string RegNo = "";
        byte[] image = null;
        ReportDocument myReport;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                ClearAlert();
                txtFundID.Value = "0";
                txtSystemRef.Value = "0";
                if (Request.QueryString["FundID"] != "")
                {
                    txtFundID.Value = Request.QueryString["FundID"].ToString();
                }
                if (Request.QueryString["SystemRef"] != "")
                {
                    txtSystemRef.Value = Request.QueryString["SystemRef"].ToString();
                }
                getBranch();
            }
            else
            {
                ReportDocument doc = (ReportDocument)Session["summaryreport"];
                CrystalReportViewer1.ReportSource = doc;
            }

            
        }

        void getBranch()
        {
            LookUp f = new LookUp("cn", 1);

            if (f.Get_Participarting_Employer(txtSystemRef.Value, RegNo) != null)
            {
                ListItem li = new ListItem("Select All", "0");
                //cbobranch.DataSource = f.getBranches(int.Parse(txtFundID.Value), int.Parse(txtSystemRef.Value));
                cbobranch.DataSource = f.Get_Participarting_Employer(txtSystemRef.Value, RegNo);
                cbobranch.DataValueField = "ID";
                cbobranch.DataTextField = "Name";
                cbobranch.DataBind();
                cbobranch.Items.Insert(0, li);
            }
            else
            {
                ListItem li = new ListItem("There are no Branch Codes", "0");
                cbobranch.DataSource = null;
                cbobranch.DataBind();
                cbobranch.Items.Insert(0, li);
            }

        }


        protected void btnView_Click(object sender, EventArgs e)
        {
            if (txtFrom.Text == "")
            {
                WarningAlert("Please select start date");
                return;
            }
            if (txtTo.Text == "")
            {
                WarningAlert("Please select end date");
                return;
            }
            if (cbobranch.Text == "")
            {
                WarningAlert("Please enter branch code");
                return;
            }

      
            LookUp up = new LookUp("cn", 1);
            string RegNo = up.getRegNo(int.Parse(txtFundID.Value));
            DataSet x = up.getFundDetails(RegNo);
            //if (up.ValidateBranch(int.Parse(cbobranch.Text), int.Parse(txtSystemRef.Value)))
            //{

            //}
            //else
            //{
            //    WarningAlert("Branch does not belong to this company");
            //    return;
            //}
            if (x != null)
            {
                foreach (DataRow dt in x.Tables[0].Rows)
                {
                    Address1 = dt["PostalAdd1"].ToString();
                    Address2 = dt["PostalAdd2"].ToString();
                    Address3 = dt["PostalAdd3"].ToString();
                    RegName = dt["RegName"].ToString();
                    RegNo = dt["RegNo"].ToString();
                    image = (byte[])dt["Logo"];

                }

            }
            string CS = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand("Contributions_Summary_Sel_By_By_Company_portal", con);
                da.SelectCommand.CommandTimeout = 0;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@RegNo", RegNo);
                da.SelectCommand.Parameters.AddWithValue("@BranchCode", cbobranch.Text);
                da.SelectCommand.Parameters.AddWithValue("@PaymentDateFrom", txtFrom.Text);
                da.SelectCommand.Parameters.AddWithValue("@PaymentDateTo", txtTo.Text);
                da.Fill(ds);
            }
            DataSet x2 = new DataSet();
            x2 = up.GetContributionPeriodDates(RegNo, int.Parse(cbobranch.Text), Convert.ToDateTime(txtFrom.Text), Convert.ToDateTime(txtTo.Text));

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand("Unreceipted_Contributions_Portal", con);
                da.SelectCommand.CommandTimeout = 0;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@RegNo", RegNo);
                da.SelectCommand.Parameters.AddWithValue("@BranchCode", txtSystemRef.Value);
                da.SelectCommand.Parameters.AddWithValue("@PaymentDateFrom", txtFrom.Text);
                da.SelectCommand.Parameters.AddWithValue("@PaymentDateTo", txtTo.Text);
                da.Fill(ds1);
            }
            //if (x2!= null)
            //{
            //    foreach (DataRow rw in x2.Tables[0].Rows)
            //    {
            //        Period = rw["Period"].ToString();
            //        PeriodDate = Convert.ToDateTime(rw["PeriodDate"].ToString());
            //    }
            //}
            try
            {
                if (ds != null)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        if (ds1 != null)
                        {
                            foreach (DataRow rowset in ds1.Tables[0].Rows)
                            {

                                if (row["Period"].ToString() == rowset["Period"].ToString())
                                {
                                    string[] item = new[] { RegName, (row["BranchCode"].ToString()), row["Branch Name"].ToString(), row["Total Salary Bill"].ToString(), row["Gross Member Contribution"].ToString(), row["Gross Member Contribution"].ToString(), row["Gross Employer Contribution"].ToString(), row["Net Employer Contribution"].ToString(), row["Membership"].ToString(), row["Period"].ToString(), txtFrom.Text, txtTo.Text, DateTime.Now.ToString(), DateTime.Now.ToString(), "", "0", "0", "0", rowset["UnreceiptedTotal"].ToString() };
                                    MemberCertificatesDS.Tables["ContributionsSummaryByBranch"].Rows.Add(item);

                                }
                            }

                        }
                        else
                        {
                            WarningAlert("Nothing to display ");

                        }

                        //if (UtilisedReceiptsDT.Tables[0].Rows.Count <= 0)
                        //{

                        //}
                        //else
                        //{

                        //}
                        //UtilisedReceiptsDT = up.GetReceiptsUtilisationHistory(RegNo, int.Parse(row["BranchCode"].ToString()), PeriodDate);
                        //if (UtilisedReceiptsDT != null)
                        //{
                        //    foreach (DataRow rwset in UtilisedReceiptsDT.Tables[0].Rows)
                        //    {
                        //        string[] item = new[] { RegName, (row["BranchCode"].ToString()), row["Branch Name"].ToString(), row["Total Salary Bill"].ToString(), row["Gross Member Contribution"].ToString(), row["Gross Member Contribution"].ToString(), row["Gross Employer Contribution"].ToString(), row["Net Employer Contribution"].ToString(), row["Membership"].ToString(), Period, txtFrom.Text, txtTo.Text, rwset["ReceiptDate"].ToString(), rwset["ReceiptDate"].ToString(), rwset["ReceiptNo"].ToString(), rwset["ReceiptTotal"].ToString(), rwset["ReceiptBalance"].ToString(), rwset["DR"].ToString() };
                        //        MemberCertificatesDS.Tables["ContributionsSummary"].Rows.Add(item);
                        //    }
                        //}
                        //else
                        //{
                        //    string[] item = new[] { RegName, (row["BranchCode"].ToString()), row["Branch Name"].ToString(), row["Total Salary Bill"].ToString(), row["Gross Member Contribution"].ToString(), row["Gross Member Contribution"].ToString(), row["Gross Employer Contribution"].ToString(), row["Net Employer Contribution"].ToString(), row["Membership"].ToString(), Period, txtFrom.Text, txtTo.Text, PeriodDate.ToString(), PeriodDate.ToString(), "", "0", "0", "0" };
                        //    MemberCertificatesDS.Tables["ContributionsSummary"].Rows.Add(item);
                        //}

                    }
                }


                myReport = new ReportDocument();
                myReport.Load(Server.MapPath(@"~/Reports/ReceiptedPeriodsDetail.rpt"));
                myReport.SetDataSource(MemberCertificatesDS);
                CrystalReportViewer1.ReportSource = myReport;
                CrystalReportViewer1.RefreshReport();
                CrystalReportViewer1.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;
                Session["summaryreport"] = myReport;

            }
            catch (Exception ex)
            {
                WarningAlert(ex.Message);
                var err= ex.ToString();
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
    }
}