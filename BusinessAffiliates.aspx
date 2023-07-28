<%@ Page Title="" Language="C#" MasterPageFile="~/AdministratorLog.Master" AutoEventWireup="true" CodeBehind="BusinessAffiliates.aspx.cs" Inherits="PenPortfolio.BusinessAffiliates" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<!-- START PAGE CONTAINER -->
		<div class="container container-boxed">
													<!-- RECENT ACTIVITY -->
													<div class="block block-condensed">
														<div class="app-heading app-heading-small">
															<div class="title">
																<h2>Business Affiliates</h2>
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
                <td colspan="2">Affiliate Name:</td>
                <td colspan="10">
                    <input name="ctl00$ContentPlaceHolder1$txtAffiliateName" type="text" id="ContentPlaceHolder1_txtAffiliateName" class="form-control" />
                </td>
            </tr>
            <tr>
                <td colspan="12"></td>
            </tr>
            <tr>
                <td colspan="12" style="text-align:center">
                    <input type="submit" name="ctl00$ContentPlaceHolder1$btnSave" value="Save Affiliate" id="ContentPlaceHolder1_btnSave" class="btn btn-outline-primary" />
                </td>
            </tr>
            <tr>
                <td colspan="12">
                    <div>
	<table class="table table-condensed" cellspacing="0" role="grid" aria-describedby="DataTables_Table_0_info" id="ContentPlaceHolder1_grdAffiliates" style="width:100%;border-collapse:collapse;border-collapse: collapse !important">
		<tr>
			<th scope="col">Affiliate Name</th><th scope="col">Status</th><th scope="col">Affiliate Contacts</th><th scope="col">Edit</th><th scope="col">Contacts</th><th scope="col">Delete</th>
		</tr><tr>
			<td>Inhouse Contacts</td><td>Active</td><td>1</td><td>
                                                <a id="ContentPlaceHolder1_grdAffiliates_lnkRecEdit_0" class="fa fa-pen-fancy fa-2x" href="javascript:__doPostBack(&#39;ctl00$ContentPlaceHolder1$grdAffiliates$ctl02$lnkRecEdit&#39;,&#39;&#39;)" style="color:Green;"></a>
                                            </td><td>
                                                <a id="ContentPlaceHolder1_grdAffiliates_lnkRecContacts_0" class="fa fa-address-book fa-2x" href="javascript:__doPostBack(&#39;ctl00$ContentPlaceHolder1$grdAffiliates$ctl02$lnkRecContacts&#39;,&#39;&#39;)" style="color:Blue;"></a>
                                            </td><td>
                                                <a id="ContentPlaceHolder1_grdAffiliates_lnkRecDel_0" class="fa fa-trash fa-2x" href="javascript:__doPostBack(&#39;ctl00$ContentPlaceHolder1$grdAffiliates$ctl02$lnkRecDel&#39;,&#39;&#39;)" style="color:Red;"></a>
                                            </td>
		</tr><tr>
			<td>Client Notications</td><td>Active</td><td>6</td><td>
                                                <a id="ContentPlaceHolder1_grdAffiliates_lnkRecEdit_1" class="fa fa-pen-fancy fa-2x" href="javascript:__doPostBack(&#39;ctl00$ContentPlaceHolder1$grdAffiliates$ctl03$lnkRecEdit&#39;,&#39;&#39;)" style="color:Green;"></a>
                                            </td><td>
                                                <a id="ContentPlaceHolder1_grdAffiliates_lnkRecContacts_1" class="fa fa-address-book fa-2x" href="javascript:__doPostBack(&#39;ctl00$ContentPlaceHolder1$grdAffiliates$ctl03$lnkRecContacts&#39;,&#39;&#39;)" style="color:Blue;"></a>
                                            </td><td>
                                                <a id="ContentPlaceHolder1_grdAffiliates_lnkRecDel_1" class="fa fa-trash fa-2x" href="javascript:__doPostBack(&#39;ctl00$ContentPlaceHolder1$grdAffiliates$ctl03$lnkRecDel&#39;,&#39;&#39;)" style="color:Red;"></a>
                                            </td>
		</tr><tr>
			<td>Test group</td><td>Active</td><td>2</td><td>
                                                <a id="ContentPlaceHolder1_grdAffiliates_lnkRecEdit_2" class="fa fa-pen-fancy fa-2x" href="javascript:__doPostBack(&#39;ctl00$ContentPlaceHolder1$grdAffiliates$ctl04$lnkRecEdit&#39;,&#39;&#39;)" style="color:Green;"></a>
                                            </td><td>
                                                <a id="ContentPlaceHolder1_grdAffiliates_lnkRecContacts_2" class="fa fa-address-book fa-2x" href="javascript:__doPostBack(&#39;ctl00$ContentPlaceHolder1$grdAffiliates$ctl04$lnkRecContacts&#39;,&#39;&#39;)" style="color:Blue;"></a>
                                            </td><td>
                                                <a id="ContentPlaceHolder1_grdAffiliates_lnkRecDel_2" class="fa fa-trash fa-2x" href="javascript:__doPostBack(&#39;ctl00$ContentPlaceHolder1$grdAffiliates$ctl04$lnkRecDel&#39;,&#39;&#39;)" style="color:Red;"></a>
                                            </td>
		</tr><tr>
			<td>Capitol Hill</td><td>Active</td><td>197</td><td>
                                                <a id="ContentPlaceHolder1_grdAffiliates_lnkRecEdit_3" class="fa fa-pen-fancy fa-2x" href="javascript:__doPostBack(&#39;ctl00$ContentPlaceHolder1$grdAffiliates$ctl05$lnkRecEdit&#39;,&#39;&#39;)" style="color:Green;"></a>
                                            </td><td>
                                                <a id="ContentPlaceHolder1_grdAffiliates_lnkRecContacts_3" class="fa fa-address-book fa-2x" href="javascript:__doPostBack(&#39;ctl00$ContentPlaceHolder1$grdAffiliates$ctl05$lnkRecContacts&#39;,&#39;&#39;)" style="color:Blue;"></a>
                                            </td><td>
                                                <a id="ContentPlaceHolder1_grdAffiliates_lnkRecDel_3" class="fa fa-trash fa-2x" href="javascript:__doPostBack(&#39;ctl00$ContentPlaceHolder1$grdAffiliates$ctl05$lnkRecDel&#39;,&#39;&#39;)" style="color:Red;"></a>
                                            </td>
		</tr><tr>
			<td>Sandringhum Hill</td><td>Active</td><td>3</td><td>
                                                <a id="ContentPlaceHolder1_grdAffiliates_lnkRecEdit_4" class="fa fa-pen-fancy fa-2x" href="javascript:__doPostBack(&#39;ctl00$ContentPlaceHolder1$grdAffiliates$ctl06$lnkRecEdit&#39;,&#39;&#39;)" style="color:Green;"></a>
                                            </td><td>
                                                <a id="ContentPlaceHolder1_grdAffiliates_lnkRecContacts_4" class="fa fa-address-book fa-2x" href="javascript:__doPostBack(&#39;ctl00$ContentPlaceHolder1$grdAffiliates$ctl06$lnkRecContacts&#39;,&#39;&#39;)" style="color:Blue;"></a>
                                            </td><td>
                                                <a id="ContentPlaceHolder1_grdAffiliates_lnkRecDel_4" class="fa fa-trash fa-2x" href="javascript:__doPostBack(&#39;ctl00$ContentPlaceHolder1$grdAffiliates$ctl06$lnkRecDel&#39;,&#39;&#39;)" style="color:Red;"></a>
                                            </td>
		</tr>
	</table>
</div>
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

