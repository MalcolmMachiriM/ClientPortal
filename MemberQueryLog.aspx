<%@ Page Title="" Language="C#" MasterPageFile="~/MemberLog.Master" AutoEventWireup="true" CodeBehind="MemberQueryLog.aspx.cs" Inherits="PenPortfolio.MemberQueryLog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container container-boxed">
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
                <asp:HiddenField ID="txtType" runat="server" />
                <asp:HiddenField ID="txtRoleType" runat="server" />
                <asp:HiddenField ID="txtFund" runat="server" />
            </div>
        </div>
        <div class="row">

            <div class="col-md-6">

                <!-- TRANSFER -->
                <div class="block block-condensed">
                    <div class="app-heading app-heading-small">
                        <div class="title">
                            <h2>Query Log <%--(<asp:Label ID="lblPensionerName" runat="server" Text="Pensioner Name"></asp:Label>)--%></h2>
                            <%--<p>On your accounts and to other</p>--%>
                        </div>
                    </div>
                    <div class="block-content">

                        <div class="form-group">
                            <div class="row">
                                <div class="col-md-12">
                                    <label>Query Type:</label>
                                    <asp:DropDownList ID="cboQueryType" CssClass="form-control dropdown" AutoPostBack="false" runat="server">
                                        <%-- <asp:ListItem Value="1" Text="Error"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Missing Records"></asp:ListItem>--%>
                                    </asp:DropDownList>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <label>Subject:</label>
                                    <asp:TextBox ID="txtQuerySubject" CssClass="form-control" placeholder="Subject" runat="server"></asp:TextBox>
                                </div>

                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    <label>Query Details:</label>
                                    <asp:TextBox ID="txtQueryDetails" TextMode="MultiLine" Height="100px" CssClass="form-control" placeholder="Query Details" runat="server"></asp:TextBox>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <label>Attachment ScreenShot::</label>
                                    <asp:FileUpload ID="FileUpload1" CssClass="form-control fa-upload" runat="server" />

                                </div>
                                <%--<div class="col-md-12">
											
											<asp:Button ID="btnUpload" OnClick="btnUpload_Click" CssClass="btn btn-primary" runat="server" Text="Upload" />

										</div>--%>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:DropDownList ID="cboCity" CssClass="form-control dropdown" runat="server"></asp:DropDownList>
                                </div>

                            </div>
                        </div>
                        <div>
                            <%--<button class="btn btn-link pull-left padding-left-0">Information about fee</button> --%>
                            <%--<button class="btn btn-primary btn-clean pull-right">Edit Profile</button>--%>
                            <asp:Button ID="btnEditProfile" OnClick="btnUpload_Click" CssClass="btn btn-primary btn-clean pull-right" runat="server" Text="Submit Query" />
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
                            <h2>Pending Queries</h2>
                            <p>Your pending submitted queries</p>
                        </div>
                        <div class="heading-elements">
                            <asp:Button ID="btnNewLoan" Visible="false" CssClass="btn btn-primary btn-clean pull-right" runat="server" Text="Log a claim query" />

                        </div>
                    </div>
                    <div class="block-content">
                        <asp:GridView ID="grdEmployees" Width="100%" runat="server"
                            AutoGenerateColumns="False"
                            DataKeyNames="ID"
                            CssClass="table table-condensed" GridLines="None" role="grid" aria-describedby="DataTables_Table_0_info"
                            Style="border-collapse: collapse !important"
                            AllowPaging="true" AllowSorting="True" PageSize="10" OnRowCommand="grdEmployees_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="ID"></asp:BoundField>
                                <asp:BoundField DataField="City" HeaderText="City"></asp:BoundField>
                                <asp:BoundField DataField="Subject" HeaderText="Subject"></asp:BoundField>
                                <asp:BoundField DataField="isSolved" HeaderText="Status"></asp:BoundField>
                                <asp:BoundField DataField="DateCreated" HeaderText="DateCreated"></asp:BoundField>

                                <asp:TemplateField HeaderText="View">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkRecDel" runat="server" ForeColor="Green" CssClass="fa fa-eye fa-2x" CommandArgument='<%#Eval("ID")%>' CommandName="selectrecord"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                        <div class="row">
                            <div class="col-md-12">
                                <div class="app-tip app-tip-runing app-tip-noborder app-tip-lg">
                                    <div class="app-tip-runner">
                                        <asp:Label ID="lblLastPensionSalaryDate" runat="server" Text="Last Payment Date: mm/DD/YYYY | Next Payroll Date: mm/DD/YYYY"></asp:Label>
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
