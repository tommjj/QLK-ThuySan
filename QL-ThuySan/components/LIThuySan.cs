using QL_ThuySan.controls;
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
    public partial class LIThuySan : UserControl
    {
        private GoodsController goodsController;

        public string NameTS { get; set; }

        public decimal Gia { get; set; }

        public int Id { get; set; }
        public LIThuySan(GoodsController goodsController)
        {
            this.goodsController = goodsController;
            InitializeComponent(); 
        }

        public void ReRender()
        {
            lNameTS.Text = NameTS;
            lGia.Text = ((int)Gia).ToString();
            lId.Text = "id: " + Id.ToString();
        }

        private void ClickEv(object sender, EventArgs e)
        {
            goodsController.getEditThuySan().SetId(Id);
        }
    }
}
