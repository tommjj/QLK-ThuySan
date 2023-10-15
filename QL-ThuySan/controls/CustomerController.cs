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
    public partial class CustomerController : UserControl
    {
        private FrRoot root;
        private EditCustomer editCustomer;

        private List<models.KhachHang> List;
        public CustomerController(FrRoot root)
        {
            this.root = root;
            InitializeComponent();
            Init();
            Setup();
        }

        private void Init()
        {
            editCustomer = new EditCustomer(root);
        }

        private void Setup()
        {
            pEditKHControl.Controls.Add(editCustomer);
            editCustomer.SetId(-1);
        }

        public EditCustomer GetEditCustomer()
        {
            return editCustomer;
        }

        public void ReLoad()
        {
            SetList();
            RenderList(tSearch.Text);
            editCustomer.SetId(-1);
        }

        private void RenderList()
        {
            int controlsNumber = pUnList.Controls.Count;
            int count = 0;

            foreach (var item in List)
            {
                if (count < controlsNumber)
                {
                    var control = (LICustomer)pUnList.Controls[count];
                    control.Id = item.Id_kh;
                    control.NameKH = item.ten_kh;
                    control.At = item.dia_chi;
                    control.SDT = item.sdt;

                    control.ReRender();
                    count++;
                    continue;
                }

                var temp = new LICustomer(this)
                {
                    Id = item.Id_kh,
                    NameKH = item.ten_kh,
                    At  = item.dia_chi,
                    SDT = item.sdt
                };

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
                if (item.ten_kh.ToLower().Contains(text.ToLower()))
                {
                    if (count < controlsNumber)
                    {
                        var control = (LICustomer)pUnList.Controls[count];
                        control.Id = item.Id_kh;
                        control.NameKH = item.ten_kh;
                        control.At = item.dia_chi;
                        control.SDT = item.sdt;

                        control.ReRender();
                        count++;
                        continue;
                    }

                    var temp = new LICustomer(this)
                    {
                        Id = item.Id_kh,
                        NameKH = item.ten_kh,
                        At = item.dia_chi,
                        SDT = item.sdt
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
        private void SetList()
        {
            List = root.getContext().KhachHangs.ToList();
        }
        //rerize
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
            root.SetMiniControl(new CreateCustomer(root));
        }
    }
}
