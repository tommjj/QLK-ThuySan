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
    public partial class EditPhieuNhap : UserControl 
    {
        private FrRoot root;
        private int Id;
        public EditPhieuNhap(FrRoot root, int Id)
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

            var ncp = root.getContext().NhaCungCaps.ToList();

            foreach(var item in ncp)
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

            foreach(var item in kho)
            {
                cKho.Items.Add(item.ten_kho);
            }
        }

        private void ReLoad()
        {
            LoadKho();

            var pn =  root.getContext().PhieuNhaps.Find(Id);

            tNCP.Text = pn.NhaCungCap.ten_ncp;
            lId.Text = pn.Id_pn.ToString();

            for(int i = 0; i < cKho.Items.Count; i++)
            {
                if(cKho.Items[i].ToString() == pn.Kho.ten_kho)
                {
                    cKho.SelectedIndex = i;
                    break;
                }
            } 

            foreach(var item in pn.TTPhieuNhaps)
            {
                LIEditPhieuNhap li = new LIEditPhieuNhap(root, fListHang, Id)
                {
                    IdTS = item.Id_ts,
                    name = item.ThuySan.ten,
                    gia = (int)item.gia_nhap,
                    soluong = item.so_luong
                };
                li.ReRender();
                fListHang.Controls.Add(li);
            }
            AddNewLI();
        }

        public void AddNewLI()
        {
            LIEditPhieuNhap li = new LIEditPhieuNhap(root, fListHang, Id);
            li.ReRender();
            fListHang.Controls.Add(li);
        }

        private void bThem_Click(object sender, EventArgs e)
        {

        }

        public Control GetULitem()
        {
            return fListHang;
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

        private void tNCP_Leave(object sender, EventArgs ev)
        {
            AutoCompleteTNCP();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            tNCP.SelectionStart = tNCP.Text.Length;
            tNCP.SelectionLength = 0;
        }

        private void tNCP_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                AutoCompleteTNCP();
                tNCP.SelectionStart = tNCP.Text.Length;

            }
        }

        private void bSave_Click(object sender, EventArgs ev)
        {
            var ncp = root.getContext().NhaCungCaps.SingleOrDefault(e => e.ten_ncp == tNCP.Text);
            var kho = root.getContext().Khoes.SingleOrDefault(e => e.ten_kho == cKho.SelectedItem.ToString());

            if (ncp == null || kho == null)
                return;

            var pn = root.getContext().PhieuNhaps.Find(Id);

            pn.id_ncp = ncp.Id_ncp;
            pn.id_kho = kho.Id_kho;

            foreach (var item in fListHang.Controls)
            {
                LIEditPhieuNhap li = (LIEditPhieuNhap)item;
                li.Save();
            }

            root.getContext().SaveChanges();
            root.GetImportController().ReLoad();
            root.MiniControlClose();
        }
    }
}
