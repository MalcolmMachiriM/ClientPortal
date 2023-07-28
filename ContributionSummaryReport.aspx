<%@ Page Title="" Language="C#" MasterPageFile="~/EmployerLog.Master" AutoEventWireup="true" CodeBehind="ContributionSummaryReport.aspx.cs" Inherits="PenPortfolio.ContributionSummaryReport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- START PAGE CONTAINER -->
    <div class="container container-boxed">
        <div class="block block-condensed">
            <div class="col-sm-9" id="dvDash" runat="server" visible="true">
                <div class="row col-sm-12">
                    <asp:Panel ID="pnlDash" runat="server" Visible="true">
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
                        <div class="card">
                            <%--<div class="card-header">Payslip History</div>--%>
                            <div class="app-heading app-heading-small">
                                <div class="title">
                                    <h2>Contribution Summary Report</h2>

                                </div>
                            </div>
                            <div class="form-block">
                                <div class="row">
                                    <asp:HiddenField ID="txtFundID" runat="server" />
                                    <asp:HiddenField ID="txtSystemRef" runat="server" />
                                </div>
                                <div class="form-block-body">
                                    <div class="form-group row gutters">

                                        <div class="form-group row gutters col-4">
                                            <label class="col-sm-5 col-form-label text-left"><b>Start Date: </b></label>
                                            <div class="col-sm-7">
                                                <asp:TextBox ID="txtFrom" CssClass="form-control" TextMode="Date" ReadOnly="false" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row gutters col-4">
                                            <label class="col-sm-5 col-form-label text-left"><b>End Date: </b></label>
                                            <div class="col-sm-7">
                                                <asp:TextBox ID="txtTo" CssClass="form-control" TextMode="Date" ReadOnly="false" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row gutters col-4">
                                            <label class="col-sm-5 col-form-label text-left"><b>Branch: </b></label>
                                            <div class="col-sm-7">
                                                <%--<asp:TextBox ID="txtBranchCode" CssClass="form-control"  ReadOnly="false" runat="server"></asp:TextBox>--%>
                                                <asp:DropDownList ID="cbobranch" CssClass="form-control dropdown" runat="server"></asp:DropDownList>
                                                <%--<asp:TextBox ID="txtBranch" runat="server" CssClass="form-control"></asp:TextBox>--%>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group row gutters col-4">
                                        <label class="col-sm-5 col-form-label text-left"><b></b></label>
                                        <div class="col-sm-7">
                                            <asp:Button ID="btnView" OnClick="btnView_Click" CssClass="btn btn-primary" runat="server" Text="View Report" />
                                        </div>
                                    </div>

                                </div>
                            </div>

                        </div>
                    </asp:Panel>

                </div>
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


        </div>
    </div>
    <!-- RECENT ACTIVITY -->

    <!-- END RECENT -->

    <!-- END PAGE CONTAINER -->
</asp:Content>
