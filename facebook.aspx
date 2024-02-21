<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="facebook.aspx.cs" Inherits="jadawelAdmin.facebook" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="send" OnClick="Button1_Click" style="width: 42px" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        <br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="delete" />
        <br />
        <br />
    </div>
    </form>
</body>
</html>
