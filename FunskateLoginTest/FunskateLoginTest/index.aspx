<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="FunskateLoginTest.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="main.css" rel="stylesheet" />
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>CPR-Nummer</h1>
            <asp:TextBox ID="CPR" runat="server"></asp:TextBox>
            <h1>Password</h1>
            <asp:TextBox ID="pPassword" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="loginknap" runat="server" OnClick="loginknap_Click" Text="Login"/>
            <br />
            <asp:Label ID="test" runat="server"></asp:Label>
            <br />
            <asp:Label ID="test2" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
