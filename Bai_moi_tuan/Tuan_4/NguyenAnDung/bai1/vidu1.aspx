<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vidu1.aspx.cs" Inherits="bai1.vidu1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>vidu1</title>
    <style type="text/css">
        .auto-style1 {
            width: 50%;
            border-style: solid;
            border-width: 1px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table style="width: 500px;" border="1" cellpadding="0" cellspacing="0" class="auto-style1">
                <tr>
                    <td style="width: 40%;">
                        <asp:Label ID="Label1" Width="100" runat="server" Text="Nhập số A:"></asp:Label>
                    </td>
                    <td style="width: 60%;">
                        <asp:TextBox ID="txtsoA" Width="200" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" Width="100" runat="server" Text="Nhập số B:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtsoB" Width="200" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" Width="100" runat="server" Text="Tổng: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTong" Width="200" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <asp:Button ID="btnTong" runat="server" Text="Tính tổng" OnClick="btnTong_Click"  />
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
