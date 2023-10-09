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
        public ExportController(FrRoot root)
        {
            this.root = root;
            init();
            InitializeComponent();
        }
        private void init()
        {

        }
    }
}
