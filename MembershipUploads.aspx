﻿<%@ Page Title="" Language="C#" MasterPageFile="~/EmployerLog.Master" AutoEventWireup="true" CodeBehind="MembershipUploads.aspx.cs" Inherits="PenPortfolio.MembershipUploads" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- START PAGE CONTAINER -->
    <div class="container container-boxed">
        <!-- RECENT ACTIVITY -->
        <div class="block block-condensed">
            <div class="app-heading app-heading-small">
                <div class="title">
                    <h2>Membership Upload Page<%--(<asp:Label ID="lblPensionerName" runat="server" Text="Employer Name"></asp:Label>)</h2>--%>
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
                            <asp:Label ID="lblSuccess" runat="server" Text=""></asp:Label>
                            .
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
                            <asp:Label ID="lblWarning" runat="server" Text=""></asp:Label>
                            .
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
                            <asp:Label ID="lblDanger" runat="server" Text=""></asp:Label>
                            .
                            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                <span class="fa fa-times" />
                            </button>
                        </div>
                    </div>
                </asp:Panel>
            </div>
            <div class="row">

                <div class="col-md-6">
                    <asp:HiddenField ID="txtID" runat="server" />
                    <asp:HiddenField ID="txtSystemRef" runat="server" />
                    <asp:HiddenField ID="txtFundID" runat="server" />
                    <asp:HiddenField ID="txtViewType" runat="server" />
                    <asp:HiddenField ID="txtbatchID" runat="server" />
                    <asp:HiddenField ID="txtRegNo" runat="server" />
                </div>
            </div>
            <div class="block-content">
                <form class="form-horizontal">
                    <div class="row">
                        <table style="width: 100%">
                            <tr>
                                <td colspan="12">
                                    <asp:Panel ID="pnlComms" Width="100%" runat="server">
                                        <asp:Label ID="lblComms" runat="server" Text="" Font-Bold="True" ForeColor="White"></asp:Label>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="12">
                                    <asp:HiddenField ID="txtMemberID" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">Cost Center:</td>
                                <td colspan="4">
                                    <asp:DropDownList ID="cboCompany" CssClass="form-control dropdown" runat="server">
                                        <%--<asp:ListItem>Head Office</asp:ListItem>
                                                                                    <asp:ListItem>Harare CBD Branch</asp:ListItem>
                                                                                    <asp:ListItem>Gweru Office</asp:ListItem>--%>
                                    </asp:DropDownList>
                                </td>

                            </tr>
                            <tr>
                                <td colspan="2">Payment Date:</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtDateOfUpload" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                                </td>


                            </tr>
                            <tr>
                                <td colspan="1">
                                    <asp:Label ID="lblCurrentMembers" runat="server" Font-Names="Courier New" Text=""></asp:Label>
                                </td>
                                <td colspan="2"></td>
                                <td colspan="1">
                                    <asp:Label ID="lblFailedUploads" runat="server" Font-Names="Courier New" Text=""></asp:Label>
                                </td>
                                <td colspan="2"></td>
                            </tr>
                            <tr>
                                <td colspan="2">File:</td>
                                <td colspan="4">
                                    <asp:FileUpload ID="flContributionsUpload" runat="server" accept=".xls,.xlsx,.csv" />
                                </td>
                            </tr>
                            <%--<tr>
                                                                            <td colspan="4">
                                                                                <asp:Button ID="btnDownload" OnClick="btnDownload_Click" CssClass="btn btn-primary" runat="server" Text="Download Template" />

                                                                            </td>
                                                                        </tr>--%>
                            <tr>
                                <td colspan="12" style="text-align: center">

                                    <asp:Button ID="btnDownload" OnClick="btnDownload_Click" CssClass="btn btn-primary" runat="server" Text="Download Template" />
                                    |
                                                 <asp:Button ID="btnUpload" OnClick="btnUpload_Click" CssClass="btn btn-primary" runat="server" Text="Upload" />


                            </tr>
                            <tr>

                                <td colspan="2">Sheet:</td>
                                <td colspan="4">
                                    <asp:ListBox ID="lstWrkSheets" OnSelectedIndexChanged="lstWrkSheets_SelectedIndexChanged" CssClass="form-control list-group" AutoPostBack="true" runat="server"></asp:ListBox>
                                </td>
                                <%--            <td colspan="1"><asp:Label ID="lblSalaryBill" runat="server" Text="" Font-Names="Courier New"></asp:Label></td>
            <td colspan="2"></td>--%>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblWrkSheetPrompt" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtFilePath" Visible="false" runat="server"></asp:TextBox>
                                    <asp:TextBox ID="txtFileName" Visible="false" runat="server"></asp:TextBox>
                                </td>

                            </tr>
                            <tr>
                                <td colspan="12">
                                    <hr />
                                </td>
                            </tr>

                            <tr>
                                <td colspan="12" style="text-align: center">
                                    <asp:Button ID="btnProcess" CssClass="btn btn-primary btn-clean" OnClick="btnProcess_Click" OnClientClick="return confirm('Are you sure want you want to upload these contributions?');" runat="server" Text="Process Upload" />
                                    <%--<button class="btn btn-primary btn-clean">Process Upload</button>--%>
                                                                                | 
                                                                                <%--<button class="btn btn-primary btn-clean">Discard Upload</button>--%>
                                    <asp:Button ID="btnDiscard" CssClass="btn btn-primary btn-clean" OnClick="btnDiscard_Click" runat="server" Text="Discard Upload" />
                                </td>
                            </tr>
                            <tr>

                                <td colspan="12" style="width: 100%;">
                                    <table style="max-width: 100vw">

                                        <tr>

                                            <td colspan="12" style="width: 100%;">
                                                <table style="max-width: 100vw">
                                                    <tr>
                                                        <td colspan="12">Pending Members Upload</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div style="display: block; overflow: scroll; height: 40vh; display: grid;">
                                                                <asp:GridView ID="grdClientsView" OnPageIndexChanging="OnPageIndexChanging" PageSize="10" AutoGenerateColumns="false" DataKeyNames="ID" CssClass="table table-condensed" GridLines="None" role="grid" aria-describedby="DataTables_Table_0_info"
                                                                    Style="border-collapse: collapse !important"
                                                                    AllowPaging="True" AllowSorting="True" runat="server">
                                                                    <columns>
                                                                        <asp:BoundField DataField="ID" HeaderText="UploadID"></asp:BoundField>
                                                                        <asp:BoundField DataField="EmployerName" HeaderText="EmployerName"></asp:BoundField>
                                                                        <asp:BoundField DataField="Surname" HeaderText="Surname"></asp:BoundField>
                                                                        <asp:BoundField DataField="Forenames" HeaderText="Forename(s)"></asp:BoundField>
                                                                        <asp:BoundField DataField="IDNumber" HeaderText="IDNumber"></asp:BoundField>
                                                                        <asp:BoundField DataField="Gender" HeaderText="Gender"></asp:BoundField>
                                                                        <asp:BoundField DataField="DateOfBirth" HeaderText="DateOfBirth"></asp:BoundField>
                                                                    </columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>




                                            </td>
                                        </tr>
                                        <tr>

                                            <td colspan="12" style="width: 100%;">
                                                <table style="max-width: 100vw">
                                                    <tr>
                                                        <td colspan="12">Failed Members Upload</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div style="display: block; overflow: scroll; height: 40vh; display: grid;">
                                                                <asp:GridView ID="grdUploadError" OnPageIndexChanging="OnPageIndexChanging" PageSize="10" AutoGenerateColumns="false" CssClass="table table-condensed" GridLines="None" role="grid" aria-describedby="DataTables_Table_0_info"
                                                                    Style="border-collapse: collapse !important"
                                                                    AllowPaging="True" AllowSorting="True" runat="server">
                                                                    <columns>
                                                                        <asp:BoundField DataField="ID" HeaderText="ID" />
                                                                        <asp:BoundField DataField="NationalID" HeaderText="NationalID" />
                                                                        <asp:BoundField DataField="Description" HeaderText="Description" />
                                                                        <asp:BoundField DataField="BranchCode" HeaderText="BranchCode" />
                                                                        <asp:BoundField DataField="DateCreated" HeaderText="DateCreated" />
                                                                    </columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>




                                            </td>
                                        </tr>
                                    </table>
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
    <!-- END PAGE CONTAINER -->
</asp:Content>
