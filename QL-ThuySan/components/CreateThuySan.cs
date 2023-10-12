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
    public partial class CreateThuySan : UserControl
    {
        private FrRoot root;
        public CreateThuySan(FrRoot root)
        {
            this.root = root;
            InitializeComponent();
        }

        private void bCreate_Click(object sender, EventArgs e)
        {
            string NameTs = tName.Text;
            decimal Price = 0;

            try
            {
                Price = decimal.Parse(tPrice.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nhap so");
            }

            if (String.IsNullOrWhiteSpace(NameTs))
            {
                MessageBox.Show("Vui long nhap ten");
                return;
            }

            var newTs = new ThuySan
            {
                ten = NameTs,
                gia_ban = Price
            };

            root.getContext().ThuySans.Add(newTs);
            root.getContext().SaveChanges();
            root.GetGoodsController().ReLoad();
            root.MiniControlClose();
        }
    }
}
