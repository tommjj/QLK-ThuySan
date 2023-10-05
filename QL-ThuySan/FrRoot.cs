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
using static QL_ThuySan.utils.Constants;

namespace QL_ThuySan
{
    public partial class FrRoot : Form
    {
        private HomeController homeController;
        private LoginController loginController;

        private DepotDB db;

        public DepotDB getDB()
        {
            return db;
        }

        public FrRoot()
        {
            loginController = new LoginController(this);
            homeController = new HomeController();
            db = new DepotDB("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Workspase\\cs\\QL-ThuySan\\QL-ThuySan\\ql-thuysan.mdf;Integrated Security=True");

            db.connection();

            InitializeComponent();

            root.Controls.Clear();          

            root.Controls.Add(loginController);
        }

        public void Logined()
        {      
            root.Controls.Clear();         

            root.Controls.Add(mainLayout);
        }

        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);

            loginController.Width = root.Width;
            loginController.Height = root.Height;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            string name = bt.Text;
            name = name.Trim();

            switch(name) {
                case Pages.HOME_PAGE:
                    break;
                case Pages.GOODS_PAGE:
                    break;
                case Pages.EXPORT_PAGE:
                    break;
                case Pages.IMPORT_PAGE:
                    break;
                case Pages.CUSTOMER_PAGE:
                    break;
                case Pages.SUPPLIER_PAGE:
                    break;
                default:
                    
                    break;
            }
        }
    }
}
