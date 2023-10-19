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
    public partial class LIexport : UserControl
    {
        private ExportController exportController;

        public decimal Gia { get; set; }
        public int Id { get; set; }
        public string name { get; set; }
        public int trongLuong { get; set; }

        public bool daXuat { get; set; }
        public LIexport(ExportController exportController)
        {
            this.exportController = exportController;
            InitializeComponent();
        }

        public void ReRender()
        {
            lTo.Text = name;
            lGia.Text = ((int)Gia).ToString();
            lKg.Text = trongLuong.ToString();
            lId.Text = "Số phiếu: " + Id;
            bImport.Visible = !daXuat;
        }
        private void ClickEv(object sender, EventArgs e)
        {
            exportController.SetId(Id);
        }

        private void bImport_Click(object sender, EventArgs e)
        {
            //importController.NhapKho(Id);
            //importController.ReLoad();
        }

        private void bImport_Click_1(object sender, EventArgs e)
        {

        }
    }
}
