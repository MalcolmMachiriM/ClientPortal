<%@ Page Title="" Language="C#" MasterPageFile="~/EmployerLog.Master" AutoEventWireup="true" CodeBehind="BranchSummary.aspx.cs" Inherits="PenPortfolio.BranchSummary" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<!-- START PAGE CONTAINER -->
		<div class="container container-boxed">
            <div class="block block-condensed">
                <div class="col-sm-9" id="dvDash" runat="server" visible="true">
    <div class="row col-sm-12">
       
                                     
                                    </div>
            																			</div>
     <div class="col-md-9" id="Div1" runat="server" visible="true">
                           <div class="row">
                            <asp:HiddenField ID="txtFundID" runat="server" />
                            <asp:HiddenField ID="txtSystemRef" runat="server" />
                        </div>
                    <asp:Panel ID="Panel1" runat="server" Width="100%">

                        <div class="col-md-12">

                                    <div>
                                        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ReuseParameterValuesOnRefresh="True" HasToggleGroupTreeButton="false" />
                                    </div>
                        </div>
                                </asp:Panel>
        </div>
                                

                            </div>
                </div>
											<!-- RECENT ACTIVITY -->

																				<!-- END RECENT -->
																			
<!-- END PAGE CONTAINER -->
</asp:Content>
