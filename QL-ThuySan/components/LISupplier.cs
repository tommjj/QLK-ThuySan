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
    public partial class LISupplier : UserControl
    {
        private SupplierContrller supplierContrller;

        public int Id;
        public string NameNCP { set; get; }
        public string At { set; get; }
        public string SDT { set; get; }
        public LISupplier(SupplierContrller supplierContrller)
        {
            this.supplierContrller = supplierContrller;
            InitializeComponent();
        }

        public void ReRender()
        {
            lNameKH.Text = NameNCP;
            lAddress.Text = At;
            lSDT.Text = SDT;
        }

        private void ClickEv(object sender, EventArgs e)
        {
            supplierContrller.GetEditSupplier().SetId(Id);
        }


    }
}
