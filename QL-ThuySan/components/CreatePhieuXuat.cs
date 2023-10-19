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
    public partial class CreatePhieuXuat : UserControl
    {
        private FrRoot root;
        public CreatePhieuXuat(FrRoot root)
        {
            this.root = root;
            InitializeComponent();

            LoadTextBox();
            LoadKho();

            var li = new LICreatePhieuXuat(root, fListHang);
            fListHang.Controls.Add(li);
        }

        private void LoadTextBox()
        {
            AutoCompleteStringCollection autotext = new AutoCompleteStringCollection();

            var ncp = root.getContext().KhachHangs.ToList();

            foreach (var item in ncp)
            {
                autotext.Add(item.ten_kh);

            }
            tKH.AutoCompleteMode = AutoCompleteMode.Suggest;
            tKH.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tKH.AutoCompleteCustomSource = autotext;
        }

        private void LoadKho()
        {
            cKho.Items.Clear();

            var kho = root.getContext().Khoes.ToList();

            foreach (var item in kho)
            {
                cKho.Items.Add(item.ten_kho);
            }
        }

        private void tNCP_TextChanged(object sender, EventArgs e)
        {
            tKH.ForeColor = Color.Black;
        }

        private void AutoCompleteKH()
        {
            var ncp = root.getContext().KhachHangs.Where(e => e.ten_kh.ToLower().Contains(tKH.Text.ToLower())).ToList();

            if (ncp.Count == 0)
            {
                tKH.ForeColor = Color.Red;
                return;
            }

            if (ncp.Count > 1)
            {
                String text = "";
                int Minlen = 9999;
                foreach (var item in ncp)
                {
                    if (item.ten_kh.ToLower().IndexOf(tKH.Text.ToLower()) < Minlen)
                    {
                        text = item.ten_kh;
                        Minlen = item.ten_kh.ToLower().IndexOf(tKH.Text.ToLower());
                    }
                }
                tKH.Text = text;
                return;
            }

            tKH.Text = ncp[0].ten_kh;
        }

        private void tKH_Leave(object sender, EventArgs e)
        {
            AutoCompleteKH();
        }

        private void tKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AutoCompleteKH();
                tKH.SelectionStart = tKH.Text.Length;
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            tKH.SelectionStart = tKH.Text.Length;
            tKH.SelectionLength = 0;
        }

        private int Save()
        {
            if (String.IsNullOrWhiteSpace(tKH.Text) || cKho.SelectedItem == null)
                return -1;

            var kh = root.getContext().KhachHangs.SingleOrDefault(e => e.ten_kh == tKH.Text);
            var kho = root.getContext().Khoes.SingleOrDefault(e => e.ten_kho == cKho.SelectedItem.ToString());

            if (kh == null || kho == null)
                return -1;

            var newPx = new models.PhieuXuat
            {
                Id_kho = kho.Id_kho,
                id_kh = kh.Id_kh,
                ngay_xuat = DateTime.Now,
                da_xuat = false
            };

            foreach (var item in fListHang.Controls)
            {
                LICreatePhieuXuat li = (LICreatePhieuXuat)item;
                if (li.IdTS != -1 && li.soluong > 0)
                    newPx.TTPhieuXuats.Add(li.GetTTPhieuXuat());
            }

            root.getContext().PhieuXuats.Add(newPx);

            root.getContext().SaveChanges();

            return newPx.Id_px;
        }
        private void bSave_Click(object sender, EventArgs ev)
        {
            Save();
            root.GetExportController().ReLoad();
            root.MiniControlClose();
        }

        private void bSaveAndPush_Click(object sender, EventArgs e)
        {
            int Id = Save();
            //root.GetImportController().NhapKho(Id);
        }
    }
}
