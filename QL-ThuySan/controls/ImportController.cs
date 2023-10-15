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
    public partial class ImportController : UserControl
    {
        private FrRoot root;
        private ImportView importView;

        private List<models.PhieuNhap> List;
        public ImportController(FrRoot root)
        {
            this.root = root;
            InitializeComponent();
            importView = new ImportView(root);
            importView.SetId(-1);
            pEditKHControl.Controls.Add(importView);
        }

        public void SetId(int Id)
        {
            importView.SetId(Id);
        }

        public void ReLoad()
        {
            SetList();

            RenderList(tSearch.Text);

            importView.SetId(-1);
        }

        private int sumWidth(List<models.TTPhieuNhap> item)
        {
            int sum = 0;
            foreach(var i in item)
            {
                sum += i.so_luong;
            }
            return sum;
        } 

        private int sumGia(List<models.TTPhieuNhap> item)
        {
            int sum = 0;
            foreach (var i in item)
            {
                sum += i.so_luong * (int)i.gia_nhap;
            }
            return sum;
        }

        private void RenderList()
        {
            int controlsNumber = pUnList.Controls.Count;
            int count = 0;

            foreach (var item in List)
            {
                if (count < controlsNumber)
                {
                    var control = (LIImport)pUnList.Controls[count];

                    control.Id = item.Id_pn;
                    control.name = item.NhaCungCap.ten_ncp;
                    control.Gia = sumGia(item.TTPhieuNhaps.ToList());
                    control.trongLuong = sumWidth(item.TTPhieuNhaps.ToList());
                    control.daThem = item.da_nhap;

                    control.ReRender();
                    count++;
                    continue;
                }
                var temp = new LIImport(this);

                temp.Id = item.Id_pn;
                temp.name = item.NhaCungCap.ten_ncp;
                temp.Gia = sumGia(item.TTPhieuNhaps.ToList());
                temp.trongLuong = sumWidth(item.TTPhieuNhaps.ToList());
                temp.daThem = item.da_nhap;

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
                if (item.NhaCungCap.ten_ncp.ToLower().Contains(text.ToLower()))
                {
                    if (count < controlsNumber)
                    {
                        var control = (LIImport)pUnList.Controls[count];

                        control.Id = item.Id_pn;
                        control.name = item.NhaCungCap.ten_ncp;
                        control.Gia = sumGia(item.TTPhieuNhaps.ToList());
                        control.trongLuong = sumWidth(item.TTPhieuNhaps.ToList());
                        control.daThem = item.da_nhap;

                        control.ReRender();
                        count++;
                        continue;
                    }
                    var temp = new LIImport(this);

                    temp.Id = item.Id_pn;
                    temp.name = item.NhaCungCap.ten_ncp;
                    temp.Gia = sumGia(item.TTPhieuNhaps.ToList());
                    temp.trongLuong = sumWidth(item.TTPhieuNhaps.ToList());
                    temp.daThem = item.da_nhap;


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
            List = root.getContext().PhieuNhaps.ToList();
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

    }
}
