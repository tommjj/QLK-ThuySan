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

        private ViewExport exportView;

        private List<models.PhieuXuat> List;

        private int PageSize = 30;

        private int PageNumber;

        private bool isSeachMode = false;
        public ExportController(FrRoot root)
        {
            this.root = root;
            init();
            InitializeComponent();

            exportView = new ViewExport(root);
            exportView.SetId(-1); 
            pEditKHControl.Controls.Add(exportView);
        }
        private void init()
        {

        }
        public bool xuatKho(int id)
        {
            var px = root.getContext().PhieuXuats.Find(id);
            if (px == null)
                return false;
            if (px.da_xuat)
                return false;

            var ttpx = px.TTPhieuXuats.ToList();

            foreach (var item in ttpx)
            {
                var tonkho = root.getContext().TonKhoes.SingleOrDefault(e => e.id_ts == item.Id_ts && e.Id_kho == px.Id_kho);
                if (tonkho == null)
                {
                    root.Rollback();
                    throw new Exception("khong du hang");
                }
                if(tonkho.so_luong - item.so_luong < 0)
                {
                    root.Rollback();
                    throw new Exception("khong du hang");
                }
                if(tonkho.so_luong - item.so_luong == 0)
                {
                    root.getContext().TonKhoes.Remove(tonkho);
                    continue;
                }
                tonkho.so_luong -= item.so_luong;
            }

            px.ngay_xuat = DateTime.Now;
            px.da_xuat = true;

            try
            {
                root.getContext().SaveChanges();
            } catch(Exception ex)
            {
                root.Rollback();
            }
            return true;
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
        private void SetPageNumber()
        {
            if(isSeachMode)
            {
                PageNumber = (int)(((double)root.getContext().PhieuXuats.Where(e => e.id_kh.ToString().Contains(tSearch.Text) || e.KhachHang.ten_kh.ToLower().Contains(tSearch.Text.ToLower())).Count() / PageSize) + 0.999999);
                return;
            }
            PageNumber = (int)(((double)root.getContext().PhieuXuats.Count() / PageSize) + 0.999999);
        }

        public void ReLoad()
        {
            SetPageNumber();
            SetList(1);

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
        private void SetList(int pageIndex)
        {
            if(isSeachMode)
            {
                tPage.Text = pageIndex.ToString();
                List = root.getContext().PhieuXuats.Where(e => e.id_kh.ToString().Contains(tSearch.Text) || e.KhachHang.ten_kh.ToLower().Contains(tSearch.Text.ToLower())).OrderByDescending(e => e.Id_px).Skip((pageIndex - 1) * PageSize).Take(PageSize).ToList();
                return;
            }
            tPage.Text = pageIndex.ToString();
            List = root.getContext().PhieuXuats.OrderByDescending(e => e.Id_px).Skip((pageIndex - 1) * PageSize).Take(PageSize).ToList();
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

        private void bNextPage_Click(object sender, EventArgs e)
        {
            int Nextpage = (int.Parse(tPage.Text) + 1);
            if (!(Nextpage <= PageNumber))
                return;

            SetList(Nextpage);
            RenderList();
        }

        private void bPrevPage_Click(object sender, EventArgs e)
        {
            int Prevpage = (int.Parse(tPage.Text) - 1);
            if (Prevpage == 0)
                return;

            SetList(Prevpage);
            RenderList();
        }

        private void bRemoveSearch_Click(object sender, EventArgs e)
        {
            isSeachMode = false;
            bRemoveSearch.Visible = false;
            tSearch.Text = "";

            SetPageNumber();
            SetList(1);

            RenderList();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tSearch.Text))
            {
                isSeachMode = false;
                bRemoveSearch.Visible = false;
                tSearch.Text = "";

                SetPageNumber();
                SetList(1);

                RenderList();
                return;
            }
                
            isSeachMode = true;
            bRemoveSearch.Visible = true;

            SetPageNumber();
            SetList(1);
            
            RenderList();
        }
    }
}
