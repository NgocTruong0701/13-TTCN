using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bai1
{
    public partial class vidu1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTong_Click(object sender, EventArgs e)
        {
            int so1, so2, tong;
            so1 = Int32.Parse(txtsoA.Text);
            so2 = Int32.Parse(txtsoB.Text);
            tong = so1 + so2;
            txtTong.Text = tong.ToString();

        }
    }
}