<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vidu3.aspx.cs" Inherits="bai1.vidu3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>vidu3</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table border="1" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 30%">
						<asp:Label ID="Label1" runat="server" Text="Thu nhập"></asp:Label>
                    </td>
                    <td>
						<asp:RadioButtonList ID="rblThu_Nhap" runat="server" AutoPostBack="true" RepeatColumns="2" Width="280px" OnSelectedIndexChanged="rblThu_Nhap_SelectedIndexChanged">
                            <asp:ListItem>Dưới 1 triệu</asp:ListItem>
                            <asp:ListItem>1-3 triệu</asp:ListItem>
                            <asp:ListItem>Trên 3 triệu</asp:ListItem>
                            <asp:ListItem>Trên 10 triệu</asp:ListItem>
                            <asp:ListItem>Trên 15 triệu</asp:ListItem>
                            <asp:ListItem>Trên 20 triệu</asp:ListItem>
						</asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center" style="color: orange;">
                        <asp:Label ID="lblThu_Nhap" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
