<%@ Page Language="C#" MasterPageFile="~/EmployerLog1.Master"  AutoEventWireup="true" CodeBehind="FundSelect.aspx.cs" Inherits="PenPortfolio.FundSelect" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%">
        
        <tr>
            <td colspan="12">
                <asp:HiddenField ID="txtFundID" runat="server" />
                <asp:HiddenField ID="txtUsername" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="12">
                <asp:Panel ID="pnlSuccessComms" CssClass="alert alert-success fade show" role="alert" Visible="false" runat="server">
        <asp:Label ID="lblSuccessComms" Font-Bold="false" runat="server" Text=""></asp:Label>
    </asp:Panel>
    <asp:Panel ID="pnlWarningComms" CssClass="alert alert-warning fade show" role="alert" Visible="false" runat="server">
        <asp:Label ID="lblWarningComms" Font-Bold="false" runat="server" Text=""></asp:Label>
    </asp:Panel>
    <asp:Panel ID="pnlErrorComms" CssClass="alert alert-danger fade show" role="alert" Visible="false" runat="server">
        <asp:Label ID="lblErrorComms" Font-Bold="false" runat="server" Text=""></asp:Label>
    </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="12" style="text-align:right">
                <asp:Button ID="btnCreateNew" Visible="false" OnClick="btnCreateNew_Click" CssClass="btn btn-primary" runat="server" Text="Create New Fund" />
            </td>
        </tr>
        <tr>
            <td colspan="2"></td>
            <td colspan="10">
                <asp:DropDownList ID="cboFundSelect" Visible="false" CssClass="form-control dropdown"  runat="server"></asp:DropDownList>
            </td>
        </tr>
        
        <tr>
            <td colspan="12" style="text-align:center">
                <asp:Button ID="btnSelect" OnClick="btnSelect_Click" Visible="false" CssClass="btn btn-success" runat="server" Text="Select Fund" />
            </td>
        </tr>
        <tr runat="server" visible="false">
            <td colspan="2">Filter Search</td>
            <td colspan="8">
                <asp:TextBox ID="txtSearchFilter" CssClass="form-control" placeholder="Search Fund By Name" runat="server"></asp:TextBox>
            </td>
            <td colspan="2">
                <asp:Button ID="btnSeach" OnClick="btnSeach_Click" CssClass="btn btn-success" runat="server" Text="Search" />
            </td>
        </tr>
        <tr>
            <td colspan ="12">
              <asp:GridView ID="grdFunds" Width="100%" runat="server"
                    AutoGenerateColumns="False" AutoGenerateSelectButton="false" 
                                    DataKeyNames="Key" OnPageIndexChanging="gridPageChange"
                                    CssClass="table table-condensed" GridLines="None" role="grid" aria-describedby="DataTables_Table_0_info" 
                                    Style="border-collapse: collapse !important" 
                                    AllowPaging="True" AllowSorting="True" OnRowCommand="grdClients_RowCommand">
                            <Columns>
                                        <asp:BoundField DataField="RegNo" HeaderText="Reg No"></asp:BoundField>                                      
                                        <asp:BoundField DataField="RegName" HeaderText="Scheme Name"></asp:BoundField>
                                                                
                                        
                                        <asp:TemplateField HeaderText="Select">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkRecDel" runat ="server" ForeColor="Green" CssClass="fa fa-check fa-2x" CommandArgument='<%#Eval("Key")%>' CommandName ="selectrecord" ></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>   
                                                                                                       
                                    
                                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="12" style="text-align:right">                             

            </td>
        </tr>
    </table>
</asp:Content>
