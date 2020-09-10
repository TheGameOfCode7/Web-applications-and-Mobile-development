<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditPage.aspx.cs" Inherits="WebApplication2.EditPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <label runat="server" text="Time stamp" />
        <asp:TextBox runat="server" ID="txttimeStamp" />
        <asp:RequiredFieldValidator runat="server" ID="reqTimeStamp" ControlToValidate="txtTimeStamp" />


    </div>

    <div>
        <label runat="server" text="Time stamp" />
        <asp:TextBox runat="server" ID="TextBox1" />


    </div>

</asp:Content>
