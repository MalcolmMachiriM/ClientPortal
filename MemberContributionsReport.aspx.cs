using System;
using CrystalDecisions.CrystalReports.Engine;
using PenPortfolio.Model;

namespace PenPortfolio
{
    partial class MemberContributionsReport : System.Web.UI.Page
    {

        CrystalDecisions.CrystalReports.Engine.ReportDocument myReport;

        CrystalDecisions.CrystalReports.Engine.FieldObject a;
        CrystalDecisions.CrystalReports.Engine.TextObject b;

        string FundID = "";
        string MemberID = "";

        //string RegNo = "";
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["FundID"] != null)
                {
                    FundID = Request.QueryString["FundID"].ToString();
                }
                if (Request.QueryString["MemberID"] != null)
                {
                    MemberID = Request.QueryString["MemberID"].ToString();
                }
                ReportView(FundID, long.Parse(MemberID));
            }
            else
            {
                ReportDocument doc = (ReportDocument)Session["MemberContributions"];
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
        protected void ReportView(string reg, long ID)
        {
            LookUp f = new LookUp("cn", 1);
            string RegNO = f.getRegNo(int.Parse(FundID));

            try
            {

                myReport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                myReport.Load(Server.MapPath(@"..\Reports\Membercontributionsrep.rpt"));

                //string servername = "DATASERVER"; //System.Configuration.ConfigurationManager.AppSettings("Hostname");
                //string ReportPass = "cive15Um";//System.Configuration.ConfigurationManager.AppSettings("RepPassword");
                //string DBName = "PensionsManComarton";//System.Configuration.ConfigurationManager.AppSettings("DBName");
                //string user1 = "sa";
                //myReport.SetDatabaseLogon(user1, ReportPass, servername, DBName);

                CrystalDecisions.Shared.ParameterFields myParameterFields = new CrystalDecisions.Shared.ParameterFields();
                CrystalDecisions.Shared.ParameterField myParameterField = new CrystalDecisions.Shared.ParameterField();
                CrystalDecisions.Shared.ParameterDiscreteValue myDiscreteValue = new CrystalDecisions.Shared.ParameterDiscreteValue();
                myParameterField.ParameterFieldName = "MemberID";
                myDiscreteValue.Value = MemberID;
                myParameterField.CurrentValues.Add(myDiscreteValue);
                myParameterFields.Add(myParameterField);

                CrystalDecisions.Shared.ParameterField myParameterField1 = new CrystalDecisions.Shared.ParameterField();
                CrystalDecisions.Shared.ParameterDiscreteValue myDiscreteValue1 = new CrystalDecisions.Shared.ParameterDiscreteValue();
                myParameterField1.ParameterFieldName = "RegNo";
                myDiscreteValue1.Value = RegNO;
                myParameterField1.CurrentValues.Add(myDiscreteValue1);
                myParameterFields.Add(myParameterField1);

                CrystalReportViewer1.ReportSource = myReport;
                CrystalReportViewer1.ParameterFieldInfo = myParameterFields;
                CrystalReportViewer1.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;

                Session["MemberContributions"] = myReport;
            }
            catch (Exception ex)
            {
                msgbox(ex.Message);
                return;
            }

        }
    }
}

