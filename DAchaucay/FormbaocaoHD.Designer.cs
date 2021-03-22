namespace DAchaucay
{
    partial class FormBaoCaoHD
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.dt_timetruoc = new System.Windows.Forms.DateTimePicker();
            this.dt_timesau = new System.Windows.Forms.DateTimePicker();
            this.btnThongke = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(-198, 167);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1139, 326);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.Load += new System.EventHandler(this.crystalReportViewer1_Load);
            // 
            // dt_timetruoc
            // 
            this.dt_timetruoc.CustomFormat = "MM/dd/yyyy";
            this.dt_timetruoc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_timetruoc.Location = new System.Drawing.Point(161, 93);
            this.dt_timetruoc.Name = "dt_timetruoc";
            this.dt_timetruoc.Size = new System.Drawing.Size(100, 20);
            this.dt_timetruoc.TabIndex = 85;
            this.dt_timetruoc.ValueChanged += new System.EventHandler(this.dt_timetruoc_ValueChanged);
            // 
            // dt_timesau
            // 
            this.dt_timesau.CustomFormat = "MM/dd/yyyy";
            this.dt_timesau.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_timesau.Location = new System.Drawing.Point(285, 93);
            this.dt_timesau.Name = "dt_timesau";
            this.dt_timesau.Size = new System.Drawing.Size(102, 20);
            this.dt_timesau.TabIndex = 86;
            this.dt_timesau.ValueChanged += new System.EventHandler(this.dt_timesau_ValueChanged);
            // 
            // btnThongke
            // 
            this.btnThongke.Location = new System.Drawing.Point(414, 93);
            this.btnThongke.Name = "btnThongke";
            this.btnThongke.Size = new System.Drawing.Size(75, 23);
            this.btnThongke.TabIndex = 87;
            this.btnThongke.Text = "Thống kê";
            this.btnThongke.UseVisualStyleBackColor = true;
            this.btnThongke.Click += new System.EventHandler(this.btnThongke_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(217, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 88;
            this.label1.Text = "Thống kê theo ngày";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(635, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 89;
            this.label2.Text = "Thống kê tất cả";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(643, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 23);
            this.button1.TabIndex = 90;
            this.button1.Text = "Thống kê tất cả";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(387, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 24);
            this.label3.TabIndex = 91;
            this.label3.Text = "Thống kê hóa đơn";
            // 
            // FormBaoCaoHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnThongke);
            this.Controls.Add(this.dt_timesau);
            this.Controls.Add(this.dt_timetruoc);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "FormBaoCaoHD";
            this.Text = "FormBaoCaoHD";
            this.Load += new System.EventHandler(this.FormBaoCaoHD_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.DateTimePicker dt_timetruoc;
        private System.Windows.Forms.DateTimePicker dt_timesau;
        private System.Windows.Forms.Button btnThongke;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
    }
}