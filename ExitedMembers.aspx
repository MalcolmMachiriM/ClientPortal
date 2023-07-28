<%@ Page Title="" Language="C#" MasterPageFile="~/EmployerLog.Master" AutoEventWireup="true" CodeBehind="ExitedMembers.aspx.cs" Inherits="PenPortfolio.ExitedMembers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<!-- START PAGE CONTAINER -->
		<div class="container container-boxed">
            <div class="block block-condensed">
                <div class="col-sm-12" id="dvDash" runat="server" visible="true">
    <div class="row col-sm-12">
        <asp:Panel ID="pnlDash" runat="server" Visible="true">
                                    <div class="card">
                                        <%--<div class="card-header">Payslip History</div>--%>
                                        <div class="app-heading app-heading-small">
															<div class="title">
																<h2>Exited Members</h2>
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
                                    AllowPaging="True" AllowSorting="True" >
                            <Columns> 
                               <asp:BoundField DataField="FirstName" HeaderText=" Name"></asp:BoundField>
                                <asp:BoundField DataField="LastName" HeaderText=" Surname"></asp:BoundField>                                      
                                <asp:BoundField DataField="IdentityNo" HeaderText="Identity Number"></asp:BoundField>
                                <asp:BoundField DataField="DateOfExit" HeaderText="Exit Date"></asp:BoundField>
                                <%--<asp:BoundField DataField="Branch" HeaderText="Branch Name"></asp:BoundField>--%>
                                <asp:BoundField DataField="Description" HeaderText="Exit Type"></asp:BoundField>
                                                                                                                                                                  
                                    
                                    </Columns>
                </asp:GridView>
                                                            </div>
                                                        </div>
                                                        
                                                    </div>
                                                   

                                                   <%-- <div class="form-group row gutters">

                                                        <div class="form-group row gutters col-12">
                                                            
                                                            <div class="col-sm-12 align-content-center">
                                                                
                                                            </div>
                                                        </div>
                                                        
                                                    </div>--%>

                                                 
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