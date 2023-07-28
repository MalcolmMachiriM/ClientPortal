<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PortalLogin.aspx.cs" Inherits="PenPortfolio.PortalLogin" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Comarsoft Client Portal</title>
    <link rel="stylesheet" href="css/styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!-- APP WRAPPER -->
            <div class="app">
                <!-- START APP CONTAINER -->
                <div class="app-container">
                    <div class="app-login-box">

                        <div class="row">
                            <asp:Panel ID="pnlSuccess" runat="server">
                                <div class="col-md-12">
                                    <div class="alert alert-success alert-icon-block alert-dismissible" role="alert">
                                        <div class="alert-icon">
                                            <span class="icon-checkmark-circle" />
                                        </div>
                                        <strong>Success!</strong>
                                        <asp:Label ID="lblSuccess" runat="server" Text=""></asp:Label>.
                                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                            <span class="fa fa-times" />
                                        </button>
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlWarning" runat="server">
                                <div class="col-md-12">
                                    <div class="alert alert-warning alert-icon-block alert-dismissible" role="alert">
                                        <div class="alert-icon">
                                            <span class="icon-chart-bars" />
                                        </div>
                                        <strong>Warning!</strong>
                                        <asp:Label ID="lblWarning" runat="server" Text=""></asp:Label>.
                                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                            <span class="fa fa-times" />
                                        </button>
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlDanger" runat="server">
                                <div class="col-md-12">
                                    <div class="alert alert-danger alert-icon-block alert-dismissible" role="alert">
                                        <div class="alert-icon">
                                            <span class="icon-menu-circle" />
                                        </div>
                                        <strong>Danger!</strong>
                                        <asp:Label ID="lblDanger" runat="server" Text=""></asp:Label>.
                                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                            <span class="fa fa-times" />
                                        </button>
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>

                        <div class="app-login-box-user">
                            <img src="img/user/no-image.png" alt="John Doe" />
                        </div>
                        <div class="app-login-box-title">
                            <div class="title">Pensions Portfolio Portal</div>
                            <div class="subtitle">Client Online Portal</div>
                        </div>
                        <div class="app-login-box-container">
                            <%-- <div class="form-group">
                                <asp:TextBox ID="txtUsername" CssClass="form-control" placeholder="login email address" runat="server"></asp:TextBox>
                            </div>--%>
                            <div class="form-group">
                                <table style="width: 100%">
                                    <%-- <tr>
                                        <td colspan="12">
                                                                    
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td colspan="12">
                                            <asp:TextBox ID="txtUsername" CssClass="form-control" placeholder="UserName" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="12">
                                            <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="form-control" placeholder="Password" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr runat="server" visible="false">
                                        <td colspan="12">
                                            <asp:DropDownList ID="cboRoleType" CssClass="form-control dropdown" runat="server"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="12">
                                            <hr />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="12" style="text-align: center">
                                            <asp:Button ID="btnLogin" Width="100%" OnClick="btnLogin_Click" CssClass="btn btn-success" runat="server" Text="Login" Style="left: 0px; top: 0px" />
                                        </td>
                                    </tr>
                                    <%--  <tr>
                                        <td colspan="12" style="text-align:center">
                                            <asp:Button ID="btnChange" OnClick="btnChange_Click" Width="100%" CssClass="btn btn-warning" runat="server" Text="Change Password" />
                                                                    
                                        </td>
                                    </tr>--%>
                                </table>
                            </div>

                        </div>


                        <div class="app-login-box-footer">© Comartsoft Solutions (Pvt) 2023. All rights reserved.</div>
                    </div>
                </div>
                <!-- END APP CONTAINER -->
            </div>
        </div>

        <!-- IMPORTANT SCRIPTS -->
        <script type="text/javascript" src="js/vendor/jquery/jquery.min.js"></script>
        <script type="text/javascript" src="js/vendor/jquery/jquery-migrate.min.js"></script>
        <script type="text/javascript" src="js/vendor/jquery/jquery-ui.min.js"></script>
        <script type="text/javascript" src="js/vendor/bootstrap/bootstrap.min.js"></script>
        <script type="text/javascript" src="js/vendor/moment/moment.min.js"></script>
        <script type="text/javascript" src="js/vendor/customscrollbar/jquery.mCustomScrollbar.min.js"></script>
        <!-- END IMPORTANT SCRIPTS -->
        <!-- APP SCRIPTS -->
        <script type="text/javascript" src="js/app.js"></script>
        <script type="text/javascript" src="js/app_plugins.js"></script>
        <script type="text/javascript" src="js/app_demo.js"></script>
        <!-- END APP SCRIPTS -->
    </form>
</body>
</html>
