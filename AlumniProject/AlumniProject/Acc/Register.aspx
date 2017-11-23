<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="AlumniProject.Acc.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
         <asp:Label ID="lblStatus" runat="server" CssClass="badge status" />
    </div>
    
    <div>
        <asp:TextBox 
            ID="txtEmail" 
            runat="server" 
            CssClass="form-control"
            placeholder="Email">
        </asp:TextBox>
    </div>
     <div>
        <asp:TextBox 
            ID="txtFirstName" 
            runat="server" 
            CssClass="form-control"
            placeholder="First Name">
        </asp:TextBox>
    </div>

     <div>
        <asp:TextBox 
            ID="txtLastName" 
            runat="server" 
            CssClass="form-control"
            placeholder="LastName">
        </asp:TextBox>
    </div>


    <div>
        <asp:DropDownList 
            ID="ddlDepartments"
            runat="Server"
            DataTextField="Name"
            DataValueField="Id"
            CssClass="form-control"
            Width="200px">
            </asp:DropDownList>
    </div>

    <div>   
        <asp:Button 
            ID="btnRegister"
            runat="server"
            Text="Register"
            CssClass="btn-primary" OnClick="btnRegister_Click" />
    </div>
</asp:Content>
