using PenPortfolio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PenPortfolio
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        QueryStringModule qn = new QueryStringModule();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                ClearAlert();
                txtLoginCode.Value = "0";
                if (Request.QueryString["Username"] != "")
                {
                    //txtLoginCode.Value = Request.QueryString["Username"].ToString();
                    txtLoginCode.Value = qn.Decrypt(HttpUtility.UrlDecode(Request.QueryString["Username"]));
                }
                ViewDetails();
            }
        }
        protected void ViewDetails()
        {
            LookUp c = new LookUp("cn", 1);

            string FullName = c.getDetails(txtLoginCode.Value);
            txtName.Text = FullName;

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {

            try
            {
                //if (txtCurrentPassword.Text == "")
                //{
                //    WarningAlert("Please Enter Current Password");
                //    return;
                //}

                if (txtNewPassword.Text == "")
                {
                    WarningAlert("Please Enter New Password");
                    return;
                }
                if (txtConfirmNewPassword.Text == "")
                {
                    WarningAlert("Please Confirn New Password");
                    return;
                }
                if (txtNewPassword.Text != txtConfirmNewPassword.Text)
                {
                    WarningAlert("Passwords do not match");
                    return;
                }
                LookUp g = new LookUp("cn", 1);
                EncryptDecryptClass ep = new EncryptDecryptClass();
                string password = ep.EncryptPassword(txtCurrentPassword.Text);
                string Newpassword = ep.EncryptPassword(txtNewPassword.Text);
                //if (g.ValidatePassword(password, txtLoginCode.Value))
                //{


                //}
                //else
                //{
                //    WarningAlert("Invalid Password");
                //    return;
                //}
                if (g.ChangePassword(txtLoginCode.Value, Newpassword) != null)
                {
                    
                }
                SuccessAlert("Password Changed Successfully");

            }
            catch (Exception ex)
            {

                RedAlert(ex.ToString());
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
        protected void Clear()
        {
            txtName.Text = "";
            txtCurrentPassword.Text = "";
            txtNewPassword.Text = "";
            txtCurrentPassword.Text = "";
            txtConfirmNewPassword.Text = "";
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