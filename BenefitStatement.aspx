<%@ Page Title="" Language="C#" MasterPageFile="~/MemberLog.Master" AutoEventWireup="true" CodeBehind="BenefitStatement.aspx.cs" Inherits="PenPortfolio.BenefitStatement" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <asp:HiddenField ID="txtID" runat="server" />
        <asp:HiddenField ID="txtClientID" runat="server" />
        <asp:HiddenField ID="txtFundID" runat="server" />
        <asp:HiddenField ID="txtNationalID" runat="server" />
        <asp:HiddenField ID="txtMemberID" runat="server" />


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
    <div class="col-md-9" id="Div1" runat="server" visible="true">

        <asp:Panel ID="Panel1" runat="server" Width="100%">

            <div class="col-md-12">

                <%-- <div class="card-header">
                                    <h5 class="title">
                                        <asp:Label ID="lblCashBookPayment" runat="server" Text="Bank Reconciliation" Font-Bold="True" ForeColor="Black"></asp:Label>
                                    </h5>
                                </div>--%>

                <div>
                    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ReuseParameterValuesOnRefresh="True" HasToggleGroupTreeButton="false" />
                </div>
            </div>
        </asp:Panel>
    </div>

</asp:Content>
