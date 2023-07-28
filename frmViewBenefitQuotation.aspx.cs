using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using CrystalDecisions.CrystalReports.Engine;
using Microsoft.VisualBasic;
using PenPortfolio.Model;

namespace PenPortfolio
{
    partial class frmViewBenefitQuotation : System.Web.UI.Page
    {

        CrystalDecisions.CrystalReports.Engine.ReportDocument myReport;

        CrystalDecisions.CrystalReports.Engine.FieldObject a;
        CrystalDecisions.CrystalReports.Engine.TextObject b;

        string MemberId = "";
        string FundID = "";
        int ExitCode = 0;
        //string RegNo = "";
        //protected void Page_Unload(object sender, System.EventArgs e)
        //{
        //    try
        //    {
        //        myReport.Close();
        //        myReport.Dispose();
        //        GC.Collect();
        //    }
        //    catch (Exception ex)
        //    {
        //        msgbox(ex.Message);
        //    }
        //}
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request.QueryString["FundID"] != null)
                {
                    FundID = Request.QueryString["FundID"].ToString();
                }
                if (Request.QueryString["MemberId"] != null)
                {
                    MemberId = Request.QueryString["MemberId"].ToString();
                }
                if (Request.QueryString["ExitCode"] != null)
                {
                    ExitCode = int.Parse(Request.QueryString["ExitCode"].ToString());
                }
                LookUp f = new LookUp("cn", 1);
                string RegNO = f.getRegNo(int.Parse(FundID));
                string IDNumber = f.getIDNumber(long.Parse(MemberId));

                try
                {

                    myReport = new ReportDocument();



                    if (ExitCode == 0)
                    {
                        //myReport.Load(Server.MapPath(@"Reports/WithDrawalBenefitCalQuotationReport.rpt"));
                        myReport.Load(Server.MapPath("Reports/WithDrawalBenefitCalQuotationReport.rpt"));
                    }
                    else if (ExitCode == 4)
                    {
                        myReport.Load(Server.MapPath("Reports/DeathInServiceCalcQuotationReport.rpt"));
                        //myReport.Load(Server.MapPath(@"../Reports/DeathInServiceCalcQuotationReport.rpt"));
                    }
                    else if (ExitCode == 5)
                    {
                        myReport.Load(Server.MapPath("Reports/IllHealthBenefitsCalQuotationReport.rpt"));
                        //myReport.Load(Server.MapPath(@"../Reports/IllHealthBenefitsCalQuotationReport.rpt"));
                    }
                    else if (ExitCode == 1 || ExitCode == 2 || ExitCode == 3 || ExitCode == 6)
                    {
                        myReport.Load(Server.MapPath("Reports/RetirementBenefitsCalcQuotationReport.rpt"));
                        //myReport.Load(Server.MapPath(@"../Reports/RetirementBenefitsCalcQuotationReport.rpt"));
                    }
                    else
                    {
                        myReport.Load(Server.MapPath("Reports/WithDrawalBenefitCalQuotationReport.rpt"));
                        //myReport.Load(Server.MapPath(@"../Reports/WithDrawalBenefitCalQuotationReport.rpt"));
                    }
                    //string servername = "DATASERVER"; //System.Configuration.ConfigurationManager.AppSettings("Hostname");
                    //string ReportPass = "cive15Um";//System.Configuration.ConfigurationManager.AppSettings("RepPassword");
                    //string DBName = "PensionsManComarton";//System.Configuration.ConfigurationManager.AppSettings("DBName");
                    //string user1 = "sa";
                    //myReport.SetDatabaseLogon(user1, ReportPass, servername, DBName);

                    string servername = ConfigurationManager.AppSettings["servername"].ToString();
                    string ReportPass = ConfigurationManager.AppSettings["ReportPass"].ToString();
                    string DBName = ConfigurationManager.AppSettings["DBName"].ToString();
                    string DbUser = ConfigurationManager.AppSettings["DbUser"].ToString();

                    //myReport = new ReportDocument();
                    //myReport.Load(Server.MapPath(@"~/Reports/TrialBalance.rpt"));
                    //myReport.SetDatabaseLogon(DbUser, ReportPass, servername, DBName);

                    //string servername = "DATASERVER"; //System.Configuration.ConfigurationManager.AppSettings("Hostname");
                    //string ReportPass = "cive15Um";//System.Configuration.ConfigurationManager.AppSettings("RepPassword");
                    //string DBName = "PensionsManComarton";//System.Configuration.ConfigurationManager.AppSettings("DBName");
                    //string user1 = "sa";
                    myReport.SetDatabaseLogon(DbUser, ReportPass, servername, DBName);

                    CrystalDecisions.Shared.ParameterFields myParameterFields = new CrystalDecisions.Shared.ParameterFields();
                    CrystalDecisions.Shared.ParameterField myParameterField = new CrystalDecisions.Shared.ParameterField();
                    CrystalDecisions.Shared.ParameterDiscreteValue myDiscreteValue = new CrystalDecisions.Shared.ParameterDiscreteValue();
                    myParameterField.ParameterFieldName = "RegNo";
                    myDiscreteValue.Value = RegNO;
                    myParameterField.CurrentValues.Add(myDiscreteValue);
                    myParameterFields.Add(myParameterField);

                    CrystalDecisions.Shared.ParameterField myParameterField1 = new CrystalDecisions.Shared.ParameterField();
                    CrystalDecisions.Shared.ParameterDiscreteValue myDiscreteValue1 = new CrystalDecisions.Shared.ParameterDiscreteValue();
                    myParameterField1.ParameterFieldName = "MemberID";
                    myDiscreteValue1.Value = int.Parse(MemberId);
                    myParameterField1.CurrentValues.Add(myDiscreteValue1);
                    myParameterFields.Add(myParameterField1);

                    CrystalDecisions.Shared.ParameterField myParameterField2 = new CrystalDecisions.Shared.ParameterField();
                    CrystalDecisions.Shared.ParameterDiscreteValue myDiscreteValue2 = new CrystalDecisions.Shared.ParameterDiscreteValue();
                    myParameterField2.ParameterFieldName = "MemberIDNumber";
                    myDiscreteValue2.Value = IDNumber;
                    myParameterField2.CurrentValues.Add(myDiscreteValue2);
                    myParameterFields.Add(myParameterField2);


                    CrystalReportViewer1.ReportSource = myReport;
                    CrystalReportViewer1.ParameterFieldInfo = myParameterFields;
                    CrystalReportViewer1.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;

                    Session["quotation"] = myReport;
                }
                catch (Exception ex)
                {
                    msgbox(ex.Message);
                    return;
                }
            }
            else
            {
                ReportDocument doc = (ReportDocument)Session["quotation"];
                CrystalReportViewer1.ReportSource = doc;
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
        //protected void ReportView()
        //{
        //    Fund f = new Fund("cn", 1);
        //    string RegNO = f.getRegNo(int.Parse(FundID));

        //    try
        //    {

        //        myReport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        //        myReport.Load(Server.MapPath(@"..\Clients\rptuploadedemployees.rpt"));
        //        //string reportPath = Server.MapPath(@"..\Clients\rptuploadedemployees.rpt");
        //        string servername = "DATASERVER"; //System.Configuration.ConfigurationManager.AppSettings("Hostname");
        //        string ReportPass = "cive15Um";//System.Configuration.ConfigurationManager.AppSettings("RepPassword");
        //        string DBName = "PensionsManComarton";//System.Configuration.ConfigurationManager.AppSettings("DBName");
        //        string user1 = "sa";
        //        myReport.SetDatabaseLogon(user1, ReportPass, servername, DBName,false);

        //        //myReport.Load(reportPath);
        //        CrystalDecisions.Shared.ParameterFields myParameterFields = new CrystalDecisions.Shared.ParameterFields();
        //        CrystalDecisions.Shared.ParameterField myParameterField = new CrystalDecisions.Shared.ParameterField();
        //        CrystalDecisions.Shared.ParameterDiscreteValue myDiscreteValue = new CrystalDecisions.Shared.ParameterDiscreteValue();
        //        myParameterField.ParameterFieldName = "From"; 
        //        myDiscreteValue.Value = From;
        //        myParameterField.CurrentValues.Add(myDiscreteValue);
        //        myParameterFields.Add(myParameterField);

        //        CrystalDecisions.Shared.ParameterField myParameterField1 = new CrystalDecisions.Shared.ParameterField();
        //        CrystalDecisions.Shared.ParameterDiscreteValue myDiscreteValue1 = new CrystalDecisions.Shared.ParameterDiscreteValue();
        //        myParameterField1.ParameterFieldName = "RegNo";
        //        myDiscreteValue1.Value = RegNO;
        //        myParameterField1.CurrentValues.Add(myDiscreteValue1);
        //        myParameterFields.Add(myParameterField1);

        //        CrystalDecisions.Shared.ParameterField myParameterField2 = new CrystalDecisions.Shared.ParameterField();
        //        CrystalDecisions.Shared.ParameterDiscreteValue myDiscreteValue2 = new CrystalDecisions.Shared.ParameterDiscreteValue();
        //        myParameterField2.ParameterFieldName = "To";
        //        myDiscreteValue2.Value = To;
        //        myParameterField2.CurrentValues.Add(myDiscreteValue2);
        //        myParameterFields.Add(myParameterField2);



        //        CrystalReportViewer1.ReportSource = myReport;
        //        CrystalReportViewer1.ParameterFieldInfo = myParameterFields;
        //        CrystalReportViewer1.RefreshReport();
        //    }
        //    catch (Exception ex)
        //    {
        //        msgbox(ex.Message);
        //        return;
        //    }
        //}
    }
}

