<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditPage.aspx.cs" Inherits="WebApplication2.EditPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:label runat="server" text="Post Time" />
        <asp:TextBox runat="server" ID="txtPostTime" ReadOnly="true"/>
    </div>

    <div>
        <asp:label runat="server" text="Database User" />
        <asp:TextBox runat="server" ID="txtDatabaseUser" Wrap="true" Rows="10"/>
        <asp:RequiredFieldValidator runat="server" ID="ReqDatabaseUser" ControlToValidate="txtDatabaseUser" ErrorMessage="(Required)"/>
    </div>

    <div>
        <asp:label runat="server" text="Object" />
        <asp:TextBox runat="server" ID="txtObject" />
    </div>
    <div>
        <asp:label runat="server" text="Event" />
        <asp:TextBox runat="server" ID="txtEvent" />
        <asp:RequiredFieldValidator runat="server" ID="ReqEvent" ControlToValidate="txtEvent" ErrorMessage="(Required)"/>
    </div>

    <div>
        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
        <asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="btnCreate_Click" visible="false"/>
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
    </div>
</asp:Content>
