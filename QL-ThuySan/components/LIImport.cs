using QL_ThuySan.controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_ThuySan.components
{
    public partial class LIImport : UserControl
    {
        private ImportController importController;

        public decimal Gia { get; set; }
        public int Id { get; set; }
        public string name { get; set; }
        public int trongLuong { get; set; }

        public bool daThem { get; set; }

        public LIImport(ImportController importController)
        {
            this.importController = importController;
            InitializeComponent();
        }

        public void ReRender()
        {
            lForm.Text = name;
            lGia.Text = ((int)Gia).ToString();
            lKg.Text = trongLuong.ToString();
            lId.Text = "Số phiếu: " + Id;
            bImport.Visible = !daThem;
        }

        private void ClickEv(object sender, EventArgs e)
        {
            importController.SetId(Id);
        }

        private void bImport_Click(object sender, EventArgs e)
        {

        }
    }
}
