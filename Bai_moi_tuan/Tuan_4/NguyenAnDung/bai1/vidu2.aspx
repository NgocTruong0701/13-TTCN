<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vidu2.aspx.cs" Inherits="bai1.vidu2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>vidu2</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table border="1" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 40%">
						<asp:Label ID="Label1" runat="server" Text="Khu du lịch"></asp:Label>
                    </td>
                    <td>
						<asp:ListBox ID="lstKhu_dl" SelectionMode="Multiple" Rows="4" Width="250px" runat="server"></asp:ListBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
						<asp:Button ID="BtChon" runat="server" Text="Chọn địa điểm" OnClick="BtChon_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center" style="color: red;">
                        <asp:Label ID="LblDia_Diem" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
