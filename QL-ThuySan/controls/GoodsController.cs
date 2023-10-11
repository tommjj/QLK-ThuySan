﻿using QL_ThuySan.components;
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

        private List<models.ThuySan> List;
        public GoodsController(FrRoot root)
        {
            this.root = root;
            InitializeComponent();
            SetList();
            RenderList();
        }

        private void SetList()
        {
            List = root.getContext().ThuySans.ToList();
        }

        private void RenderList(string str)
        {
            if(String.IsNullOrWhiteSpace(str))
            {
                RenderList();
                return;
            }

            pUnList.Controls.Clear();

            foreach (var item in List)
            {
                if(item.ten.ToLower().Contains(str.ToLower()))
                {
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

            ResizeList();
        }

        private void RenderList()
        {
            pUnList.Controls.Clear();

            foreach(var item in List)
            {
                var temp = new LIThuySan(this) {
                    NameTS = item.ten,
                    Gia = item.gia_ban,
                    Id = item.Id_ts                    
                };

                temp.ReRender();

                pUnList.Controls.Add(temp);
            }

            ResizeList();
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
                item.Width = pUnList.Width - 10;
            }
        }

        private void tSearch_TextChanged(object sender, EventArgs e)
        {
            RenderList(tSearch.Text);
        }
    }
}
