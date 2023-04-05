using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bai1
{
    public partial class bai2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnTinh_Click(object sender, EventArgs e)
        {
            double tieuthu = double.Parse(txtCSM.Text) - double.Parse(txtCSC.Text);
            double ketqua = 0;
            if (tieuthu > 200)
            {
                ketqua = 100 * 2000 + 50 * 2500 + 50 * 2800 + (tieuthu - 200) * 3500;
            }
            else if (tieuthu > 150)
            {
                ketqua = 100 * 2000 + 50 * 2500 + (tieuthu - 150) * 2800;
            }
            else if (tieuthu > 100)
            {
                ketqua = 100 * 2000 + (tieuthu - 100) * 2500;
            }
            else if (tieuthu <= 100 && tieuthu > 0)
            {
                ketqua = tieuthu * 2000;
            }
            txtKetQua.Text = ketqua.ToString();
        }
    }
}