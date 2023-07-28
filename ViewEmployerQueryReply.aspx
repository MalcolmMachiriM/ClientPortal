<%@ Page Title="" Language="C#" MasterPageFile="~/EmployerLog.Master" AutoEventWireup="true" CodeBehind="ViewEmployerQueryReply.aspx.cs" Inherits="PenPortfolio.ViewEmployerQueryReply" %>
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
																<h2>Query Details <%--(<asp:Label ID="lblPensionerName" runat="server" Text="Pensioner Name"></asp:Label>)--%></h2>
																<%--<p>Last visit: 14:54 28.06.2017</p>--%>
															</div>
														</div>
														<div class="block-content">
															<form class="form-horizontal">
																<div class="row">
                            <asp:HiddenField ID="txtQueryID" runat="server" />
                            <asp:HiddenField ID="txtFundID" runat="server" />
                            <asp:HiddenField ID="txtSystemRef" runat="server" />

                        </div>
																<div class="row">
																	<div class="col-md-6">
																		<div class="form-group">
																			<label class="col-md-3 control-label">System Ref</label>
																			<div class="col-md-9">
																				<asp:TextBox ID="txtEmployer" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>

																			</div>
																			</div>
																			<div class="form-group">
																				<label class="col-md-3 control-label">Query Type</label>
																				<div class="col-md-9">
																					<asp:TextBox ID="txtQueryType" ReadOnly="true" placeholder="Query Type" CssClass="form-control" runat="server"></asp:TextBox>

																				</div>
																				</div>
                                                                            <div class="form-group">
																				<label class="col-md-3 control-label">Subject:</label>
																				<div class="col-md-9">
																					<asp:TextBox ID="txtSubject" placeholder="Subject" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>

																				</div>
																				</div>
                                                                        <div class="form-group">
																				<label class="col-md-3 control-label">Query Description</label>
																				<div class="col-md-9">
																					<asp:TextBox ID="txtDescription" placeholder="Description" ReadOnly="true" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>

																				</div>
																				</div>
																		     <div class="form-group">
																				<label class="col-md-3 control-label">Action Type</label>
																				<div class="col-md-9">
																					<asp:TextBox ID="txtAction" placeholder="" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>

																				</div>
																		                              
																				</div>
																		<div class="form-group">
																				<label class="col-md-3 control-label">Admin Comment</label>
																				<div class="col-md-9">
																					<asp:TextBox ID="txtComment" placeholder="" ReadOnly="true" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>

																				</div>
																		                              
																				</div>
																				</div>
																								</div>
                                                                   
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
