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
    public partial class LICreatePhieuNhap : UserControl
    {
        private FrRoot root;
        private Control ul;

        public int gia;
        public int soluong;
        public int IdTS = -1;
        public string name;
        public LICreatePhieuNhap(FrRoot root, Control ul)
        {
            this.ul = ul;
            this.root = root;
            InitializeComponent();
            ReRender();
        }
        public void loadListThuySan()
        {
            AutoCompleteStringCollection autotext = new AutoCompleteStringCollection();

            var ncp = root.getContext().ThuySans.ToList();

            foreach (var item in ncp)
            {
                autotext.Add(item.ten);
            }
            tName.AutoCompleteMode = AutoCompleteMode.Suggest;
            tName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tName.AutoCompleteCustomSource = autotext;
        }

        public void AutoCompleteTS()
        {
            var ncp = root.getContext().ThuySans.Where(e => e.ten.ToLower().Contains(tName.Text.ToLower())).ToList();

            if (ncp.Count == 0)
            {
                tName.ForeColor = Color.Red;
                return;
            }

            if (ncp.Count > 1)
            {
                string text = "";
                int Minlen = 9999;
                foreach (var item in ncp)
                {
                    if (item.ten.ToLower().IndexOf(tName.Text.ToLower()) < Minlen)
                    {
                        text = item.ten;
                        Minlen = item.ten.ToLower().IndexOf(tName.Text.ToLower());

                    }
                }
                tName.Text = text;
                return;
            }
            tName.Text = ncp[0].ten;
        }
        public void RenderById(int IdTS)
        {
            var ts = root.getContext().ThuySans.Find(IdTS);
            this.IdTS = ts.Id_ts;
            name = ts.ten;
            soluong = 0;
            gia = 0;

            ReRender();
        }

        public void ReRender()
        {
            if (IdTS != -1)
            {
                pAdd.Visible = false;
                lName.Text = name;
                tSoLuong.Text = soluong.ToString();
                tGia.Text = gia.ToString();
            }
            else
            {
                pAdd.Visible = true;
                loadListThuySan();
            }
        }

        private void tName_TextChanged(object sender, EventArgs e)
        {
            tName.ForeColor = Color.Black;
        }

        private void tName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AutoCompleteTS();
            }
        }

        private void tName_Leave(object sender, EventArgs e)
        {
            AutoCompleteTS();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            var ts = root.getContext().ThuySans.SingleOrDefault(i => i.ten == tName.Text);
            if (ts != null)
            {
                foreach (var item in ul.Controls)
                {
                    LICreatePhieuNhap temp = (LICreatePhieuNhap)item;
                    if (temp.name == ts.ten)
                    {
                        MessageBox.Show("Thuy Sản đa tồn tại");
                        return;
                    }
                }
                RenderById(ts.Id_ts);
                var newLi = new LICreatePhieuNhap(root, ul);
                newLi.ReRender();
                ul.Controls.Add(newLi);
                return;
            }
            MessageBox.Show("Thuy Sản không tồn tại");
        }
   
        public TTPhieuNhap GetTTPhieuNhap()
        {
            return new TTPhieuNhap
            { 
                Id_ts = IdTS,
                gia_nhap =gia,
                so_luong = soluong
            };
        }

        private void tSoLuong_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tSoLuong.Text))
                return;
            try
            {
                soluong = int.Parse(tSoLuong.Text);
            }
            catch
            {
                MessageBox.Show("Nhap so");
            }
        }

        private void tGia_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tGia.Text))
                return;
            try
            {
                gia = int.Parse(tGia.Text);          
            }
            catch
            {
                MessageBox.Show("Nhập số");
            }
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            ul.Controls.Remove(this);
        }
    }
}
