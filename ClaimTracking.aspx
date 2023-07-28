<%@ Page Title="" Language="C#" MasterPageFile="~/EmployerLog.Master" AutoEventWireup="true" CodeBehind="ClaimTracking.aspx.cs" Inherits="PenPortfolio.ClaimTracking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<!-- START PAGE CONTAINER -->
		<div class="container container-boxed">
													<!-- RECENT ACTIVITY -->
													<div class="block block-condensed">
														<div class="app-heading app-heading-small">
															<div class="title">
																<h2>Lodged Claims Tracking(<asp:Label ID="lblPensionerName" runat="server" Text="Employer Name"></asp:Label>)</h2>
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
                                                                            <td colspan="2">Search Option:</td>
                                                                            <td colspan="10">
                                                                                <asp:DropDownList ID="cboSearchOptions" CssClass="form-control dropdown" runat="server"></asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">Search Value:</td>
                                                                            <td colspan="10">
                                                                                <asp:TextBox ID="txtSearchValue" CssClass="form-control" placeholder="Search Value" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
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
                                                                            <td colspan="2">Claim Status:</td>
                                                                            <td colspan="10">
                                                                                <asp:TextBox ID="TextBox10" placeholder="Processing/Approved/Awaiting Payment/Paid" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                                            </td>
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
                                                                            <td colspan="4"><asp:TextBox ID="txtDob" placeholder="dd/MM/YYYY" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox></td>
                                                                            <td colspan="2">National ID:</td>
                                                                            <td colspan="4">
                                                                                <asp:TextBox ID="txtNationalID" placeholder="##-#######-X-##" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">Age at Claim Log:</td>
                                                                            <td colspan="4">
                                                                                <asp:TextBox ID="txtEmployer" placeholder="##" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                                            </td>
                                                                            <td colspan="2">Normal Retirement Date:</td>
                                                                            <td colspan="4">
                                                                                <asp:TextBox ID="txtBranch" placeholder="dd/MM/YYYY" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">Exit Date:</td>
                                                                            <td colspan="4">
                                                                                <asp:TextBox ID="txtDepartment" placeholder="dd/MM/YYYY" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                                            </td>
                                                                            <td colspan="2">Exit Type:</td>
                                                                            <td colspan="4">
                                                                                <asp:TextBox ID="txtMembershipCategory" placeholder="Withdrawal/Ret/Death" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="12"><hr /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">Last Bonus Declaration Date:</td>
                                                                            <td colspan="4">
                                                                                <asp:TextBox ID="txtDJC" placeholder="dd/MM/YYYY" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                                            </td>
                                                                            <td colspan="2">Pensionable Service:</td>
                                                                            <td colspan="4">
                                                                                <asp:TextBox ID="txtDJF" placeholder="###.##" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        
                                                                        <tr>
                                                                            <td colspan="2">Company:</td>
                                                                            <td colspan="10">
                                                                                <asp:TextBox ID="TextBox2" placeholder="Company Name" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                                            </td>
                                                                            
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">Member Category:</td>
                                                                            <td colspan="10">
                                                                                <asp:TextBox ID="TextBox3" placeholder="Fund Category" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                                            </td>
                                                                            
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">Member Portion At Declaration:</td>
                                                                            <td colspan="10">
                                                                                <asp:TextBox ID="TextBox4" placeholder="######.##" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                                            </td>
                                                                            
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">Employer Portion At Declaration:</td>
                                                                            <td colspan="10">
                                                                                <asp:TextBox ID="TextBox5" placeholder="######.##" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                                            </td>
                                                                            
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2"><b>Accumulated Reserve as at Last Review:</b></td>
                                                                            <td colspan="10">
                                                                                <asp:TextBox ID="TextBox6" placeholder="######.##" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                                            </td>
                                                                            
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">Member Cont without Interest (since last review):</td>
                                                                            <td colspan="10">
                                                                                <asp:TextBox ID="TextBox7" placeholder="######.##" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                                            </td>
                                                                            
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">Employer Cont without Interest (since last review):</td>
                                                                            <td colspan="10">
                                                                                <asp:TextBox ID="TextBox8" placeholder="######.##" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                                            </td>
                                                                            
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">Accumulated Reserve (plus interest accrued to exit date):</td>
                                                                            <td colspan="10">
                                                                                <asp:TextBox ID="TextBox9" placeholder="######.##" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                                            </td>
                                                                            
                                                                        </tr>
                                                                         <tr>
                                            <td colspan="2">Member Contributions with Interest since Last Review</td>
                                            <td colspan="10">
                                                <input name="ctl00$ContentPlaceHolder1$txtMemberContWithInt" type="text" value="0" readonly="readonly" id="ContentPlaceHolder1_txtMemberContWithInt" class="form-control" style="font-weight:normal;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">Net Employer Contributions with Interest since Last Review</td>
                                            <td colspan="10">
                                                <input name="ctl00$ContentPlaceHolder1$txtEmployerContWithInt" type="text" value="0" readonly="readonly" id="ContentPlaceHolder1_txtEmployerContWithInt" class="form-control" style="font-weight:normal;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">Member Portion as at Exit Date</td>
                                            <td colspan="10">
                                                <input name="ctl00$ContentPlaceHolder1$txtMemberPortAtExit" type="text" value="0" readonly="readonly" id="ContentPlaceHolder1_txtMemberPortAtExit" class="form-control" style="font-weight:normal;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">Employer Portion as at Exit Date</td>
                                            <td colspan="10">
                                                <input name="ctl00$ContentPlaceHolder1$txtEmployerPortAtExit" type="text" value="0" readonly="readonly" id="ContentPlaceHolder1_txtEmployerPortAtExit" class="form-control" style="font-weight:normal;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2"><b>Accumulated Reserve as at Exit Date</b></td>
                                            <td colspan="10">
                                                <input name="ctl00$ContentPlaceHolder1$txtAccumReserveAtExit" type="text" value="0" readonly="readonly" id="ContentPlaceHolder1_txtAccumReserveAtExit" class="form-control" style="font-weight:bold;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">Member Portion with interest as at payment date:</td>
                                            <td colspan="10">
                                                <input name="ctl00$ContentPlaceHolder1$txtMemberPortwithIntAtPayment" type="text" value="0" readonly="readonly" id="ContentPlaceHolder1_txtMemberPortwithIntAtPayment" class="form-control" style="font-weight:normal;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">Employer Portion with interest as at payment date:</td>
                                            <td colspan="10">
                                                <input name="ctl00$ContentPlaceHolder1$txtEmployerPortWithIntAtPayment" type="text" value="0" readonly="readonly" id="ContentPlaceHolder1_txtEmployerPortWithIntAtPayment" class="form-control" style="font-weight:normal;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2"><b>Accumulated Reserve with interest as at payment date:</b></td>
                                            <td colspan="10">
                                                <input name="ctl00$ContentPlaceHolder1$txtAccumReserveAtPayment" type="text" value="0" readonly="readonly" id="ContentPlaceHolder1_txtAccumReserveAtPayment" class="form-control" style="font-weight:bold;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="12"><hr /></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">One Third Cash Commutation:</td>
                                            <td colspan="10">
                                                <input name="ctl00$ContentPlaceHolder1$txtOneThird" type="text" value="0" readonly="readonly" id="ContentPlaceHolder1_txtOneThird" class="form-control" style="font-weight:normal;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2"><b>One Third Cash Commutation (Inclusive of Interest):</b></td>
                                            <td colspan="10">
                                                <input name="ctl00$ContentPlaceHolder1$txtOneThirdInclusive" type="text" value="0" readonly="readonly" id="ContentPlaceHolder1_txtOneThirdInclusive" class="form-control" style="font-weight:normal;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">Member's Age on Retirement:</td>
                                            <td colspan="10">
                                                <input name="ctl00$ContentPlaceHolder1$txtMembersAge" type="text" value="0" readonly="readonly" id="ContentPlaceHolder1_txtMembersAge" class="form-control" style="font-weight:normal;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">Residual Consideration:</td>
                                            <td colspan="10">
                                                <input name="ctl00$ContentPlaceHolder1$txtResidualConsid" type="text" value="0" readonly="readonly" id="ContentPlaceHolder1_txtResidualConsid" class="form-control" style="font-weight:normal;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">Conversion Factor:</td>
                                            <td colspan="10">
                                                <input name="ctl00$ContentPlaceHolder1$txtConversionFactor" type="text" value="0" readonly="readonly" id="ContentPlaceHolder1_txtConversionFactor" class="form-control" style="font-weight:normal;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">Annual Pension:</td>
                                            <td colspan="10">
                                                <input name="ctl00$ContentPlaceHolder1$txtAnnualPension" type="text" value="0" readonly="readonly" id="ContentPlaceHolder1_txtAnnualPension" class="form-control" style="font-weight:bold;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">Monthly Pension:</td>
                                            <td colspan="10">
                                                <input name="ctl00$ContentPlaceHolder1$txtMonthlyPension" type="text" value="0" readonly="readonly" id="ContentPlaceHolder1_txtMonthlyPension" class="form-control" style="font-weight:bold;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">Member Benefit Tax:</td>
                                            <td colspan="10">
                                                <input name="ctl00$ContentPlaceHolder1$txtMemberBenefitTax" type="text" value="0" readonly="readonly" id="ContentPlaceHolder1_txtMemberBenefitTax" class="form-control" style="font-weight:bold;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">Add Award Tax:</td>
                                            <td colspan="10">
                                                <input name="ctl00$ContentPlaceHolder1$txtAddAwardTax" type="text" value="0" readonly="readonly" id="ContentPlaceHolder1_txtAddAwardTax" class="form-control" style="font-weight:bold;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="12"><hr /></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">Actual Exit Date:</td>
                                            <td colspan="10">
                                                <input name="ctl00$ContentPlaceHolder1$txtActualExitDate" type="text" value="" readonly="readonly" id="ContentPlaceHolder1_txtActualExitDate" class="form-control" style="font-weight:bold;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">Checked By:</td>
                                            <td colspan="10">
                                                <input name="ctl00$ContentPlaceHolder1$txtCheckedBy" type="text" readonly="readonly" id="ContentPlaceHolder1_txtCheckedBy" class="form-control" style="font-weight:bold;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">Checked On:</td>
                                            <td colspan="10">
                                                <input name="ctl00$ContentPlaceHolder1$txtCheckedOn" type="text" readonly="readonly" id="ContentPlaceHolder1_txtCheckedOn" class="form-control" style="font-weight:bold;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">Authorised By:</td>
                                            <td colspan="10">
                                                <input name="ctl00$ContentPlaceHolder1$txtAuhorisedBy" type="text" readonly="readonly" id="ContentPlaceHolder1_txtAuhorisedBy" class="form-control" style="font-weight:bold;" />
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

