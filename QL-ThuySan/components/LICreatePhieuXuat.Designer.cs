
namespace QL_ThuySan.components
{
    partial class LICreatePhieuXuat
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
            System.Windows.Forms.Button button1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LICreatePhieuNhap));
            this.pAdd = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bAdd = new System.Windows.Forms.Button();
            this.tName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pMain = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tSoLuong = new System.Windows.Forms.TextBox();
            this.tGia = new System.Windows.Forms.TextBox();
            this.lName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            button1 = new System.Windows.Forms.Button();
            this.pAdd.SuspendLayout();
            this.pMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pAdd
            // 
            this.pAdd.BackColor = System.Drawing.Color.White;
            this.pAdd.Controls.Add(this.panel1);
            this.pAdd.Controls.Add(this.bAdd);
            this.pAdd.Controls.Add(this.tName);
            this.pAdd.Controls.Add(this.label3);
            this.pAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pAdd.Location = new System.Drawing.Point(0, 0);
            this.pAdd.Name = "pAdd";
            this.pAdd.Size = new System.Drawing.Size(520, 59);
            this.pAdd.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(4, 59);
            this.panel1.TabIndex = 3;
            // 
            // bAdd
            // 
            this.bAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.bAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAdd.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAdd.ForeColor = System.Drawing.Color.White;
            this.bAdd.Location = new System.Drawing.Point(412, 19);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(83, 34);
            this.bAdd.TabIndex = 2;
            this.bAdd.Text = "Thêm";
            this.bAdd.UseVisualStyleBackColor = false;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // tName
            // 
            this.tName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tName.Location = new System.Drawing.Point(31, 19);
            this.tName.Name = "tName";
            this.tName.Size = new System.Drawing.Size(374, 34);
            this.tName.TabIndex = 1;
            this.tName.TextChanged += new System.EventHandler(this.tName_TextChanged);
            this.tName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tName_KeyDown);
            this.tName.Leave += new System.EventHandler(this.tName_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tên sản phẩm:";
            // 
            // pMain
            // 
            this.pMain.BackColor = System.Drawing.Color.White;
            this.pMain.Controls.Add(this.label2);
            this.pMain.Controls.Add(this.label1);
            this.pMain.Controls.Add(this.tSoLuong);
            this.pMain.Controls.Add(this.tGia);
            this.pMain.Controls.Add(this.lName);
            this.pMain.Controls.Add(button1);
            this.pMain.Controls.Add(this.panel2);
            this.pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMain.Location = new System.Drawing.Point(0, 0);
            this.pMain.Margin = new System.Windows.Forms.Padding(0);
            this.pMain.Name = "pMain";
            this.pMain.Size = new System.Drawing.Size(520, 59);
            this.pMain.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Số lượng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(345, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "giá";
            // 
            // tSoLuong
            // 
            this.tSoLuong.Location = new System.Drawing.Point(211, 24);
            this.tSoLuong.Name = "tSoLuong";
            this.tSoLuong.Size = new System.Drawing.Size(115, 22);
            this.tSoLuong.TabIndex = 3;
            this.tSoLuong.TextChanged += new System.EventHandler(this.tSoLuong_TextChanged);
            // 
            // tGia
            // 
            this.tGia.Location = new System.Drawing.Point(348, 24);
            this.tGia.Name = "tGia";
            this.tGia.Size = new System.Drawing.Size(109, 22);
            this.tGia.TabIndex = 3;
            this.tGia.TextChanged += new System.EventHandler(this.tGia_TextChanged);
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lName.Location = new System.Drawing.Point(11, 4);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(63, 28);
            this.lName.TabIndex = 2;
            this.lName.Text = "name";
            // 
            // button1
            // 
            button1.BackColor = System.Drawing.Color.Red;
            button1.Cursor = System.Windows.Forms.Cursors.Hand;
            button1.Dock = System.Windows.Forms.DockStyle.Right;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            button1.Location = new System.Drawing.Point(479, 0);
            button1.Margin = new System.Windows.Forms.Padding(0);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(41, 59);
            button1.TabIndex = 1;
            button1.UseVisualStyleBackColor = false;
            button1.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(4, 59);
            this.panel2.TabIndex = 0;
            // 
            // LICreatePhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pAdd);
            this.Controls.Add(this.pMain);
            this.Name = "LICreatePhieuNhap";
            this.Size = new System.Drawing.Size(520, 59);
            this.pAdd.ResumeLayout(false);
            this.pAdd.PerformLayout();
            this.pMain.ResumeLayout(false);
            this.pMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.TextBox tName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tSoLuong;
        private System.Windows.Forms.TextBox tGia;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Panel panel2;
    }
}
