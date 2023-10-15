
namespace QL_ThuySan.components
{
    partial class EditSupplier
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
            this.pMain = new System.Windows.Forms.Panel();
            this.tAddress = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bDeleteDelop = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.tSDT = new System.Windows.Forms.TextBox();
            this.tName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pMain
            // 
            this.pMain.BackColor = System.Drawing.Color.White;
            this.pMain.Controls.Add(this.tAddress);
            this.pMain.Controls.Add(this.label4);
            this.pMain.Controls.Add(this.label3);
            this.pMain.Controls.Add(this.label2);
            this.pMain.Controls.Add(this.bDeleteDelop);
            this.pMain.Controls.Add(this.bSave);
            this.pMain.Controls.Add(this.tSDT);
            this.pMain.Controls.Add(this.tName);
            this.pMain.Controls.Add(this.label1);
            this.pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMain.Location = new System.Drawing.Point(0, 0);
            this.pMain.Name = "pMain";
            this.pMain.Size = new System.Drawing.Size(352, 474);
            this.pMain.TabIndex = 3;
            // 
            // tAddress
            // 
            this.tAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tAddress.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tAddress.Location = new System.Drawing.Point(15, 248);
            this.tAddress.MaxLength = 255;
            this.tAddress.Name = "tAddress";
            this.tAddress.Size = new System.Drawing.Size(319, 115);
            this.tAddress.TabIndex = 6;
            this.tAddress.Text = "";
            this.tAddress.TextChanged += new System.EventHandler(this.Text_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.label4.Location = new System.Drawing.Point(15, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Địa chỉ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.label3.Location = new System.Drawing.Point(15, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "sdt:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 38);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nhà cung cấp";
            // 
            // bDeleteDelop
            // 
            this.bDeleteDelop.BackColor = System.Drawing.Color.Red;
            this.bDeleteDelop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bDeleteDelop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bDeleteDelop.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bDeleteDelop.ForeColor = System.Drawing.Color.White;
            this.bDeleteDelop.Location = new System.Drawing.Point(100, 391);
            this.bDeleteDelop.Margin = new System.Windows.Forms.Padding(0);
            this.bDeleteDelop.Name = "bDeleteDelop";
            this.bDeleteDelop.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.bDeleteDelop.Size = new System.Drawing.Size(75, 34);
            this.bDeleteDelop.TabIndex = 3;
            this.bDeleteDelop.Text = "xoá";
            this.bDeleteDelop.UseVisualStyleBackColor = false;
            this.bDeleteDelop.Click += new System.EventHandler(this.bDeleteDelop_Click);
            // 
            // bSave
            // 
            this.bSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bSave.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.bSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSave.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSave.Location = new System.Drawing.Point(175, 391);
            this.bSave.Margin = new System.Windows.Forms.Padding(0);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(159, 34);
            this.bSave.TabIndex = 2;
            this.bSave.Text = "Lưu";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // tSDT
            // 
            this.tSDT.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tSDT.Location = new System.Drawing.Point(15, 174);
            this.tSDT.Name = "tSDT";
            this.tSDT.Size = new System.Drawing.Size(319, 38);
            this.tSDT.TabIndex = 1;
            this.tSDT.TextChanged += new System.EventHandler(this.Text_TextChanged);
            // 
            // tName
            // 
            this.tName.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tName.Location = new System.Drawing.Point(15, 95);
            this.tName.Name = "tName";
            this.tName.Size = new System.Drawing.Size(319, 38);
            this.tName.TabIndex = 1;
            this.tName.TextChanged += new System.EventHandler(this.Text_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên nhà cung cấp:";
            // 
            // EditSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pMain);
            this.Name = "EditSupplier";
            this.Size = new System.Drawing.Size(352, 474);
            this.pMain.ResumeLayout(false);
            this.pMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.RichTextBox tAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bDeleteDelop;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.TextBox tSDT;
        private System.Windows.Forms.TextBox tName;
        private System.Windows.Forms.Label label1;
    }
}
