<%@ Page Title="" Language="C#" MasterPageFile="~/EmployerLog.Master" AutoEventWireup="true" CodeBehind="ContributionsUploads.aspx.cs" Inherits="PenPortfolio.ContributionsUploads" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<!-- START PAGE CONTAINER -->
		<div class="container container-boxed">
													<!-- RECENT ACTIVITY -->
													<div class="block block-condensed">
														<div class="app-heading app-heading-small">
															<div class="title">
																<h2>Contributions Upload Page <%--(<asp:Label ID="lblPensionerName" runat="server" Text="Employer Name"></asp:Label>)--%></h2>
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
                            <asp:HiddenField ID="txtFundID" runat="server" />
							<asp:HiddenField ID="txtSystemRef" runat="server" />
                            <asp:HiddenField ID="txtBatchID" runat="server" />
                            <asp:HiddenField ID="txtBatchNo" runat="server" />
                            <asp:HiddenField ID="txtDB" runat="server" />
							</div>
			</div>
														<div class="block-content">
															<form class="form-horizontal">
																<div class="row">
																	<table style="width:100%">
                                                                        <tr>
            <td colspan="12">
                <asp:Panel ID="pnlComms" Width="100%" runat="server">
                    <asp:Label ID="lblComms" runat="server" Text="" Font-Bold="True" ForeColor="White"></asp:Label>
                </asp:Panel>
            </td>
        </tr>
                                                                        <tr>
                                                                            <td colspan="12">
                                                                                <asp:HiddenField ID="txtMemberID" runat="server" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">Upload Year:</td>
                                                                            <td colspan="4">
                                                                                <asp:DropDownList ID="cboPeriod" CssClass="form-control dropdown" runat="server">
                                                                                    <%--<asp:ListItem>2010</asp:ListItem>
                                                                                    <asp:ListItem>2011</asp:ListItem>
                                                                                    <asp:ListItem>2012</asp:ListItem>
                                                                                    <asp:ListItem>2013</asp:ListItem>
                                                                                    <asp:ListItem>2014</asp:ListItem>
                                                                                    <asp:ListItem>2015</asp:ListItem>
                                                                                    <asp:ListItem>2016</asp:ListItem>
                                                                                    <asp:ListItem>2017</asp:ListItem>
                                                                                    <asp:ListItem>2018</asp:ListItem>
                                                                                    <asp:ListItem>2019</asp:ListItem>
                                                                                    <asp:ListItem>2020</asp:ListItem>
                                                                                    <asp:ListItem>2021</asp:ListItem>
                                                                                    <asp:ListItem>2022</asp:ListItem>
                                                                                    <asp:ListItem>2023</asp:ListItem>
                                                                                    <asp:ListItem>2024</asp:ListItem>
                                                                                    <asp:ListItem>2025</asp:ListItem>
                                                                                    <asp:ListItem>2026</asp:ListItem>
                                                                                    <asp:ListItem>2027</asp:ListItem>
                                                                                    <asp:ListItem>2028</asp:ListItem>--%>

                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td colspan="2">Upload Month:</td>
                                                                            <td colspan="4">
                                                                                <asp:DropDownList ID="cboMonths" CssClass="form-control dropdown" runat="server">
                                                                                   <%-- <asp:ListItem>January</asp:ListItem>
                                                                                    <asp:ListItem>February</asp:ListItem>
                                                                                    <asp:ListItem>March</asp:ListItem>
                                                                                    <asp:ListItem>April</asp:ListItem>
                                                                                    <asp:ListItem>May</asp:ListItem>
                                                                                    <asp:ListItem>June</asp:ListItem>
                                                                                    <asp:ListItem>July</asp:ListItem>
                                                                                    <asp:ListItem>August</asp:ListItem>
                                                                                    <asp:ListItem>September</asp:ListItem>
                                                                                    <asp:ListItem>October</asp:ListItem>
                                                                                    <asp:ListItem>November</asp:ListItem>
                                                                                    <asp:ListItem>December</asp:ListItem>--%>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">Cost Center:</td>
                                                                            <td colspan="4">
                                                                                <asp:DropDownList ID="cboCompany" CssClass="form-control dropdown" runat="server">
                                                                                    <%--<asp:ListItem>Head Office</asp:ListItem>
                                                                                    <asp:ListItem>Harare CBD Branch</asp:ListItem>
                                                                                    <asp:ListItem>Gweru Office</asp:ListItem>--%>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td colspan="2">Branch:</td>
                                                                            <td colspan="4">
                                                                                <asp:DropDownList ID="cbobranch" CssClass="form-control dropdown" runat="server">
                                                                                    <%--<asp:ListItem>Harare Branch</asp:ListItem>
                                                                                    <asp:ListItem>Gweru Branch</asp:ListItem>
                                                                                    <asp:ListItem>Mutare Branch</asp:ListItem>
                                                                                    <asp:ListItem>Bulawayo Branch</asp:ListItem>
                                                                                    <asp:ListItem>Chinhoyi Branch</asp:ListItem>--%>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">Payment Date:</td>
                                                                            <td colspan="4">
                                                                                <asp:TextBox ID="txtPaymentDate" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox></td>
                                                                            <td colspan="2">File:</td>
                                                                            <td colspan="4">
                                                                                <asp:FileUpload ID="flContributionsUpload" runat="server" accept=".xls,.xlsx,.csv" />
                                                                            </td>
                                                                            
                                                                        </tr>
                                                                        <tr>
<td colspan="12" style="text-align:center"">
    <asp:Button ID="btnDownload" OnClick="btnDownload_Click" CssClass="btn btn-outline-primary btn-sm" runat="server" Text="Download Template" /> |
                                                 <asp:Button ID="btnUpload" OnClick="btnUpload_Click" CssClass="btn btn-outline-primary btn-sm" runat="server" Text="Upload" />
                                                                        </tr>
                                                                        <tr>

            <td colspan="2">Select Sheet:</td>
            <td colspan="4"><asp:ListBox ID="lstWrkSheets" OnSelectedIndexChanged="lstWrkSheets_SelectedIndexChanged" CssClass="form-control list-group" AutoPostBack="true" runat="server"></asp:ListBox></td>
<%--            <td colspan="1"><asp:Label ID="lblSalaryBill" runat="server" Text="" Font-Names="Courier New"></asp:Label></td>
            <td colspan="2"></td>--%>
                                                                        </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblWrkSheetPrompt" runat="server" Text=""></asp:Label>
                        <asp:TextBox ID="txtFilePath" Visible="false" runat="server"></asp:TextBox>
                        <asp:TextBox ID="txtFileName" Visible="false" runat="server"></asp:TextBox></td>

                </tr>
                <tr>
                    <td colspan="12">
                        <hr />
                    </td>
                </tr>

                <tr>
                    <td colspan="2">Records Detected:</td>
                    <td colspan="4">
                        <asp:TextBox ID="txtRecordsCount" placeholder="0" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">Salary Bill:</td>
                    <td colspan="4">
                        <asp:TextBox ID="txtSalaryBill" placeholder="0" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">Actual Member Contribution:</td>
                    <td colspan="4">
                        <asp:TextBox ID="txtMemberActual" placeholder="0" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">Actual Employer Contribution:</td>
                    <td colspan="4">
                        <asp:TextBox ID="txtEmployerActual" placeholder="0" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td colspan="2">Expected Member Contribution:</td>
                    <td colspan="4">
                        <asp:TextBox ID="txtExpectedMember" placeholder="0" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">Expected Employer Contribution:</td>
                    <td colspan="4">
                        <asp:TextBox ID="txtExpectedEmployer" placeholder="0" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">Transfer In Member Contribution:</td>
                    <td colspan="4">
                        <asp:TextBox ID="txtTransferInMember" placeholder="0" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">Transfer In Employer Contribution:</td>
                    <td colspan="4">
                        <asp:TextBox ID="txtTransferInEmployer" placeholder="0" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">Other Member Contribution:</td>
                    <td colspan="4">
                        <asp:TextBox ID="txtOtherMember" placeholder="0" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">Other Employer Contribution:</td>
                    <td colspan="4">
                        <asp:TextBox ID="txtOtherEmployer" placeholder="0" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">Balancing Status:</td>
                    <td colspan="10">
                        <asp:TextBox ID="lblBalancing" placeholder="Balanced/Unbalanced" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td colspan="12" style="text-align: center">
                        <asp:Button ID="btnProcess" CssClass="btn btn-primary btn-clean" OnClick="btnProcess_Click" OnClientClick="return confirm('Are you sure want you want to upload these contributions?');" runat="server" Text="Process Upload" />
                        <%--<button class="btn btn-primary btn-clean">Process Upload</button>--%>
                                                                                | 
                                                                                <%--<button class="btn btn-primary btn-clean">Discard Upload</button>--%>
                        <asp:Button ID="btnDiscard" CssClass="btn btn-primary btn-clean" OnClick="btnDiscard_Click" runat="server" Text="Discard Upload" />
                    </td>
                </tr>
                <tr>

                    <td colspan="12" style="width: 100%;">
                        <table style="max-width: 60vw">
                            <tr>
                                <td colspan="12">Pending Uploaded Contributions</td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="display: block; overflow: scroll; height: 40vh; display: grid;">
                                        <asp:GridView ID="grdMatchAccounts" OnPageIndexChanging="grdMatchAccounts_PageIndexChanging" PageSize="10" AutoGenerateColumns="false" CssClass="table table-condensed" GridLines="None" role="grid" aria-describedby="DataTables_Table_0_info"
                                            Style="border-collapse: collapse !important"
                                            AllowPaging="True" AllowSorting="True" runat="server">
                                            <Columns>
                                                <asp:BoundField DataField="SystemRefNo" HeaderText="SystemRefNo" />
                                                <asp:BoundField DataField="IDNumber" HeaderText="Identity No." />
                                                <asp:BoundField DataField="MemberSalary" HeaderText="Member Salary" />
                                                <asp:BoundField DataField="Surname" HeaderText="Surname" />
                                                <asp:BoundField DataField="Forenames" HeaderText="Firstname(s)" />
                                                <asp:BoundField DataField="MemberContributions" HeaderText="Member Contribution" />
                                                <asp:BoundField DataField="CompanyContributions" HeaderText="Employer Contribution" />
                                                <asp:BoundField DataField="VoluntaryContributions" HeaderText="AVC" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>

                <tr>
                    <td colspan="12" style="width: 100%;">
                        <table style="max-width: 60vw">
                            <tr>
                                <td colspan="12">Failed Upload Contribution Records</td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="display: block; overflow: scroll; height: 40vh; display: grid;">
                                        <asp:GridView ID="grdUploadError" AutoGenerateColumns="false" CssClass="table table-condensed" OnPageIndexChanging="grdUploadError_PageIndexChanging" GridLines="None" role="grid" aria-describedby="DataTables_Table_0_info"
                                            Style="border-collapse: collapse !important"
                                            AllowPaging="True" AllowSorting="True" runat="server">
                                            <Columns>
                                                <asp:BoundField DataField="ID" HeaderText="ID" />
                                                <asp:BoundField DataField="NationalID" HeaderText="NationalID" />
                                                <asp:BoundField DataField="Description" HeaderText="Description" />
                                                <asp:BoundField DataField="BranchCode" HeaderText="BranchCode" />
                                                <asp:BoundField DataField="DateCreated" HeaderText="DateCreated" />

                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                        </table>
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

