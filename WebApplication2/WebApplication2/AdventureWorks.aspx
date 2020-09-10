 <%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdventureWorks.aspx.cs" Inherits="WebApplication2.AdventureWorks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Databse logs</h3>

    <asp:Label ID="Lbl1" runat="server" Text="Hello user" />
    <br /><br />

    <asp:GridView ID="Gv1" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
        AutoGenerateColumns="false" DataKeyNames="DatabaseLogID" EmptyDataText="There are no data records to display"
        PageSize="10" AllowPaging="true" OnPageIndexChanging="Gv1_OnPageIndexChanging"
        PagerSettings-Position="TopAndBottom" PagerSettings-Mode="NumericFirstLast"
        OnRowUpdating="Gv1_RowUpdating"       
        OnRowCancelingEdit="Gv1_RowCancelingEdit"
        OnRowEditing="Gv1_RowEditing" OnRowDeleting="Gv1_RowDeleting">

        <Columns>
            <asp:BoundField DataField="DatabaseLogID" HeaderText="ID" SortExpression="DatabaseLogID" ReadOnly="true"/>
            <asp:BoundField DataField="PostTime" HeaderText="Post Time" SortExpression="PostTime"/>
            <asp:BoundField DataField="DatabaseUser" HeaderText="Database User" SortExpression="DatabaseUser"/>
            <asp:BoundField DataField="Object" HeaderText="Object" SortExpression="Object"/>
            <asp:BoundField DataField="Event" HeaderText="Event" SortExpression="Event" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg"/>
            <asp:CommandField ShowEditButton="True"/>
            <asp:CommandField ShowDeleteButton="True"/>

            <asp:HyperLinkField DataNavigateUrlFields="DatabaseLogID" DataNavigateUrlFormatString="~/EditPage?logid={0}" Text="Edit" />
        </Columns>
    </asp:GridView>

</asp:Content>
