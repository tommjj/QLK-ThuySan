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
    public partial class EditPhieuXuat : UserControl
    {
        private FrRoot root;
        private int Id;
        public EditPhieuXuat(FrRoot root, int Id)
        {
            this.root = root;
            this.Id = Id;
            InitializeComponent();

            ReLoad();
            LoadTextBox();
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

        private void AutoCompleteTNCP()
        {
            var kh = root.getContext().KhachHangs.Where(e => e.ten_kh.ToLower().Contains(tKH.Text.ToLower())).ToList();

            if (kh.Count == 0)
            {
                tKH.ForeColor = Color.Red;
                return;
            }

            if (kh.Count > 1)
            {
                String text = "";
                int Minlen = 9999;
                foreach (var item in kh)
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

            tKH.Text = kh[0].ten_kh;
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

        private void ReLoad()
        {
            LoadKho();

            var px = root.getContext().PhieuXuats.Find(Id);

            tKH.Text = px.KhachHang.ten_kh;
            lId.Text = px.Id_px.ToString();

            for (int i = 0; i < cKho.Items.Count; i++)
            {
                if (cKho.Items[i].ToString() == px.Kho.ten_kho)
                {
                    cKho.SelectedIndex = i;
                    break;
                }
            }

            foreach (var item in px.TTPhieuXuats)
            {
                LIEditPhieuXuat li = new LIEditPhieuXuat(root, fListHang, Id)
                {
                    IdTS = item.Id_ts,
                    name = item.ThuySan.ten,
                    gia = (int)item.gia_xuat,
                    soluong = item.so_luong
                };
                li.ReRender();
                fListHang.Controls.Add(li);
            }
            AddNewLI();
        }
        public void AddNewLI()
        {
            LIEditPhieuXuat li = new LIEditPhieuXuat(root, fListHang, Id);
            li.ReRender();
            fListHang.Controls.Add(li);
        }

        private void tKH_TextChanged(object sender, EventArgs e)
        {
            tKH.ForeColor = Color.Black;
        }

        private void bSave_Click(object sender, EventArgs ev)
        {
            var kh = root.getContext().KhachHangs.SingleOrDefault(e => e.ten_kh == tKH.Text);
            var kho = root.getContext().Khoes.SingleOrDefault(e => e.ten_kho == cKho.SelectedItem.ToString());

            if (kh == null || kho == null)
                return;

            var px = root.getContext().PhieuXuats.Find(Id);

            px.id_kh = kh.Id_kh;
            px.Id_kho = kho.Id_kho;

            foreach (var item in fListHang.Controls)
            {
                LIEditPhieuXuat li = (LIEditPhieuXuat)item;
                li.Save();
            }

            root.getContext().SaveChanges();
            root.GetExportController().ReLoad();
            root.MiniControlClose();
        }

        private void tKH_Leave(object sender, EventArgs e)
        {
            AutoCompleteTNCP();
        }

        private void tKH_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                AutoCompleteTNCP();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            tKH.SelectionStart = tKH.Text.Length;
            tKH.SelectionLength = 0;
        }
    }
}
