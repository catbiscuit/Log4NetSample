<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomSQLAppend.aspx.cs" Inherits="Log4NetCustomSQL.CustomSQLAppend" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <asp:Button ID="btnAdd" runat="server" Style="width: 200px; height: 100px;" Text="添加Log4Net日志" OnClick="btnAdd_Click" />
        </div>
    </form>
</body>
</html>
