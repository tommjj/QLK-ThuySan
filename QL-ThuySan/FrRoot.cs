using QL_ThuySan.controls;
using QL_ThuySan.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_ThuySan
{
    public partial class FrRoot : Form
    {
        private HomeController homeController;
        private LoginController loginController;

        private DepotDB db;

        public FrRoot()
        {
            loginController = new LoginController(this);
            homeController = new HomeController();
            db = new DepotDB("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Workspase\\cs\\QL-ThuySan\\QL-ThuySan\\ql-thuysan.mdf;Integrated Security=True");

            db.connection();


            InitializeComponent();

            root.Controls.Clear();
       
            //FormBorderStyle = FormBorderStyle.FixedSingle;
            //MaximizeBox = false;
            //MinimizeBox = false;

            

            root.Controls.Add(loginController);
        }

        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);

            loginController.Width = root.Width;
            loginController.Height = root.Height;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
