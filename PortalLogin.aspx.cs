using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PenPortfolio.Model;

namespace PenPortfolio
{
    public partial class PortalLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                ClearAlert();
                getPortalRoles();
            }
        }
        protected void loginMember()
        {
            try
            {
                logins log = new logins("cn", 1);
                PortalAccesssUsers pa = new PortalAccesssUsers("cn", 1);
                if (pa.ValidateUserLogin(txtUsername.Text, txtPassword.Text))
                {
                    Session["SystemRef"] = pa.SystemRef;
                    Session["RoleType"] = pa.RoleType;
                    Session["RegNo"] = pa.RegNo;
                    Session["LoginCode"] = pa.Code;
                    
                    if (pa.RoleType == "1")
                    {
                        Response.Redirect("PensionerHome?SystemRef=" + pa.SystemRef + "&RegNo=" + pa.RegNo + "");
                        log.UserAction = "Logged In";
                        log.Message = pa.MsgFlg;
                        log.UserName = txtUsername.Text;
                        log.IpAddress = HttpContext.Current.Request.UserHostAddress;
                        log.Save();
                    }

                    if (pa.RoleType == "2")
                    {
                       Session["Empcode"] = txtUsername.Text;
                        log.UserAction = "Logged In";
                        log.Message = pa.MsgFlg;
                        log.UserName = txtUsername.Text;
                        log.IpAddress = HttpContext.Current.Request.UserHostAddress;
                        log.Save();
                        Response.Redirect("FundSelect");
                        //Response.Redirect("EmployerHome?CompanyID=" + pa.SystemRef + "&RegNo=" + pa.RegNo + "");
                    }
                    if (pa.RoleType == "3")
                    {
                        Session["Empcode"] = txtUsername.Text;
                        log.UserAction = "Logged In";
                        log.Message = pa.MsgFlg;
                        log.UserName = txtUsername.Text;
                        log.IpAddress = HttpContext.Current.Request.UserHostAddress;
                        log.Save();
                        Response.Redirect("FundSelect");
                        ////Response.Redirect("MemberHome?SystemRef=" + pa.SystemRef + "&RegNo=" + pa.RegNo + "");
                        //Response.Redirect("EmployerHome?CompanyID=" + pa.SystemRef + "&RegNo=" + pa.RegNo + "");
                    }
                    //if (pa.RoleType == "administrator")
                    //{
                    //    Response.Redirect("AdminHome?RoleType=" + pa.RoleType + "&ID=" + pa.SystemRef + "");
                    //}
                }
                else
                {
                    RedAlert(pa.MsgFlg);
                    log.UserAction = "Wrong Credentials";
                    log.Message = pa.MsgFlg;
                    log.UserName = txtUsername.Text;
                    log.IpAddress = HttpContext.Current.Request.UserHostAddress;
                    log.Save();
                }

            }
            catch (Exception ex)
            {
                RedAlert(ex.Message);
            }
        }
        protected void getPortalRoles()
        {
            try
            {

                //Model.ContributionsBilling cb = new Model.ContributionsBilling("cn", 1);
                Model.LookUp cb = new Model.LookUp("cn",1);
                if (cb.getRoles() != null)
                {
                    ListItem li = new ListItem("Select Role", "0");
                    cboRoleType.DataSource = cb.getRoles();
                    cboRoleType.DataValueField = "RoleID";
                    cboRoleType.DataTextField = "RoleName";
                    cboRoleType.DataBind();
                    cboRoleType.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no defined Roles", "0");
                    cboRoleType.DataSource = null;
                    cboRoleType.DataBind();
                    cboRoleType.Items.Insert(0, li);
                }
                
            }
            catch (Exception ex)
            {
                RedAlert(ex.Message);
            }
        }
        #region alerts
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

        #endregion
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            loginMember();
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            Response.Redirect("ValidateEmailAddress");
        }
    }
}