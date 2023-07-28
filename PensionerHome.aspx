<%@ Page Title="" Language="C#" MasterPageFile="~/PensionerLog.Master" AutoEventWireup="true" CodeBehind="PensionerHome.aspx.cs" Inherits="PenPortfolio.PensionerHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container container-boxed">
					<%--<div class="alert alert-info alert-icon-block alert-dismissible" role="alert">
						<div class="alert-icon"><span class="icon-question-circle"></span></div>
						We use cookies to offer you the best experience on our website. Continuing browsing, you accept our cookies policy. 
						<button type="button" class="close" data-dismiss="alert" aria-label="Close">
							<span class="fa fa-times"></span>
						</button>
					</div>--%>
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
							<asp:HiddenField ID="txtRecID" runat="server" />
							<asp:HiddenField ID="txtRoleType" runat="server" />
                            <asp:HiddenField ID="txtRegNo" runat="server" />
							</div>
			</div>
					<div class="row">

                        <div class="col-md-6">
					<!-- NEWS -->
						<ul class="app-feature-gallery app-feature-gallery-noshadow">
							<li>
								<div class="tile-basic tile-basic-bordered">
									<div class="tile-content text-center">
										<h3 class="tile-title">
											<asp:Label ID="lblPensionerName" runat="server" Text="Pensioner Name"></asp:Label></h3>
										<span class="tile-subtitle"><asp:Label ID="lblPensionType" runat="server" Text="Pension Type"></asp:Label></span>
										<p>
											<asp:Label ID="lblPensionNo" runat="server" Text="Pension No"></asp:Label>
										</p>
										<%--<p class="text-muted text-center">25.06.2017 15:19</p>--%>
									</div>
								</div>
							</li>
							<li>
								<div class="tile-basic tile-basic-bordered">
									<div class="tile-content text-center">
										<h3 class="tile-title">National ID:</h3>
										<span class="tile-subtitle">
											<asp:Label ID="lblNationalID" runat="server" Text="##-#######-X-##"></asp:Label></span>
										<p>
											<asp:Label ID="lblDOB" runat="server" Text="dd/MM/YYYY"></asp:Label></p>
										<p class="text-muted text-center">
											<asp:Label ID="Label1" runat="server" Text=""></asp:Label></p>
									</div>
								</div>
							</li>
							<li>
								<div class="tile-basic tile-basic-bordered">
									<div class="tile-content text-center">
										<h3 class="tile-title"><asp:Label ID="lblDJP" runat="server" Text="Date Joined Payroll: dd/MM/YYYY"></asp:Label></h3>
										<span class="tile-subtitle"><asp:Label ID="lblPensionStartDate" runat="server" Text="Pension Start Date: dd/MM/YYYY"></asp:Label></span>
										<p><asp:Label ID="lblLastPaymentDate" runat="server" Text="Last Payroll Date: dd/MM/YYYY"></asp:Label></p>
										
									</div>
								</div>
							</li>
							<%--<li>
								<div class="tile-basic tile-basic-bordered">
									<div class="tile-content text-center">
										<h3 class="tile-title">New action special for you</h3>
										<span class="tile-subtitle">Actions</span>
										<p>Cras mattis tortor vitae pulvinar sollicitudin. Aliquam suscipit sed arcu at tincidunt. Suspendisse ut massa id odio tristique placerat.</p>
										<p class="text-muted text-center">22.06.2017 14:22</p>
									</div>
								</div>
							</li>--%>
						</ul>
						<!-- END NEWS -->
						<!-- TRANSFER -->
						<div class="block block-condensed">
							<div class="app-heading app-heading-small">
								<div class="title">
									<h2>Your Contact Details</h2>
									<%--<p>On your accounts and to other</p>--%>
								</div>
							</div>
							<div class="block-content">
								<div class="form-group">
									<div class="row">
										<div class="col-md-12">
											<div class="form-group">
												<label>Contact No.</label>
												<asp:TextBox ID="txtContactNo" CssClass="form-control" placeholder="phone number" runat="server"></asp:TextBox>
											</div>
										</div>
									</div>
									<div class="row">
										<div class="col-md-12">
											<label>Email Address</label>
											<asp:TextBox ID="txtEmailAdd" CssClass="form-control" placeholder="email address" runat="server"></asp:TextBox>
										</div>
										
									</div>
								</div>
								<div class="form-group">
									<div class="row">
										<div class="col-md-12">
											<label>Address</label>
											<asp:TextBox ID="txtAddress1" CssClass="form-control" placeholder="Address 1" runat="server"></asp:TextBox>
										</div>
										
									</div>
                                    <div class="row">
										<div class="col-md-12">
											<asp:TextBox ID="txtAddress2" CssClass="form-control" placeholder="Address 2" runat="server"></asp:TextBox>
										</div>
										
									</div>
                                    <div class="row">
										<div class="col-md-12">
											<asp:TextBox ID="txtAddress3" CssClass="form-control" placeholder="Address 3" runat="server"></asp:TextBox>
										</div>
										
									</div>
									<%--<div class="row">
										<div class="col-md-12">
											<asp:DropDownList ID="cboCity" CssClass="form-control dropdown" runat="server"></asp:DropDownList>
										</div>
										
									</div>--%>
								</div>
								<div>
									<%--<button class="btn btn-link pull-left padding-left-0">Information about fee</button> --%>
									<%--<button class="btn btn-primary btn-clean pull-right">Edit Profile</button>--%>
                                    <asp:Button ID="btnEditProfile" CssClass="btn btn-primary btn-clean pull-right" runat="server" Visible="false" Text="Update Contact Details" />
								</div>
							</div>
						</div>
						<!-- END TRANSFER -->
						
					</div>

					<div class="col-md-6">
					<!-- CARDS -->
					<div class="block block-condensed">
						<div class="app-heading app-heading-small">
							<div class="title"><h2>Pension Accounts</h2><p>List of your active accounts</p></div>
							<div class="heading-elements">
                                <asp:Button ID="btnNewLoan" OnClick="btnNewLoan_Click" CssClass="btn btn-primary btn-clean pull-right" runat="server" Text="Log a claim query" />

							</div>
						</div>
						<div class="block-content">
							<div class="list-group margin-bottom-15">
								<a href="#" class="list-group-item list-group-item-highlighted">
									<div class="row">
										<div class="col-md-6"><h4 class="text-rg text-uppercase text-bolder margin-bottom-5">Pension Payroll Acc</h4>
											<p class="subheader">Account No: <asp:Label ID="lblPayrollAccNo" runat="server" Text="0"></asp:Label></p>
										</div>
										<div class="col-md-6 text-right">
											<h4 class="text-rg text-uppercase text-bolder margin-bottom-5"><asp:Label ID="lblSalary" runat="server" Text="0"> </asp:Label></h4>
											<%--<p class="subheader">Latest Salary:<span class="text-danger"><asp:Label ID="" runat="server" Text="0"> </asp:Label></span></p>--%>
										</div>
									</div>
								</a>
								<a href="#" class="list-group-item list-group-item-highlighted">
								<div class="row">
									<div class="col-md-6">
										<h4 class="text-rg text-uppercase text-bolder margin-bottom-5">Pension Arrears Acc</h4>
										<p class="subheader">Account No:<asp:Label ID="Label2" runat="server" Text="0"></asp:Label></p>
									</div>
									<div class="col-md-6 text-right">
										<h4 class="text-rg text-uppercase text-bolder margin-bottom-5"><asp:Label ID="Label5" runat="server" Text="0"> </asp:Label></h4>
										<%--<p class="subheader">Balance:<span class="text-success"><asp:Label ID="" runat="server" Text="0"> </asp:Label></span></p>--%>
									</div>
								</div>
								</a>
							</div>
							<div class="row">
								<div class="col-md-12">
									<div class="app-tip app-tip-runing app-tip-noborder app-tip-lg">
										<div class="app-tip-runner">
											<asp:Label ID="lblLastPensionSalaryDate" runat="server" Text="Last Payment Date: mm/DD/YYYY | Next Payroll Date: mm/DD/YYYY"></asp:Label> </div>
									</div>
								</div>
							</div>
						</div>
					</div>
					<!-- END CARDS -->
					<!-- RECENT ACTIVITY -->
					<%--<div class="block block-condensed">
						<div class="app-heading app-heading-small margin-bottom-0">
							<div class="title"><h2>Recent Activity</h2><p>Last Login Date:</p></div>
							
							<div class="heading-elements" style="width: 150px">
								<div class="input-group">
									<div class="input-group-addon"><span class="icon-calendar-full"></span></div>
									<input type="text" class="form-control bs-datepicker" value="27/06/2022">
								</div>
							</div>
						</div>
						<div class="block-divider-text">Account Status</div>
							<div class="block-content">
								<div class="listing margin-bottom-0">
									<div class="listing-item listing-item-with-icon"><span class="icon-car listing-item-icon"></span>
										<h4 class="text-rg text-bold">_<span class="text-muted pull-right">_</span></h4>
										<div class="list-group list-group-inline">
											<div class="list-group-item col-md-4 col-sm-4"><span class="text-muted">Status</span>
												<br>
												<span class="text-bold">Active</span>
											</div>
											<div class="list-group-item col-md-4 col-sm-4">
												<span class="text-muted">Last Declaration Date</span>
												<br>
												<span class="text-bold text-danger">
													<asp:Label ID="lblDeclarationDate" runat="server" Text=""></asp:Label>
												</span>
											</div>
											<div class="list-group-item col-md-4 col-sm-4">
												<span class="text-muted">Suspension Date:</span>
												<br>
												<span class="text-bold"></span>
											</div>
										</div>
									</div>
									<div class="listing-item listing-item-with-icon">
										<span class="icon-file-add listing-item-icon text-success"></span>
										<h4 class="text-rg text-bold">My Dependants<span class="text-muted pull-right"></span></h4>
										<div class="list-group list-group-inline margin-bottom-0">
											<div class="list-group-item col-md-4 col-sm-4">
												<span class="text-muted">Firstname</span>
												<br>
												<span class="text-bold"></span>
											</div>
											<div class="list-group-item col-md-4 col-sm-4">
												<span class="text-muted">Lastname</span>
												<br>
												<span class="text-bold text-success"></span>
											</div>
											<div class="list-group-item col-md-4 col-sm-4">
												<span class="text-muted">Relationship</span>
												<br>
												<span class="text-bold"></span>
											</div>
										</div>
									</div>
								</div>
							</div>
							
							<div class="block-content">
								<div class="row">
									<div class="col-md-6 col-md-offset-3 col-sm-12">
										<a href="#" class="btn btn-primary btn-clean btn-block">All Activity</a>
									</div>
								</div>
							</div>
						
					</div>--%>
					<!-- END RECENT -->
					</div>
					
				</div>
			</div>
</asp:Content>


<%--<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<!-- START PAGE CONTAINER -->
		<div class="container container-boxed">
													<!-- RECENT ACTIVITY -->
													<div class="block block-condensed">
														<div class="app-heading app-heading-small">
															<div class="title">
																<h2>Account Settings</h2>
																<p>Last visit: 14:54 28.06.2017</p>
															</div>
														</div>
														<div class="block-content">
															<form class="form-horizontal">
																<div class="row">
																	<div class="col-md-6">
																		<div class="form-group">
																			<label class="col-md-3 control-label">Name</label>
																			<div class="col-md-9">
																				<input type="text" class="form-control" value="John"></div>
																			</div>
																			<div class="form-group">
																				<label class="col-md-3 control-label">Surname</label>
																				<div class="col-md-9">
																					<input type="text" class="form-control" value="Doe"></div>
																				</div>
                                                                            <div class="form-group">
																				<label class="col-md-3 control-label">D.O.B</label>
																				<div class="col-md-9">
																					<input type="date" class="form-control" ></div>
																				</div>
                                                                        <div class="form-group">
																				<label class="col-md-3 control-label">Gender</label>
																				<div class="col-md-9">
																					<asp:DropDownList ID="cboGender" CssClass="form-control dropdown" runat="server"></asp:DropDownList>

																				</div>
																				</div>
                                                                        <div class="form-group">
																				<label class="col-md-3 control-label">Primary Identity Type</label>
																				<div class="col-md-9">
																					<asp:DropDownList ID="cboPrimaryIdentDoc" CssClass="form-control dropdown" runat="server"></asp:DropDownList>

																				</div>
																				</div>
                                                                        <div class="form-group">
																				<label class="col-md-3 control-label">Identity Reference</label>
																				<div class="col-md-9">
																					<asp:TextBox ID="txtIdentityReference" CssClass="form-control text" placeholder="Identity Reference" runat="server"></asp:TextBox>

																				</div>
																				</div>
                                                                                <div class="form-group">
																				<label class="col-md-3 control-label">Nationality</label>
																				<div class="col-md-9">
																					<asp:DropDownList ID="cboNationality" CssClass="form-control dropdown" runat="server"></asp:DropDownList>

																				</div>
																				</div>
																				<div class="form-group">
																					<label class="col-md-3 control-label">Email</label>
																					<div class="col-md-9">
																						<input type="text" class="form-control" value="johndoe@domain.com"></div>
																					</div>

																					<div class="form-group">
																						<label class="col-md-3 control-label">Mobile No.</label>
																						<div class="col-md-9">
																						    <asp:TextBox ID="txtMobileNo" CssClass="form-control" placeholder="MobileNo" runat="server"></asp:TextBox>	
                                                                                        </div>
																						</div>
                                                                                        <div class="form-group">
																							<label class="col-md-3 control-label">Address</label>
																							<div class="col-md-9">
																							<asp:TextBox ID="txtAddress1" CssClass="form-control" placeholder="Address Line1" runat="server"></asp:TextBox>	
                                                                                            </div>
																								
																									
																						</div>
                                                                                        <div class="form-group">
																							<label class="col-md-3 control-label"></label>
																							<div class="col-md-9">
																							<asp:TextBox ID="txtAddress2" CssClass="form-control" placeholder="Address Line2" runat="server"></asp:TextBox>	
                                                                                            </div>
																								
																									
																						</div>
                                                                                        <div class="form-group">
																							<label class="col-md-3 control-label">Country</label>
																							<div class="col-md-9">
																								<asp:DropDownList ID="cboCountry" CssClass="form-control dropdown" runat="server"></asp:DropDownList>	
																							</div>
																						</div>
                                                                                        <div class="form-group">
																							<label class="col-md-3 control-label">City</label>
																							<div class="col-md-9">
																							<asp:DropDownList ID="cboCity" CssClass="form-control dropdown" runat="server"></asp:DropDownList>	
                                                                                            </div>
																								
																									
																						</div>
																						
																						
																								</div>
																								<div class="col-md-6">
																									<div class="form-group">
																										<label class="col-md-3 control-label">Employment status</label>
																										<div class="col-md-9">
																											<asp:DropDownList ID="cboEmploymentStatus" CssClass="form-control dropdown" runat="server"></asp:DropDownList>
																										</div>
																									</div>
																									<div class="form-group">
																										<label class="col-md-3 control-label">Employer</label>
																										<div class="col-md-9">
																											<asp:TextBox ID="txtEmployerName" CssClass="form-control text" runat="server"></asp:TextBox>
																										</div>
																									</div>
                                                                                                    <div class="form-group">
																										<label class="col-md-3 control-label">Employment Type</label>
																										<div class="col-md-9">
																											<asp:DropDownList ID="cboEmploymentType" CssClass="form-control dropdown" runat="server"></asp:DropDownList>
																										</div>
																									</div>
                                                                                                    <div class="form-group">
																										
																										<div class="col-md-12">
																											<hr />
																										</div>
																									</div>
                                                                                                    <div class="form-group">
																										<label class="col-md-3 control-label">Bank</label>
																										<div class="col-md-9">
																											<asp:DropDownList ID="DropDownList1" CssClass="form-control dropdown" runat="server"></asp:DropDownList>
																										</div>
																									</div>
                                                                                                    <div class="form-group">
																										<label class="col-md-3 control-label">Branch</label>
																										<div class="col-md-9">
																											<asp:DropDownList ID="DropDownList2" CssClass="form-control dropdown" runat="server"></asp:DropDownList>
																										</div>
																									</div>
                                                                                                    <div class="form-group">
																										<label class="col-md-3 control-label">Account No.</label>
																										<div class="col-md-9">
																											<asp:TextBox ID="txtAccountNo" CssClass="form-control" placeholder="Account No" runat="server"></asp:TextBox>
																										</div>
																									</div>
																								</div>
																							</div>
                                                            </form>
																							<div class="row">
																								<div class="col-md-12 text-right">
																									<button class="btn btn-primary btn-clean">Update Settings</button>
																								</div>
																							</div>
																						
																					</div>
																				</div>
																				<!-- END RECENT -->
																			</div>
<!-- END PAGE CONTAINER -->
</asp:Content>--%>
