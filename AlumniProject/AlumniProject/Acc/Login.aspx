<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AlumniProject.Acc.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table>
         <tr>

            <td>    
                <asp:Label ID="lblStatus" runat="server" CssClass="badge status" />
                <td>

            </td>
        </tr>
        <tr>

            <td>    
                <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" CssClass="form-control"></asp:TextBox>
                <td>

            </td>
        </tr>
        <tr>

            <td>    
                <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" CssClass="form-control" TextMode="Password"></asp:TextBox>
                <td>

            </td>
        </tr>
        <tr>

            <td>    
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn-primary" OnClick="btnLogin_Click" />
                <td>

            </td>
        </tr>
       
    </table>
</asp:Content>
