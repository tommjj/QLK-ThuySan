﻿using System;
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
    public partial class DashboardController : UserControl
    {
        private FrRoot root;

        public DashboardController(FrRoot root)
        {
            this.root = root;
            InitializeComponent();
        }
    }
}
