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
    public partial class LICustomer : UserControl
    {
        private CustomerController customerController;

        public int Id;
        public string NameKH { set; get; }
        public string At { set; get; }
        public string SDT { set; get; }
        public LICustomer(CustomerController customerController)
        {
            this.customerController = customerController;
            InitializeComponent();
        }

        public void ReRender()
        {
            lNameKH.Text = NameKH;
            lAddress.Text = At;
            lSDT.Text = SDT;
        }

        private void ClickEv(object sender, EventArgs e)
        {
            customerController.GetEditCustomer().SetId(Id);
        }
    }
}
