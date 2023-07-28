<%@ Page Title="" Language="C#" MasterPageFile="~/EmployerLog.Master" AutoEventWireup="true" CodeBehind="PensionerDeclarationForm.aspx.cs" Inherits="PenPortfolio.PensionerDeclarationForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- START PAGE CONTAINER -->
    <div class="container container-boxed">
        <!-- RECENT ACTIVITY -->
        <div class="block block-condensed">
            <div class="app-heading app-heading-small">
                <div class="title">
                    <h2>Declaration Form <%--(<asp:Label ID="lblPensionerName" runat="server" Text="Employer Name"></asp:Label>)--%></h2>
                    <%--<p>Last visit: 14:54 28.06.2017</p>--%>
                </div>
            </div>
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
                    <asp:HiddenField ID="txtFundID" runat="server" />
                    <asp:HiddenField ID="txtMemberIDs" runat="server" />
                    <asp:HiddenField ID="txtSystemRef" runat="server" />
                </div>
            </div>
            <div class="block-content">
                <form class="form-horizontal">
                    <div class="row">
                        <table style="width: 100%">
                            <tr>
                                <td colspan="12">
                                    <asp:HiddenField ID="txtMemberID" runat="server" />
                                </td>
                            </tr>

                            <tr runat="server" visible="false">
                                <td colspan="12" style="text-align: center">
                                    <button class="btn btn-primary btn-clean">Search</button>
                                </td>
                            </tr>

                            <tr>
                                <td colspan="12">
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">Pensioner:</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtPensioner" placeholder="pensioner" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox></td>

                            </tr>
                            <tr>
                                <td colspan="2">PensionNo:</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtID" placeholder="pensionNo" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox></td>

                            </tr>
                            <tr>
                                <td colspan="2">Pension Basis:</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtPensionBasis" placeholder="Pension Basis" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                </td>

                            </tr>
                            <tr>
                                <td colspan="2">Year:</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtYear" placeholder="year" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                </td>

                            </tr>
                            <tr>
                                <td colspan="2">Document Type:</td>
                                <td colspan="4">
                                    <asp:DropDownList ID="cboDocument" CssClass="form-control dropdown" AutoPostBack="false" runat="server"></asp:DropDownList>

                                </td>

                            </tr>
                            <tr>
                                <td colspan="2">File:</td>
                                <td colspan="4">
                                    <asp:FileUpload ID="FileUpload1" CssClass="form-control fa-upload" runat="server" />
                                </td>

                            </tr>
                            <tr>
                                <td colspan="12" style="text-align: center">


                                    <asp:Button ID="btnUpload" OnClick="btnUpload_Click" CssClass="btn btn-primary" runat="server" Text="Upload" />


                                </td>
                            </tr>
                            <tr>
                                <td colspan="12">

                                    <asp:GridView ID="grdDocuments" Width="100%" runat="server"
                                        AutoGenerateColumns="False" AutoGenerateSelectButton="false" OnPageIndexChanging="grdDocuments_PageIndexChanging"
                                        DataKeyNames="ID" PageSize="10"
                                        CssClass="table table-condensed" GridLines="None" role="grid" aria-describedby="DataTables_Table_0_info"
                                        Style="border-collapse: collapse !important"
                                        AllowPaging="True" AllowSorting="True" OnRowCommand="grdDocuments_RowCommand">
                                        <Columns>
                                            <asp:BoundField DataField="ID" HeaderText="ID"></asp:BoundField>
                                            <asp:BoundField DataField="Name" HeaderText="Name"></asp:BoundField>
                                            <asp:BoundField DataField="IdentityDocument" HeaderText="IdentityDocument"></asp:BoundField>
                                            <asp:BoundField DataField="YearOfDeclaration" HeaderText="Year Of Declaration"></asp:BoundField>


                                            <asp:TemplateField HeaderText="Download">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkRecSel" runat="server" ForeColor="green" CssClass="fa fa-download fa-2x" CommandArgument='<%#Eval("ID")%>' CommandName="selectrecord"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkRecDel" runat="server" ForeColor="red" CssClass="fa fa-trash fa-2x" CommandArgument='<%#Eval("ID")%>' CommandName="deleterecord"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                        </Columns>
                                    </asp:GridView>


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

    </div>

</asp:Content>

