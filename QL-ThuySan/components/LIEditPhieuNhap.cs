﻿using System;
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
    public partial class LIEditPhieuNhap : UserControl
    {
        private FrRoot root;
        private Control ul;

        public int gia;
        public int soluong;
        public int Id = -1;
        public int IdTS = -1;
        public string name;
        public bool isChange = false;
        public bool isDelete = false;
        public bool isNew = false;

        public LIEditPhieuNhap(FrRoot root, Control ul,int Id)
        {
            this.ul = ul;
            this.Id = Id;
            this.root = root;
            InitializeComponent();
        }

        public void ReRender()
        {
            if(IdTS != -1)
            {
                pAdd.Visible = false;
                lName.Text = name;
                tSoLuong.Text = soluong.ToString();
                tGia.Text = gia.ToString();
            } else
            {
                pAdd.Visible = true;
                loadListThuySan();
            }
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

        private void tSoLuong_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tSoLuong.Text))
                return;
            try
            {
                soluong = int.Parse(tSoLuong.Text);
                isChange = true;
            } catch
            {
                MessageBox.Show("Nhập số");
            }
        }

        private void tGia_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tGia.Text))
                return;
            try
            {
                gia = int.Parse(tGia.Text);
                isChange = true;
            }
            catch
            {
                MessageBox.Show("Nhập số");
            }
        }

        
        public void Save()
        { 
            if(isDelete)
            {
                var ttn = root.getContext().TTPhieuNhaps.SingleOrDefault(e => e.Id_pn == Id && e.Id_ts == IdTS);

                root.getContext().TTPhieuNhaps.Remove(ttn);
                return;
            }
            if(isNew)
            {
                if (soluong < 1)
                    return;
                var ttn = new models.TTPhieuNhap
                {
                    Id_pn = Id,
                    Id_ts = IdTS,
                    so_luong = soluong,
                    gia_nhap = gia
                };
                root.getContext().TTPhieuNhaps.Add(ttn);
                
                return;
            }

            if(isChange)
            {
                if (soluong < 1)
                    return;
                var ttn = root.getContext().TTPhieuNhaps.SingleOrDefault(e => e.Id_pn == Id && e.Id_ts == IdTS);
                ttn.so_luong = soluong;
                ttn.gia_nhap = gia;
            }
        }

        private void tName_TextChanged(object sender, EventArgs e)
        {
            tName.ForeColor = Color.Black;
        }

        private void tName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
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
            if(ts != null)
            {
                foreach(var item in ul.Controls)
                {
                    LIEditPhieuNhap temp = (LIEditPhieuNhap)item;
                    if (temp.name == ts.ten && temp.isDelete == false)
                    {
                        MessageBox.Show("Thuy Sản đa tồn tại");
                        return;
                    }                    
                }
                RenderById(ts.Id_ts);
                isNew = true;
                var newLi = new LIEditPhieuNhap(root, ul, Id);
                newLi.ReRender();
                ul.Controls.Add(newLi);
                return;
            }
            MessageBox.Show("Thuy Sản không tồn tại");
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            isDelete = true;
        }
    }
}
