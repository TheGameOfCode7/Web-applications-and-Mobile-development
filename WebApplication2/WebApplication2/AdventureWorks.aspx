 <%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdventureWorks.aspx.cs" Inherits="WebApplication2.AdventureWorks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Databse logs</h3>

    <asp:Label ID="Lbl1" runat="server"/>
    <br /><br />

    <asp:GridView ID="Gv1" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
        AutoGenerateColumns="false" DataKeyNames="DatabaseLogID" EmptyDataText="There are no data records to display"
        PageSize="10" AllowPaging="true" OnPageIndexChanging="Gv1_OnPageIndexChanging"
        PagerSettings-Position="Top" PagerSettings-Mode="NumericFirstLast"
        OnRowUpdating="Gv1_RowUpdating"       
        OnRowCancelingEdit="Gv1_RowCancelingEdit"
        OnRowEditing="Gv1_RowEditing" OnRowDeleting="Gv1_RowDeleting"
        ShowFooter="true" OnRowCommand="Gv1_RowCommand">

        <Columns>
            
            <asp:BoundField DataField="DatabaseLogID" HeaderText="ID" SortExpression="DatabaseLogID" ReadOnly="true"/><%--<asp:BoundField DataField="PostTime" HeaderText="Post Time" SortExpression="PostTime"/>--%>

            <asp:TemplateField HeaderText="Post Time">
                <ItemTemplate>
                    <asp:Label ID="lblPostTime" runat="server" Text='<%#Bind("PostTime")%>'/>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtPostTime" runat="server" Text='<%#Bind("PostTime")%>' ReadOnly="true"/>
                     <asp:requiredfieldvalidator ID="reqPostTime" runat="server" ControlToValidate="txtPostTime" ErrorMessage="(Required)" ValidationGroup="UpdateValidation"/>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Database User">
                <ItemTemplate>
                    <asp:Label ID="lblDbUser" runat="server" Text='<%#Bind("DatabaseUser")%>'/>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtDbUser" runat="server" Text='<%#Bind("DatabaseUser")%>'/>
                    <asp:requiredfieldvalidator ID="reqDbUser" runat="server" ControlToValidate="txtDbUser" ErrorMessage="(Required)" ValidationGroup="UpdateValidation"/>
                </EditItemTemplate>

                <FooterTemplate>
                    <asp:TextBox ID="txtNewDbUser" runat="server"/>
                    <asp:requiredfieldvalidator ID="reqNewDbUser" runat="server" ControlToValidate="txtNewDbUser" ErrorMessage="(Required)" ValidationGroup="InsertValidation"/>
                </FooterTemplate>

            </asp:TemplateField>

            <asp:TemplateField HeaderText="Object">
                <ItemTemplate>
                    <asp:Label ID="lblObject" runat="server" Text='<%#Bind("Object")%>'/>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtObject" runat="server" Text='<%#Bind("Object")%>'/>
                </EditItemTemplate>

                <FooterTemplate>
                    <asp:TextBox ID="txtNewObject" runat="server"/>
                </FooterTemplate>

            </asp:TemplateField>

            <asp:TemplateField HeaderText="Event">
                <ItemTemplate>
                    <asp:Label ID="lblEvent" runat="server" Text='<%#Bind("Event")%>'/>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEvent" runat="server" Text='<%#Bind("Event")%>'/>
                    <asp:requiredfieldvalidator ID="reqEvent" runat="server" ControlToValidate="txtEvent" ErrorMessage="(Required)" ValidationGroup="UpdateValidation"/>
                </EditItemTemplate>

                <FooterTemplate>
                    <asp:TextBox ID="txtNewEvent" runat="server"/>
                    <asp:requiredfieldvalidator ID="reqNewEvent" runat="server" ControlToValidate="txtNewEvent" ErrorMessage="(Required)" ValidationGroup="InsertValidation"/>
                </FooterTemplate>

            </asp:TemplateField>

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkButton" runat="server" Text="Edit" CommandName="Edit"></asp:LinkButton>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:LinkButton ID="lnkUpdate" runat="server" Text="Update" CommandName="Update" ValidationGroup="UpdateValidation"/>
                    <asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="false"/>
                </EditItemTemplate>

                <FooterTemplate>
                    <asp:LinkButton ID="lnkInsert" runat="server" Text="Insert" CommandName="Insert"  ValidationGroup="InsertValidation"/>
                </FooterTemplate>

            </asp:TemplateField>
            
            <asp:CommandField ShowDeleteButton="True"/>

            <asp:HyperLinkField DataNavigateUrlFields="DatabaseLogID" DataNavigateUrlFormatString="~/EditPage?logid={0}" Text="Edit Page" />
        </Columns>
    </asp:GridView>

</asp:Content>
