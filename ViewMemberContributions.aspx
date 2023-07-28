<%@ Page Title="" Language="C#" MasterPageFile="~/MemberLog.Master" AutoEventWireup="true" CodeBehind="ViewMemberContributions.aspx.cs" Inherits="PenPortfolio.ViewMemberContributions" %>
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
																<h2>Member Contribution History</h2>
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
                                             <div class="form-block-body">
               
                                                 <hr />
                                                 <hr />
                                                 <div class="form-group row gutters">

                                                        <div class="form-group row gutters col-12">
                                                            
                                                            <div class="col-sm-12 align-content-center">
                                                                  <asp:GridView ID="grdContributions" Width="100%" runat="server" 
                    AutoGenerateColumns="False" AutoGenerateSelectButton="false" OnPageIndexChanging="grdContributions_PageIndexChanging"
                                    DataKeyNames="ID" pagesize="10"
                                    CssClass="table table-condensed" GridLines="None" role="grid" aria-describedby="DataTables_Table_0_info" 
                                    Style="border-collapse: collapse !important"  
                                    AllowPaging="True" AllowSorting="True" >
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