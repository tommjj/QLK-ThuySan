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
    public partial class ImportView : UserControl
    {
        private FrRoot root;
        private int Id;

        public ImportView(FrRoot root)
        {
            this.root = root;
            InitializeComponent();
        }

        private int SumQuantity(List<models.TTPhieuNhap> item)
        {
            int sum = 0;
            foreach (var i in item)
            {
                sum += i.so_luong;
            }
            return sum;
        }

        private int SumPrice(List<models.TTPhieuNhap> item)
        {
            int sum = 0;
            foreach (var i in item)
            {
                sum += i.so_luong * (int)i.gia_nhap;
            }
            return sum;
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

            var pn = root.getContext().PhieuNhaps.Find(Id);

            lKho.Text = pn.Kho.ten_kho;
            lSoPhieu.Text = Id.ToString();
            lName.Text = pn.NhaCungCap.ten_ncp;

            lGia.Text = SumPrice(pn.TTPhieuNhaps.ToList()).ToString();
            lSoluong.Text = SumQuantity(pn.TTPhieuNhaps.ToList()).ToString();

            if(pn.da_nhap)
            {
                lNgayNhap.Text = pn.ngay_nhap.ToString();
            } else
            {
                lNgayNhap.Text = "none";
            }

            fHang.Controls.Clear();
            foreach(var item in pn.TTPhieuNhaps)
            {
                LIHangView temp = new LIHangView();
                temp.name = item.ThuySan.ten;
                temp.soluong = item.so_luong;
                temp.gia = item.gia_nhap;

                temp.Render();

                fHang.Controls.Add(temp);
            }
        }

        public void Render()
        {
           
        }

        private void bDelete_Click(object sender, EventArgs ev)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn xoá?", "delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var pn = root.getContext().PhieuNhaps.Find(Id);
                var ttpn = root.getContext().TTPhieuNhaps.Where(e => e.Id_pn == Id);
                root.getContext().TTPhieuNhaps.RemoveRange(ttpn);
                root.getContext().PhieuNhaps.Remove(pn);
                root.getContext().SaveChanges();
                root.GetImportController().ReLoad();
            }            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            root.SetMiniControl(new EditPhieuNhap(root, Id));
        }
    }
}
