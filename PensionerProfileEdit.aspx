<%@ Page Title="" Language="C#" MasterPageFile="~/PensionerLog.Master" AutoEventWireup="true" CodeBehind="PensionerProfileEdit.aspx.cs" Inherits="PenPortfolio.PensionerProfileEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<!-- START PAGE CONTAINER -->
		<div class="container container-boxed">
            <div class="row">

                        <div class="col-md-6">
							<asp:HiddenField ID="txtMemberID" runat="server" />
							<asp:HiddenField ID="txtRoleType" runat="server" />
							</div>
			</div>
													<!-- RECENT ACTIVITY -->
													<div class="block block-condensed">
														<div class="app-heading app-heading-small">
															<div class="title">
																<h2>Profile Details <%--(<asp:Label ID="lblPensionerName" runat="server" Text="Pensioner Name"></asp:Label>)--%></h2>
																<%--<p>Last visit: 14:54 28.06.2017</p>--%>
															</div>
														</div>
														<div class="block-content">
															<form class="form-horizontal">
																<div class="row">
																	<div class="col-md-6">
																		<div class="form-group">
																			<label class="col-md-3 control-label">Firstname(s)</label>
																			<div class="col-md-9">
																				<asp:TextBox ID="txtFirstnames" ReadOnly="true" placeholder="Firstname(s)" CssClass="form-control" runat="server"></asp:TextBox>

																			</div>
																			</div>
																			<div class="form-group">
																				<label class="col-md-3 control-label">Surname</label>
																				<div class="col-md-9">
																					<asp:TextBox ID="txtSurname" ReadOnly="true" placeholder="Surname" CssClass="form-control" runat="server"></asp:TextBox>

																				</div>
																				</div>
                                                                            <div class="form-group">
																				<label class="col-md-3 control-label">National ID:</label>
																				<div class="col-md-9">
																					<asp:TextBox ID="txtNationalID" placeholder="##-#######-X-##" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>

																				</div>
																				</div>
                                                                        <div class="form-group">
																				<label class="col-md-3 control-label">Date Of Birth</label>
																				<div class="col-md-9">
																					<asp:TextBox ID="txtDOB" placeholder="dd/MM/YYYY" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>

																				</div>
																				</div>

                                                                        <div class="form-group">
																				<label class="col-md-3 control-label">Address 1</label>
																				<div class="col-md-9">
																					<asp:TextBox ID="txtAddress1" CssClass="form-control" runat="server"></asp:TextBox>

																				</div>
																			</div>
																			<div class="form-group">
																							<label class="col-md-3 control-label">Address 2</label>
																							<div class="col-md-9">
																							<asp:TextBox ID="txtAddress2" CssClass="form-control" placeholder="Address 2" runat="server"></asp:TextBox>	
                                                                                            </div>
																								
																									
																						</div>
																			<div class="form-group">
																							<label class="col-md-3 control-label">Address 3</label>
																							<div class="col-md-9">
																							<asp:TextBox ID="txtAddress3" CssClass="form-control" placeholder="Address 3" runat="server"></asp:TextBox>	
                                                                                            </div>
																								
																									
																						</div>
                                                                                        
                                                                                        <div class="form-group">
																							<label class="col-md-3 control-label">City</label>
																							<div class="col-md-9">
																							<asp:DropDownList ID="drpCity" CssClass="form-control dropdown" runat="server"></asp:DropDownList>	
                                                                                            </div>
																								
																									
																						</div>


																				
                                                                        <div class="form-group">
																				<label class="col-md-3 control-label">Mobile No 1:</label>
																				<div class="col-md-9">
																					<asp:TextBox ID="txtMobile1" CssClass="form-control text" placeholder="(0##) ### ###" runat="server"></asp:TextBox>

																				</div>
																				</div>
                                                                                <div class="form-group">
																				<label class="col-md-3 control-label">Mobile No 2:</label>
																				<div class="col-md-9">
																					<asp:TextBox ID="txtMobile2" CssClass="form-control text" placeholder="(0##) ### ###" runat="server"></asp:TextBox>

																				</div>
																				</div>
																				<div class="form-group">
																					<label class="col-md-3 control-label">Email</label>
																					<div class="col-md-9">
																						<asp:TextBox ID="txtEmail" CssClass="form-control text" placeholder="xxxxx@emaildomain.co.zw" runat="server"></asp:TextBox>

																					</div>
																					</div>
																		 <div class="form-group">
																										<label class="col-md-3 control-label">Bank</label>
																										<div class="col-md-9">
																											<asp:DropDownList ID="drpBank" CssClass="form-control dropdown" runat="server"></asp:DropDownList>
																										</div>
																									</div>
                                                                                                    <div class="form-group">
																										<label class="col-md-3 control-label">Branch</label>
																										<div class="col-md-9">
																											<asp:DropDownList ID="drpBranch" CssClass="form-control dropdown" runat="server"></asp:DropDownList>
																										</div>
																									</div>
                                                                                                    <div class="form-group">
																										<label class="col-md-3 control-label">Account No.</label>
																										<div class="col-md-9">
																											<asp:TextBox ID="txtAccountNo" CssClass="form-control" placeholder="Account No" runat="server"></asp:TextBox>
																										</div>
																									</div>
																								</div>
                                                                     <div class="col-md-6">
																									<div class="form-group">
																										<label class="col-md-3 control-label">Monthly Salary (ZWL):</label>
																										<div class="col-md-9">
																											<asp:TextBox ID="txtMonthlySalary" ReadOnly="true" CssClass="form-control" placeholder="Pension Basis" runat="server"></asp:TextBox>	
																										</div>
																									</div>
																		 <div class="form-group">
																										<label class="col-md-3 control-label">Last Salary (ZWL):</label>
																										<div class="col-md-9">
																											<asp:TextBox ID="txtLastSalary" ReadOnly="true" CssClass="form-control" placeholder="Pension Basis" runat="server"></asp:TextBox>	
																										</div>
																									</div>
																		 <div class="form-group">
																										<label class="col-md-3 control-label">Last Payment Date:</label>
																										<div class="col-md-9">
																											<asp:TextBox ID="txtLastPaymentDate" ReadOnly="true" CssClass="form-control" placeholder="Pension Basis" runat="server"></asp:TextBox>	
																										</div>
																									</div>
																									<div class="form-group">
																										<label class="col-md-3 control-label">Date Joined Payroll:</label>
																										<div class="col-md-9">
																											<asp:TextBox ID="txtDJP" ReadOnly="true" CssClass="form-control" placeholder="Pension Type" runat="server"></asp:TextBox>	
																										</div>
																									</div>
                                                                                                    <div class="form-group">
																										<label class="col-md-3 control-label">Pension Start Date:</label>
																										<div class="col-md-9">
																											<asp:TextBox ID="txtPSD" ReadOnly="true" CssClass="form-control" placeholder="Pension Type" runat="server"></asp:TextBox>	
																										</div>
																									</div>
                                                                                            
                                                                                                    <div class="form-group">
																										<label class="col-md-3 control-label">Last Existence Date</label>
																										<div class="col-md-9">
																											<asp:TextBox ID="txtED" CssClass="form-control" placeholder="Account No" runat="server"></asp:TextBox>
																										</div>
																									</div>
																		 	<div class="form-group">
																										<label class="col-md-3 control-label">Pension Basis:</label>
																										<div class="col-md-9">
																											<asp:TextBox ID="txtPensionBasis" ReadOnly="true" CssClass="form-control" placeholder="Pension Basis" runat="server"></asp:TextBox>	
																										</div>
																									</div>
																									<div class="form-group">
																										<label class="col-md-3 control-label">Pension Type:</label>
																										<div class="col-md-9">
																											<asp:TextBox ID="txtPensionType" ReadOnly="true" CssClass="form-control" placeholder="Pension Type" runat="server"></asp:TextBox>	
																										</div>
																									</div>
                                                                                                    <div class="form-group">
																										<label class="col-md-3 control-label">Payment Period:</label>
																										<div class="col-md-9">
																											<asp:TextBox ID="txtPaymentPeriod" ReadOnly="true" CssClass="form-control" placeholder="Pension Type" runat="server"></asp:TextBox>	
																										</div>
																									</div>
																		 <div class="form-group">
																										<label class="col-md-3 control-label">Payroll Status:</label>
																										<div class="col-md-9">
																											<asp:TextBox ID="txtStatus" ReadOnly="true" CssClass="form-control" placeholder="Pension Type" runat="server"></asp:TextBox>	
																										</div>
																									</div>
																		 <div class="form-group">
																										<label class="col-md-3 control-label">PaySlip Type:</label>
																										<div class="col-md-9">
																											<asp:TextBox ID="txtPaySlipType" ReadOnly="true" CssClass="form-control" placeholder="Pension Type" runat="server"></asp:TextBox>	
																										</div>
																									</div>
                                                                                                    <div class="form-group">
																										
																										<div class="col-md-12">
																											<hr />
																										</div>
																									</div>
																									<div class="form-group">
																										<br />
																										<hr />
																									</div>
                                                                                                   
																								</div>
																							<%--	<div class="col-md-6">
																								
																								</div>--%>
                                                                   
																							</div>
                                                            </form>
																							<div class="row">
																								<div class="col-md-12 text-right">
																									<button class="btn btn-primary  btn-clean" runat="server" visible="false">Update Profile details</button>
																								</div>
																							</div>
																						
																					</div>
																				</div>
																				<!-- END RECENT -->
																			</div>
<!-- END PAGE CONTAINER -->
</asp:Content>
