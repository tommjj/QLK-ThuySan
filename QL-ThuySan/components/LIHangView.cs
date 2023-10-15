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
    public partial class LIHangView : UserControl
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int soluong { get; set; }
        public decimal gia { get; set; }
        public LIHangView()
        {
            InitializeComponent();
        }

        public void Render()
        {
            lName.Text = name;
            lGia.Text = ((int)gia).ToString();
            lSoluong.Text = soluong.ToString();
        }
    }
}
