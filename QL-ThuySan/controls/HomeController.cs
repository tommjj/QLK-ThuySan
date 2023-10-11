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
    public partial class HomeController : UserControl
    {
        private FrRoot root;
        private List<models.TonKho> List;
        private EditDelop editDelop;

        public HomeController(FrRoot root)
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
            pUnList.Controls.Clear();

            foreach (var item in List)
            {
                LITonKho temp = new LITonKho
                {
                    NameTS = item.ThuySan.ten,
                    At = item.Kho.ten_kho,
                    SL = item.so_luong
                };
                temp.ReRander();
                pUnList.Controls.Add(temp);
            }

            ResizeList();
        }

        private void ReRander(string str)
        {
            if(String.IsNullOrWhiteSpace(str))
            {
                ReRander();
                return;
            }
            pUnList.Controls.Clear();

            foreach (var item in List)
            {
                if(item.ThuySan.ten.ToLower().Contains(str.ToLower()))
                {
                    LITonKho temp = new LITonKho
                    {
                        NameTS = item.ThuySan.ten,
                        At = item.Kho.ten_kho,
                        SL = item.so_luong
                    };
                    temp.ReRander();
                    pUnList.Controls.Add(temp);
                }   
            }

            ResizeList();
        }

        private void LoadList()
        {         
            if (cbKho.SelectedItem.ToString() == "All")
            {   
                List = root.getContext().TonKhoes.ToList();

                ReRander(TSearch.Text);

                editDelop.SetId(-1);
                return;
            }
            var kho = root.getContext().Khoes.SingleOrDefault(s => s.ten_kho == cbKho.SelectedItem.ToString());       

            List  = root.getContext().TonKhoes.Where(e => e.Id_kho == kho.Id_kho).ToList();

            editDelop.SetId(kho.Id_kho);

            ReRander(TSearch.Text);
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
                item.Width = pUnList.Width - 10;
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
