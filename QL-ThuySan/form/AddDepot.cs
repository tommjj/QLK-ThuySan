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

namespace QL_ThuySan.form
{
    public partial class AddDepot : Form
    {
        private FrRoot root;
        public AddDepot(FrRoot root)
        {
            this.root = root;
            InitializeComponent();
        }

        private void bCreate_Click(object sender, EventArgs e)
        {
            string delopName = tName.Text;

            if (String.IsNullOrWhiteSpace(delopName))
                return;
            if (root.getContext().Khoes.SingleOrDefault(k => k.ten_kho == delopName) != null)
                return;

            try
            {
                var newDelop = new Kho
                {
                    ten_kho = delopName,
                };

                root.getContext().Khoes.Add(newDelop);

                root.getContext().SaveChanges();

                root.GetDepotController().ReLoad();
                this.Close();
            } catch (Exception ex)
            {

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
