<%@ Page Title="" Language="C#" MasterPageFile="~/MemberLog.Master" AutoEventWireup="true" CodeBehind="MemberContributions.aspx.cs" Inherits="PenPortfolio.MemberContributions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<!-- START PAGE CONTAINER -->
		<div class="container container-boxed">
            <div class="block block-condensed">
                <div class="col-sm-11" id="dvDash" runat="server" visible="true">
    <div class="row">
        <div class="app-heading app-heading-small">
															<div class="title">
																<h2>Member Contribution History</h2>
																<%--<p>Last visit: 14:54 28.06.2017</p>--%>
															</div>
														</div>
                                        <div class="block-content">
                                             <div class="row">
                                                 <asp:HiddenField ID="txtID" runat="server" />
                            <asp:HiddenField ID="txtClientID" runat="server" />
                            <asp:HiddenField ID="txtFundID" runat="server" />
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
                                            <div class="row">   

                                                      <table style="width:110%">
                                                          <tr>
																			<td colspan="12" runat="server">
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
                                <%--<asp:BoundField DataField="Total" HeaderText="Total"></asp:BoundField>--%>
                                    </Columns>
                </asp:GridView>
                                                                                </td>

                                                          </tr>
                                                     </table>
                                            </div>
                                             <%--<div class="form-block-body">
               
                                                 <div class="form-group row gutters">

                                                        <div class="form-group row gutters col-12">
                                                            
                                                            <div class="col-sm-12 align-content-center">
                                                                  
                                                            </div>
                                                        </div>
                                                        
                                                    </div>
                                                   

                                                    <div class="form-group row gutters">

                                                        <div class="form-group row gutters col-12">
                                                            
                                                            <div class="col-sm-12 align-content-center">
                                                                
                                                            </div>
                                                        </div>
                                                        
                                                    </div>

                                                 
                                                </div>--%>

                                        </div>
        </div>
                                

                            </div>
                </div>
													<!-- RECENT ACTIVITY -->

																				<!-- END RECENT -->
																			</div>
<!-- END PAGE CONTAINER -->
</asp:Content>
