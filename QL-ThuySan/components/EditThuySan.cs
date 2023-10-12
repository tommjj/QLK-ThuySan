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
    public partial class EditThuySan : UserControl
    {
        private FrRoot root;

        private int Id;

        private decimal Gia;

        private String NameTS;
        public EditThuySan(FrRoot root)
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

            var ts = root.getContext().ThuySans.Find(Id);

            NameTS = ts.ten;
            Gia = ts.gia_ban;
            Render();
        }

        private void Render()
        {
            tName.Text = NameTS;
            tGia.Text = ((int)Gia).ToString();
        }

        private void Text_TextChanged(object sender, EventArgs e)
        {
            if (NameTS != tName.Text || tGia.Text != ((int)Gia).ToString())
            {
                setActiveBt(true);
                return;
            }
            setActiveBt(false);
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

        private void bSave_Click(object sender, EventArgs e)
        {
            string newName = tName.Text;
            decimal newGia = 0;

            try
            {
                newGia = decimal.Parse(tGia.Text);
            } catch (Exception ex)
            {
                MessageBox.Show("Nhap so");
            }

            if(String.IsNullOrWhiteSpace(newName))
            {
                MessageBox.Show("Vui long nhap ten");
                return;
            }

            var ts = root.getContext().ThuySans.Find(Id);
            ts.gia_ban = newGia;
            ts.ten = newName;
            root.getContext().SaveChanges();

            root.GetGoodsController().ReLoad();
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
            var ts = root.getContext().ThuySans.Find(id);          

            var pn = root.getContext().PhieuNhaps.Where(e => e.TTPhieuNhaps.Any(a => a.Id_ts == id));

            var px = root.getContext().PhieuXuats.Where(e => e.TTPhieuXuats.Any(a => a.Id_ts == id));

            var tk = root.getContext().TonKhoes.Where(e => e.id_ts == id);

            foreach (var item in pn)
            {
                root.getContext().TTPhieuNhaps.RemoveRange(item.TTPhieuNhaps);
            }

            foreach (var item in px)
            {
                root.getContext().TTPhieuXuats.RemoveRange(item.TTPhieuXuats);
            }

            root.getContext().TonKhoes.RemoveRange(tk);
            root.getContext().PhieuNhaps.RemoveRange(pn);
            root.getContext().PhieuXuats.RemoveRange(px);

            root.getContext().ThuySans.Remove(ts);

            root.getContext().SaveChanges();
            
            root.GetGoodsController().ReLoad();
        }
    }
}
