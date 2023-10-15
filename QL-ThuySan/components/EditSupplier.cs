using QL_ThuySan.form;
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
    public partial class EditSupplier : UserControl
    {
        private FrRoot root;

        private int Id;

        private string SDT;
        private string NameNCP;
        private string Address;
        public EditSupplier(FrRoot root)
        {
            this.root = root;
            InitializeComponent();
        }

        public void SetId(int Id)
        {
            if (Id == -1)
            {
                this.Controls.Clear();
                return;
            }

            if (this.Controls.Count == 0)
            {
                this.Controls.Add(pMain);
            }

            this.Id = Id;

            var ncp = root.getContext().NhaCungCaps.Find(Id);

            NameNCP = ncp.ten_ncp;
            SDT = ncp.sdt;
            Address = ncp.dia_chi;

            Render();
        }

        private void Render()
        {
            tName.Text = NameNCP;
            tSDT.Text = SDT;
            tAddress.Text = Address;
        }

        private void setActiveBt(bool isActive)
        {
            if (isActive)
            {
                bSave.BackColor = Color.FromArgb(255, 79, 70, 229);
                bSave.ForeColor = Color.White;
                return;
            }
            bSave.BackColor = Color.White;
            bSave.ForeColor = Color.Black;
        }

        private void Text_TextChanged(object sender, EventArgs e)
        {
            if (NameNCP != tName.Text || tSDT.Text != SDT || tAddress.Text != Address)
            {
                setActiveBt(true);
                return;
            }
            setActiveBt(false);
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            string newName = tName.Text;
            string newAddress = tAddress.Text;
            string newSDT;

            try
            {
                int.Parse(tSDT.Text);
                newSDT = tSDT.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nhap so");
                return;
            }

            if (String.IsNullOrWhiteSpace(newName))
            {
                MessageBox.Show("Vui long nhap ten");
                return;
            }

            if (String.IsNullOrWhiteSpace(newAddress))
            {
                MessageBox.Show("Vui long nhap dia chi");
                return;
            }

            var ncp = root.getContext().NhaCungCaps.Find(Id);

            ncp.ten_ncp = newName;
            ncp.sdt = newSDT;
            ncp.dia_chi = newAddress;

            root.getContext().SaveChanges();

            root.GetSupplierContrller().ReLoad();
        }

        private void bDeleteDelop_Click(object sender, EventArgs e)
        {
            ConfirmPW formlog = new ConfirmPW();

            if (formlog.ShowDialog(this) == DialogResult.OK)
            {
                var user = root.getContext().accounts.Find(root.getUserId());

                if (user.password.TrimEnd(' ') == formlog.Password)
                {
                    DeleteDelop();
                }
            }
            formlog.Dispose();
        }

        private void DeleteDelop()
        {
            var ncp = root.getContext().NhaCungCaps.Find(Id);

            foreach (var item in ncp.PhieuNhaps)
            {
                root.getContext().TTPhieuNhaps.RemoveRange(item.TTPhieuNhaps);
            }

            root.getContext().PhieuNhaps.RemoveRange(ncp.PhieuNhaps);

            root.getContext().NhaCungCaps.Remove(ncp);

            root.getContext().SaveChanges();

            root.GetSupplierContrller().ReLoad();
        }
    }
}
