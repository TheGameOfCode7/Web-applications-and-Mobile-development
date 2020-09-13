<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditPage.aspx.cs" Inherits="WebApplication2.EditPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <style type="text/css">
        .Segments {
            margin-bottom:10px;
            margin-top:10px;
        }
        .BtnSegment{
            margin-left:150px
        }
    </style>

    <div class="Segments">
        <asp:Label Style="margin-right: 60px" runat="server" Text="Post Time" CssClass="" />
        <asp:TextBox runat="server" ID="txtPostTime" ReadOnly="true" />
    </div>

    <div class="Segments">
        <asp:Label Style="margin-right: 28px" runat="server" Text="Database User" />
        <asp:TextBox runat="server" ID="txtDatabaseUser" Wrap="true" Rows="10" />
        <asp:RequiredFieldValidator runat="server" ID="ReqDatabaseUser" ControlToValidate="txtDatabaseUser" ErrorMessage="(Required)" ValidationGroup="CreAndUpd"/>
    </div>

    <div class="Segments">
        <asp:Label Style="margin-right: 80px" runat="server" Text="Object" />
        <asp:TextBox runat="server" ID="txtObject" />
    </div>

    <div class="Segments">
        <asp:Label Style="margin-right: 85px" runat="server" Text="Event" />
        <asp:TextBox runat="server" ID="txtEvent" />
        <asp:RequiredFieldValidator runat="server" ID="ReqEvent" ControlToValidate="txtEvent" ErrorMessage="(Required)" ValidationGroup="CreAndUpd"/>
    </div>

    <div class="BtnSegment">
        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" ValidationGroup="CreAndUpd"/>
        <asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="btnCreate_Click" Visible="false" ValidationGroup="CreAndUpd"/>
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" Style="margin-left: 10px"/>
    </div>
</asp:Content>
