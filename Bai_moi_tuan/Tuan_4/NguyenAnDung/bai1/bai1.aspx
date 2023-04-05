<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bai1.aspx.cs" Inherits="bai1.bai1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>bai1</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table border="1" cellpadding="0" cellspacing="0">
				<tr>
					<td style="width: 40%">
						<asp:Label ID="Label1" runat="server" Text="Nhập hệ số A: " Width="200px"></asp:Label>
					</td>
					<td>
						<asp:TextBox ID="txtSoA" type="number" runat="server" Width="200px"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Label ID="Label2" runat="server" Text="Nhập hệ số B: " Width="200px"></asp:Label>
					</td>
					<td>
						<asp:TextBox ID="txtSoB" type="number" runat="server" Width="200px"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Label ID="Label3" runat="server" Text="Nhập hệ số C: " Width="200px"></asp:Label>
					</td>
					<td>
						<asp:TextBox ID="txtSoC" type="number" runat="server" Width="200px"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Label ID="Label4" runat="server" Text="Kết quả: " Width="200px"></asp:Label>
					</td>
					<td>
						<asp:TextBox ID="txtKetQua" runat="server" Width="200px" ReadOnly></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td colspan="2" align="center">
						<asp:Button ID="BtnGiai" runat="server" Text="Giải" OnClick="BtnGiai_Click"/>
					</td>
				</tr>
			</table>
        </div>
    </form>
</body>
</html>
