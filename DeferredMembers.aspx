<%@ Page Title="" Language="C#" MasterPageFile="~/EmployerLog.Master" AutoEventWireup="true" CodeBehind="DeferredMembers.aspx.cs" Inherits="PenPortfolio.DeferredMembers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- START PAGE CONTAINER -->
    <div class="container container-boxed">
        <div class="block block-condensed">
            <div class="col-sm-9" id="dvDash" runat="server" visible="true">
                <div class="row col-sm-12">
                    <%--<asp:Panel ID="pnlWarning" runat="server">
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
                    </asp:Panel>--%>
                    <asp:Panel ID="pnlDash" runat="server" Visible="true">
                        <div class="card">
                            <%--<div class="card-header">Payslip History</div>--%>
                            <div class="app-heading app-heading-small">
                                <div class="title">
                                    <h2>Deferred Members</h2>
                                    <%--<p>Last visit: 14:54 28.06.2017</p>--%>
                                </div>
                            </div>
                            <div class="form-block">
                                <div class="row">
                                    <asp:HiddenField ID="txtID" runat="server" />
                                    <asp:HiddenField ID="txtClientID" runat="server" />
                                    <asp:HiddenField ID="txtFundID" runat="server" />
                                    <asp:HiddenField ID="txtMemberID" runat="server" />
                                </div>
                                <div class="row">
                                    <asp:Panel ID="pnlComms" Width="100%" runat="server">
                    <asp:Label ID="lblComms" runat="server" Text="" Font-Bold="True" ForeColor="White"></asp:Label>
                </asp:Panel>

                                </div>
                                <div class="form-block-body">

                                    <div class="form-group row gutters">

                                        <div class="form-group row gutters col-12">

                                            <div class="col-sm-12 align-content-center">
                                                <asp:GridView ID="grdClientsView" Width="100%" runat="server"
                                                    AutoGenerateColumns="False" AutoGenerateSelectButton="false" OnPageIndexChanging="OnPageIndexChanging"
                                                    DataKeyNames="ID"
                                                    CssClass="table table-condensed" GridLines="None" role="grid" aria-describedby="DataTables_Table_0_info"
                                                    Style="border-collapse: collapse !important"
                                                    AllowPaging="True" AllowSorting="True">
                                                    <Columns>
                                                        <asp:BoundField DataField="FirstName" HeaderText="FirstName"></asp:BoundField>
                                                        <asp:BoundField DataField="LastName" HeaderText="LastName"></asp:BoundField>
                                                        <asp:BoundField DataField="IdentityNo" HeaderText="IdentityNo"></asp:BoundField>
                                                        <asp:BoundField DataField="DateOfBirth" HeaderText="DateOfBirth"></asp:BoundField>
                                                        <asp:BoundField DataField="DateJoinedFund" HeaderText="DateJoinedFund"></asp:BoundField>
                                                        <asp:BoundField DataField="DateUploaded" HeaderText="DateUploaded"></asp:BoundField>
                                                        <asp:BoundField DataField="age" HeaderText="Age"></asp:BoundField>



                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>

                                    </div>


                                    <div class="form-group row gutters">

                                        <div class="form-group row gutters col-12">

                                            <div class="col-sm-12 align-content-center">
                                            </div>
                                        </div>

                                    </div>


                                </div>

                            </div>

                        </div>
                    </asp:Panel>
                </div>


            </div>
        </div>
        <!-- RECENT ACTIVITY -->

        <!-- END RECENT -->
    </div>
    <!-- END PAGE CONTAINER -->
</asp:Content>
