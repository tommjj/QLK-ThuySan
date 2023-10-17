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
    public partial class CreatePhieuNhap : UserControl
    {
        private FrRoot root;
        public CreatePhieuNhap(FrRoot root)
        {
            this.root = root;
            InitializeComponent();

            LoadTextBox();
            LoadKho();

            var li = new LICreatePhieuNhap(root, fListHang);
            fListHang.Controls.Add(li);
        }

        private void LoadTextBox()
        {
            AutoCompleteStringCollection autotext = new AutoCompleteStringCollection();

            var ncp = root.getContext().NhaCungCaps.ToList();

            foreach (var item in ncp)
            {
                autotext.Add(item.ten_ncp);

            }
            tNCP.AutoCompleteMode = AutoCompleteMode.Suggest;
            tNCP.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tNCP.AutoCompleteCustomSource = autotext;
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
            tNCP.ForeColor = Color.Black;
        }

        private void AutoCompleteTNCP()
        {
            var ncp = root.getContext().NhaCungCaps.Where(e => e.ten_ncp.ToLower().Contains(tNCP.Text.ToLower())).ToList();

            if (ncp.Count == 0)
            {
                tNCP.ForeColor = Color.Red;
                return;
            }

            if (ncp.Count > 1)
            {
                String text = "";
                int Minlen = 9999;
                foreach (var item in ncp)
                {
                    if (item.ten_ncp.ToLower().IndexOf(tNCP.Text.ToLower()) < Minlen)
                    {
                        text = item.ten_ncp;
                        Minlen = item.ten_ncp.ToLower().IndexOf(tNCP.Text.ToLower());
                    }
                }
                tNCP.Text = text;
                return;
            }

            tNCP.Text = ncp[0].ten_ncp;
        }

        private void tNCP_Leave(object sender, EventArgs e)
        {
            AutoCompleteTNCP();
        }

        private void tNCP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AutoCompleteTNCP();
                tNCP.SelectionStart = tNCP.Text.Length;
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            tNCP.SelectionStart = tNCP.Text.Length;
            tNCP.SelectionLength = 0;
        }

        private void bSave_Click(object sender, EventArgs ev)
        {
            if (String.IsNullOrWhiteSpace(tNCP.Text) || cKho.SelectedItem == null)
                return;

            var ncp = root.getContext().NhaCungCaps.SingleOrDefault(e => e.ten_ncp == tNCP.Text);
            var kho = root.getContext().Khoes.SingleOrDefault(e => e.ten_kho == cKho.SelectedItem.ToString());

            if (ncp == null || kho == null)
                return;

            var newPn = new models.PhieuNhap
            {
                id_kho = kho.Id_kho,
                id_ncp = ncp.Id_ncp,
                ngay_nhap = DateTime.Now,
                da_nhap = false
            };

            foreach (var item in fListHang.Controls)
            {
                LICreatePhieuNhap li = (LICreatePhieuNhap)item;
                if(li.IdTS != -1)
                    newPn.TTPhieuNhaps.Add(li.GetTTPhieuNhap());
            }

            root.getContext().PhieuNhaps.Add(newPn);

            root.getContext().SaveChanges();

            root.GetImportController().ReLoad();
            root.MiniControlClose();
        }
    }
}
