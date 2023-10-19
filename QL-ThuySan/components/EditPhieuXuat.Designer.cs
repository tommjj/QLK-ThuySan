
namespace QL_ThuySan.components
{
    partial class EditPhieuXuat
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.bSave = new System.Windows.Forms.Button();
            this.bThem = new System.Windows.Forms.Button();
            this.fListHang = new System.Windows.Forms.FlowLayoutPanel();
            this.cKho = new System.Windows.Forms.ComboBox();
            this.tKH = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lId = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bSave);
            this.panel1.Controls.Add(this.bThem);
            this.panel1.Controls.Add(this.fListHang);
            this.panel1.Controls.Add(this.cKho);
            this.panel1.Controls.Add(this.tKH);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lId);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(573, 646);
            this.panel1.TabIndex = 1;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // bSave
            // 
            this.bSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.bSave.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSave.ForeColor = System.Drawing.Color.White;
            this.bSave.Location = new System.Drawing.Point(420, 595);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(136, 48);
            this.bSave.TabIndex = 6;
            this.bSave.Text = "Lưu";
            this.bSave.UseVisualStyleBackColor = false;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bThem
            // 
            this.bThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.bThem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bThem.ForeColor = System.Drawing.Color.White;
            this.bThem.Location = new System.Drawing.Point(419, 194);
            this.bThem.Name = "bThem";
            this.bThem.Size = new System.Drawing.Size(136, 37);
            this.bThem.TabIndex = 6;
            this.bThem.Text = "Thêm hàng";
            this.bThem.UseVisualStyleBackColor = false;
            // 
            // fListHang
            // 
            this.fListHang.Location = new System.Drawing.Point(16, 237);
            this.fListHang.Name = "fListHang";
            this.fListHang.Size = new System.Drawing.Size(540, 352);
            this.fListHang.TabIndex = 5;
            // 
            // cKho
            // 
            this.cKho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cKho.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cKho.FormattingEnabled = true;
            this.cKho.Location = new System.Drawing.Point(419, 130);
            this.cKho.Name = "cKho";
            this.cKho.Size = new System.Drawing.Size(137, 39);
            this.cKho.TabIndex = 4;
            // 
            // tKH
            // 
            this.tKH.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tKH.Location = new System.Drawing.Point(16, 130);
            this.tKH.Name = "tKH";
            this.tKH.Size = new System.Drawing.Size(396, 38);
            this.tKH.TabIndex = 3;
            this.tKH.TextChanged += new System.EventHandler(this.tKH_TextChanged);
            this.tKH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tKH_KeyDown);
            this.tKH.Leave += new System.EventHandler(this.tKH_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(415, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Kho:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "Hàng xuất:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Khách hàng:";
            // 
            // lId
            // 
            this.lId.AutoSize = true;
            this.lId.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lId.Location = new System.Drawing.Point(90, 54);
            this.lId.Name = "lId";
            this.lId.Size = new System.Drawing.Size(55, 23);
            this.lId.TabIndex = 1;
            this.lId.Text = "00000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số phiếu:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sửa phiếu xuất";
            // 
            // EditPhieuXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Name = "EditPhieuXuat";
            this.Size = new System.Drawing.Size(573, 646);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bThem;
        private System.Windows.Forms.FlowLayoutPanel fListHang;
        private System.Windows.Forms.ComboBox cKho;
        private System.Windows.Forms.TextBox tKH;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
