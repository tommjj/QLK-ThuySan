using QL_ThuySan.components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_ThuySan.controls
{
    public partial class ExportController : UserControl
    {
        private FrRoot root;

        private ExportView exportView;

        private List<models.PhieuXuat> List;
        public ExportController(FrRoot root)
        {
            this.root = root;
            init();
            InitializeComponent();

            exportView = new ExportView(root);
            exportView.SetId(-1);
            pEditKHControl.Controls.Add(exportView);
        }
        private void init()
        {

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

        public void SetId(int id)
        {
            exportView.SetId(id);
        }

        public void ReLoad()
        {
            SetList();

            RenderList(tSearch.Text);
      
            exportView.SetId(-1);
        }

        private void RenderList()
        {
            int controlsNumber = pUnList.Controls.Count;
            int count = 0;

            foreach (var item in List)
            {
                if (count < controlsNumber)
                {
                    var control = (LIexport)pUnList.Controls[count];

                    control.Id = item.Id_px;
                    control.name = item.KhachHang.ten_kh;
                    control.Gia = SumPrice(item.TTPhieuXuats.ToList());
                    control.trongLuong = SumQuantity(item.TTPhieuXuats.ToList());
                    control.daXuat = item.da_xuat;

                    control.ReRender();
                    count++;
                    continue;
                }
                var temp = new LIexport(this);

                temp.Id = item.Id_px;
                temp.name = item.KhachHang.ten_kh;
                temp.Gia = SumPrice(item.TTPhieuXuats.ToList());
                temp.trongLuong = SumQuantity(item.TTPhieuXuats.ToList());
                temp.daXuat = item.da_xuat;

                temp.ReRender();

                pUnList.Controls.Add(temp);
            }

            while (count < controlsNumber)
            {
                pUnList.Controls.RemoveAt(pUnList.Controls.Count - 1);
                count++;
            }

            ResizeList();
        }

        private void RenderList(string text)
        {
            if (String.IsNullOrWhiteSpace(text))
            {
                RenderList();
                return;
            }

            int controlsNumber = pUnList.Controls.Count;
            int count = 0;

            foreach (var item in List)
            {
                if (item.KhachHang.ten_kh.ToLower().Contains(text.ToLower()) || item.Id_px.ToString().Contains(text))
                {
                    if (count < controlsNumber)
                    {
                        var control = (LIexport)pUnList.Controls[count];

                        control.Id = item.Id_px;
                        control.name = item.KhachHang.ten_kh;
                        control.Gia = SumPrice(item.TTPhieuXuats.ToList());
                        control.trongLuong = SumQuantity(item.TTPhieuXuats.ToList());
                        control.daXuat = item.da_xuat;

                        control.ReRender();
                        count++;
                        continue;
                    }
                    var temp = new LIexport(this);

                    temp.Id = item.Id_px;
                    temp.name = item.KhachHang.ten_kh;
                    temp.Gia = SumPrice(item.TTPhieuXuats.ToList());
                    temp.trongLuong = SumQuantity(item.TTPhieuXuats.ToList());
                    temp.daXuat = item.da_xuat;

                    temp.ReRender();

                    pUnList.Controls.Add(temp);
                }
            }

            while (count < controlsNumber)
            {
                pUnList.Controls.RemoveAt(pUnList.Controls.Count - 1);
                count++;
            }

            ResizeList();
        }
        private void SetList()
        {
            List = root.getContext().PhieuXuats.OrderByDescending(e => e.Id_px).ToList();
        }

        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            ResizeList();
        }

        private void ResizeList()
        {
            foreach (Control item in pUnList.Controls)
            {
                item.Width = pUnList.Width - (pUnList.Controls.Count < ((pUnList.Height - 6) / 81) + 3 ? 10 : 25);
            }
        }

        private void bAddKH_Click(object sender, EventArgs e)
        {
            root.SetMiniControl(new CreatePhieuXuat(root));
        }
    }
}
