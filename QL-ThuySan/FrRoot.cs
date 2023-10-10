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
        private CustomerController customerController;
        private ExportController exportController;
        private ImportController importController;
        private GoodsController goodsController;
        private SupplierContrller supplierContrller;

        private DepotDB db;
        private Models context;

        public DepotDB getDB()
        {
            return db;
        }

        public FrRoot()
        {
            Init();
            
            InitializeComponent();

            Setup();
        }

        public void Init()
        {
            loginController = new LoginController(this);
            homeController = new HomeController(this);
            customerController = new CustomerController(this);
            exportController = new ExportController(this);
            importController = new ImportController(this);
            goodsController = new GoodsController(this);
            supplierContrller = new SupplierContrller(this);

            context = new Models();

            db = new DepotDB(Config.CONNECTION_STRING);

            db.Connection();
        }

        public Models getContext()
        {
            return context;
        }

        public void Setup()
        {
            SetLock();
            //
            ResizeControl();
           
        }

        public void SetLock()
        {
            root.Controls.Clear();
            root.Controls.Add(loginController);
        }

        public void Logined()
        {      
            root.Controls.Clear();         

            root.Controls.Add(mainLayout);

            SetNavButtonColorActive(bHome);
            SetMainControl(homeController);
        }

        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);

            ResizeControl();
            ResizeMain();
        }

        private void ResizeControl()
       {
            foreach (Control item in root.Controls)
            {
                item.Width = root.Width;
                item.Height = root.Height;
            }
       }

        private void ResizeMain()
        {
            foreach (Control item in Main.Controls)
            {
                item.Width = Main.Width;
                item.Height = Main.Height;
            }
        }

        private void SetMainControl(Control control)
        {
            if(Main.Controls.Count == 0)
            {
                Main.Controls.Add(control);
            } else if(Main.Controls[0] != control)
            {
                Main.Controls.Clear();
                Main.Controls.Add(control);
            }
            ResizeMain();
        }

        private void ResetButtonColor()
        {
            Color color = Color.FromArgb(255, 79, 70, 229);
            bHome.BackColor = color;
            bGoods.BackColor = color;
            bImport.BackColor = color;
            bExport.BackColor = color;
            bCustomer.BackColor = color;
            bSupplier.BackColor = color;
        }

        private void SetNavButtonColorActive(Button button)
        {
            ResetButtonColor();

            button.BackColor = Color.FromArgb(255, 60, 50, 210);
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            Button bt = (Button)sender;
            SetNavButtonColorActive(bt);

            string name = bt.Text;
            name = name.Trim();

            switch (name)
            {
                case Pages.HOME_PAGE:
                    SetMainControl(homeController);
                    break;
                case Pages.GOODS_PAGE:
                    SetMainControl(goodsController);
                    break;
                case Pages.EXPORT_PAGE:
                    SetMainControl(exportController);
                    break;
                case Pages.IMPORT_PAGE:
                    SetMainControl(importController);
                    break;
                case Pages.CUSTOMER_PAGE:
                    SetMainControl(customerController);
                    break;
                case Pages.SUPPLIER_PAGE:
                    SetMainControl(supplierContrller);
                    break;
                default:
                    break;
            }
        }
    }
}
