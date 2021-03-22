using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAchaucay
{

    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        //logout
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Hide();
            FormLogin fl = new FormLogin();
            fl.Show();
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        //-----
        private void FormMain_Load(object sender, EventArgs e)
        {
            Class.Functions.Connect();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Class.Functions.Disconnect(); //Đóng kết nối
            Application.Exit(); //Thoát
        }

        private void loạiChậuCâyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                FormLoaiChauCay formLoaiChauCay= new FormLoaiChauCay(); //Khởi tạo đối tượng
                formLoaiChauCay.Show(); //Hiển thị
                Visible = false;
            }
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                FormNhanVien formNhanVien = new FormNhanVien();
                formNhanVien.Show();
                Visible = false;
            }
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                FormKhachHang formKhachHang = new FormKhachHang();
                formKhachHang.Show();
                Visible = false;
            }
        }

        private void hóaĐơnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            {
                FormChiTietHoaDon formChiTietHoaDon = new FormChiTietHoaDon();
                formChiTietHoaDon.Show();
                Visible = false;
            }
        }

        private void chậuCâyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                FormChauCay formChauCay = new FormChauCay();
                formChauCay.Show();
                Visible = false;
            }
        }

        private void tìmHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHoaDon formHoaDon = new FormHoaDon();
            formHoaDon.Show();
            Visible = false;
        }

        private void hóaĐơnToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FormBaoCao formBaoCao = new FormBaoCao();
            formBaoCao.ShowDialog();
        }

        private void hóaĐơnToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FormBaoCaoHD formBaoCaoHD = new FormBaoCaoHD();
            formBaoCaoHD.ShowDialog();
        }
    }
}
