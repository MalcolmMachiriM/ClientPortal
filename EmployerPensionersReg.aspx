<%@ Page Title="" Language="C#" MasterPageFile="~/EmployerLog.Master" AutoEventWireup="true" CodeBehind="EmployerPensionersReg.aspx.cs" Inherits="PenPortfolio.EmployerPensionersReg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<!-- START PAGE CONTAINER -->
		<div class="container container-boxed">
													<!-- RECENT ACTIVITY -->
													<div class="block block-condensed">
														<div class="app-heading app-heading-small">
															<div class="title">
																<h2>Pensioner Details <%--(<asp:Label ID="lblPensionerName" runat="server" Text="Employer Name"></asp:Label>)--%></h2>
																<%--<p>Last visit: 14:54 28.06.2017</p>--%>
															</div>
														</div>
                                                        <div class="row">
													<asp:Panel ID="pnlSuccess" runat="server">
													<div class="col-md-12">
														<div class="alert alert-success alert-icon-block alert-dismissible" role="alert">
        														<div class="alert-icon">
																	<span class="icon-checkmark-circle"/>
																</div>
																<strong>Success!</strong> <asp:Label ID="lblSuccess" runat="server" Text=""></asp:Label>. <button type="button" class="close" data-dismiss="alert" aria-label="Close">
																	<span class="fa fa-times"/>
																</button>
														</div>
													</div>
												</asp:Panel>
													<asp:Panel ID="pnlWarning" runat="server">
													<div class="col-md-12">
																												<div class="alert alert-warning alert-icon-block alert-dismissible" role="alert">
																													<div class="alert-icon">
																														<span class="icon-chart-bars"/>
																													</div>
																													<strong>Warning!</strong> <asp:Label ID="lblWarning" runat="server" Text=""></asp:Label>. <button type="button" class="close" data-dismiss="alert" aria-label="Close">
																														<span class="fa fa-times"/>
																													</button>
																												</div>
																											</div>
												</asp:Panel>
													<asp:Panel ID="pnlDanger" runat="server">
													<div class="col-md-12">
																												<div class="alert alert-danger alert-icon-block alert-dismissible" role="alert">
																													<div class="alert-icon">
																														<span class="icon-menu-circle"/>
																													</div>
																													<strong>Danger!</strong> <asp:Label ID="lblDanger" runat="server" Text=""></asp:Label>. <button type="button" class="close" data-dismiss="alert" aria-label="Close">
																														<span class="fa fa-times"/>
																													</button>
																												</div>
																											</div>
												</asp:Panel>
												</div>
		<div class="row">

                        <div class="col-md-6">
							<asp:HiddenField ID="txtFundID" runat="server" />
							<asp:HiddenField ID="txtMemberIDs" runat="server" />
                            <asp:HiddenField ID="txtSystemRef" runat="server" />
							</div>
			</div>
														<div class="block-content">
															<form class="form-horizontal">
																<div class="row">
																	<table style="width:100%">
                                                                        <tr>
                                                                            <td colspan="12">
                                                                                <asp:HiddenField ID="txtMemberID" runat="server" />
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
                                                                            <td colspan="12" style="text-align:center">
                                                                                <button class="btn btn-primary btn-clean">Search</button>
                                                                            </td>
                                                                        </tr>
																		<tr>
																			<td colspan="12">

																				<asp:GridView ID="grdEmployees" Width="100%" runat="server"
                    AutoGenerateColumns="False" 
                                    DataKeyNames="ID" 
                                    CssClass="table table-condensed" GridLines="None" role="grid" aria-describedby="DataTables_Table_0_info" 
                                    Style="border-collapse: collapse !important"  
                                    AllowPaging="true" AllowSorting="True" OnPageIndexChanged="grdEmployees_PageIndexChanged" OnPageIndexChanging="grdEmployees_PageIndexChanging"  PageSize="10">
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
                                <%--<asp:BoundField DataField="DateJoinedCompany" HeaderText="Date Joined Company"></asp:BoundField>
                                <asp:BoundField DataField="EmploymentType" HeaderText="EmploymentType"></asp:BoundField>--%>
                                <asp:BoundField DataField="DJF" HeaderText="Payroll Start Date"></asp:BoundField>
                                <asp:BoundField DataField="MemberCategory" HeaderText="Pension Type"></asp:BoundField>
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
                                                                        <tr>
                                                                            <td colspan="12"><hr /></td>
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
                                                                            <td colspan="4"><asp:TextBox ID="txtDOB" placeholder="dd/MM/YYYY" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox></td>
                                                                            <td colspan="2">National ID:</td>
                                                                            <td colspan="4">
                                                                                <asp:TextBox ID="txtNationalID" placeholder="##-#######-X-##" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">Pension Type:</td>
                                                                            <td colspan="4">
                                                                                <asp:TextBox ID="txtPensionType" placeholder="Pension Type" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                                            </td>
                                                                            <td colspan="2">Pension Basis:</td>
                                                                            <td colspan="4">
                                                                                <asp:TextBox ID="txtPensionBasis" placeholder="Pension Basis" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">Monthly Salary:</td>
                                                                            <td colspan="4">
                                                                                <asp:TextBox ID="txtMonthlySalary" placeholder="#######" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                                            </td>
                                                                            <td colspan="2">Payment Frequency:</td>
                                                                            <td colspan="4">
                                                                                <asp:TextBox ID="txtPaymentPeriod" placeholder="Monthly/Quarterly" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">Last Declaration Date:</td>
                                                                            <td colspan="4">
                                                                                <asp:TextBox ID="txtED" placeholder="dd/MM/YYYY" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                                            </td>
                                                                            <td colspan="2">Membership Status:</td>
                                                                            <td colspan="4">
                                                                                <asp:TextBox ID="txtStatus" placeholder="Active/Suspended" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">Arrears:</td>
                                                                            <td colspan="4">
                                                                                <asp:TextBox ID="txtMemberShipStatus" placeholder="######.##" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                                            </td>
                                                                            <td colspan="2">Last Payroll Date:</td>
                                                                            <td colspan="4">
                                                                                <asp:TextBox ID="txtLastPaymentDate" placeholder="dd/MM/YYYY" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="12" style="text-align:center">
                                                                               <%-- <button class="btn btn-primary btn-clean">Declare Existance</button>--%>
                                                                                <asp:Button ID="btnDeclare" OnClick="btnDeclare_Click" CssClass="btn btn-primary" runat="server" Text="Declare Existance" />
                                                                                <asp:Button ID="btnLogQuery" OnClick="btnLogQuery_Click" CssClass="btn btn-primary" runat="server" Text="Log a Query" />
                                                                               <%-- <asp:Button ID="btnBenefitStm" OnClick="btnBenefitStm_Click" CssClass="btn btn-primary" runat="server" Text="View Benefit Statement" />                                                                  
                                                                                  <button class="btn btn-primary btn-clean">Log a Query</button>--%>
                                                                                
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

