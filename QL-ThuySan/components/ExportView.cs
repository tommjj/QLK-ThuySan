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
    public partial class ExportView : UserControl
    {
        private FrRoot root;
        private int Id;
        public ExportView(FrRoot root)
        {
            this.root = root;
            InitializeComponent();
        }

        private int SumQuantity(List<models.TTPhieuXuat> item)
        {
            int sum = 0;
            foreach (var i in item)
            {
                sum += i.so_luong;
            }
            return sum;
        }

        private int SumPrice(List<models.TTPhieuXuat> item)
        {
            int sum = 0;
            foreach (var i in item)
            {
                sum += i.so_luong * (int)i.gia_xuat;
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

            var px = root.getContext().PhieuXuats.Find(Id);

            lKho.Text = px.Kho.ten_kho;
            lSoPhieu.Text = Id.ToString();
            lName.Text = px.KhachHang.ten_kh;

            lGia.Text = SumPrice(px.TTPhieuXuats.ToList()).ToString();
            lSoluong.Text = SumQuantity(px.TTPhieuXuats.ToList()).ToString();

            if (px.da_xuat)
            {
                lNgayNhap.Text = px.ngay_xuat.ToString();
                bEdit.Visible = false;
            }
            else
            {
                lNgayNhap.Text = "none";
                bEdit.Visible = true;
            }

            fHang.Controls.Clear();
            foreach (var item in px.TTPhieuXuats)
            {
                LIHangView temp = new LIHangView();
                temp.name = item.ThuySan.ten;
                temp.soluong = item.so_luong;
                temp.gia = item.gia_xuat;

                temp.Render();

                fHang.Controls.Add(temp);
            }
        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            root.SetMiniControl(new EditPhieuXuat(root, Id));
        }

        private void bDelete_Click(object sender, EventArgs ev)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn xoá?", "delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var px = root.getContext().PhieuXuats.Find(Id);
                var ttpx = root.getContext().TTPhieuXuats.Where(e => e.Id_px == Id);
                root.getContext().TTPhieuXuats.RemoveRange(ttpx);
                root.getContext().PhieuXuats.Remove(px);
                root.getContext().SaveChanges();
                root.GetExportController().ReLoad();
            }
        }
    }
}
