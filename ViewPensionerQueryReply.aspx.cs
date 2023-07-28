using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PenPortfolio
{
    public partial class ViewPensionerQueryReply : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //ClearAlert();
                txtFundID.Value = "0";
                txtSystemRef.Value = "0";
                txtQueryID.Value = "0";

                if (Request.QueryString["SystemRef"] != "")
                {
                    txtSystemRef.Value = Request.QueryString["SystemRef"].ToString();
                }
                if (Request.QueryString["FundID"] != "")
                {
                    txtFundID.Value = Request.QueryString["FundID"].ToString();
                }
                if (Request.QueryString["QueryID"] != "")
                {
                    txtQueryID.Value = Request.QueryString["QueryID"].ToString();
                }

                getLoggedQueries();
            }
        }
        private void getLoggedQueries()
        {
            try
            {
                Model.LookUp t = new Model.LookUp("cn", 1);

                //string RegNo = t.getRegNo(int.Parse(txtFundID.Value));

                if (t.ViewPortalQuery(txtFundID.Value, long.Parse(txtQueryID.Value)) != null)
                {
                    DataRow rw = t.ViewPortalQuery(txtFundID.Value, long.Parse(txtQueryID.Value)).Tables[0].Rows[0];

                    if (rw["PensionNo"].ToString() != "")
                    {
                        txtEmployer.Text = rw["PensionNo"].ToString();
                    }
                    if (rw["QueryType"].ToString() != "")
                    {
                        txtQueryType.Text = rw["QueryType"].ToString();
                    }
                    if (rw["Subject"].ToString() != "")
                    {
                        txtSubject.Text = rw["Subject"].ToString();
                    }
                    if (rw["ActionType"].ToString() != "")
                    {
                        txtAction.Text = rw["ActionType"].ToString();
                    }
                    if (rw["Comment"].ToString() != "")
                    {
                        txtComment.Text = rw["Comment"].ToString();
                    }
                    if (rw["Description"].ToString() != "")
                    {
                        txtDescription.Text = rw["Description"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                //d(ex.Message);
            }
        }
    }
}