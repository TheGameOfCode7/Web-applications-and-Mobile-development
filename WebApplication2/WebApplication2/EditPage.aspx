<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditPage.aspx.cs" Inherits="WebApplication2.EditPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <label runat="server" text="Time stamp" />
        <asp:TextBox runat="server" ID="txtTimeStamp" />
        <asp:RequiredFieldValidator runat="server" ID="reqTimeStamp" ControlToValidate="txtTimeStamp" />
    </div>

    <div>
        <label runat="server" text="Database USer" />
        <asp:TextBox runat="server" ID="txtDatabaseUser" Wrap="true" Rows="10"/>
    </div>

    <div>
        <label runat="server" text="Object" />
        <asp:TextBox runat="server" ID="txtObject" />
    </div>
    <div>
        <label runat="server" text="Event" />
        <asp:TextBox runat="server" ID="txtEvent" />
    </div>

    <div>
        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
    </div>




</asp:Content>
