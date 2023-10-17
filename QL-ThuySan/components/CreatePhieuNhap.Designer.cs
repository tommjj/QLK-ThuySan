
namespace QL_ThuySan.components
{
    partial class CreatePhieuNhap
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
            this.tNCP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bSaveAndPush = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bSaveAndPush);
            this.panel1.Controls.Add(this.bSave);
            this.panel1.Controls.Add(this.bThem);
            this.panel1.Controls.Add(this.fListHang);
            this.panel1.Controls.Add(this.cKho);
            this.panel1.Controls.Add(this.tNCP);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(573, 646);
            this.panel1.TabIndex = 1;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // bSave
            // 
            this.bSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.bSave.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSave.ForeColor = System.Drawing.Color.White;
            this.bSave.Location = new System.Drawing.Point(266, 595);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(136, 48);
            this.bSave.TabIndex = 6;
            this.bSave.Text = "Thêm";
            this.bSave.UseVisualStyleBackColor = false;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bThem
            // 
            this.bThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.bThem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bThem.ForeColor = System.Drawing.Color.White;
            this.bThem.Location = new System.Drawing.Point(419, 158);
            this.bThem.Name = "bThem";
            this.bThem.Size = new System.Drawing.Size(136, 37);
            this.bThem.TabIndex = 6;
            this.bThem.Text = "Thêm hàng";
            this.bThem.UseVisualStyleBackColor = false;
            // 
            // fListHang
            // 
            this.fListHang.Location = new System.Drawing.Point(16, 201);
            this.fListHang.Name = "fListHang";
            this.fListHang.Size = new System.Drawing.Size(540, 388);
            this.fListHang.TabIndex = 5;
            // 
            // cKho
            // 
            this.cKho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cKho.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cKho.FormattingEnabled = true;
            this.cKho.Location = new System.Drawing.Point(419, 103);
            this.cKho.Name = "cKho";
            this.cKho.Size = new System.Drawing.Size(137, 39);
            this.cKho.TabIndex = 4;
            // 
            // tNCP
            // 
            this.tNCP.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tNCP.Location = new System.Drawing.Point(16, 103);
            this.tNCP.Name = "tNCP";
            this.tNCP.Size = new System.Drawing.Size(396, 38);
            this.tNCP.TabIndex = 3;
            this.tNCP.TextChanged += new System.EventHandler(this.tNCP_TextChanged);
            this.tNCP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tNCP_KeyDown);
            this.tNCP.Leave += new System.EventHandler(this.tNCP_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(415, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Kho:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "Hàng nhập:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nhà cung cấp:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sửa phiếu nhập";
            // 
            // bSaveAndPush
            // 
            this.bSaveAndPush.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.bSaveAndPush.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSaveAndPush.ForeColor = System.Drawing.Color.White;
            this.bSaveAndPush.Location = new System.Drawing.Point(405, 595);
            this.bSaveAndPush.Margin = new System.Windows.Forms.Padding(0);
            this.bSaveAndPush.Name = "bSaveAndPush";
            this.bSaveAndPush.Size = new System.Drawing.Size(150, 48);
            this.bSaveAndPush.TabIndex = 7;
            this.bSaveAndPush.Text = "Thêm và nhập";
            this.bSaveAndPush.UseVisualStyleBackColor = false;
            // 
            // CreatePhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Name = "CreatePhieuNhap";
            this.Size = new System.Drawing.Size(573, 646);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bSaveAndPush;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bThem;
        private System.Windows.Forms.FlowLayoutPanel fListHang;
        private System.Windows.Forms.ComboBox cKho;
        private System.Windows.Forms.TextBox tNCP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}
