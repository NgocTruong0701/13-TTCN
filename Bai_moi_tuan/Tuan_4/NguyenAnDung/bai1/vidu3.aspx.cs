using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bai1
{
    public partial class vidu3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rblThu_Nhap_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblThu_Nhap.Text = "Bạn chọn thu nhập: " + rblThu_Nhap.SelectedItem.Text;
        }
    }
}