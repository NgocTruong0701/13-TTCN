<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bai2.aspx.cs" Inherits="bai1.bai2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>bai2</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table border="1" cellpadding="0" cellspacing="0">
				<tr>
					<td style="width: 40%">
						<asp:Label ID="Label1" runat="server" Text="Nhập chỉ số điện cũ: " Width="200px"></asp:Label>
					</td>
					<td>
						<asp:TextBox ID="txtCSC" type="number" runat="server" Width="200px"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Label ID="Label2" runat="server" Text="Nhập chỉ số điện mới: " Width="200px"></asp:Label>
					</td>
					<td>
						<asp:TextBox ID="txtCSM" type="number" runat="server" Width="200px"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Label ID="Label3" runat="server" Text="Kết quả: " Width="200px"></asp:Label>
					</td>
					<td>
						<asp:TextBox ID="txtKetQua" runat="server" Width="200px" ReadOnly></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td colspan="2" align="center">
						<asp:Button ID="BtnTinh" runat="server" Text="Tính" OnClick="BtnTinh_Click"/>
					</td>
				</tr>
			</table>
        </div>
    </form>
</body>
</html>
