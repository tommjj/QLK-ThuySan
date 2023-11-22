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
        private ViewImport importView;

        private List<models.PhieuNhap> List;

        private int PageSize = 30;
        private int PageNumber;

        private bool isSeachMode = false;

        public ImportController(FrRoot root)
        {
            this.root = root;
            InitializeComponent();
            importView = new ViewImport(root);
            importView.SetId(-1);
            pEditKHControl.Controls.Add(importView);
        }

        public void SetId(int Id)
        {
            importView.SetId(Id);
        }

        public void ReLoad()
        {
            SetPageNumber();
            SetList(1);

            RenderList(tSearch.Text);

            importView.SetId(-1);
        }

        public bool NhapKho(int id)
        {
            var pn = root.getContext().PhieuNhaps.Find(id);
            if (pn == null)
                return false;
            if (pn.da_nhap)
                return false;
            pn.ngay_nhap = DateTime.Now;
            pn.da_nhap = true;

            var ttpn = pn.TTPhieuNhaps.ToList();

            foreach(var item in ttpn)
            {
                var tonkho = root.getContext().TonKhoes.SingleOrDefault(e => e.id_ts == item.Id_ts && e.Id_kho == pn.id_kho);
                if(tonkho == null)
                {
                    var newTK = new models.TonKho { 
                        id_ts = item.Id_ts,
                        Id_kho = pn.id_kho,
                        so_luong = item.so_luong
                    };
                    root.getContext().TonKhoes.Add(newTK);

                    continue;
                }
                tonkho.so_luong += item.so_luong;
            }
            try
            {
                root.getContext().SaveChanges();
                return true;
            } catch (Exception ex)
            {
                root.Rollback();
                return false;
            }
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
            pUnList.VerticalScroll.Value = 0;

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
        private void SetPageNumber()
        {
            if (isSeachMode)
            {
                PageNumber = (int)(((double)root.getContext().PhieuNhaps.Where(e => e.Id_pn.ToString().Contains(tSearch.Text) || e.NhaCungCap.ten_ncp.ToLower().Contains(tSearch.Text.ToLower())).Count() / PageSize) + 0.999999);
                return;
            }
            PageNumber = (int)(((double)root.getContext().PhieuNhaps.Count() / PageSize) +0.999999);
        }
        private void SetList(int pageIndex)
        {
            if (isSeachMode)
            {
                tPage.Text = pageIndex.ToString();
                List = root.getContext().PhieuNhaps.Where(e => e.Id_pn.ToString().Contains(tSearch.Text) || e.NhaCungCap.ten_ncp.ToLower().Contains(tSearch.Text.ToLower())).OrderByDescending(e => e.Id_pn                
                ).Skip((pageIndex - 1) * PageSize).Take(PageSize).ToList();
                return;
            }
            tPage.Text = pageIndex.ToString();
            List = root.getContext().PhieuNhaps.OrderByDescending(e => e.Id_pn).Skip((pageIndex-1)* PageSize).Take(PageSize).ToList();
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
            root.SetMiniControl(new CreatePhieuNhap(root));
        }

        private void Search(object sender, EventArgs e)
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
    }
}
