using PenPortfolio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PenPortfolio
{
    public partial class MemberLog : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            QueryStringModule qn = new QueryStringModule();
            if (!IsPostBack)
            {

                string EncryptedSystemRef = qn.Encrypt(HttpUtility.UrlDecode(Session["SystemRef"].ToString().Trim()));
                string EncryptedLoginCode = qn.Encrypt(HttpUtility.UrlDecode(Session["LoginCode"].ToString().Trim()));
                string EncryptedRegNo = qn.Encrypt(HttpUtility.UrlDecode(Session["RegNo"].ToString().Trim()));
                string EncodedReg = qn.Encrypt(Session["RegNo"].ToString().Trim());


                ma.Attributes["href"] = (string.Format("MemberHome?SystemRef={0}&RegNo={1}", Session["SystemRef"], Session["RegNo"]));
                db.Attributes["href"] = (string.Format("MemberHome?SystemRef={0}&RegNo={1}", Session["SystemRef"], Session["RegNo"]));
                ep.Attributes["href"] = (string.Format("MemberClaimLogging?SystemRef={0}&RegNo={1}", EncryptedSystemRef, EncryptedRegNo));
                //A1.Attributes["href"] = (string.Format("MemberBenefitStatement?SystemRef={0}&RegNo={1}", EncryptedSystemRef, EncryptedRegNo));
                cnt.Attributes["href"] = (string.Format("MemberContributions?SystemRef={0}&RegNo={1}", EncryptedSystemRef, EncryptedRegNo));
                ch.Attributes["href"] = (string.Format("MemberQueryLog?SystemRef={0}&RegNo={1}", EncryptedSystemRef, EncryptedRegNo));
                cp.Attributes["href"] = (string.Format("ChangePassword?SystemRef={0}&Username={1}", EncryptedSystemRef, EncryptedLoginCode));
            }
        }
    }
}