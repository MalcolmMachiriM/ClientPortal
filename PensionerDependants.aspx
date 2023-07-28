<%@ Page Title="" Language="C#" MasterPageFile="~/PensionerLog.Master" AutoEventWireup="true" CodeBehind="PensionerDependants.aspx.cs" Inherits="PenPortfolio.PensionerDependants" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<!-- START PAGE CONTAINER -->
		<div class="container container-boxed">
													<!-- RECENT ACTIVITY -->
													<div class="block block-condensed">
														<div class="app-heading app-heading-small">
															<div class="title">
																<h2>Dependants (<asp:Label ID="lblPensionerName" runat="server" Text="Pensioner Name"></asp:Label>)</h2>
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
														<div class="block-content">
															<form class="form-horizontal">
																<div class="row">
																	<table style="width:100%">
                                                                        <tr>
                                                                            <td colspan="12">
                                                                                <asp:HiddenField ID="txtRecID" runat="server" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">Firstname(s)</td>
                                                                            <td colspan="4">
                                                                                <asp:TextBox ID="txtFirstname" CssClass="form-control" runat="server"></asp:TextBox></td>
                                                                            <td colspan="2">Surname</td>
                                                                            <td colspan="4">
                                                                                <asp:TextBox ID="txtSurname" CssClass="form-control" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">National ID</td>
                                                                            <td colspan="4">
                                                                                <asp:TextBox ID="txtNationalID" CssClass="form-control" runat="server"></asp:TextBox>
                                                                            </td>
                                                                            <td colspan="2">Date Of Birth</td>
                                                                            <td colspan="4">
                                                                                <asp:TextBox ID="txtDOB" CssClass="form-control" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">Relationship To Member</td>
                                                                            <td colspan="4">
                                                                                <asp:DropDownList ID="cboRelationship" CssClass="form-control dropdown" runat="server"></asp:DropDownList>
                                                                            </td>
                                                                            <td colspan="2">Gender</td>
                                                                            <td colspan="4">
                                                                                <asp:DropDownList ID="cboGender" CssClass="form-control dropdown" runat="server"></asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2"></td>
                                                                            <td colspan="4"></td>
                                                                            <td colspan="2"></td>
                                                                            <td colspan="4"></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="12"><hr /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="12" style="text-align:center">
                                                                                <button class="btn btn-primary btn-clean">Save Dependant Profile</button>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="12"><hr /></td>
                                                                        </tr>
																		<tr>
																			<td colspan="12">

																				<asp:GridView ID="grdDependants" Width="100%" runat="server"
                    AutoGenerateColumns="False" 
                                    DataKeyNames="ID" 
                                    CssClass="table table-condensed" GridLines="None" role="grid" aria-describedby="DataTables_Table_0_info" 
                                    Style="border-collapse: collapse !important"  
                                    AllowPaging="true" AllowSorting="True" OnPageIndexChanging="grdDependants_PageIndexChanging"  PageSize="10">
                            <Columns>
                                        <asp:TemplateField HeaderText="Mark">
                                            <ItemTemplate>
                                                <%--<asp:LinkButton ID="lnkRecDel" runat ="server" ForeColor="Green" CssClass="fa fa-check fa-2x" CommandArgument='<%#Eval("ID")%>' CommandName ="selectrecord" ></asp:LinkButton>--%>
                                                <asp:CheckBox ID="chkSel" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ID" HeaderTEXT="RefID" ></asp:BoundField>                                      
                                        <asp:BoundField DataField="ECNo"  HeaderText="Employee No."></asp:BoundField>                                      
                                        <asp:BoundField DataField="Surname"  HeaderText="Last Name"></asp:BoundField>                                      
                                        <asp:BoundField DataField="Firstnames" HeaderText="FirstName(s)"></asp:BoundField>
                                <asp:BoundField DataField="NRC" HeaderText="NRC"></asp:BoundField>
                                <%--<asp:BoundField DataField="DateJoinedCompany" HeaderText="Date Joined Company"></asp:BoundField>
                                <asp:BoundField DataField="EmploymentType" HeaderText="EmploymentType"></asp:BoundField>--%>
                                <asp:BoundField DataField="Category" HeaderText="Category"></asp:BoundField>
                                <asp:BoundField DataField="ClientLoanBalance" HeaderText="Current Loan Balance"></asp:BoundField>
                                <asp:BoundField DataField="NewLoanAmount" HeaderText="New Loan Amount"></asp:BoundField>
                                <asp:BoundField DataField="MonthlyInstallments" HeaderText="Installments"></asp:BoundField>
                                <%--<asp:BoundField DataField="LoanTenure" HeaderText="Loan Tenure"></asp:BoundField>--%>
                                <asp:BoundField DataField="DateRequested" HeaderText="Date Requested"></asp:BoundField>
                                <asp:BoundField DataField="Initiator" HeaderText="Requested By"></asp:BoundField>
                                <%--<asp:BoundField DataField="AgeOfRequest" HeaderText="Age of Request"></asp:BoundField>
                                <asp:BoundField DataField="RequestCreatedBy" HeaderText="Request By"></asp:BoundField>--%>
                                                                
                                        
                                        <%--<asp:TemplateField HeaderText="Select">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="chkSelect" runat ="server" ForeColor="Green" CssClass="fa fa-check fa-2x" CommandArgument='<%#Eval("ID")%>' CommandName ="selectrecord" ></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>   --%>
                                        
                                <asp:TemplateField >
                                            <ItemTemplate>
                                                <%--<asp:LinkButton ID="chkSelect" runat ="server" ForeColor="Green" CssClass="fa fa-check fa-2x" CommandArgument='<%#Eval("ID")%>' CommandName ="selectrecord" ></asp:LinkButton>--%>
                                                <asp:HiddenField ID="txtRecVal" Value='<%#Eval("ID") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    
                                    </Columns>
                </asp:GridView>

																			</td>
																		</tr>
																	</table>
																	</div>
                                                            </form>
																							<div class="row">
																								<div class="col-md-12 text-right">
																									<button class="btn btn-primary btn-clean">Go To Statements</button>
																								</div>
																							</div>
																						
																					</div>
																				</div>
																				<!-- END RECENT -->
																			</div>
<!-- END PAGE CONTAINER -->
</asp:Content>

