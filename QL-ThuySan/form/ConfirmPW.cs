using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_ThuySan.form
{
    public partial class ConfirmPW : Form
    {
        public string Password = "";
        public ConfirmPW()
        {
            InitializeComponent();
        }

        private void submit_Click(object sender, EventArgs e)
        {
            Password = tPassword.Text;
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
