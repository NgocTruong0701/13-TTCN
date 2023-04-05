using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bai1
{
    public partial class bai1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnGiai_Click(object sender, EventArgs e)
        {
            double a = double.Parse(txtSoA.Text);
            double b = double.Parse(txtSoB.Text);
            double c = double.Parse(txtSoC.Text);
            if (a == 0)
            {
                if (b == 0)
                {
                    if (c == 0)
                    {
                        txtKetQua.Text = "Phương trình có vô số nghiệm";
                    }
                    else
                    {
                        txtKetQua.Text = "Phương trình vô nghiệm";
                    }
                }
                else
                {
                    if (c == 0)
                    {
                        txtKetQua.Text = "x = 0";
                    }
                    else
                    {
                        txtKetQua.Text = "x = " + (-c / b).ToString();
                    }
                }
            }
            else
            {
                double delta = b * b - 4 * a * c;
                if (delta > 0)
                {
                    double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                    double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                    txtKetQua.Text = "x1 = " + x1.ToString() + "; x2 = " + x2.ToString();
                }
                else if (delta == 0)
                {
                    double x = -b / (2 * a);
                    txtKetQua.Text = "x1 = x2 = " + x.ToString();
                }
                else
                {
                    txtKetQua.Text = "Phương trình vô nghiệm";
                }
            }
        }
    }
}