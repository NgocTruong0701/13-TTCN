using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bai1
{
    public partial class bai3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnTinh_Click(object sender, EventArgs e)
        {
            int tienlinh = 0;
            int bacluong = int.Parse(txtBacLuong.Text);
            int ngaycong = int.Parse(txtNgayCong.Text);
            if (ngaycong < 25)
            {
                tienlinh += bacluong * 650000 * ngaycong;
            }
            else
            {
                tienlinh += bacluong * 650000 * ((ngaycong - 25) * 2 + 25);
            }
            if (DdlChucVu.SelectedValue == "0")
            {
                tienlinh += 500000;
            }
            else if (DdlChucVu.SelectedValue == "1")
            {
                tienlinh += 300000;
            }
            else if (DdlChucVu.SelectedValue == "2")
            {
                tienlinh += 100000;
            }
            lblTienLinh.Text = tienlinh.ToString();
        }

        protected void BtnXoa_Click(object sender, EventArgs e)
        {
            txtMaNV.Text = "";
            txtBacLuong.Text = "";
            txtNgayCong.Text = "";
            DdlChucVu.SelectedIndex = 0;
            RbtlGioiTinh.SelectedIndex = -1;
            CblNgoaiNgu.SelectedIndex = -1;
            lblTienLinh.Text = "";
            txtMaNV.Focus();
        }
    }
}