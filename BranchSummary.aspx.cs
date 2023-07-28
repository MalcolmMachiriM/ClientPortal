using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PenPortfolio
{
    public partial class BranchSummary : System.Web.UI.Page
    {
        ReportDocument myReport;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                //ClearAlert();
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
                viewreport();
            }
            else
            {
                ReportDocument doc = (ReportDocument)Session["branchreport"];
                CrystalReportViewer1.ReportSource = doc;
            }
        }
        protected void viewreport()
        {
            myReport = new ReportDocument();
            myReport.Load(Server.MapPath("Reports/BranchSummaryReport.rpt"));
            


            string servername = ConfigurationManager.AppSettings["servername"].ToString();
            string ReportPass = ConfigurationManager.AppSettings["ReportPass"].ToString();
            string DBName = ConfigurationManager.AppSettings["DBName"].ToString();
            string DbUser = ConfigurationManager.AppSettings["DbUser"].ToString();

            myReport.SetDatabaseLogon(DbUser, ReportPass, servername, DBName);

            CrystalDecisions.Shared.ParameterFields myParameterFields = new CrystalDecisions.Shared.ParameterFields();
            CrystalDecisions.Shared.ParameterField myParameterField = new CrystalDecisions.Shared.ParameterField();
            CrystalDecisions.Shared.ParameterDiscreteValue myDiscreteValue = new CrystalDecisions.Shared.ParameterDiscreteValue();
            myParameterField.ParameterFieldName = "CompanyID";
            myDiscreteValue.Value = txtSystemRef.Value;
            myParameterField.CurrentValues.Add(myDiscreteValue);
            myParameterFields.Add(myParameterField);


            CrystalReportViewer1.ReportSource = myReport;
            CrystalReportViewer1.ParameterFieldInfo = myParameterFields;
            CrystalReportViewer1.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;

            Session["branchreport"] = myReport;
        }
    }
}