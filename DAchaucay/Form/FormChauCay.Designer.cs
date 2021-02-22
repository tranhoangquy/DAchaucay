namespace DAchaucay
{
    partial class FormChauCay
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnBoQua = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvCC = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaCC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtKichthuoc = new System.Windows.Forms.TextBox();
            this.txtTenCC = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboMaLCC = new System.Windows.Forms.ComboBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.picAnh = new System.Windows.Forms.PictureBox();
            this.txtAnh = new System.Windows.Forms.TextBox();
            this.txtSoluong = new System.Windows.Forms.TextBox();
            this.txtDongia = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnTimkiem = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCC)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnh)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnTimkiem);
            this.panel1.Controls.Add(this.btnDong);
            this.panel1.Controls.Add(this.btnBoQua);
            this.panel1.Controls.Add(this.btnLuu);
            this.panel1.Controls.Add(this.btnSua);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 359);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 91);
            this.panel1.TabIndex = 0;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(584, 17);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 23);
            this.btnDong.TabIndex = 11;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnBoQua
            // 
            this.btnBoQua.Location = new System.Drawing.Point(476, 16);
            this.btnBoQua.Name = "btnBoQua";
            this.btnBoQua.Size = new System.Drawing.Size(75, 23);
            this.btnBoQua.TabIndex = 10;
            this.btnBoQua.Text = "Bỏ qua";
            this.btnBoQua.UseVisualStyleBackColor = true;
            this.btnBoQua.Click += new System.EventHandler(this.btnBoQua_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(368, 17);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 9;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(260, 16);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 8;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(152, 17);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 7;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(44, 17);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgvCC
            // 
            this.dgvCC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCC.Location = new System.Drawing.Point(0, 181);
            this.dgvCC.Name = "dgvCC";
            this.dgvCC.Size = new System.Drawing.Size(800, 178);
            this.dgvCC.TabIndex = 2;
            this.dgvCC.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCC_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(340, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 24);
            this.label1.TabIndex = 16;
            this.label1.Text = "CHẬU CÂY";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Mã chậu cây";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Mã Loại chậu cây";
            // 
            // txtMaCC
            // 
            this.txtMaCC.Location = new System.Drawing.Point(110, 47);
            this.txtMaCC.Name = "txtMaCC";
            this.txtMaCC.Size = new System.Drawing.Size(165, 20);
            this.txtMaCC.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Tên chậu cây";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Kích thước";
            // 
            // txtKichthuoc
            // 
            this.txtKichthuoc.Location = new System.Drawing.Point(110, 146);
            this.txtKichthuoc.Name = "txtKichthuoc";
            this.txtKichthuoc.Size = new System.Drawing.Size(165, 20);
            this.txtKichthuoc.TabIndex = 23;
            // 
            // txtTenCC
            // 
            this.txtTenCC.Location = new System.Drawing.Point(110, 109);
            this.txtTenCC.Name = "txtTenCC";
            this.txtTenCC.Size = new System.Drawing.Size(165, 20);
            this.txtTenCC.TabIndex = 29;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cboMaLCC);
            this.panel2.Controls.Add(this.btnOpen);
            this.panel2.Controls.Add(this.picAnh);
            this.panel2.Controls.Add(this.txtAnh);
            this.panel2.Controls.Add(this.txtSoluong);
            this.panel2.Controls.Add(this.txtDongia);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtTenCC);
            this.panel2.Controls.Add(this.txtKichthuoc);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtMaCC);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 181);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // cboMaLCC
            // 
            this.cboMaLCC.FormattingEnabled = true;
            this.cboMaLCC.Location = new System.Drawing.Point(110, 72);
            this.cboMaLCC.Name = "cboMaLCC";
            this.cboMaLCC.Size = new System.Drawing.Size(165, 21);
            this.cboMaLCC.TabIndex = 38;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(541, 131);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(37, 23);
            this.btnOpen.TabIndex = 37;
            this.btnOpen.Text = "Mở";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // picAnh
            // 
            this.picAnh.Location = new System.Drawing.Point(584, 43);
            this.picAnh.Name = "picAnh";
            this.picAnh.Size = new System.Drawing.Size(188, 132);
            this.picAnh.TabIndex = 36;
            this.picAnh.TabStop = false;
            // 
            // txtAnh
            // 
            this.txtAnh.Location = new System.Drawing.Point(364, 112);
            this.txtAnh.Multiline = true;
            this.txtAnh.Name = "txtAnh";
            this.txtAnh.Size = new System.Drawing.Size(170, 63);
            this.txtAnh.TabIndex = 35;
            // 
            // txtSoluong
            // 
            this.txtSoluong.Location = new System.Drawing.Point(364, 81);
            this.txtSoluong.Name = "txtSoluong";
            this.txtSoluong.Size = new System.Drawing.Size(170, 20);
            this.txtSoluong.TabIndex = 34;
            // 
            // txtDongia
            // 
            this.txtDongia.Location = new System.Drawing.Point(364, 43);
            this.txtDongia.Name = "txtDongia";
            this.txtDongia.Size = new System.Drawing.Size(170, 20);
            this.txtDongia.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(314, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Ảnh";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(305, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Số lượng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(305, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Đơn giá";
            // 
            // btnTimkiem
            // 
            this.btnTimkiem.Location = new System.Drawing.Point(692, 17);
            this.btnTimkiem.Name = "btnTimkiem";
            this.btnTimkiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimkiem.TabIndex = 12;
            this.btnTimkiem.Text = "Tìm kiếm";
            this.btnTimkiem.UseVisualStyleBackColor = true;
            this.btnTimkiem.Click += new System.EventHandler(this.btnTimkiem_Click);
            // 
            // FormChauCay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvCC);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormChauCay";
            this.Text = "Chậu Cây";
            this.Load += new System.EventHandler(this.FormChauCay_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCC)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvCC;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnBoQua;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaCC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtKichthuoc;
        private System.Windows.Forms.TextBox txtTenCC;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox picAnh;
        private System.Windows.Forms.TextBox txtAnh;
        private System.Windows.Forms.TextBox txtSoluong;
        private System.Windows.Forms.TextBox txtDongia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.ComboBox cboMaLCC;
        private System.Windows.Forms.Button btnTimkiem;
    }
}