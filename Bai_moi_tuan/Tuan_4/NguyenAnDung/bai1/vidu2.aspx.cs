using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bai1
{
    public partial class vidu2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lstKhu_dl.Items.Add("Vịnh Hạ Long");
                lstKhu_dl.Items.Add("Phan Thiết - Mũi Né");
                lstKhu_dl.Items.Add("Nha Trang");
                lstKhu_dl.Items.Add("Đà Lạt");
            }
        }
        protected void BtChon_Click(object sender, EventArgs e)
        {
            LblDia_Diem.Text = "";
            if (lstKhu_dl.SelectedItem.Selected)
                LblDia_Diem.Text = "Bạn đã chọn: " + lstKhu_dl.SelectedValue;
        }
    }
}