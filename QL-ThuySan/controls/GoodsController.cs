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
    public partial class GoodsController : UserControl
    {
        private FrRoot root;

        private EditThuySan editThuySan;

        private List<models.ThuySan> List = new List<models.ThuySan>();
        public GoodsController(FrRoot root)
        {
            this.root = root;
            InitializeComponent();
            Init();          
        }

        public EditThuySan getEditThuySan()
        {
            return editThuySan;
        }

        private void Init()
        {
            editThuySan = new EditThuySan(root);

            editThuySan.SetId(-1);

            pEditTSControl.Controls.Add(editThuySan);

            cbSort.SelectedIndex = 0;
        }  

        private void SetList()
        {
            List = root.getContext().ThuySans.ToList();     
        }

        private void RenderList()
        {
            int controlsNumber = pUnList.Controls.Count;
            int count = 0;

            foreach (var item in List)
            {
                if (count < controlsNumber)
                {
                    var control = (LIThuySan)pUnList.Controls[count];
                    control.NameTS = item.ten;
                    control.Gia = item.gia_ban;
                    control.Id = item.Id_ts;

                    control.ReRender();
                    count++;
                    continue;
                }

                var temp = new LIThuySan(this) {
                    NameTS = item.ten,
                    Gia = item.gia_ban,
                    Id = item.Id_ts                    
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

        private void RenderList(string str)
        {
            if(String.IsNullOrWhiteSpace(str))
            {
                RenderList();
                return;
            }

            int controlsNumber = pUnList.Controls.Count;
            int count = 0;

            foreach (var item in List)
            {
                if(item.ten.ToLower().Contains(str.ToLower()))
                {
                    if (count < controlsNumber)
                    {
                        var control = (LIThuySan)pUnList.Controls[count];
                        control.NameTS = item.ten;
                        control.Gia = item.gia_ban;
                        control.Id = item.Id_ts;

                        control.ReRender();
                        count++;
                        continue;
                    }

                    var temp = new LIThuySan(this)
                    {
                        NameTS = item.ten,
                        Gia = item.gia_ban,
                        Id = item.Id_ts
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


        public void ReLoad()
        {
            SetList();
            SortList();

            RenderList(tSearch.Text);
            editThuySan.SetId(-1);        
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
                item.Width = pUnList.Width - (pUnList.Controls.Count < ((pUnList.Height-6) / 74)+3 ? 10 : 25);
            }
        }

        private void tSearch_TextChanged(object sender, EventArgs e)
        {
            RenderList(tSearch.Text);
        }

        private void bAddTS_Click(object sender, EventArgs e)
        {
            root.SetMiniControl(new CreateThuySan(root));
        }

        private void SortList()
        {
            if (List == null)
                return;

            switch (cbSort.SelectedIndex)
            {
                case 0:
                    List = List.OrderByDescending(e => e.Id_ts).ToList();
                    break;
                case 1:
                    List = List.OrderBy(e => e.Id_ts).ToList();
                    break;
                case 2:
                    List = List.OrderBy(e => e.ten).ToList();
                    break;
                case 3:
                    List = List.OrderByDescending(e => e.ten).ToList();
                    break;
            }
        }

        private void cbSort_SelectedIndexChanged(object sender, EventArgs ev)
        {
            SortList();
            RenderList(tSearch.Text);
        }
    }
}
