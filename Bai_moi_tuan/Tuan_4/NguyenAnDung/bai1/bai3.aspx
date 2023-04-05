<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bai3.aspx.cs" Inherits="bai1.bai3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>bai3</title>
    <style type="text/css">
        .auto-style1 {
            height: 31px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table border="1" cellpadding="0" cellspacing="0">
				<tr>
					<td style="width: 40%">
						<asp:Label ID="Label1" runat="server" Text="Mã NV: " Width="200px"></asp:Label>
					</td>
					<td>
						<asp:TextBox ID="txtMaNV" runat="server" Width="200px"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Label ID="Label2" runat="server" Text="Bậc lương: " Width="200px"></asp:Label>
					</td>
					<td>
						<asp:TextBox ID="txtBacLuong" type="number" runat="server" Width="200px"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Label ID="Label3" runat="server" Text="Ngày công: " Width="200px"></asp:Label>
					</td>
					<td>
						<asp:TextBox ID="txtNgayCong" type="number" runat="server" Width="200px"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Label ID="Label4" runat="server" Text="Chức vụ: " Width="200px"></asp:Label>
					</td>
					<td>
						<asp:DropDownList ID="DdlChucVu" runat="server">
							<asp:ListItem Text="Trưởng phòng" Value="0"></asp:ListItem>
							<asp:ListItem Text="Phó phòng" Value="1"></asp:ListItem>
							<asp:ListItem Text="Nhân viên" Value="2"></asp:ListItem>
						</asp:DropDownList>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Label ID="Label5" runat="server" Text="Giới tính: " Width="200px"></asp:Label>
					</td>
					<td>
						<asp:RadioButtonList ID="RbtlGioiTinh" runat="server" RepeatColumns="2">
							<asp:ListItem  Text="Nam" Value="0"></asp:ListItem>
							<asp:ListItem  Text="Nữ" Value="1"></asp:ListItem>
						</asp:RadioButtonList>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Label ID="Label6" runat="server" Text="Ngoại ngữ: " Width="200px"></asp:Label>
					</td>
					<td>
						<asp:CheckBoxList ID="CblNgoaiNgu" runat="server" RepeatColumns="3">
							<asp:ListItem Text="Anh" Value="0"></asp:ListItem>
							<asp:ListItem Text="Pháp" Value="1"></asp:ListItem>
							<asp:ListItem Text="Nga" Value="2"></asp:ListItem>
						</asp:CheckBoxList>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Label ID="Label7" runat="server" Text="Tiền lĩnh: " Width="200px"></asp:Label>
					</td>
					<td>
						<asp:Label ID="lblTienLinh" runat="server" Text="" Width="200px"></asp:Label>
					</td>
				</tr>
				<tr>
					<td colspan="2" align="center" class="auto-style1">
						<asp:Button ID="BtnTinh" runat="server" Text="TÍNH" OnClick="BtnTinh_Click"/>
						<asp:Button ID="BtnXoa" runat="server" Text="XOÁ" OnClick="BtnXoa_Click"/>
					</td>
				</tr>
			</table>
        </div>
    </form>
</body>
</html>
