using QL_ThuySan.components;
using QL_ThuySan.form;
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
    public partial class DepotController : UserControl
    {
        private FrRoot root;
        private List<models.TonKho> List;
        private EditDelop editDelop;

        public DepotController(FrRoot root)
        {
            this.root = root;
            InitializeComponent();

            init();
            Setup();
        }

        private void init()
        {
            editDelop = new EditDelop(root);

            editDelop.SetId(-1);

            pEditDelop.Controls.Add(editDelop);
        }

        private void Setup()
        {
            ReLoad();
        }

        public void ReLoad()
        {
            LoadCbKho();
            ReRander(TSearch.Text);
            LoadTongTonKho();
        }

        public void LoadTongTonKho()
        {
            int sum = 0;
            foreach(var item in List)
            {
              sum += item.so_luong;
            }
            lTongTonKho.Text = sum.ToString();
        }

        private void LoadCbKho()
        {
            var kho = root.getContext().Khoes.ToList();

            cbKho.Items.Clear();
            cbKho.Items.Add("All");

            cbKho.SelectedIndex = 0; 

            foreach (var item in kho)
            {
                cbKho.Items.Add(item.ten_kho);
            }
        }
        
        private void ReRander()
        {
            int controlsNumber = pUnList.Controls.Count;
            int count = 0;

            foreach (var item in List)
            {
                if (count < controlsNumber)
                {
                    var control = (LITonKho)pUnList.Controls[count];
                    control.NameTS = item.ThuySan.ten;
                    control.At = item.Kho.ten_kho;
                    control.SL = item.so_luong;
                    
                   control.ReRender();
                    count++;
                    continue;
                }
                LITonKho temp = new LITonKho
                {
                    NameTS = item.ThuySan.ten,
                    At = item.Kho.ten_kho,
                    SL = item.so_luong
                };
                temp.ReRender();
                pUnList.Controls.Add(temp);
            }

            while (count < controlsNumber)
            {
                pUnList.Controls.RemoveAt(pUnList.Controls.Count-1);
                count++;
            }

            ResizeList();
        }

        public void ReRander(string str)
        {     
            if(String.IsNullOrWhiteSpace(str))
            {
                ReRander();
                return;
            }
            int controlsNumber = pUnList.Controls.Count;
            int count = 0;

            foreach (var item in List)
            {
                if(item.ThuySan.ten.ToLower().Contains(str.ToLower()))
                {
                    if (count < controlsNumber)
                    {
                        var control = (LITonKho)pUnList.Controls[count];
                        control.NameTS = item.ThuySan.ten;
                        control.At = item.Kho.ten_kho;
                        control.SL = item.so_luong;

                        control.ReRender();
                        count++;
                        continue;
                    }
                    LITonKho temp = new LITonKho
                    {
                        NameTS = item.ThuySan.ten,
                        At = item.Kho.ten_kho,
                        SL = item.so_luong
                    };
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

        private void LoadList()
        {         
            if (cbKho.SelectedItem.ToString() == "All")
            {   
                List = root.getContext().TonKhoes.ToList();

                ReRander(TSearch.Text);
                LoadTongTonKho();

                editDelop.SetId(-1);        
                return;
            }
            var kho = root.getContext().Khoes.SingleOrDefault(s => s.ten_kho == cbKho.SelectedItem.ToString());       

            List  = root.getContext().TonKhoes.Where(e => e.Id_kho == kho.Id_kho).ToList();

            editDelop.SetId(kho.Id_kho);

            ReRander(TSearch.Text);
            LoadTongTonKho();
        }

        

        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);

            ResizeList();
        }

        private void ResizeList()
        {
            foreach(Control item in pUnList.Controls)
            {
                item.Width = pUnList.Width - (pUnList.Controls.Count < ((pUnList.Height - 6) / 80) + 3 ? 10 : 25);
            }
        }

        private void cbKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadList();
        }

        private void TSearch_TextChanged(object sender, EventArgs e)
        {
            ReRander(TSearch.Text);
        }

        private void bAddDepot_Click(object sender, EventArgs e)
        {
            AddDepot addDepotForm = new AddDepot(root);

            addDepotForm.ShowDialog(this);
            addDepotForm.Dispose();
        }
    }
}
