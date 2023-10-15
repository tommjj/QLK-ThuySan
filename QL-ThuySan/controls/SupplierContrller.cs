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
    public partial class SupplierContrller : UserControl
    {
        private FrRoot root;

        private EditSupplier editSupplier;
        private List<models.NhaCungCap> List;
        public SupplierContrller(FrRoot root)
        {
            this.root = root;
            InitializeComponent();

            editSupplier = new EditSupplier(root);
            editSupplier.SetId(-1);
            pEditKHControl.Controls.Add(editSupplier);
        }

        public EditSupplier GetEditSupplier()
        {
            return editSupplier;
        }

        public void ReLoad()
        {
            SetList();
            RenderList(tSearch.Text);
            editSupplier.SetId(-1);
        }

        private void RenderList()
        {
            int controlsNumber = pUnList.Controls.Count;
            int count = 0;

            foreach (var item in List)
            {
                if(count < controlsNumber)
                {
                    var control = (LISupplier)pUnList.Controls[count];
                    control.Id = item.Id_ncp;
                    control.NameNCP = item.ten_ncp;
                    control.At = item.dia_chi;
                    control.SDT = item.sdt;
                    control.ReRender();
                    count++;
                    continue;
                }
                var temp = new LISupplier(this)
                {
                    Id = item.Id_ncp,
                    NameNCP = item.ten_ncp,
                    At = item.dia_chi,
                    SDT = item.sdt
                };
                
                temp.ReRender();

                pUnList.Controls.Add(temp);
            }

            while(count < controlsNumber)
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
                if (item.ten_ncp.ToLower().Contains(text.ToLower()))
                {
                    if (count < controlsNumber)
                    {
                        var control = (LISupplier)pUnList.Controls[count];
                        control.Id = item.Id_ncp;
                        control.NameNCP = item.ten_ncp;
                        control.At = item.dia_chi;
                        control.SDT = item.sdt;
                        control.ReRender();
                        count++;
                        continue;
                    }
                    var temp = new LISupplier(this)
                    {
                        Id = item.Id_ncp,
                        NameNCP = item.ten_ncp,
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
            List = root.getContext().NhaCungCaps.ToList();
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
            root.SetMiniControl(new CreateSupplier(root));
        }
    }
}
