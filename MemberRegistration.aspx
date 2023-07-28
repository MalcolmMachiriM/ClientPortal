<%@ Page Title="" Language="C#" MasterPageFile="~/EmployerLog.Master" AutoEventWireup="true" CodeBehind="MemberRegistration.aspx.cs" Inherits="PenPortfolio.MemberRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
        <div class="block block-condensed">
            <div class="app-heading app-heading-small">
                <div class="title">
                    <h2>View Member Details<%--(<asp:Label ID="lblPensionerName" runat="server" Text="Employer Name"></asp:Label>)--%></h2>
                    <%--<p>Last visit: 14:54 28.06.2017</p>--%>
                </div>
            </div>
            <%-- Allerts --%>
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
            <%-- end alets --%>
            <div class="row">

                <div class="col-md-6">
                    <asp:HiddenField ID="txtFundID" runat="server" />
                    <asp:HiddenField ID="txtSystemRef" runat="server" />

                </div>
            </div>
            <div class="block-content">
                    <div class="row">
                        <table style="width: 100%">


                            <tr>
                                <td colspan="12">
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">Firstname(s):</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtFirstnames" placeholder="Firstname(s)" CssClass="form-control" ReadOnly="false" runat="server"></asp:TextBox></td>
                                <td colspan="2">Surname:</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtSurname" placeholder="Surname" CssClass="form-control" ReadOnly="false" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">Date Of Birth:</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtDob" CssClass="form-control" ReadOnly="false" runat="server"></asp:TextBox></td>
                                <td colspan="2">National ID:</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtNationalID" placeholder="##-#######-X-##" CssClass="form-control" ReadOnly="false" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">Email Address :</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtemail" CssClass="form-control" ReadOnly="false" runat="server"></asp:TextBox>
                                </td>
                                <td colspan="2">Phone Number:</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtPhone" CssClass="form-control" ReadOnly="false" runat="server"></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td colspan="2">Employer:</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtEmployer" placeholder="Employer" CssClass="form-control" ReadOnly="false" runat="server"></asp:TextBox>
                                </td>
                                <td colspan="2">Branch:</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtBranch" placeholder="Branch" CssClass="form-control" ReadOnly="false" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">Membership Status:</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtMemberShipStatus" placeholder="Active/Deferred/Pensioner" CssClass="form-control" ReadOnly="false" runat="server"></asp:TextBox>
                                </td>
                                <td colspan="2">Fund Membership Category:</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtMembershipCategory" placeholder="Fund Category" CssClass="form-control" ReadOnly="false" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">Date Joined Company:</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtDJC" CssClass="form-control" ReadOnly="false" runat="server"></asp:TextBox>
                                </td>
                                <td colspan="2">Date Joined Fund:</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtDJF" CssClass="form-control" ReadOnly="false" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">Fund:</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtFund" CssClass="form-control" ReadOnly="false" runat="server"></asp:TextBox>
                                </td>

                            </tr>
                            <tr>
                                <td colspan="2">Account Number:</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtAccNo" CssClass="form-control" ReadOnly="false" runat="server"></asp:TextBox>
                                </td>
                                <td colspan="2">Account Name:</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtAccName" CssClass="form-control" ReadOnly="false" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                            </tr>
                        </table>
                    </div>
                <div class="row">
                    <div class="col-md-12 text-right">
                        <asp:Button ID="btnRegister" OnClick="btnRegister_Click" CssClass="btn btn-success" runat="server" Text="Register Member" Style="left: 0px; top: 0px" />
                    </div>
                </div>

            </div>
        </div>
</asp:Content>
