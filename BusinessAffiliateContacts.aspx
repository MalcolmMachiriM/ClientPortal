<%@ Page Title="" Language="C#" MasterPageFile="~/AdministratorLog.Master" AutoEventWireup="true" CodeBehind="BusinessAffiliateContacts.aspx.cs" Inherits="PenPortfolio.BusinessAffiliateContacts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<!-- START PAGE CONTAINER -->
		<div class="container container-boxed">
													<!-- RECENT ACTIVITY -->
													<div class="block block-condensed">
														<div class="app-heading app-heading-small">
															<div class="title">
																<h2>Former Employees (Pensioners) Register(<asp:Label ID="lblPensionerName" runat="server" Text="Employer Name"></asp:Label>)</h2>
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
                                                                                <asp:HiddenField ID="txtMemberID" runat="server" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                <td colspan="2">Select a Business Affiliate</td>
                <td colspan="10">
                    <select name="ctl00$ContentPlaceHolder1$cboBusinessAffiliate" onchange="javascript:setTimeout(&#39;__doPostBack(\&#39;ctl00$ContentPlaceHolder1$cboBusinessAffiliate\&#39;,\&#39;\&#39;)&#39;, 0)" id="ContentPlaceHolder1_cboBusinessAffiliate" class="form-control dropdown">
	<option value="0">Select a business affiliate</option>
	<option value="1">Inhouse Contacts</option>
	<option selected="selected" value="2">Client Notications</option>
	<option value="3">Test group</option>
	<option value="4">Capitol Hill</option>
	<option value="5">Sandringhum Hill</option>

</select>
                </td>
            </tr>
            <tr>
                <td colspan="12">
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="5" style="text-align:center">Unassigned Affiliate Contacts</td>
                <td colspan="2" style="text-align:center"></td>
                <td colspan="5" style="text-align:center">Assigned Affiliate Contacts</td>
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
                    <select size="4" name="ctl00$ContentPlaceHolder1$lstAll" multiple="multiple" id="ContentPlaceHolder1_lstAll" class="form-control slick-list" style="height:200px;width:100%;">
	<option value="233">ZHUWAKINI EURITA</option>
	<option value="234">GURURE CLEMENT</option>
	<option value="249">MARIRIDZA RITA</option>
	<option value="250">MUCHAZORWIRA EVANS</option>
	<option value="266">TENDENGU REBBECA</option>
	<option value="267">MUVENGERANWA OBVIOUS</option>
	<option value="268">CHIOFA NOMAGUGU</option>
	<option value="273">NDLOVU DUDUZILE</option>
	<option value="274">NDLOVU SIMANGA </option>
	<option value="275">SPINDIYE TENDAI </option>
	<option value="276">SIBANDA BUSI</option>
	<option value="278">PHIRI NQOBIZITHA</option>
	<option value="283">NYONI ZEPHANIAH</option>
	<option value="284">SITHOLE KENNETH</option>
	<option value="286">MUJERA JOYCE</option>
	<option value="294">KASERERA TAKUDZWA</option>
	<option value="295">MHANDU OTILIA </option>
	<option value="296">SHUMBA GIFT</option>
	<option value="297">MUNEMO LAWRENCE </option>
	<option value="300">SHOKO ELIZABETH</option>
	<option value="239">MARARA PETRONELLA</option>
	<option value="240">CHEMUTENGURE JINA</option>
	<option value="241">KATSIGIRA ANGELLA</option>
	<option value="251">MUTUMBAMI JEALOUS</option>
	<option value="252">DAITON MANYARA</option>
	<option value="253">NJESERA MIKE</option>
	<option value="254">CHEKENYA MAUREEN</option>
	<option value="255">MASHINGE GLADYS</option>
	<option value="256">TICHABAIWA MELODY</option>
	<option value="257">NDORO CHIPO</option>
	<option value="258">MAVAZA DONEMORE</option>
	<option value="259">MUKUCHA SEKAI</option>
	<option value="260">GAWERE NERIA</option>
	<option value="261">MABANI CATHRINE</option>
	<option value="262">MAPARISA CRISPEN</option>
	<option value="263">CHIKUMBO CAROLINE</option>
	<option value="264">MAZHINDU NOMATTER</option>
	<option value="265">MYAMBUDU MILDRED</option>
	<option value="269">NKOMO PHATISANI</option>
	<option value="270">CHASAKARA TAPFUMANEI</option>
	<option value="271">MUPOMHORI SAMUEL</option>
	<option value="272">NYAWO LIZZY</option>
	<option value="279">MANDIRINGA LAWRENCE</option>
	<option value="280">TSONDAI TENDAI</option>
	<option value="281">NONDO AMANDA</option>
	<option value="285">SIZIBA HAPPINESS</option>
	<option value="287">MUSIYAMANJE EVERMAY</option>
	<option value="288">MURADZIKWA RUDO</option>
	<option value="289">DIHWA PRAISE</option>
	<option value="290">ZWENYERE SINCE</option>
	<option value="291">MASIMBA VIOLA</option>
	<option value="292">MANDIWO WASHINGTON</option>
	<option value="293">KARUPENI CLEMENCE</option>
	<option value="301">JANGARA FARAI</option>
	<option value="242">CHIKUPO WILBROAD</option>
	<option value="243">MANDIZVIDZA SUSAN</option>
	<option value="277">MUREWANHEMA FADZANAI</option>
	<option value="282">KHUMALO PINDUKAYI </option>
	<option value="1">Suwedi Macyline</option>
	<option value="3">Matemera Tendai</option>
	<option value="4">Matanda Morven</option>
	<option value="5">Chikwata Tendai</option>
	<option value="6">Mungoni Shingirai</option>
	<option value="7">Nyakudya Muchaneta</option>
	<option value="9">Manyinyire Vivian</option>
	<option value="298">PHIRI SHAME</option>
	<option value="230">RUZVIDZO BRIAN</option>
	<option value="231">CHINOMONA EVARISTO</option>
	<option value="232">KUNYETU ROBEN</option>
	<option value="235">MUTANDWA JENNIFER</option>
	<option value="236">GUZHA MOREBLESSING </option>
	<option value="237">MASHANGA CANNAN</option>
	<option value="238">MANDIZVIDZA DELIA </option>
	<option value="244">MACHINGARUFU EUNICE</option>
	<option value="245">MANDIZVIDZA CULTUS</option>
	<option value="246">DENHERE CHIEDZA</option>
	<option value="247">MACHERECHEDZE THERESA</option>
	<option value="248">JOKONIAH CAROLINE</option>
	<option value="299">NYONI DOUGLAS</option>

</select>
                </td>
                <td colspan="2" style="text-align:center">
                    <a id="ContentPlaceHolder1_lnkAdd" class="btn btn-outline-primary" href="javascript:__doPostBack(&#39;ctl00$ContentPlaceHolder1$lnkAdd&#39;,&#39;&#39;)">
                                                <i class="fa fa-plus"></i>>></a>
                    <a id="ContentPlaceHolder1_lnkRemove" class="btn btn-outline-danger" href="javascript:__doPostBack(&#39;ctl00$ContentPlaceHolder1$lnkRemove&#39;,&#39;&#39;)">
                                                <<<i class="fa fa-minus"></i></a>
                </td>
                <td colspan="5">
                    <select size="4" name="ctl00$ContentPlaceHolder1$lstAssigned" multiple="multiple" id="ContentPlaceHolder1_lstAssigned" class="form-control slick-list" style="height:200px;width:100%;">

</select>
                </td>
            </tr>
            <tr>
                <td colspan="12" style="text-align:center">
                    <input type="submit" name="ctl00$ContentPlaceHolder1$btnSave" value="Save Affiliate" id="ContentPlaceHolder1_btnSave" class="btn btn-outline-primary" />
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