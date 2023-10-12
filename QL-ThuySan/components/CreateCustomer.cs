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
    public partial class CreateCustomer : UserControl
    {
        private FrRoot root;
        public CreateCustomer(FrRoot root)
        {
            this.root = root;
            InitializeComponent();
        }

        private void bCreate_Click(object sender, EventArgs e)
        {
            string NameKH = tName.Text;
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

            if (String.IsNullOrWhiteSpace(NameKH))
            {
                MessageBox.Show("Vui long nhap ten");
                return;
            }

            if (String.IsNullOrWhiteSpace(Address))
            {
                MessageBox.Show("Vui long dia chi");
                return;
            }

            var newKH = new KhachHang
            {
                ten_kh = NameKH,
                dia_chi = Address,
                sdt = SDT
            };

            root.getContext().KhachHangs.Add(newKH);
            root.getContext().SaveChanges();
            root.GetCustomerController().ReLoad();
            root.MiniControlClose();
        }
    }
}
