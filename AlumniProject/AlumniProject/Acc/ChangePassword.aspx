<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="AlumniProject.Acc.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
          <asp:Label 
            ID="lblStatus" 
            runat="server"
            CssClass="badge status">

        </asp:Label>
    </div>
    <div>
        <asp:TextBox 
            ID="txtNewPassword" 
            runat="server" 
            placeholder="New Password"
            CssClass="form-control">

            </asp:TextBox>
     </div>
    <div>
        <asp:TextBox 
            ID="txtConfirm"
            runat="server" 
            placeholder="Confirm Password"
             CssClass="form-control">

        </asp:TextBox>
     </div>
    <div>
        <asp:Button 
            ID="btnChangePassword" 
            runat="server" 
            Text="Change Passwor"
            CssClass="btn-primary" OnClick="btnChangePassword_Click" />
       
     </div>
</asp:Content>
