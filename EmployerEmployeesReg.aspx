<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/EmployerLog.Master" AutoEventWireup="true"  CodeBehind="EmployerEmployeesReg.aspx.cs" Inherits="PenPortfolio.EmployerEmployeesReg" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- START PAGE CONTAINER -->
    <div class="container container-boxed">
        <!-- RECENT ACTIVITY -->
        <div class="block block-condensed">
            <div class="app-heading app-heading-small">
                <div class="title">
                    <h2>View Member Details<%--(<asp:Label ID="lblPensionerName" runat="server" Text="Employer Name"></asp:Label>)--%></h2>
                    <%--<p>Last visit: 14:54 28.06.2017</p>--%>
                </div>
            </div>
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
            <div class="row">

                <div class="col-md-6">
                    <asp:HiddenField ID="txtFundID" runat="server" />
                    <asp:HiddenField ID="txtMemberIDs" runat="server" />
                    <asp:HiddenField ID="txtSystemRef" runat="server" />
                </div>
            </div>
            <div class="block-content">
                <form class="form-horizontal">
                    <div class="row">
                        <table style="width: 100%">
                            <tr>
                                <td colspan="12">
                                    <asp:HiddenField ID="txtMemberID" runat="server" />
                                </td>
                            </tr>
                       
                            <tr>
                                <td colspan="12">
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">Firstname(s):</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtFirstnames" placeholder="Firstname(s)" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox></td>
                                <td colspan="2">Surname:</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtSurname" placeholder="Surname" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">Date Of Birth:</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtDob" placeholder="dd/MM/YYYY" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox></td>
                                <td colspan="2">National ID:</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtNationalID" placeholder="##-#######-X-##" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">Employer:</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtEmployer" placeholder="Employer" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                </td>
                                <td colspan="2">Branch:</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtBranch" placeholder="Branch" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <%--<td colspan="2">Department:</td>
                                                                            <td colspan="4">
                                                                                <asp:TextBox ID="txtDepartment" placeholder="Department/Employment Status" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                                            </td>--%>
                                <td colspan="2">Membership Status:</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtMemberShipStatus" placeholder="Active/Deferred/Pensioner" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                </td>
                                <td colspan="2">Fund Membership Category:</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtMembershipCategory" placeholder="Fund Category" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">Date Joined Company:</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtDJC" placeholder="dd/MM/YYYY" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                </td>
                                <td colspan="2">Date Joined Fund:</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtDJF" placeholder="dd/MM/YYYY" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td colspan="12" style="text-align: center">

                                    <asp:Button ID="btnExit" OnClick="btnExit_Click" CssClass="btn btn-primary" runat="server" Text="Exit Member from Fund" />
                                    <asp:Button ID="btnCntHistory" OnClick="btnCntHistory_Click" CssClass="btn btn-primary" runat="server" Text="View Contributions History" />
                                    <asp:Button ID="btnBenefitStm" OnClick="btnBenefitStm_Click" OnClientClick="window.scrollTo(0, document.body.scrollHeight);" CssClass="btn btn-primary" runat="server" Text="View Benefit Statement" />

                                </td>
                            </tr>
                            <tr>
                                <td colspan="12">

                                    <asp:GridView ID="grdContributions" Width="100%" runat="server"
                                        AutoGenerateColumns="False" AutoGenerateSelectButton="false" OnPageIndexChanging="grdContributions_PageIndexChanging"
                                        DataKeyNames="ID" PageSize="10"
                                        CssClass="table table-condensed" GridLines="None" role="grid" aria-describedby="DataTables_Table_0_info"
                                        Style="border-collapse: collapse !important"
                                        AllowPaging="True" AllowSorting="True">
                                        <Columns>
                                            <asp:BoundField DataField="Period" HeaderText="Period"></asp:BoundField>
                                            <asp:BoundField DataField="Description" HeaderText="Type"></asp:BoundField>
                                            <asp:BoundField DataField="Salary" HeaderText="Salary"></asp:BoundField>
                                            <asp:BoundField DataField="Payment Date" HeaderText="Payment Date"></asp:BoundField>
                                            <asp:BoundField DataField="Member Contribution" HeaderText="Member Portion"></asp:BoundField>
                                            <asp:BoundField DataField="Employer Contribution" HeaderText="Employer Portion"></asp:BoundField>
                                            <asp:BoundField DataField="Other Member" HeaderText="Other Member"></asp:BoundField>
                                            <asp:BoundField DataField="Other Employer" HeaderText="Other Employer"></asp:BoundField>
                                            <asp:BoundField DataField="Transfer In Member" HeaderText="Transfer In Member"></asp:BoundField>
                                            <asp:BoundField DataField="Transfer In Employer" HeaderText="Transfer In Employer"></asp:BoundField>
                                            <asp:BoundField DataField="AVC" HeaderText="Voluntary Portion"></asp:BoundField>
                                            <asp:BoundField DataField="Total" HeaderText="Total"></asp:BoundField>

                                        </Columns>
                                    </asp:GridView>
                                    <asp:Button ID="btnExport" runat="server" Visible="false" Text="View Report" OnClick="btnExport_Click" />

                                </td>
                            </tr>
                        </table>
                    </div>
                </form>
                <div class="row">
                    <div class="col-md-12 text-right">
                    </div>
                </div>

            </div>
        </div>
        <!-- END RECENT -->
    </div>
    <div class="col-md-9" id="Div1" runat="server" visible="true">
    <asp:Panel ID="Panel1" runat="server" Width="100%">
        <div class="col-md-12" style="text-align: center;">
            <div>
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ReuseParameterValuesOnRefresh="True" HasToggleGroupTreeButton="false" />
            </div>
        </div>
    </asp:Panel>
</div>

    <!-- END PAGE CONTAINER -->
</asp:Content>

