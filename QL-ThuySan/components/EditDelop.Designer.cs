﻿
namespace QL_ThuySan.components
{
    partial class EditDelop
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
            this.bDeleteDelop = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.tName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pMain
            // 
            this.pMain.BackColor = System.Drawing.Color.White;
            this.pMain.Controls.Add(this.bDeleteDelop);
            this.pMain.Controls.Add(this.bSave);
            this.pMain.Controls.Add(this.tName);
            this.pMain.Controls.Add(this.label1);
            this.pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMain.Location = new System.Drawing.Point(0, 0);
            this.pMain.Name = "pMain";
            this.pMain.Size = new System.Drawing.Size(340, 211);
            this.pMain.TabIndex = 0;
            // 
            // bDeleteDelop
            // 
            this.bDeleteDelop.BackColor = System.Drawing.Color.Red;
            this.bDeleteDelop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bDeleteDelop.FlatAppearance.BorderSize = 0;
            this.bDeleteDelop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bDeleteDelop.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bDeleteDelop.ForeColor = System.Drawing.Color.White;
            this.bDeleteDelop.Location = new System.Drawing.Point(115, 114);
            this.bDeleteDelop.Margin = new System.Windows.Forms.Padding(0);
            this.bDeleteDelop.Name = "bDeleteDelop";
            this.bDeleteDelop.Size = new System.Drawing.Size(67, 34);
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
            this.bSave.Location = new System.Drawing.Point(187, 114);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(140, 34);
            this.bSave.TabIndex = 2;
            this.bSave.Text = "Lưu";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // tName
            // 
            this.tName.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tName.Location = new System.Drawing.Point(8, 53);
            this.tName.Name = "tName";
            this.tName.Size = new System.Drawing.Size(319, 38);
            this.tName.TabIndex = 1;
            this.tName.TextChanged += new System.EventHandler(this.tName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên kho:";
            // 
            // EditDelop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pMain);
            this.Name = "EditDelop";
            this.Size = new System.Drawing.Size(340, 211);
            this.pMain.ResumeLayout(false);
            this.pMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.TextBox tName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bDeleteDelop;
    }
}
