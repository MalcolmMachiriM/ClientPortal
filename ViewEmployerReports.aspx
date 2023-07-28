<%@ Page Title="" Language="C#" MasterPageFile="~/EmployerLog.Master" AutoEventWireup="true" CodeBehind="ViewEmployerReports.aspx.cs" Inherits="PenPortfolio.ViewEmployerReports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="main-panel ps ps--active-y">
        <nav class="navbar-absolute fixed-top navbar-transparent navbar navbar-expand-lg">
            <div class="container-fluid">
            </div>
        </nav>
        <div class="content">
          
            <div class="row">
                <asp:HiddenField ID="txtFundID" runat="server" />
                <asp:HiddenField ID="txtMemberID" runat="server" />
            </div>
            <div class="row">

                 <div class="card-body">
                                    <div class="row gutters col-12">
                                                <ul class="traffic-sources col-3">
                   
                                                       <li>
                                                        <div class="row no-gutters">
                                                            <div class="col-xl-1 col-lg-1 col-md-1 col-sm-1">
                                                                <span class="symbol blue"></span>
                                                            </div>
                                                            <div class="col-xl-7 col-lg-7 col-md-7 col-sm-7">
                                                                <asp:LinkButton ID="lblContributionSummary" OnClick="lblContributionSummary_Click" runat="server"> >>Contributions Summary Report</asp:LinkButton>
                                                                 
                                                            </div>

                                                        </div>
                                                    </li>
                                                    <li>
                                                        <div class="row no-gutters">
                                                            <div class="col-xl-1 col-lg-1 col-md-1 col-sm-1">
                                                                <span class="symbol blue"></span>
                                                            </div>
                                                            <div class="col-xl-7 col-lg-7 col-md-7 col-sm-7">
                                                                <asp:LinkButton ID="lblBranchSummary" OnClick="lblBranchSummary_Click" runat="server"> >>Branch Listing Report</asp:LinkButton>
                                                                 
                                                            </div>

                                                        </div>
                                                    </li>
                                                </ul>
                                            </div>
                                </div>
            </div>

          

            </div>
  </div>
</asp:Content>
