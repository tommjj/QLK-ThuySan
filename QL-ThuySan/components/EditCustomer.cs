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
    public partial class EditCustomer : UserControl
    {
        private FrRoot root;

        private int Id;

        private string SDT;
        private string NameKH;
        private string Address;
        public EditCustomer(FrRoot root)
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

            var kh = root.getContext().KhachHangs.Find(Id);

            NameKH = kh.ten_kh;
            SDT = kh.sdt;
            Address = kh.dia_chi;

            Render();
        }

        private void Render()
        {
            tName.Text = NameKH;
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
            if (NameKH != tName.Text || tSDT.Text != SDT || tAddress.Text != Address)
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

            var kh = root.getContext().KhachHangs.Find(Id);

            kh.ten_kh = newName;
            kh.sdt = newSDT;
            kh.dia_chi = newAddress;

            root.getContext().SaveChanges();

            root.GetCustomerController().ReLoad();
        }

        private void bDeleteDelop_Click(object sender, EventArgs e)
        {
            ConfirmPW formlog = new ConfirmPW();

            if (formlog.ShowDialog(this) == DialogResult.OK)
            {
                var user = root.getContext().accounts.Find(root.getUserId());

                if (user.password.TrimEnd(' ') == formlog.Password)
                {
                    DeleteDelop(Id);

                }
            }
            formlog.Dispose();
        }

        private void DeleteDelop(int id)
        {
            var kh = root.getContext().KhachHangs.Find(Id);

            foreach(var item in kh.PhieuXuats)
            {
                root.getContext().TTPhieuXuats.RemoveRange(item.TTPhieuXuats);
            }

            root.getContext().PhieuXuats.RemoveRange(kh.PhieuXuats);

            root.getContext().KhachHangs.Remove(kh);

            root.getContext().SaveChanges();

            root.GetCustomerController().ReLoad();
        }
    }
}
