<%@ Page Title="" Language="C#" MasterPageFile="~/PensionerLog.Master" AutoEventWireup="true" CodeBehind="PensionerPayrollSummary.aspx.cs" Inherits="PenPortfolio.PensionerPayrollSummary" %>

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
																<h2>Payslip History</h2>
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
                                                 <div class="form-group row gutters">
                   
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

                                                    </div>
                                                 <hr />
                                                 
                                                    
                                                 <hr />
                                                 <div class="form-group row gutters">

                                                        <div class="form-group row gutters col-12">
                                                            
                                                            <div class="col-sm-12 align-content-center">
                                                                   <asp:GridView ID="grdClientsView" Width="100%" runat="server"
                    AutoGenerateColumns="False" AutoGenerateSelectButton="false" OnPageIndexChanging="OnPageIndexChanging"
                                    DataKeyNames="Pay Date" 
                                    CssClass="table table-condensed" GridLines="None" role="grid" aria-describedby="DataTables_Table_0_info" 
                                    Style="border-collapse: collapse !important"  
                                    AllowPaging="True" AllowSorting="True" >
                            <Columns>
                                <asp:BoundField DataField="Pay Date" HeaderText="Pay Date"></asp:BoundField>
                                        <asp:BoundField DataField="Monthly BAsic" HeaderText="Monthly Basic"></asp:BoundField>                                      
                                        <asp:BoundField DataField="Paye" HeaderText="Paye"></asp:BoundField>
                                <%--<asp:BoundField DataField="DateOfBirth" HeaderText="DateOfBirth"></asp:BoundField>--%>
                                <asp:BoundField DataField="AidsLevy" HeaderText="Aids Levy"></asp:BoundField>
                                <asp:BoundField DataField="NetSalary" HeaderText="Net Salary"></asp:BoundField>
                                
                                                                                                                                                                  
                                    
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

