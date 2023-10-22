using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace QL_ThuySan.components
{
    public partial class ViewImport : UserControl
    {
        private FrRoot root;
        private int Id;

        public ViewImport(FrRoot root)
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
                bEdit.Visible = false;
            } else
            {
                lNgayNhap.Text = "none";
                bEdit.Visible = true;
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

        private void bEdit_Click(object sender, EventArgs e)
        {
            root.SetMiniControl(new EditPhieuNhap(root, Id));
        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog1 = new PrintPreviewDialog();
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.Show();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            var pn = root.getContext().PhieuNhaps.Find(Id);

            Font font14 = new Font("Segoe UI", 14, FontStyle.Regular);

            e.Graphics.DrawString("PHIẾU NHẬP KHO", new Font("Segoe UI", 26, FontStyle.Bold), Brushes.Black, new Point(265, 80));
            e.Graphics.DrawString("Số: " + pn.Id_pn.ToString(), new Font("Segoe UI", 14, FontStyle.Regular), Brushes.Black, new Point(377, 125));

            e.Graphics.DrawString("Tên nhà cung cấp: " + pn.NhaCungCap.ten_ncp, new Font("Segoe UI", 16, FontStyle.Regular), Brushes.Black, new Point(50, 175));
            e.Graphics.DrawString("Ngày nhập: " + (pn.da_nhap ? pn.ngay_nhap.ToString() : "chưa nhập"), new Font("Segoe UI", 16, FontStyle.Regular), Brushes.Black, new Point(50, 208));
            e.Graphics.DrawString("Nhập tại kho: " + pn.Kho.ten_kho, new Font("Segoe UI", 16, FontStyle.Regular), Brushes.Black, new Point(50, 241));

            e.Graphics.DrawLine(new Pen(Brushes.Black),50, 275, 800, 275);
            e.Graphics.DrawLine(new Pen(Brushes.Black), 50, 275, 50, 305);
            e.Graphics.DrawLine(new Pen(Brushes.Black), 100, 275, 100, 305);
            e.Graphics.DrawLine(new Pen(Brushes.Black), 800, 275, 800, 305);
            e.Graphics.DrawLine(new Pen(Brushes.Black), 680, 275, 680, 305);
            e.Graphics.DrawLine(new Pen(Brushes.Black), 560, 275, 560, 305);
            e.Graphics.DrawLine(new Pen(Brushes.Black), 440, 275, 440, 305);

            e.Graphics.DrawString("STT" , font14, Brushes.Black, new Point(55, 277));
            e.Graphics.DrawString("Tên thuỷ sản", font14, Brushes.Black, new Point(105, 277));
            e.Graphics.DrawString("Số lượng", font14, Brushes.Black, new Point(445, 277));
            e.Graphics.DrawString("Đơn giá", font14, Brushes.Black, new Point(565, 277));
            e.Graphics.DrawString("Thành tiền", font14, Brushes.Black, new Point(685, 277));

            int sum = 0;
            int count = 0;
            foreach (var item in pn.TTPhieuNhaps)
            {
                e.Graphics.DrawLine(new Pen(Brushes.Black), 50, 305 + (30 * count), 50, 335 + (30 * count));
                e.Graphics.DrawLine(new Pen(Brushes.Black), 100, 305 + (30 * count), 100, 335 + (30 * count));
                e.Graphics.DrawLine(new Pen(Brushes.Black), 800, 305 + (30 * count), 800, 335 + (30 * count));
                e.Graphics.DrawLine(new Pen(Brushes.Black), 680, 305 + (30 * count), 680, 335 + (30 * count));
                e.Graphics.DrawLine(new Pen(Brushes.Black), 560, 305 + (30 * count), 560, 335 + (30 * count));
                e.Graphics.DrawLine(new Pen(Brushes.Black), 440, 305 + (30 * count), 440, 335 + (30 * count));
                e.Graphics.DrawLine(new Pen(Brushes.Black), 50 , 305 + (30 * count), 800, 305 + (30 * count));

                e.Graphics.DrawString((count+1).ToString(), font14, Brushes.Black, new Point(55, 307 + (30 * count)));
                e.Graphics.DrawString(item.ThuySan.ten, font14, Brushes.Black, new Point(105, 307 + (30 * count)));
                e.Graphics.DrawString(item.so_luong.ToString(), font14, Brushes.Black, new Point(445, 307 + (30 * count)));
                e.Graphics.DrawString(((int)(item.gia_nhap)).ToString(), font14, Brushes.Black, new Point(565, 307 + (30 * count)));
                e.Graphics.DrawString(((int)(item.so_luong * item.gia_nhap)).ToString(), font14, Brushes.Black, new Point(685, 307 + (30 * count)));

                sum += (int)(item.so_luong * item.gia_nhap);
                count++;
            }
            e.Graphics.DrawLine(new Pen(Brushes.Black), 50, 305 + (30 * count), 50, 335 + (30 * count));         
            e.Graphics.DrawLine(new Pen(Brushes.Black), 680, 305 + (30 * count), 680, 335 + (30 * count));
            e.Graphics.DrawLine(new Pen(Brushes.Black), 50, 305 + (30 * count), 800, 305 + (30 * count));
            e.Graphics.DrawLine(new Pen(Brushes.Black), 50, 335 + (30 * count), 800, 335 + (30 * count));
            e.Graphics.DrawLine(new Pen(Brushes.Black), 800, 305 + (30 * count), 800, 335 + (30 * count));

            e.Graphics.DrawString("Tổng giá", font14, Brushes.Black, new Point(55, 307 + (30 * count)));
            e.Graphics.DrawString(sum.ToString(), font14, Brushes.Black, new Point(685, 307 + (30 * count)));

            e.Graphics.DrawString("Nhà cung cấp", new Font("Segoe UI", 16, FontStyle.Regular), Brushes.Black, new Point(60, 350 + (30 * count)));
            e.Graphics.DrawString("Bên nhận hàng", new Font("Segoe UI", 16, FontStyle.Regular), Brushes.Black, new Point(620, 350 + (30 * count)));
        }
    }
}
