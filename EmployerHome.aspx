<%@ Page Title="" Language="C#" MasterPageFile="~/EmployerLog.Master" AutoEventWireup="true" CodeBehind="EmployerHome.aspx.cs" Inherits="PenPortfolio.EmployerHome" %>

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
                <asp:HiddenField ID="txtFund" runat="server" />
            </div>
        </div>
        <div class="row">

            <div class="col-md-6">

                <div class="block block-condensed">
                    <div class="app-heading app-heading-small">
                        <div class="title">
                            <h2>Your Basic Details</h2>
                            <%--<p>On your accounts and to other</p>--%>
                        </div>
                    </div>
                    <div class="block-content">
                        <div class="form-group">
                            <div class="row margin-bottom-5z">
                                <div class="col-md-12">
                                    <label>Registered Fund:</label>
                                    <asp:TextBox ID="txtFundName" CssClass="form-control" placeholder="Fund Name" runat="server"></asp:TextBox>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <label>Registered Company Name:</label>
                                    <asp:TextBox ID="txtCompanyName" CssClass="form-control" placeholder="Company Name" runat="server"></asp:TextBox>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <label>Registered Business Category:</label>
                                    <asp:TextBox ID="txtBusinessCategory" CssClass="form-control" placeholder="Business Category" runat="server"></asp:TextBox>
                                </div>

                            </div>
                            <%--<div class="row">
										<div class="col-md-12">
											<asp:DropDownList ID="cbo" CssClass="form-control dropdown" runat="server"></asp:DropDownList>
										</div>
										
									</div>--%>
                        </div>

                        <div class="form-group">
                            <div class="row">
                                <div class="col-md-12">
                                    <label>Address</label>
                                    <asp:TextBox ID="txtAddress1" CssClass="form-control" placeholder="Address 1" runat="server"></asp:TextBox>
                                </div>

                            </div>
                           <%-- <div class="row">
                                <div class="col-md-12">
                                    <asp:TextBox ID="txtAddress2" CssClass="form-control" placeholder="Address 2" runat="server"></asp:TextBox>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:TextBox ID="txtAddress3" CssClass="form-control" placeholder="Address 3" runat="server"></asp:TextBox>
                                </div>

                            </div>--%>
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
                        <div class="title">
                            <h2>Quick</h2>
                            <p>Stats</p>
                        </div>
                        <div class="heading-elements">
                            <%--<asp:Button ID="btnNewLoan" OnClick="btnNewLoan_Click" CssClass="btn btn-primary btn-clean pull-right" runat="server" Text="Log a claim query" />--%>
                            <asp:Button ID="btnLogQuery" OnClick="btnLogQuery_Click" CssClass="btn btn-primary" runat="server" Text="Log a Query" />

                        </div>
                    </div>
                    <div class="block-content">
                        <div class="list-group margin-bottom-15">
                            <a href="ActiveContributingMembers" id="am" runat="server" class="list-group-item list-group-item-highlighted">
                                <div class="row">
                                    <div class="col-md-6">
                                        <h4 class="text-rg text-uppercase text-bolder margin-bottom-5">Current Active Contributing Members</h4>
                                        <%--<p class="subheader">Account No: <asp:Label ID="lblPayrollAccNo" runat="server" Text="9871"></asp:Label></p>--%>
                                    </div>
                                    <div class="col-md-6 text-right">
                                        <h4 class="text-rg text-uppercase text-bolder margin-bottom-5">
                                            <asp:Label ID="lblActiveMemberss" runat="server" Text="0"> </asp:Label></h4>

                                        <%--<p class="subheader">Balance:<span class="text-danger">-$14.88</span></p>--%>
                                    </div>
                                </div>
                            </a>
                            <a href="DeferredMembers" id="dm" runat="server" class="list-group-item list-group-item-highlighted">
                                <div class="row">
                                    <div class="col-md-6">
                                        <h4 class="text-rg text-uppercase text-bolder margin-bottom-5">Current Deferred Members</h4>
                                        <%--<p class="subheader">Account No:<asp:Label ID="Label2" runat="server" Text="11728"></asp:Label></p>--%>
                                    </div>
                                    <div class="col-md-6 text-right">
                                        <h4 class="text-rg text-uppercase text-bolder margin-bottom-5">
                                            <asp:Label ID="lblDeferredMemberss" runat="server" Text="0"> </asp:Label></h4>
                                        <%--<p class="subheader">Balance:<span class="text-success">-$12,420</span></p>--%>
                                    </div>
                                </div>
                            </a>

                            <a href="ExitedMembers" id="em" runat="server" class="list-group-item list-group-item-highlighted">
                                <div class="row">
                                    <div class="col-md-6">
                                        <h4 class="text-rg text-uppercase text-bolder margin-bottom-5">Fund Exited Members</h4>
                                        <%--<p class="subheader">Account No:<asp:Label ID="Label2" runat="server" Text="11728"></asp:Label></p>--%>
                                    </div>
                                    <div class="col-md-6 text-right">
                                        <h4 class="text-rg text-uppercase text-bolder margin-bottom-5">
                                            <asp:Label ID="lblExitedMemberss" runat="server" Text="0"> </asp:Label></h4>
                                        <%--<p class="subheader">Balance:<span class="text-success">-$12,420</span></p>--%>
                                    </div>
                                </div>
                            </a>


                            <a href="ActivePensioners" id="ap" runat="server" class="list-group-item list-group-item-highlighted">
                                <div class="row">
                                    <div class="col-md-6">
                                        <h4 class="text-rg text-uppercase text-bolder margin-bottom-5">Fund Active Pensioners</h4>
                                        <%--<p class="subheader">Account No:<asp:Label ID="Label2" runat="server" Text="11728"></asp:Label></p>--%>
                                    </div>
                                    <div class="col-md-6 text-right">
                                        <h4 class="text-rg text-uppercase text-bolder margin-bottom-5">
                                            <asp:Label ID="lblActivePensionerss" runat="server" Text="0"> </asp:Label></h4>
                                        <%--<p class="subheader">Balance:<span class="text-success">-$12,420</span></p>--%>
                                    </div>
                                </div>
                            </a>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="app-tip app-tip-runing app-tip-noborder app-tip-lg">
                                    <div class="app-tip-runner">
                                        <asp:Label ID="lblLastPensionSalaryDate" runat="server" Text="Last Contributions Uploaded on: mm/DD/YYYY"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- END CARDS -->
                <!-- RECENT ACTIVITY -->
                <%--	<div class="block block-condensed">
						<div class="app-heading app-heading-small margin-bottom-0">
							<div class="title"><h2>Recent Activity</h2><p>Last Login Date:</p></div>
							
							<div class="heading-elements" style="width: 150px">
								<div class="input-group">
									<div class="input-group-addon"><span class="icon-calendar-full"></span></div>
									<input type="text" class="form-control bs-datepicker" value="27/06/2022">
								</div>
							</div>
						</div>
						<div class="block-divider-text">Your correspondence</div>
							<div class="block-content">
								<div class="listing margin-bottom-0">
									<div class="listing-item listing-item-with-icon"><span class="icon-car listing-item-icon"></span>
										<h4 class="text-rg text-bold">_<span class="text-muted pull-right">_</span></h4>
										<div class="list-group list-group-inline">
											<div class="list-group-item col-md-4 col-sm-4"><span class="text-muted">Message</span>
												<br>
												<span class="text-bold">-</span>
											</div>
											<div class="list-group-item col-md-4 col-sm-4">
												<span class="text-muted">Date Submited</span>
												<br>
												<span class="text-bold text-danger">
													<asp:Label ID="lblDeclarationDate" runat="server" Text=""></asp:Label>
												</span>
											</div>
											<div class="list-group-item col-md-4 col-sm-4">
												<span class="text-muted">Response Status:</span>
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
