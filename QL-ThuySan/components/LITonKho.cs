using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_ThuySan.components
{
    public partial class LITonKho : UserControl
    {
        public string NameTS { set; get; }
        public string At { set; get; }
        public int SL { set; get; }

        public LITonKho()
        {
            InitializeComponent();

            ReRender();
        }

        public void ReRender()
        {
            lNameTS.Text = NameTS;
            lNameKho.Text = At;
            lSoLuong.Text = SL.ToString();
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
