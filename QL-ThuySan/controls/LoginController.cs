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
    public partial class LoginController : UserControl
    {
        private FrRoot fRoot;
        public LoginController(FrRoot fRoot)
        {
            InitializeComponent();
            this.fRoot = fRoot;
        }

        private void bLogin_Click(object sender, EventArgs e)
        {

        }

        private void bLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {

            }
        }
    }
}
