using QL_ThuySan.models;
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
    public partial class CreateSupplier : UserControl
    {
        private FrRoot root;
        public CreateSupplier(FrRoot root)
        {
            this.root = root;
            InitializeComponent();
        }

        private void bCreate_Click(object sender, EventArgs e)
        {
            string NameNCP = tName.Text;
            string Address = tAddress.Text;
            string SDT;

            try
            {
                int.Parse(tSDT.Text);
                SDT = tSDT.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nhap so");
                return;
            }

            if (String.IsNullOrWhiteSpace(NameNCP))
            {
                MessageBox.Show("Vui long nhap ten");
                return;
            }

            if (String.IsNullOrWhiteSpace(Address))
            {
                MessageBox.Show("Vui long dia chi");
                return;
            }

            var newKH = new NhaCungCap
            {
                ten_ncp = NameNCP,
                dia_chi = Address,
                sdt = SDT
            };

            root.getContext().NhaCungCaps.Add(newKH);
            root.getContext().SaveChanges();
            root.GetSupplierContrller().ReLoad();
            root.MiniControlClose();
        }
    }
}
