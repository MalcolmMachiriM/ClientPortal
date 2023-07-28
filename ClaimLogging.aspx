<%@ Page Title="" Language="C#" MasterPageFile="~/EmployerLog.Master" AutoEventWireup="true" CodeBehind="ClaimLogging.aspx.cs" Inherits="PenPortfolio.ClaimLogging" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- START PAGE CONTAINER -->
    <div class="container container-boxed">
        <!-- RECENT ACTIVITY -->
        <div class="block block-condensed">
            <div class="app-heading app-heading-small">
                <div class="title">
                    <h2>Claims Logging <%--(<asp:Label ID="lblPensionerName" runat="server" Text="Employer Name"></asp:Label>)--%></h2>
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
                    <asp:HiddenField ID="txtRecID" runat="server" />
                    <asp:HiddenField ID="txtRoleType" runat="server" />
                </div>
            </div>
            <div class="block-content">
                <form class="form-horizontal">
                    <div class="row">
                        <table style="width: 100%">
                            <tr>
                                <td colspan="12">
                                    <asp:HiddenField ID="txtMemberID" runat="server" />
                                    <asp:HiddenField ID="txtFundID" runat="server" />
                                    <asp:HiddenField ID="txtSystemRef" runat="server" />
                                    <asp:HiddenField ID="txtCalType" runat="server" />
                                    <asp:HiddenField ID="txtExitCode" runat="server" />
                                </td>
                            </tr>
                            <tr runat="server" visible="false">
                                <td colspan="2">Search Option:</td>
                                <td colspan="10">
                                    <asp:DropDownList ID="cboSearchOptions" CssClass="form-control dropdown" runat="server"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr runat="server" visible="false">
                                <td colspan="2">Search Value:</td>
                                <td colspan="10">
                                    <asp:TextBox ID="txtSearchValue" CssClass="form-control" placeholder="Search Value" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr runat="server" visible="false">
                                <td colspan="12" style="text-align: center">
                                    <button class="btn btn-primary btn-clean">Search</button>
                                </td>
                            </tr>
                            <tr>
                                <%--<td colspan="12">

																				<asp:GridView ID="grdEmployees" Width="100%" runat="server"
                    AutoGenerateColumns="False" 
                                    DataKeyNames="ID" 
                                    CssClass="table table-condensed" GridLines="None" role="grid" aria-describedby="DataTables_Table_0_info" 
                                    Style="border-collapse: collapse !important"  
                                    AllowPaging="true" AllowSorting="True"" OnPageIndexChanging="grdEmployees_PageIndexChanging"  PageSize="10">
                            <Columns>
                                        <asp:TemplateField HeaderText="Select">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkRecDel" runat ="server" ForeColor="Green" CssClass="fa fa-check fa-2x" CommandArgument='<%#Eval("ID")%>' CommandName ="selectrecord" ></asp:LinkButton>
                                                
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ID" HeaderTEXT="System Ref:" ></asp:BoundField>                                      
                                        <asp:BoundField DataField="Branch"  HeaderText="Pension Basis:"></asp:BoundField>                                      
                                   
                                        <asp:BoundField DataField="Lastname"  HeaderText="Last Name"></asp:BoundField>                                      
                                        <asp:BoundField DataField="Firstname" HeaderText="FirstName(s)"></asp:BoundField>
                                <asp:BoundField DataField="Dob"  HeaderText="Date Of Birth:"></asp:BoundField>   
                                <asp:BoundField DataField="DJC" HeaderText="Date Joined Payroll"></asp:BoundField>
                                <asp:BoundField DataField="DateJoinedCompany" HeaderText="Date Joined Company"></asp:BoundField>
                                <asp:BoundField DataField="EmploymentType" HeaderText="EmploymentType"></asp:BoundField>
                                <asp:BoundField DataField="DJF" HeaderText="Payroll Start Date"></asp:BoundField>
                                <asp:BoundField DataField="MemberCategory" HeaderText="Pension Type"></asp:BoundField>
                                <asp:TemplateField >
                                            <ItemTemplate>
                                                <asp:LinkButton ID="chkSelect" runat ="server" ForeColor="Green" CssClass="fa fa-check fa-2x" CommandArgument='<%#Eval("ID")%>' CommandName ="selectrecord" ></asp:LinkButton>
                                                <asp:HiddenField ID="txtRecVal" Value='<%#Eval("ID") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    
                                    </Columns>
                </asp:GridView>

																			</td>--%>
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
                                <td colspan="2">Claim Type:</td>
                                <td colspan="4">
                                    <asp:DropDownList ID="cboClaimType" CssClass="form-control dropdown" AutoPostBack="true" OnSelectedIndexChanged="cboClaimType_SelectedIndexChanged" runat="server">
                                        <%--<asp:ListItem>Withdrawal</asp:ListItem>
                                                                                    <asp:ListItem>Normal Retirement</asp:ListItem>
                                                                                    <asp:ListItem>Early Retirement</asp:ListItem>
                                                                                    <asp:ListItem>Late Retirement</asp:ListItem>
                                                                                    <asp:ListItem>Ill-Health Retirement</asp:ListItem>
                                                                                    <asp:ListItem>Death</asp:ListItem>
                                                                                    <asp:ListItem>Retrenchment</asp:ListItem>--%>
                                    </asp:DropDownList>
                                </td>
                                <td colspan="2">Gender:</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtGender" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">Exit Date:</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtExitDate" TextMode="Date" CssClass="form-control" ReadOnly="false" runat="server"></asp:TextBox>
                                </td>
                                <td colspan="2">Calculation Date:</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtCalDate" TextMode="Date" CssClass="form-control" ReadOnly="false" runat="server"></asp:TextBox>
                                </td>

                            </tr>
                            <tr id="sh" runat="server" visible="false">
                                <td colspan="15">
                                    <hr />
                                    Beneficiary Details</td>

                            </tr>
                            <tr id="sh1" runat="server" visible="false">
                                <td colspan="2">FirstName:</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtSpouseFirstname" CssClass="form-control" ReadOnly="false" runat="server"></asp:TextBox>
                                </td>
                                <td colspan="2">Surname:</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtSpouseSurname" CssClass="form-control" ReadOnly="false" runat="server"></asp:TextBox>
                                </td>
                                <td colspan="2">NationalID:</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtSpouseID" CssClass="form-control" ReadOnly="false" runat="server"></asp:TextBox>
                                </td>

                            </tr>
                            <tr id="sh2" runat="server" visible="false">
                                <td colspan="2">Date Of Birth:</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtSpouseDOB" TextMode="Date" CssClass="form-control" ReadOnly="false" runat="server"></asp:TextBox>
                                </td>
                                <td colspan="2">Postal Address:</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtSpouseAdd" CssClass="form-control" ReadOnly="false" runat="server"></asp:TextBox>
                                </td>
                                <td colspan="2">Phone Number:</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtSpouseNo" CssClass="form-control" ReadOnly="false" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="sh3" runat="server" visible="false">
                                <td colspan="2">Email:</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtSpouseEmail" CssClass="form-control" ReadOnly="false" runat="server"></asp:TextBox>
                                </td>
                                <td colspan="2">Acc Name:</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtAccName" CssClass="form-control" ReadOnly="false" runat="server"></asp:TextBox>
                                </td>
                                <td colspan="2">Acc No:</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtAccNo" CssClass="form-control" ReadOnly="false" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="sh4" runat="server" visible="false">
                                <td colspan="2">Bank:</td>
                                <td colspan="4">
                                    <asp:DropDownList ID="drpBank" CssClass="form-control dropdown" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td colspan="2">Branch:</td>
                                <td colspan="4">
                                    <asp:DropDownList ID="drpBranch" CssClass="form-control dropdown" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td colspan="2">Share(%):</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtSpouseShare" CssClass="form-control" ReadOnly="false" runat="server"></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td colspan="2">Claim No:</td>
                                <td colspan="10">
                                    <asp:TextBox ID="txtClaimNo" placeholder="######" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                </td>

                            </tr>
                            <tr>
                                <td colspan="12" style="text-align: center">
                                    <%-- <button class="btn btn-primary btn-clean">Save Claim</button>--%>
                                    <asp:Button ID="btnSaveClaim" CssClass="btn btn-primary btn-clean" OnClick="btnSaveClaim_Click" runat="server" Text="Save Claim" />

                                    <%--<button class="btn btn-primary btn-clean">Discard Claim</button>--%>
                                    <asp:Button ID="btnDiscardClaim" CssClass="btn btn-primary btn-clean" OnClick="btnDiscardClaim_Click" runat="server" Visible="false" Text="Discard Claim" />

                                    <asp:Button ID="Button1" CssClass="btn btn-primary btn-clean" OnClick="Button1_Click" runat="server" Visible="false" Text="Track A Claim" />

                                </td>
                            </tr>
                        </table>
                    </div>
                </form>
                <div class="row">
                    <div class="col-md-12 text-right">
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
                                <CR:CrystalReportViewer ID="CrvTrialBalance" runat="server" AutoDataBind="true" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ReuseParameterValuesOnRefresh="True" HasToggleGroupTreeButton="false" />
                            </div>
                        </div>
                    </asp:Panel>
                </div>
                <div class="form-group row gutters">

                    <div class="form-group row gutters col-12">

                        <div class="col-sm-12 align-content-center">
                            <asp:GridView ID="grdClientsView" Width="100%" runat="server"
                                AutoGenerateColumns="False" AutoGenerateSelectButton="false"
                                DataKeyNames="ID"
                                CssClass="table table-condensed" GridLines="None" role="grid" aria-describedby="DataTables_Table_0_info"
                                Style="border-collapse: collapse !important"
                                AllowPaging="True" AllowSorting="True" OnRowCommand="grdClientsView_RowCommand">
                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="Claim No"></asp:BoundField>
                                    <asp:BoundField DataField="MemberID" HeaderText="MemberID"></asp:BoundField>
                                    <asp:BoundField DataField="ExitDate" HeaderText="ExitDate"></asp:BoundField>
                                    <asp:BoundField DataField="FirstName" HeaderText="FirstName"></asp:BoundField>
                                    <asp:BoundField DataField="LastName" HeaderText="LastName"></asp:BoundField>
                                    <asp:BoundField DataField="ExitType" HeaderText="ExitType"></asp:BoundField>
                                    <asp:BoundField DataField="ClaimStatus" HeaderText="ClaimStatus"></asp:BoundField>


                                    <%--        
                                        <asp:TemplateField HeaderText="View Quotation">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkRecSel" runat ="server" ForeColor="green" CssClass="fa fa-bank fa-2x" CommandArgument='<%#Eval("ID")%>' CommandName ="selectrecord" ></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField> --%>
                                    <asp:TemplateField HeaderText="View Quotation">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnView" runat="server" CssClass="btn btn-success btn-icon btn-sm " CommandName="selectrecord" CommandArgument="<%# Container.DataItemIndex %>">
                                                        <i class="fa fa-eye"></i>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Discard">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkRecDel" runat="server" ForeColor="red" CssClass="fa fa-trash fa-2x" CommandArgument='<%#Eval("ID")%>' CommandName="deleterecord"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>

                </div>

            </div>
        </div>
        <!-- END RECENT -->
    </div>
    <!-- END PAGE CONTAINER -->
</asp:Content>

