<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication6.Default" MasterPageFile="~/Site1.Master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
            Hello world<br />
            
            <asp:Label ID="lblFornamn" runat="server" Text="Förnamn:"></asp:Label>
                <asp:TextBox ID="txtFirstName" runat="server" MaxLength="50"></asp:TextBox>
            <asp:Button ID="btnSubmit" runat="server" Text="Skicka" OnClick="btnSubmit_Click" />
            <asp:Literal ID="ltrUtdata" runat="server"></asp:Literal>
            <br />
            <br />

            <asp:FileUpload ID="fileUpload1" runat="server" />
            <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />

<%--    <asp:GridView ID="gvPeople" runat="server">
    </asp:GridView>--%>
<%--    <asp:DropDownList ID="ddlPeople" runat="server">
    </asp:DropDownList>--%>
    <asp:ListBox ID="lbPeople" runat="server" AutoPostBack="true"></asp:ListBox>
    <br />
    <br />
    <asp:Literal ID="ltrMessage" runat="server"></asp:Literal>
</asp:Content>