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

        private int SumQuantity(List<models.TTPhieuNhap> item)
        {
            int sum = 0;
            foreach(var i in item)
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
                    control.Gia = SumPrice(item.TTPhieuNhaps.ToList());
                    control.trongLuong = SumQuantity(item.TTPhieuNhaps.ToList());
                    control.daThem = item.da_nhap;

                    control.ReRender();
                    count++;
                    continue;
                }
                var temp = new LIImport(this);

                temp.Id = item.Id_pn;
                temp.name = item.NhaCungCap.ten_ncp;
                temp.Gia = SumPrice(item.TTPhieuNhaps.ToList());
                temp.trongLuong = SumQuantity(item.TTPhieuNhaps.ToList());
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
                if (item.NhaCungCap.ten_ncp.ToLower().Contains(text.ToLower()) || item.Id_pn.ToString().Contains(text))
                {
                    if (count < controlsNumber)
                    {
                        var control = (LIImport)pUnList.Controls[count];

                        control.Id = item.Id_pn;
                        control.name = item.NhaCungCap.ten_ncp;
                        control.Gia = SumPrice(item.TTPhieuNhaps.ToList());
                        control.trongLuong = SumQuantity(item.TTPhieuNhaps.ToList());
                        control.daThem = item.da_nhap;

                        control.ReRender();
                        count++;
                        continue;
                    }
                    var temp = new LIImport(this);

                    temp.Id = item.Id_pn;
                    temp.name = item.NhaCungCap.ten_ncp;
                    temp.Gia = SumPrice(item.TTPhieuNhaps.ToList());
                    temp.trongLuong = SumQuantity(item.TTPhieuNhaps.ToList());
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
            List = root.getContext().PhieuNhaps.OrderByDescending(e => e.Id_pn).ToList();
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

        private void tSearch_TextChanged(object sender, EventArgs e)
        {
            RenderList(tSearch.Text);
        }

        private void bAddKH_Click(object sender, EventArgs e)
        {
            root.SetMiniControl(new CreatePhieuNhap(root));
        }
    }
}
