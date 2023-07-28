using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PenPortfolio
{
    public partial class EmployerLog1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ma.Attributes["href"] = (string.Format("PensionerProfileEdit?FundID={0}&SystemRef={1}", Session["FundID"],Session["SystemRef"]));
                db.Attributes["href"] = (string.Format("EmployerHome?FundID={0}&SystemRef={1}", Session["FundID"], Session["SystemRef"]));
                ep.Attributes["href"] = (string.Format("EmployerRegister?FundID={0}&SystemRef={1}", Session["FundID"], Session["SystemRef"]));
                pn.Attributes["href"] = (string.Format("PensionerRegister?FundID={0}&SystemRef={1}", Session["FundID"], Session["SystemRef"]));
                cnt.Attributes["href"] = (string.Format("ContributionsUploads?FundID={0}&SystemRef={1}", Session["FundID"], Session["SystemRef"]));
                clm.Attributes["href"] = (string.Format("ClaimLogging?FundID={0}&SystemRef={1}", Session["FundID"], Session["SystemRef"]));
                ch.Attributes["href"] = (string.Format("EmployerQueryLog?FundID={0}&SystemRef={1}", Session["FundID"], Session["SystemRef"]));
            }
        }
    }
}