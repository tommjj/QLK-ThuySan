using QL_ThuySan.form;
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
    public partial class EditDelop : UserControl
    {
        private FrRoot root;

        private int Id;

        private string NameDelop;
        public EditDelop(FrRoot root)
        {
            this.root = root;
            InitializeComponent();
        }

        public void SetId(int Id)
        {
            if(Id == -1)
            {
                this.Controls.Clear();
                return;
            }

            if(this.Controls.Count == 0)
            {
                this.Controls.Add(pMain);
            }
            
            this.Id = Id;
            setActiveBt(false);
            Render();
        }
        private void Render()
        {
            NameDelop = root.getContext().Khoes.Find(Id).ten_kho;
            tName.Text = NameDelop;
            
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tName.Text))
                return;

            var delop = root.getContext().Khoes.Find(Id);
            delop.ten_kho = tName.Text;
            root.getContext().SaveChanges();

            root.GetDepotController().ReLoad();
        }

        private void bDeleteDelop_Click(object sender, EventArgs e)
        {
            ConfirmPW formlog = new ConfirmPW();

            if(formlog.ShowDialog(this) == DialogResult.OK)
            {
                var user = root.getContext().accounts.Find(root.getUserId());

                if (user.password.TrimEnd(' ') == formlog.Password)
                {
                    DeleteDelop(Id);
                    root.GetDepotController().ReLoad();
                }
            }
            formlog.Dispose();
        }

        private void DeleteDelop(int Id)
        {
            var Kho = root.getContext().Khoes.Find(Id);
            foreach(var item in Kho.PhieuNhaps)
            {
                root.getContext().TTPhieuNhaps.RemoveRange(item.TTPhieuNhaps);
            }
            root.getContext().PhieuNhaps.RemoveRange(Kho.PhieuNhaps);

            foreach (var item in Kho.PhieuXuats)
            {
                root.getContext().TTPhieuXuats.RemoveRange(item.TTPhieuXuats);
            }
            root.getContext().PhieuXuats.RemoveRange(Kho.PhieuXuats);

            root.getContext().TonKhoes.RemoveRange(Kho.TonKhoes);       
          
            root.getContext().Khoes.Remove(Kho);
            root.getContext().SaveChanges();
        }

        private void setActiveBt(bool isActive)
        {
            if(isActive)
            {
                bSave.BackColor = Color.FromArgb(255, 79, 70, 229);
                bSave.ForeColor = Color.White;
                return;
            }
            bSave.BackColor = Color.White;
            bSave.ForeColor = Color.Black;
        }

        private void tName_TextChanged(object sender, EventArgs e)
        {
             
            if(NameDelop != tName.Text)
            {
                setActiveBt(true);
                return;
            }
            setActiveBt(false);
        }
    }
}
