<%@ Page Title="" Language="C#" MasterPageFile="~/AdministratorLog.Master" AutoEventWireup="true" CodeBehind="CampaingSetUp.aspx.cs" Inherits="PenPortfolio.CampaingSetUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<!-- START PAGE CONTAINER -->
		<div class="container container-boxed">
													<!-- RECENT ACTIVITY -->
													<div class="block block-condensed">
														<div class="app-heading app-heading-small">
															<div class="title">
																<h2>Campaign Set Up</h2>
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
							<asp:HiddenField ID="txtRecID" runat="server" />
							<asp:HiddenField ID="txtRoleType" runat="server" />
							</div>
			</div>
														<div class="block-content">
															<form class="form-horizontal">
																<div class="row">
																	<table style="width:100%">
																			
																		<tr>
                <td colspan="12">
                    <input type="hidden" name="ctl00$ContentPlaceHolder1$txtRecID" id="ContentPlaceHolder1_txtRecID" value="0" />
                </td>
            </tr>
            <tr>
                <td colspan="2">Campaign Name:</td>
                <td colspan="10">
                    <input name="ctl00$ContentPlaceHolder1$txtCampaignName" type="text" id="ContentPlaceHolder1_txtCampaignName" class="form-control" />
                </td>
            </tr>
            <tr>
                <td colspan="2">Date to send</td>
               <td colspan="10">
                   <asp:TextBox ID="txtSateTosend" TextMode="Date" runat="server"></asp:TextBox>
               </td>
            </tr>
            <tr>
                <td colspan="2">Campaign Type</td>
                <td colspan="10">
                    <select name="ctl00$ContentPlaceHolder1$cboCampaignType" onchange="javascript:setTimeout(&#39;__doPostBack(\&#39;ctl00$ContentPlaceHolder1$cboCampaignType\&#39;,\&#39;\&#39;)&#39;, 0)" id="ContentPlaceHolder1_cboCampaignType" class="form-control dropdown">
	<option selected="selected" value="0">Select a campaign type</option>
	<option value="1">Email</option>
	<option value="2">SMS</option>
	<option value="3">WhatsApp</option>

</select>
                </td>
            </tr>
            <tr>
                <td colspan="12">
                    
                </td>
            </tr>
            <tr>
                <td colspan="2">Campaign Message</td>
                <td colspan="10">
                    <textarea name="ctl00$ContentPlaceHolder1$txtCampaignMessage" rows="2" cols="20" id="ContentPlaceHolder1_txtCampaignMessage" class="form-control" style="height:50px;">
</textarea>
                </td>
            </tr>
            <tr>
                <td colspan="12"><hr /></td>
            </tr>
            <tr>
                <td colspan="12" style="text-align:center">
                    <input type="submit" name="ctl00$ContentPlaceHolder1$btnSave" value="Save Campaign" id="ContentPlaceHolder1_btnSave" class="btn btn-outline-primary" />
                    <input type="submit" name="ctl00$ContentPlaceHolder1$btnCreateNew" value="Create New Campaign" id="ContentPlaceHolder1_btnCreateNew" class="btn btn-outline-success" />
                </td>
            </tr>
            <tr>
                <td colspan="12"><hr /></td>
            </tr>
              <tr>
                <td colspan="5" style="text-align:center">All Affiliates</td>
                <td colspan="2" style="text-align:center"></td>
                <td colspan="5" style="text-align:center">Campaign Affiliates</td>
            </tr>
            <tr>
                <td colspan="5" style="text-align:center">
                    <input name="ctl00$ContentPlaceHolder1$txtFilterUnassigned" type="text" id="ContentPlaceHolder1_txtFilterUnassigned" class="form-control" placeholder="Search Filter" />
                </td>
                <td colspan="2" style="text-align:center"></td>
                <td colspan="5" style="text-align:center">
                    <input name="ctl00$ContentPlaceHolder1$txtFilterAssigned" type="text" id="ContentPlaceHolder1_txtFilterAssigned" class="form-control" placeholder="Search Filter" />
                </td>
            </tr>
            <tr>
                <td colspan="5" style="text-align:center">
                    <a id="ContentPlaceHolder1_lnkFilterUnassigned" class="btn btn-outline-warning" href="javascript:__doPostBack(&#39;ctl00$ContentPlaceHolder1$lnkFilterUnassigned&#39;,&#39;&#39;)">
                                                <i class="fa fa-search-plus"></i>Filter Search</a>
                    <a id="ContentPlaceHolder1_lnkAllUnassigned" class="btn btn-outline-primary" href="javascript:__doPostBack(&#39;ctl00$ContentPlaceHolder1$lnkAllUnassigned&#39;,&#39;&#39;)">
                                                <i class="fa fa-address-book"></i>View All</a>
                </td>
                <td colspan="2" style="text-align:center"></td>
                <td colspan="5" style="text-align:center">
                    <a id="ContentPlaceHolder1_lnkFilterAssigned" class="btn btn-outline-warning" href="javascript:__doPostBack(&#39;ctl00$ContentPlaceHolder1$lnkFilterAssigned&#39;,&#39;&#39;)">
                                                <i class="fa fa-search-plus"></i>Filter Search</a>
                    <a id="ContentPlaceHolder1_linkAllAssigned" class="btn btn-outline-primary" href="javascript:__doPostBack(&#39;ctl00$ContentPlaceHolder1$linkAllAssigned&#39;,&#39;&#39;)">
                                                <i class="fa fa-address-book"></i>View All</a>
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <select size="4" name="ctl00$ContentPlaceHolder1$lstAll" multiple="multiple" id="ContentPlaceHolder1_lstAll" class="form-control slick-list" style="width:100%;">
	<option value="1">Inhouse Contacts</option>
	<option value="2">Client Notications</option>
	<option value="3">Test group</option>
	<option value="4">Capitol Hill</option>
	<option value="5">Sandringhum Hill</option>

</select>
                </td>
                <td colspan="2" style="text-align:center">
                    <a id="ContentPlaceHolder1_lnkAdd" class="btn btn-outline-primary" href="javascript:__doPostBack(&#39;ctl00$ContentPlaceHolder1$lnkAdd&#39;,&#39;&#39;)">
                                                <i class="fa fa-plus"></i>>></a>
                    <a id="ContentPlaceHolder1_lnkRemove" class="btn btn-outline-danger" href="javascript:__doPostBack(&#39;ctl00$ContentPlaceHolder1$lnkRemove&#39;,&#39;&#39;)">
                                                <<<i class="fa fa-minus"></i></a>
                </td>
                <td colspan="5">
                    <select size="4" name="ctl00$ContentPlaceHolder1$lstAssigned" multiple="multiple" id="ContentPlaceHolder1_lstAssigned" class="form-control slick-list" style="width:100%;">

</select>
                </td>
            </tr>
            <tr>
                <td colspan="12"><hr /></td>
            </tr>
            <tr>
                <td colspan="12" style="text-align:center">
                                        <a id="ContentPlaceHolder1_lnkSubMit" class="btn btn-outline-secondary" href="javascript:__doPostBack(&#39;ctl00$ContentPlaceHolder1$lnkSubMit&#39;,&#39;&#39;)">
                                                <i class="fa fa-balance-scale"></i>Submit for Authorisation</a>

                </td>
            </tr>
            <tr>
                <td colspan="12">
                    
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
