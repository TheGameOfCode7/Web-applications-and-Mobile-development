<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LaughOrCry.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="align-content: center; text-align:center">
    <form id="form1" runat="server" stylr="display: inline-block">
        <div>
            <asp:Image ID="Image" runat="server" Height="447px" Width="640px" ImageUrl="~/Image/Laughing and Crying.png" style="margin-left: 0px" />
            <br />
            <p>
                <asp:Literal ID="StatusLtr" runat="server" Text="Laughing Or Crying"></asp:Literal>
            </p>
            <br />
            <asp:Button ID="btnTry" runat="server" Text="Try again" OnClick="btnTry_Click" />
            <br />
            <p>
                <asp:Literal ID="ResultLrt" runat="server" Text="0 Laughing / 0 Crying"></asp:Literal>
            </p>
            <br />
            <asp:Label ID="LblLaughResult" style="margin-right:20px" runat="server" Text="Laughing result" ></asp:Label>
            <asp:Label ID="LblCryingResult" style="margin-left:20px" runat="server" Text="Crying result"></asp:Label>
            <p>
                <asp:ListBox ID="LbLaughing" runat="server"> <asp:ListItem>** Laughing list **</asp:ListItem></asp:ListBox>
                <asp:ListBox ID="LbCrying" runat="server"><asp:ListItem>** Crying list **</asp:ListItem></asp:ListBox>
            </p>
        </div>

    </form>
</body>
</html>
