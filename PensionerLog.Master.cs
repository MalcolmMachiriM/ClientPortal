using PenPortfolio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PenPortfolio
{
    public partial class PensionerLog : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ma.Attributes["href"] = (string.Format("PensionerProfileEdit?SystemRef={0}&RegNo={1}", Session["SystemRef"],Session["RegNo"]));
                db.Attributes["href"] = (string.Format("PensionerHome?SystemRef={0}&RegNo={1}", Session["SystemRef"],Session["RegNo"]));
                mp.Attributes["href"] = (string.Format("PensionerProfileEdit?SystemRef={0}&RegNo={1}", Session["SystemRef"],Session["RegNo"]));
                mpr.Attributes["href"] = (string.Format("PensionerPayrollSummary?SystemRef={0}&RegNo={1}", Session["SystemRef"], Session["RegNo"]));
                //dp.Attributes["href"] = (string.Format("PensionerDependants?PensionNo={0}", Session["UserID"]));
                ch.Attributes["href"] = (string.Format("PensionerQueryLog?SystemRef={0}&RegNo={1}", Session["SystemRef"],Session["RegNo"]));
                cp.Attributes["href"] = (string.Format("ChangePassword?SystemRef={0}&Username={1}", Session["SystemRef"], Session["LoginCode"]));
                //string b = (string.Format("PensionerPayrollSummary?PensionNo={0}&RegNo={1}", Session["UserID"], Session["RegNo"]));
            }
        }
    }
}