<%@ Page Language="C#" MasterPageFile="~/EmployerLog.Master" AutoEventWireup="true" CodeBehind="EmployerRegister.aspx.cs" Inherits="PenPortfolio.EmployerRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
<!-- START PAGE CONTAINER -->
		<div class="container container-boxed">
            <div class="block block-condensed">
                <div class="col-sm-9" id="dvDash" runat="server" visible="true">
    <div class="row col-sm-12">
        <asp:Panel ID="pnlDash" runat="server" Visible="true">
                                    <div class="card">
                                        <%--<div class="card-header">Payslip History</div>--%>
                                        <div class="app-heading app-heading-small">
															<div class="title">
																<h2>Active Contributing Members</h2>
																<%--<p>Last visit: 14:54 28.06.2017</p>--%>
															</div>
														</div>
                                        <div class="form-block">
                                             <div class="row">
                            <asp:HiddenField ID="txtID" runat="server" />
                            <asp:HiddenField ID="txtClientID" runat="server" />
                            <asp:HiddenField ID="txtFundID" runat="server" />
                            <asp:HiddenField ID="txtParticipatingEmployerID" runat="server" />
                        </div>
                                             <div class="form-block-body">
                                                <%-- <div class="form-group row gutters">
                   
                                                        <div class="form-group row gutters col-4">
                                                            <label class="col-sm-5 col-form-label text-left"><b>First Name(s): </b></label>
                                                            <div class="col-sm-7">
                                                                <asp:TextBox ID="txtFirstName" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                     <div class="form-group row gutters col-4">
                                                            <label class="col-sm-5 col-form-label text-left"><b>Last Name(s): </b></label>
                                                            <div class="col-sm-7">
                                                                <asp:TextBox ID="txtLastName" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>

                                                    </div>--%>
                                                 <hr />
                                                 <table style="width: 100%">
                                                     <tr>
            <td colspan="2">
                <asp:TextBox ID="txtSSNSearch" placeholder="System Ref" CssClass="form-control" runat="server"></asp:TextBox></td>
            <td colspan="2">
                <asp:TextBox ID="txtFnameSearch" placeholder="Firstname" CssClass="form-control" runat="server"></asp:TextBox>
            </td>
            <td colspan="2"><asp:TextBox ID="txtLnameSearch" placeholder="Lastname" CssClass="form-control" runat="server"></asp:TextBox></td>
            <td colspan="2">
                <asp:TextBox ID="txtNationalID" placeholder="IdentityNo" CssClass="form-control" runat="server"></asp:TextBox>
            </td>
            <td colspan="2"></td>
            <td colspan="2">
                <asp:Button ID="btnSearch" OnClick="btnSearch_Click" CssClass="btn btn-primary" runat="server" Text="Filter Search" />
            </td>
        </tr>
                                                     </table>
                                                    
                                                 <hr />
                                                 <div class="form-group row gutters">

                                                        <div class="form-group row gutters col-12">
                                                            
                                                            <div class="col-sm-12 align-content-center">
                                                                   <asp:GridView ID="grdClientsView" Width="100%" runat="server"
                    AutoGenerateColumns="False" AutoGenerateSelectButton="false" OnPageIndexChanging="grdClientsView_PageIndexChanging"
                                    DataKeyNames="ID"
                                    CssClass="table table-condensed" GridLines="None" role="grid" aria-describedby="DataTables_Table_0_info" 
                                    Style="border-collapse: collapse !important" 
                                    AllowPaging="True" AllowSorting="True" PageSize="10" OnRowCommand="grdClients_RowCommand">
                            <Columns>
                                <%--<asp:BoundField DataField="SSN" HeaderText="SSN"></asp:BoundField>--%>
                                <asp:BoundField DataField="ID" HeaderText="SystemRef"></asp:BoundField> 
                                        <asp:BoundField DataField="FundCategory" HeaderText="Fund Category"></asp:BoundField>                                      
                                        <asp:BoundField DataField="LastName" HeaderText="Surname"></asp:BoundField>
                                <asp:BoundField DataField="FirstName" HeaderText="Firstname(s)"></asp:BoundField>
                                <asp:BoundField DataField="IdentityNo" HeaderText="ID Number"></asp:BoundField>
                                
                                                   <asp:TemplateField HeaderText="View">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkRecDel" runat ="server" ForeColor="Green" CssClass="fa fa-file-archive-o fa-2x" CommandArgument='<%#Eval("ID")%>' CommandName ="selectrecord" ></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>                                                                                                                  
                                    
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
